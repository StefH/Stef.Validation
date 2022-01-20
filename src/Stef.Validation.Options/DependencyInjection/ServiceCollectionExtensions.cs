using Stef.Validation;
using Stef.Validation.Options;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOptionsWithDataAnnotationValidation<TOptions>(this IServiceCollection services, TOptions options) where TOptions : class, new()
    {
        Guard.NotNull(services, nameof(services));

        DataAnnotationOptionsValidator<TOptions>.ValidateAndThrow(options);

        return services.AddSingleton(Options.Options.Create(options));
    }
}