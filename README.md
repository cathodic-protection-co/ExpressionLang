# ExpressionLang
A VERY Basic language for evaluating expressions.

## Syntax
> This syntax is for the example / test project, any syntax (tokens) can be defined within the tokenizer.

### Boolean
Token | Operation
----- | ---------
"true"| Boolean True
"false"| Boolean False

### Logical
Token | Operation
----- | ---------
"&&", "and"  | Logical and
"\|\|", "or"  | Logical or

### Equality
Token | Operation
----- | ---------
"=="  | Equal to
"!="  | Not equal to
"<"   | Less than
"<="  | Less than or equal to
">"   | Greater than
">="  | Greater than or equal to

### Operators
Token | Operation
----- | --------
"-"   | Subtraction
"+"   | Addition
"*"   | Multiplication
"/"   | Division
"%"   | Modulo

## Auto casting
Expressions will be left-hand auto-casted.
```
10 + 10.5 == 20
```
> Evaluates to true.
```
10.5 + 10 == 20
```
> Evaluates to false.
