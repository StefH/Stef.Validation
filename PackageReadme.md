## Stef.Validation
Guard methods for argument validation (NotNull, NotEmpty, ...)

### Usage example

``` c#
using Stef.Validation;

public Person(string name, int age)
{
    Guard.NotNullOrEmpty(name, nameof(name));

    Guard.NotNullOrEmpty(name); // It's also possible to omit the `nameof(...)`-statement because CallerArgumentExpression is used internally.

    Guard.Condition(age, a => a > 0, nameof(age));
}
```