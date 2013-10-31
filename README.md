FizzBuzzGenerator
=================

A library for generating an infinitely-long sequence of FizzBuzz using deferred execution and configurable rules.

Usage
-----

```csharp
using using FizzBuzzGenerator;
var generator = new Generator();
var fizzbuzz = generator.Generate(
    Tuple.Create(3, "fizz"),
    Tuple.Create(5, "buzz")
    ).Take(100);
Console.WriteLine(fizzbuzz.Aggregate((a,b) => a + ", " + b));
```
