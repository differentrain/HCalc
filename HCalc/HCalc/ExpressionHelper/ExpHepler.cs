using System;


namespace HCalc.ExpressionHelper
{

    /// <summary>
    /// Provides some static methods to parse the expression string.
    /// </summary>
    /// <threadsafety static="false" instance="false"/>
    public static class ExpHepler
    {

        /// <summary>
        /// A byte array buffer.
        /// </summary>
        public static readonly Byte[] ByteArrayBuffer = new Byte[256 << 1];


        /// <summary>
        /// Gets a class represents the expression that is created by parsing exp string.
        /// </summary>
        /// <param name="exp">The exp string.</param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ExpType GetExpression(String exp, out Int64 result)
        {
            result = 0;
            try
            {
                return GetExpCore(exp, out result);
            }
            catch (DivideByZeroException)
            {
                return ExpType.DivideByZero;
            }
            catch (OverflowException)
            {
                return ExpType.Overflow;
            }
        }


        /// <summary>
        /// Gets bytes from hex string and store these values in <see cref="ByteArrayBuffer"/>. 
        /// </summary>
        /// <param name="hexString">The hex string.</param>
        /// <returns>Count of the elements in byte array, if succeed; overwise, 0.</returns>
        public static Int32 UpdataByteArrayBuffer(String hexString)
        {
            var count = 0;
            unsafe
            {
                fixed (char* pChar = hexString)
                {
                    fixed (Byte* pByte = ByteArrayBuffer)
                    {
                        var maxIndex = hexString.Length - 1;
                        for (int i = 2; i < hexString.Length; i++)
                        {
                            var bitHeigh = pChar + i;
                            if (*bitHeigh == ' ') continue;

                            if (i == maxIndex) break;
                            var val = GetHexVal(*(bitHeigh++)) << 4 | GetHexVal(*bitHeigh);
                            if (val == Int32.MaxValue || val < 0)
                            {

                                return 0;
                            }
                            *(pByte + (count++)) = (Byte)val;
                            ++i;
                        }
                    }
                }
            }
            return count;
        }


        /// <summary>
        /// Get a constant form string.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="startIndex"></param>
        /// <param name="constant"></param>
        /// <returns>The next index to be parsed, if succeed, otherwise, -1.</returns>
        public static unsafe Int32 TryGetConstant(in ParseContext context, Int32 startIndex, out Int64 constant)
        {
            constant = 0;

            //Must not be a hex or bin number.
            if (context.StopIndex - startIndex < 2) return GetDecNumber(context, startIndex, out constant);

            var firstChar = *(context.Exp + startIndex);

            if (firstChar == '0')
            {
                var nextChar = *(context.Exp + startIndex + 1);

                //Bin
                if (nextChar == 'b' || nextChar == 'B') return GetBinNumber(context, startIndex + 2, out constant);
                //Hex
                if (nextChar == 'x' || nextChar == 'X') return GetHexNumber(context, startIndex + 2, out constant);
            }

            return GetDecNumber(context, startIndex, out constant);
        }




        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        /// <summary>
        /// 10^n.
        /// </summary>
        private static readonly UInt64[] mPowTenTable = new UInt64[] { 0, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000, 10000000000, 100000000000, 1000000000000, 10000000000000, 100000000000000, 1000000000000000, 10000000000000000, 100000000000000000, 1000000000000000000, 10000000000000000000 };

        private static readonly Byte[] mByteArrayTable = new Byte[] {
                                                      0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                                                      0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                                                      0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                                                      0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                                                      0xFF, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                                                      0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                                                      0xFF, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                                                      0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                                                      0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                                                      0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                                                      0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                                                      0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                                                      0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                                                      0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                                                      0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                                                      0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF
                                                    };

        private static unsafe Int32 GetDecNumber(in ParseContext context, Int32 startIndex, out Int64 decNumber)
        {

            decNumber = 0;
            var unsignedDecNumber = 0Ul;
            fixed (Byte* everyNumber = ByteArrayBuffer)
            {

                //We process the it as unsinged number, and only 64 bit number need to add 1.

                Boolean negative = *(context.Exp + startIndex) == '-';

                startIndex += negative ? 1 : 0;
                var count = 0;
                var bufferPos = everyNumber + 18;
                var exp = context.Exp + startIndex;

                //copy number to buffer on stack, and the number is reversed.
                for (; startIndex <= context.StopIndex && bufferPos >= everyNumber; startIndex++, bufferPos--)
                {
                    var number = *(exp++);
                    if (number < 48 || number > 57) //0, 9
                    {
                        if (count == 0) return -1;
                        --startIndex;
                        break;
                    }
                    *bufferPos = (Byte)(number - 48);
                    ++count;
                }

                if (count == 19) --startIndex;

                var numStartIndex = 19 - count;

                var startPose = everyNumber + (numStartIndex++);

                unsignedDecNumber += (*startPose);

                // if it's nagative, it's max unsigned value is it's signed max value+1
                var maxValue = (UInt64)Int64.MaxValue + 1;

                fixed (UInt64* pow = mPowTenTable)
                {
                    for (int j = 1; numStartIndex < 19; j++, numStartIndex++)
                    {
                        var temp = *(startPose + j);
                        var value = temp * (*(pow + j));
                        if (j == 18 && 19 == count && maxValue - unsignedDecNumber < value)
                        {
                            return -1;
                        }
                        unsignedDecNumber += value;
                    }
                }
                decNumber = negative ? 0 - (Int64)unsignedDecNumber : (Int64)unsignedDecNumber;
            }
            return startIndex;
        }

