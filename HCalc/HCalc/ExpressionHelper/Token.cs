using System;
using System.Runtime.InteropServices;


namespace HCalc.ExpressionHelper
{
    /// <summary>
    /// A token.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct Token
    {
        /// <summary>
        /// The type of token.
        /// </summary>
        public TokenType TokenType;

        /// <summary>
        /// Value of token
        /// </summary>
        public Int64 Value;

    }
}
