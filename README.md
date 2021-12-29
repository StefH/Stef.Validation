# Stef.Validation
Guard methods for argument validation (NotNull, NotEmpty, ...)

## NuGet
[![NuGet Badge](https://buildstats.info/nuget/Stef.Validation)](https://www.nuget.org/packages/Stef.Validation)

## Introduction

Here is a sample constructor that validates its arguments without Guard:

``` c#
public Person(string name, int age)
{
    if (name == null)
    {
        throw new ArgumentNullException(nameof(name), "Name cannot be null.");
    }

    if (name.Length == 0)
    {
        throw new ArgumentException("Name cannot be empty.", nameof(name));
    }

    if (age < 0)
    {
        throw new ArgumentOutOfRangeException(nameof(age), age, "Age cannot be negative.");
    }
}
```


And this is how we write the same constructor with Stef.Validation:

``` c#
using Stef.Validation;

public Person(string name, int age)
{
    Guard.NotNullOrEmpty(name, nameof(name));

    Guard.NotNullOrEmpty(name); // It's also possible to omit the `nameof(...)`-statement because CallerArgumentExpression is used internally.

    Guard.Condition(age, a => a > 0, nameof(age));
}
```