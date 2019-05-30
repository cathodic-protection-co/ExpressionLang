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

## Variables
Variables can be added by passing a dictionary of "variables" to the compiler.
```C#
Dictionary<string, Variable> vars = new Dictionary<string, Variable>
{
    { "foobar", new BoolVariable("foobar", true) },
    { "foo", new FloatVariable("foo", 10.5f) },
    { "bar", new FloatVariable("bar", 20) }
};
```

## Auto casting
Expressions will be left-hand auto-casted.
```C#
10 + 10.5 == 20
```
> Evaluates to true.
```C#
10.5 + 10 == 20
```
> Evaluates to false.
