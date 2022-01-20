using Microsoft.Extensions.Options;

namespace Stef.Validation.Options;

public static class DataAnnotationOptionsValidator<TOptions> where TOptions : class, new()
{
    private static readonly string Name = typeof(TOptions).Name;

    public static void ValidateAndThrow(TOptions options)
    {
        if (options == null)
        {
            throw new OptionsValidationException(Name, typeof(TOptions), new[] { $"The {Name} object is null." });
        }

        var optionsValidator = new DataAnnotationValidateOptions<TOptions>(Name);
        var validateResult = optionsValidator.Validate(Name, options);
        if (validateResult.Failed)
        {
            throw new OptionsValidationException(Name, typeof(TOptions), validateResult.Failures);
        }
    }
}