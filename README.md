# Stef.Validation
Guard methods for argument validation (NotNull, NotEmpty, ...)

## Packages
| NuGet | NuGet |
| - | - |
| Stef.Validation | [![NuGet Badge](https://img.shields.io/nuget/v/Stef.Validation)](https://www.nuget.org/packages/Stef.Validation)
| Stef.Validation.Options | [![NuGet Badge](https://img.shields.io/nuget/v/Stef.Validation.Options)](https://www.nuget.org/packages/Stef.Validation.Options)

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
