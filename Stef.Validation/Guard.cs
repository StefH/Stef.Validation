using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

// Based on https://github.com/aspnet/EntityFrameworkCore/src/Shared/Check.cs
namespace Stef.Validation
{
    [DebuggerStepThrough]
    public static class Guard
    {
        public static T Condition<T>([ValidatedNotNull] T value, [ValidatedNotNull] Predicate<T> predicate, [ValidatedNotNull] string parameterName)
        {
            NotNull(predicate, nameof(predicate));
            NotNull(value, nameof(value));

            if (!predicate(value))
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentOutOfRangeException(parameterName);
            }

            return value;
        }

        public static T? NotNull<T>(T? value, [ValidatedNotNull] string parameterName)
        {
            if (value is null)
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        public static T? NotNull<T>(T? value, [ValidatedNotNull] string parameterName, [ValidatedNotNull] string propertyName)
        {
            if (value is null)
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));
                NotNullOrEmpty(propertyName, nameof(propertyName));

                throw new ArgumentException(CoreStrings.ArgumentPropertyNull(propertyName, parameterName));
            }

            return value;
        }

        public static IEnumerable<T>? NotNullOrEmpty<T>([ValidatedNotNull] IEnumerable<T> value, [ValidatedNotNull] string parameterName)
        {
            NotNull(value, parameterName);

            if (value?.Count() == 0)
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentException(CoreStrings.CollectionArgumentIsEmpty(parameterName));
            }

            return value;
        }

        public static string? NotNullOrEmpty(string? value, [ValidatedNotNull] string parameterName)
        {
            Exception? e = null;
            if (value is null)
            {
                e = new ArgumentNullException(parameterName);
            }
            else if (value.Trim().Length == 0)
            {
                e = new ArgumentException(CoreStrings.ArgumentIsEmpty(parameterName));
            }

            if (e is { })
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw e;
            }

            return value;
        }

        public static string? NotNullOrWhiteSpace(string? value, [ValidatedNotNull] string parameterName)
        {
            Exception? e = null;
            if (value is null)
            {
                e = new ArgumentNullException(parameterName);
            }
            else if (value.IsNullOrWhiteSpace())
            {
                e = new ArgumentException(CoreStrings.ArgumentIsEmpty(parameterName));
            }

            if (e is { })
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw e;
            }

            return value;
        }

        public static ICollection<T?> HasNoNulls<T>([ValidatedNotNull] ICollection<T?> value, [ValidatedNotNull] string parameterName) where T : class
        {
            NotNull(value, parameterName);

            if (value.Any(e => e is null))
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentException(parameterName);
            }

            return value;
        }
    }
}