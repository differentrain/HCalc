using System;

namespace HCalc.ExpressionHelper
{
    /// <summary>
    /// Just for performance.
    /// </summary>
    public unsafe readonly ref struct ParseContext
    {
        /// <summary>
        /// The pointer to expression string.
        /// </summary>
        public readonly char* Exp;
        /// <summary>
        /// The max index that a exp can be parsed.
        /// </summary>
        public readonly Int32 StopIndex;

        
        public ParseContext(char* exp, Int32 stopIndex)
        {
            Exp = exp;
            StopIndex = stopIndex;
        }
    }
}
