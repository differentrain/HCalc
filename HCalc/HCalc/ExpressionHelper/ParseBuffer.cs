using System;

#if USING_EXP_TREE
using System.Collections.Generic;
using System.Linq.Expressions;
#else
using System.Runtime.InteropServices;
#endif

namespace HCalc.ExpressionHelper
{
    /// <summary>
    /// Buffer to store parse infos.
    /// </summary>
    /// <remarks>
    /// In order to improve the efficiency of parsing exp, I don't use Stack<T>, 
    /// instead I store tokens in an array alloced in real stack, and do my best to optimize  code,
    /// so these codes may be very dirty.... ;P 
    /// </remarks>
    internal unsafe ref struct ParseBuffer
    {
        private Int32 mQueueIndex;
        private Int32 mStackIndex;
        private readonly Token* mQueue;
        private readonly Int64* mStack;

        public ParseBuffer(Token* queue, Int64* stack)
        {
            mQueue = queue;
            mStack = stack;
            mQueueIndex = -1;
            mStackIndex = -1;
        }

        /// <summary>
        /// Push value to queue.
        /// </summary>
        /// <param name="tokenInfo"></param>
        public void QueuePush(in TokenInfoBuffer tokenInfo)
        {
            var pQueue = mQueue + (++mQueueIndex);
            (*pQueue).Value = tokenInfo.Value;
            (*pQueue).TokenType = tokenInfo.TokenType;

        }

        /// <summary>
        /// Push value to stack.
        /// </summary>
        /// <param name="op"></param>
        public void StackPush(Int64 op)
        {
            *(mStack + (++mStackIndex)) = op;
        }

        /// <summary>
        /// Pop stack, and push in Queue.
        /// </summary>
        public void StackPopToQueue()
        {
            var pQueue = mQueue + (++mQueueIndex);
            (*pQueue).Value = *(mStack + (mStackIndex--));
            (*pQueue).TokenType = TokenType.Operator;
        }

        /// <summary>
        /// If token is left barcked.
        /// </summary>
        /// <returns></returns>
        public Boolean ProcessLBarcked()
        {
            while (mStackIndex >= 0)
            {
                if ((OperatorType)(*(mStack + mStackIndex)) == OperatorType.LBrackets)
                {
                    --mStackIndex;
                    return true;
                }
                var pQueue = mQueue + (++mQueueIndex);
                (*pQueue).Value = *(mStack + (mStackIndex--));
                (*pQueue).TokenType = TokenType.Operator;
            }
            return false;
        }

        /// <summary>
        /// Process noraml barcked.
        /// </summary>
        /// <param name="op"></param>
        public void ProcessOperator(OperatorType op)
        {
            var priority = (Int32)op & 0b1111111_00000000;
            //Notes that NOT operator (!) is right associative, so it's condition of pushing is priority < stack-top-value, but here only NOT in this priority...
            while (mStackIndex >= 0 && (OperatorType)(*(mStack + mStackIndex)) != OperatorType.LBrackets && priority <= ((Int32)(*(mStack + mStackIndex)) & 0b1111111_00000000))
            {
                var pQueue = mQueue + (++mQueueIndex);
                (*pQueue).Value = *(mStack + (mStackIndex--));
                (*pQueue).TokenType = TokenType.Operator;
            }
            *(mStack + (++mStackIndex)) = (Int64)op;
        }

        /// <summary>
        /// O yeah~
        /// </summary>
        /// <returns></returns>
        public ExpType GetCalcExp(in TokenInfoBuffer tokenInfo, out Int64 result)
        {
            result = 0;
            for (int i = 0; i <= mQueueIndex; i++)
            {
                var token = (*(mQueue + i));

                switch (token.TokenType)
                {
                    case TokenType.Constant:
                        *(mStack + (++mStackIndex)) = token.Value;
                        break;
                    default:
                        switch ((OperatorType)token.Value)
                        {
                            case OperatorType.Not:
                                if (mStackIndex < 0) return ExpType.InvalidExpression;
                                *(mStack + mStackIndex) = ~(*(mStack + mStackIndex));
                                break;
                            case OperatorType.Mul:
                                if (mStackIndex < 1) return ExpType.InvalidExpression;
                                var ROP = (*(mStack + (mStackIndex--)));
                                *(mStack + mStackIndex) = checked(*(mStack + mStackIndex) * ROP);
                                break;
                            case OperatorType.Div:
                                if (mStackIndex < 1) return ExpType.InvalidExpression;
                                ROP = (*(mStack + (mStackIndex--)));
                                *(mStack + mStackIndex) = (*(mStack + mStackIndex)) / ROP;
                                break;
                            case OperatorType.Mod:
                                if (mStackIndex < 1) return ExpType.InvalidExpression;
                                ROP = (*(mStack + (mStackIndex--)));
                                *(mStack + mStackIndex) = (*(mStack + mStackIndex)) % ROP;
                                break;
                            case OperatorType.Add:
                                if (mStackIndex < 1) return ExpType.InvalidExpression;
                                ROP = (*(mStack + (mStackIndex--)));
                                *(mStack + mStackIndex) = checked(unchecked(*(mStack + mStackIndex)) + ROP);
                                break;
                            case OperatorType.Sub:
                                if (mStackIndex < 1) return ExpType.InvalidExpression;
                                ROP = (*(mStack + (mStackIndex--)));
                                *(mStack + mStackIndex) = checked(unchecked(*(mStack + mStackIndex)) - ROP);
                                break;
                            case OperatorType.LShift:
                                if (mStackIndex < 1) return ExpType.InvalidExpression;
                                var opara = (Int32)(*(mStack + (mStackIndex--)));
                                if (opara > 64) return ExpType.InvalidExpression;
                                *(mStack + mStackIndex) <<= opara;
                                break;
                            case OperatorType.RShift:
                                if (mStackIndex < 1) return ExpType.InvalidExpression;
                                opara = (Int32)(*(mStack + (mStackIndex--)));
                                if (opara > 64) return ExpType.InvalidExpression;
                                *(mStack + mStackIndex) >>= opara;
                                break;
                            case OperatorType.URShift:
                                if (mStackIndex < 1) return ExpType.InvalidExpression;
                                opara = (Int32)(*(mStack + (mStackIndex--)));
                                if (opara > 64) return ExpType.InvalidExpression;
                                *(mStack + mStackIndex) = (Int64)((UInt64)(*(mStack + mStackIndex)) >> opara);
                                break;
                            case OperatorType.And:
                                if (mStackIndex < 1) return ExpType.InvalidExpression;
                                ROP = (*(mStack + (mStackIndex--)));
                                *(mStack + mStackIndex) = (*(mStack + mStackIndex)) & ROP;
                                break;
                            case OperatorType.Xor:
                                if (mStackIndex < 1) return ExpType.InvalidExpression;
                                ROP = (*(mStack + (mStackIndex--)));
                                *(mStack + mStackIndex) = (*(mStack + mStackIndex)) ^ ROP;
                                break;
                            case OperatorType.Or:
                                if (mStackIndex < 1) return ExpType.InvalidExpression;
                                ROP = (*(mStack + (mStackIndex--)));
                                *(mStack + mStackIndex) = (*(mStack + mStackIndex)) | ROP;
                                break;
                        }
                        break;
                }
            }

            if (mStackIndex == 0)
            {
                result = *mStack;
                return ExpType.Succeed;

            }
            return ExpType.InvalidExpression;

        }

             

        /// <summary>
        /// Gets if stack is empty.
        /// </summary>
        public Boolean StackEmpty => mStackIndex == -1;

        /// <summary>
        /// Get the value in the top of stack.
        /// </summary>
        public Int64 StackTop => mStack[mStackIndex];


    }
}
