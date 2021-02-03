# Return Exceptional Code

Demonstrates how to have multiple return types in C#.

Not really sum types because we cannot exhaustively match.

```c#
// str is one of ["123", "4, 5, 6", "hello"]
try { ChooseInput(str); }
catch (NumberBox box) { Console.WriteLine($"Got a number: {box.Number}"); }
catch (ListBox box)   { Console.WriteLine($"Got a list  : [{String.Join(", ", box.Numbers)}]"); }
catch (StringBox box) { Console.WriteLine($"Got a string: {box.Input}"); }
```

To run:

```bash
dotnet run
```

Output:

```
Got a number: 123
Got a list  : [4, 5, 6]
Got a string: hello
```
