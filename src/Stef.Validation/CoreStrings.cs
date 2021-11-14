// Based on https://github.com/aspnet/EntityFramework/blob/dev/src/Microsoft.EntityFrameworkCore/Properties/CoreStrings.resx
namespace Stef.Validation
{
    internal static class CoreStrings
    {
        public static string ArgumentPropertyNull(string property, string argument)
        {
            return $"The property '{property}' of the argument '{argument}' cannot be null.";
        }

        public static string ArgumentIsEmpty(string? argumentName)
        {
            return $"The string argument '{argumentName}' cannot be empty.";
        }

        public static string CollectionArgumentIsEmpty(string? argumentName)
        {
            return $"The collection argument '{argumentName}' must contain at least one element.";
        }
    }
}