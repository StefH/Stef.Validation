# 🛡️ Stef.Validation
Guard methods for argument validation (NotNull, NotEmpty, ...)

## Packages
| NuGet | NuGet |
| - | - |
| Stef.Validation | [![NuGet Badge](https://img.shields.io/nuget/v/Stef.Validation)](https://www.nuget.org/packages/Stef.Validation)
| Stef.Validation.Options | [![NuGet Badge](https://img.shields.io/nuget/v/Stef.Validation.Options)](https://www.nuget.org/packages/Stef.Validation.Options)

## Introduction `Stef.Validation `

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

## Usage `Stef.Validation.Options`
This package provides an extension method to validate options using data annotations.
It is useful when you want to ensure that your options are correctly configured at startup.

### Define options class

``` c#
public class MyOptions
{
    [Required] // This attribute ensures that the Name property is not null or empty
    public required string Name { get; init; }
}
```

### Validate options

``` c#
using Stef.Validation.Options;

public static IServiceCollection Register(this IServiceCollection services, MyOptions options)
{
    Guard.NotNull(services);
    Guard.NotNull(options);

    // Add the options to the service collection. And throw an exception if the options are not valid.
    services.AddOptionsWithDataAnnotationValidation(options);
}
```

## Sponsors

[Entity Framework Extensions](https://entityframework-extensions.net/?utm_source=StefH) and [Dapper Plus](https://dapper-plus.net/?utm_source=StefH) are major sponsors and proud to contribute to the development of **Stef.Validation** and **Stef.Validation.Options**.

[![Entity Framework Extensions](https://raw.githubusercontent.com/StefH/resources/main/sponsor/entity-framework-extensions-sponsor.png)](https://entityframework-extensions.net/bulk-insert?utm_source=StefH)

[![Dapper Plus](https://raw.githubusercontent.com/StefH/resources/main/sponsor/dapper-plus-sponsor.png)](https://dapper-plus.net/bulk-insert?utm_source=StefH)