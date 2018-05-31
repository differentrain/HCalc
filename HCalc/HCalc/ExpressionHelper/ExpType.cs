

namespace HCalc.ExpressionHelper
{
    /// <summary>
    /// Represents the attribute of an expression String.
    /// </summary>
    public enum ExpType
    {
        /// <summary>
        /// Succeed.
        /// </summary>
        Succeed,
        /// <summary>
        /// Overflow.
        /// </summary>
        Overflow,
        /// <summary>
        /// Operand divede by 0.
        /// </summary>
        DivideByZero,
        /// <summary>
        /// Invalid expression.
        /// </summary>
        InvalidExpression,
    }
}
