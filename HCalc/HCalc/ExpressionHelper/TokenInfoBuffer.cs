using System;

namespace HCalc.ExpressionHelper
{
    /// <summary>
    /// represents a buffer that stores the infomation of token when parse exp.
    /// </summary>
    internal ref struct TokenInfoBuffer
    {

        /// <summary>
        /// The type of token.
        /// </summary>
        public TokenType TokenType;

        /// <summary>
        /// Value of token
        /// </summary>
        public Int64 Value;

        /// <summary>
        /// The start pos of string that to be parsed in next time.
        /// </summary>
        public Int32 NextIndex;


        private static readonly Int16[] OperatorEnums = (Int16[])Enum.GetValues(typeof(OperatorType));


        private Boolean mLastIsOperator;

        /// <summary>
        /// Update token info by parse the exp string.
        /// </summary>
        /// <param name="context">context.</param>
        public unsafe void Updata(in ParseContext context)
        {

            //Set the type to error.
            this.TokenType = TokenType.Error;

            var mOperator = *(context.Exp + this.NextIndex);


            if (mOperator == ' ') //ignore white space
            {
                this.TokenType = TokenType.Space;
                ++this.NextIndex;
                mLastIsOperator = false;
                return;
            }


            fixed (Int16* flag = OperatorEnums)
            {
                for (int i = 0; i < OperatorEnums.Length; i++)
                {
                    var op = *(flag + i);

                    if ((op & 0xFF) == (mOperator & 0xFF)) //if it's operator
                    {
                        if (mOperator == '-' && (this.NextIndex==0 ||mLastIsOperator)) //Special treatment for "-".
                        {
                            goto GetConst;
                        }
                        else if ((op & 0B100_00000000) == 0B100_00000000)
                        {
                            //< or  >
                            //Shift operation has tow chars.

                            if (this.NextIndex == context.StopIndex || *(context.Exp + (++this.NextIndex)) != mOperator) return;
                            if (mOperator == '>' && this.NextIndex < context.StopIndex && *(context.Exp + this.NextIndex + 1) == '>') //>>>,sha 
                            {
                                this.TokenType = TokenType.Operator;
                                this.NextIndex += 2;
                                this.Value = op | 0xFF;
                                return;
                            }
                        }
                        this.TokenType = TokenType.Operator;
                        ++this.NextIndex;
                        this.Value = op;
                        mLastIsOperator = true;
                        return;
                    }
                }
            }
            GetConst:
            this.NextIndex = ExpHepler.TryGetConstant(context, this.NextIndex, out var conValue);
            if (this.NextIndex == -1) return;
            this.TokenType = TokenType.Constant;
            ++this.NextIndex;
            this.Value = conValue;
            mLastIsOperator = false;
        }

    }
}
