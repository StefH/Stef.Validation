## Stef.Validation.Options
This package provides an extension method to validate options using data annotations.
It is useful when you want to ensure that your options are correctly configured at startup.

### Usage example

#### Define options class

``` c#
public class MyOptions
{
    [Required] // This attribute ensures that the Name property is not null or empty
    public required string Name { get; init; }
}
```

#### Validate options

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