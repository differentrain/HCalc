using System;


namespace HCalc.ExpressionHelper
{
    /// <summary>
    /// Operator, low 8 bits is the value of operator, high 7 bits is priority.
    /// </summary>
    internal enum OperatorType : Int16
    {
        LBrackets = 0b1000000_00000000 | '(',
        RBrackets = 0b1000000_00000000 | ')',
        Not = 0b0100000_00000000 | '~',
        Mul = 0b0010000_00000000 | '*',
        Div = 0b0010000_00000000 | '/',
        Mod = 0b0010000_00000000 | '%',
        Add = 0b0001000_00000000 | '+',
        Sub = 0b0001000_00000000 | '-',
        LShift = 0b0000100_00000000 | '<',
        RShift = 0b0000100_00000000 | '>',
        /// <summary>
        /// logic right shift,>>>
        /// </summary>
        URShift = 0b0000100_00000000 | 0xFF,
        And = 0b0000010_00000000 | '&',
        Xor = 0b0000001_00000000 | '^',
        Or = 0b0000000_00000000 | '|',

    }
}
