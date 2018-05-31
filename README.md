# About
HCalc is lightweight calculator for programmers, and reversers.

Features:
* Expression.
* Converting between byte array and string.
* Portable.
 
[Download](https://github.com/differentrain/HCalc/releases/download/v1.0.0.0/HCalc.zip)
 
## How to use HCalc

### Basic operations
![](https://raw.githubusercontent.com/differentrain/HCalc/master/Images/1.png)

As shown, HCalc has a very clean UI, once you input a expression, results are readily displayed, without further operation.

Now HCalc supports the following operators ( ordered by priority ): 
* Brackets: '(' and ')'
* NOT: '~'  
* MUl: '*'
* DIv: '/'
* MOD: '%'
* ADD: '+'
* SUB: '-'
* SHL: "<<"
* SAR: ">>"  
* SHR: ">>>"  
* XOR: '^'
* OR : '|'

As for operands, you can use decimal integer directly, if the operand is a hexadecimal or binary number, you __must__ add it's prefix (0x or 0b, ignoring case) .

### Convertion

HCalc will deem a expression to byte array, if a prefix "b:" in front of it, for example, "0b:FF FF FF FF". You needn't (and can't) add  prefix "0x" before elements, and any white space between each elements will be ignored, vice versa, if a prefix "s:" in fornt of expression, the expression will be deemed to a string.

In these case, HCalc will convert the expression to a string ( or a byte array ), by using the codepage you specified. (Right click the tray icon and select the codepage in it's menu item. )

![](https://raw.githubusercontent.com/differentrain/HCalc/master/Images/2.png)

Now the CodePage menu has these options: ascii, unicode, GB2312, big5, shift-JIS, and windows 1250. if you want more options, contact me or edit source code by your self :p

Tips: Press `F1` or `F2` to quick-add prefix.

## About source code

I wrote this gadget in C# 7.2, Visual studio 2017, nothing else to say. By the way, the readability and renormalization is sacrificed for performance, if you feel hard to read these code, debug it.

--- 

# 关于
HCalc 是一个面向程序员或逆向人员的计算器。
 
特性 ：
* 表达式。
* 字节数组与字符串之间的转换。
* 便携。

[下载](https://github.com/differentrain/HCalc/releases/download/v1.0.0.0/HCalc.zip)

## 使用方法

### 基础运算
![](https://raw.githubusercontent.com/differentrain/HCalc/master/Images/1.png)
 
如图所示，HCalc的UI非常简介。一旦你输入了表达式，程序会直接显示计算结果。
 
目前HCalc支持以下运算符 ( 以优先级进行排列 ): 
* 括号: '(' and ')'
* NOT: '~'  
* MUl: '*'
* DIv: '/'
* MOD: '%'
* ADD: '+'
* SUB: '-'
* SHL: "<<"
* SAR: ">>"  
* SHR: ">>>"  
* XOR: '^'
* OR : '|'
 
可以直接使用十进制数作为操作数，如果要使用十六进制或二进制数字，必须增加 "0x" 或 "0b" 前缀，忽略大小写。

### 转换

HCalc将把以 "b:" 前缀开始的表达式视为字节数组，例如 "0b:FF FF FF FF" 。 您不必(也不能)在元素前添加 "0x" 前缀， 任何元素之间的空白字符都将被忽略。
 
反之 ，前缀是 "b:" 的表达式将被视作字符串。
 
在这两种情况下, HCalc 将依照您指定的代码页，把表达式转换成字符串(或字节数组)。(右键单机托盘图标，在菜单项中选择代码页进行设置。 )

![](https://raw.githubusercontent.com/differentrain/HCalc/master/Images/2.png)
 
目前代码页菜单包括以下选项: ascii, unicode, GB2312, big5, shift-JIS, 以及 windows 1250. 如果需要更多选项, 联系我或自行修改代码。
 
提示 ：按 `F1` 或 `F2` 可以快速输入前缀。
  
## 关于源码
 
我用C# 7.2，VS2017 写了这个工具，其他没什么可说的了。另外为了性能，我牺牲了代码的可读性和重构性，如果你觉得很难读，就调试一下。
