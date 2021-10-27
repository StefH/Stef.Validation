using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

// Based on https://github.com/dotnet/efcore/blob/main/src/Shared/Check.cs
namespace Stef.Validation
{
    [DebuggerStepThrough]
    public static class Guard
    {
        public static T Condition<T>(T? value, [ValidatedNotNull] Predicate<T?> predicate, [ValidatedNotNull] string parameterName)
        {
            NotNull(predicate, nameof(predicate));
            var result = NotNull(value, nameof(value));

            if (!predicate(value))
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentOutOfRangeException(parameterName);
            }

            return result;
        }

        public static T NotNull<T>(T? value, [ValidatedNotNull] string parameterName)
        {
            if (value is null)
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        public static T NotNull<T>(T? value, [ValidatedNotNull] string parameterName, [ValidatedNotNull] string propertyName)
        {
            if (value is null)
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));
                NotNullOrEmpty(propertyName, nameof(propertyName));

                throw new ArgumentException(CoreStrings.ArgumentPropertyNull(propertyName, parameterName));
            }

            return value;
        }

        public static IEnumerable<T> NotNullOrEmpty<T>(IEnumerable<T>? value, [ValidatedNotNull] string parameterName)
        {
            IEnumerable<T> result = NotNull(value, parameterName);

            if (result.Count() == 0)
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentException(CoreStrings.CollectionArgumentIsEmpty(parameterName));
            }

            return result;
        }

        public static string NotNullOrEmpty(string? value, [ValidatedNotNull] string parameterName)
        {
            string result = NotNull(value, parameterName);

            if (string.IsNullOrEmpty(result))
            {
                throw new ArgumentException(CoreStrings.ArgumentIsEmpty(parameterName));
            }

            return result;
        }

        public static string NotNullOrWhiteSpace(string? value, [ValidatedNotNull] string parameterName)
        {
            string result = NotNull(value, parameterName);

            if (result.IsNullOrWhiteSpace())
            {
                throw new ArgumentException(CoreStrings.ArgumentIsEmpty(parameterName));
            }

            return result;
        }

        public static IEnumerable<T> HasNoNulls<T>(IEnumerable<T?>? value, [ValidatedNotNull] string parameterName) where T : class
        {
            IEnumerable<T?> nonNullValue = NotNull(value, parameterName);

            if (nonNullValue.Any(e => e is null))
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentException(parameterName);
            }

            return nonNullValue.Cast<T>();
        }
    }
}