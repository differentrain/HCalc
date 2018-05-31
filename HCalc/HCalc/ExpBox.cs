using HCalc.ExpressionHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCalc
{
    /// <summary>
    /// A textbox that can process expressions.
    /// </summary>
    public class ExpBox : TextBox
    {
        [Browsable(false)]
        public String HexString { get; private set; } = String.Empty;


        [Browsable(false)]
        public String SingedDecString { get; private set; } = String.Empty;

        [Browsable(false)]
        public String UnsignedDecString { get; private set; } = String.Empty;


        [Browsable(false)]
        public String BinString { get; private set; } = String.Empty;


        [Browsable(false)]
        public String ByteArrayString { get; private set; } = String.Empty;

        private Encoding mCodePage = Encoding.ASCII;

        private ExpState mState = ExpState.Ignore;

        private Int32 mByteArrayBufferCount = 0;




        public void SetCodePage(Encoding codepage)
        {
            if (codepage == mCodePage) return;
            mCodePage = codepage;
            if (mState == ExpState.ByteArray)
            {
                SetByteArrayExpOutput();
            }
            else if (mState == ExpState.String)
            {
                SetStringExpOutput();
            }

        }





        /// <summary>
        /// Occurs when the result of the expression in this TextBox is changed.
        /// </summary>
        [Browsable(true), Category("ExpStateChanged"), Description("Occurs when the result of the expression in this TextBox is changed.")]
        public event EventHandler<ExpState> ExpOutputChanged;


        /// <summary>
        /// Represents the state of expression in combobox.
        /// </summary>
        public enum ExpState
        {
            /// <summary>
            /// Is a expression.
            /// </summary>
            Exp,
            /// <summary>
            /// Is String.
            /// </summary>
            String,
            /// <summary>
            /// Is byte array.
            /// </summary>
            ByteArray,
            /// <summary>
            /// Invalid or a expression, it's should be ignore. 
            /// </summary>
            Ignore,
            /// <summary>
            /// Caught an error.
            /// </summary>
            Error
        }


        protected override void OnTextChanged(EventArgs e)
        {
            var length = this.Text.Length;

            //ignore it.
            if (length == 0)
            {
                SetToEmpty();
                base.OnTextChanged(e);
                return;
            }

            unsafe
            {
                fixed (char* pChar = this.Text)
                {

                    if (length > 1 && *(pChar + 1) == ':')
                    {
                        //If it's a string.
                        if (*pChar == 's' || *pChar == 'S')
                        {
                            SetStringExpOutput();
                            base.OnTextChanged(e);
                            return;
                        }

                        //Try parse byte array.
                        if (*pChar == 'b' || *pChar == 'B')
                        {
                            mByteArrayBufferCount = ExpHepler.UpdataByteArrayBuffer(this.Text);

                            if (mByteArrayBufferCount > 0)
                            {
                                SetByteArrayExpOutput();
                                base.OnTextChanged(e);
                                return;
                            }
                        }

                        SetToEmpty();
                        base.OnTextChanged(e);
                        return;
                    }


                    //Try parse expression.
                    var stopIndex = length - 1;
                    var context = new ParseContext(pChar, stopIndex);
                    var expType = ExpHepler.GetExpression(this.Text, out var expResult);
                    if (expType == ExpType.Succeed)
                    {
                        SetConstOutput(expResult);
                        base.OnTextChanged(e);
                        return;
                    }
                    SetError(expType);
                    base.OnTextChanged(e);
                    return;

                }
            }

        }


        private void SetConstOutput(Int64 value)
        {
            mState = ExpState.Exp;
            SetIntText(value);
            unsafe
            {
                ByteArrayString = ByteArrayToHexString((Byte*)&value, 8);
            }
            ExpOutputChanged?.Invoke(this, mState);
        }

        private void SetByteArrayExpOutput()
        {
            mState = ExpState.ByteArray;
            SetIntText(GetStartIntValueFromBuffer());
            ByteArrayString = mCodePage.GetString(ExpHepler.ByteArrayBuffer, 0, mByteArrayBufferCount);
            ExpOutputChanged?.Invoke(this, mState);
        }



        private void SetStringExpOutput()
        {
            mByteArrayBufferCount = mCodePage.GetBytes(this.Text, 2, this.Text.Length - 2, ExpHepler.ByteArrayBuffer, 0);
            if (mByteArrayBufferCount == 0)
            {
                SetToEmpty();
                return;
            }
            SetIntText(GetStartIntValueFromBuffer());
            unsafe
            {
                fixed (Byte* pByte = ExpHepler.ByteArrayBuffer)
                {
                    ByteArrayString = ByteArrayToHexString(pByte, mByteArrayBufferCount);
                }
            }
            mState = ExpState.String;
            ExpOutputChanged?.Invoke(this, mState);
        }


        private void SetToEmpty()
        {
            if (mState != ExpState.Ignore)
            {
                mState = ExpState.Ignore;
                SingedDecString = String.Empty;
                UnsignedDecString = String.Empty;
                HexString = String.Empty;
                BinString = String.Empty;
                ByteArrayString = String.Empty;
                ExpOutputChanged?.Invoke(this, mState);
            }
        }


        private void SetError(ExpType reason)
        {
            mState = ExpState.Error;
            UnsignedDecString = String.Empty;
            SingedDecString = String.Empty;
            HexString = String.Empty;
            BinString = String.Empty;
            ByteArrayString = reason.ToString();
            ExpOutputChanged?.Invoke(this, mState);
        }


        private void SetIntText(Int64 value)
        {
            unsafe
            {
                var unsigned = *(UInt32*)(&value);
                UnsignedDecString = Convert.ToString(unsigned, 10);
            }
            SingedDecString = value.ToString();
            HexString = value.ToString("X");
            BinString = Convert.ToString(value, 2).PadLeft(64,'0');
        }


        private Int64 GetStartIntValueFromBuffer()
        {
            unsafe
            {
                fixed (Byte* pByte = ExpressionHelper.ExpHepler.ByteArrayBuffer)
                {
                    var result = 0L;

                    var bResult = (Byte*)&result;

                    var length = mByteArrayBufferCount > 8 ? 8 : mByteArrayBufferCount;

                    for (int i = 0; i < length; i++)
                    {
                        *(bResult + i) = *(pByte + i);
                    }
                    return result;
                }
            }
        }

        private unsafe String ByteArrayToHexString(Byte* pByte, Int32 count)
        {

            fixed (UInt32* lookupP = mStrTable)
            {
                var result = new char[count * 2 + count - 1];

                fixed (char* resultP = result)
                {
                    var hex = (UInt32*)(resultP);
                    *hex = *(lookupP + (*pByte));
                    for (int i = 1; i < count; i++)
                    {
                        var pos = i + (i << 1);
                        *(resultP + pos - 1) = ' ';
                        hex = (UInt32*)(resultP + pos);
                        *hex = *(lookupP + (*(pByte + i)));
                    }
                }
                return new string(result);
            }
        }

        private static readonly UInt32[] mStrTable;

        unsafe static ExpBox()
        {
            mStrTable = new UInt32[256];

            fixed (UInt32* p = mStrTable)
            {
                for (int i = 0; i < 256; i++)
                {
                    var s = i.ToString("X2");
                    *(p + i) = s[0] + ((UInt32)s[1] << 16);
                }
            }
        }

    }
}