        private static unsafe Int32 GetBinNumber(in ParseContext context, Int32 startIndex, out Int64 binNumber)
        {

            binNumber = 0;
            var unsignedBinNumber = 0Ul;
            var count = 0;
            var mask = 0x8000000000000000U;
            var exp = context.Exp + startIndex;
            for (; startIndex <= context.StopIndex && mask > 0; startIndex++, mask >>= 1, count++, exp++)
            {
                var temp = *exp;
                if (temp == '1')
                {
                    unsignedBinNumber |= mask;
                    continue;
                }
                if (temp != '0')
                {
                    if (count == 0) return -1;
                    --startIndex;
                    break;
                }
            }
            if (count == 64) --startIndex;

            unsignedBinNumber >>= 64 - count;
            binNumber = (Int64)unsignedBinNumber;
            return startIndex;

        }

        private static unsafe Int32 GetHexNumber(in ParseContext context, Int32 startIndex, out Int64 hexNumber)
        {
            hexNumber = 0;
            var unsignedHexNumber = 0UL;
            var count = 0;
            var rShift = 60;
            var exp = context.Exp + startIndex;
            for (; startIndex <= context.StopIndex && rShift >= 0; startIndex++, rShift -= 4, exp++)
            {
                var number = (UInt64)GetHexVal(*exp);
                if (number == Int32.MaxValue)
                {
                    if (count == 0) return -1;
                    --startIndex;
                    break;
                }
                unsignedHexNumber |= number << rShift;
                ++count;
            }
            if (count == 16) startIndex--;
            unsignedHexNumber >>= 64 - (count << 2);
            hexNumber = (Int64)unsignedHexNumber;
            return startIndex;

        }

        private static Int32 GetHexVal(Char hex)
        {
            Int32 val = hex;
            unsafe
            {
                fixed (Byte* table = mByteArrayTable)
                {
                    if ((val & 0xFF) == val)
                    {
                        val = *(table + val);
                        if (val != 255) return val;
                    }
                    return Int32.MaxValue;
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static readonly Token[] mOutputQueue = new Token[256];
        private static readonly Int64[] mGlobalStack = new Int64[(256 << 1) + 1]; //  N/2+1 should be enough.



        /// <summary>
        /// Here to convert the infix exp to postfix exp ( Reverse Polish notation ) by using Shunting Yard Algorithm :https://en.wikipedia.org/wiki/Shunting-yard_algorithm
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="constPart"></param>
        /// <param name="constPartValue"></param>
        /// <returns></returns>
        private static ExpType GetExpCore(String exp, out Int64 result)
        {
            result = 0;

            var stopIndex = exp.Length - 1;

            unsafe
            {
                fixed (Token* outputQueue = mOutputQueue)
                {
                    fixed (Int64* operatorStack = mGlobalStack)
                    {
                        var buffer = new ParseBuffer(outputQueue, operatorStack);
                        var token = new TokenInfoBuffer();
                        fixed (char* pChar = exp)
                        {
                            var context = new ParseContext(pChar, stopIndex);

                            while (token.NextIndex <= stopIndex)
                            {
                                token.Updata(context);

                                switch (token.TokenType)
                                {
                                    case TokenType.Space:
                                        break;
                                    case TokenType.Constant:
                                        buffer.QueuePush(token);
                                        break;
                                    case TokenType.Operator:
                                        var op = (OperatorType)token.Value;
                                        switch (op)
                                        {
                                            case OperatorType.LBrackets:
                                                buffer.StackPush((Int16)op);
                                                break;
                                            case OperatorType.RBrackets:
                                                if (!buffer.ProcessLBarcked()) return ExpType.InvalidExpression;
                                                break;
                                            default:
                                                buffer.ProcessOperator(op);
                                                break;
                                        }
                                        break;
                                    default:
                                        return ExpType.InvalidExpression;
                                }
                            }
                        }

                        if (!buffer.StackEmpty)
                        {
                            while (!buffer.StackEmpty)
                            {
                                if ((OperatorType)buffer.StackTop == OperatorType.LBrackets) return ExpType.InvalidExpression;
                                buffer.StackPopToQueue();
                            }
                        }

                        return buffer.GetCalcExp(token, out result);
                    }
                }


            }

        }


    }
}
