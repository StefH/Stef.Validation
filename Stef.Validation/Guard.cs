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

        public static T NotNull<T>([ValidatedNotNull] T value, [ValidatedNotNull] string parameterName)
        {
            if (ReferenceEquals(value, null))
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        public static T NotNull<T>([ValidatedNotNull] T value, [ValidatedNotNull] string parameterName, [ValidatedNotNull] string propertyName)
        {
            if (ReferenceEquals(value, null))
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));
                NotNullOrEmpty(propertyName, nameof(propertyName));

                throw new ArgumentException(CoreStrings.ArgumentPropertyNull(propertyName, parameterName));
            }

            return value;
        }

        public static IEnumerable<T> NotNullOrEmpty<T>([ValidatedNotNull] IEnumerable<T> value, [ValidatedNotNull] string parameterName)
        {
            NotNull(value, parameterName);

            if (value?.Count() == 0)
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentException(CoreStrings.CollectionArgumentIsEmpty(parameterName));
            }

            return value;
        }

        public static string NotNullOrEmpty([ValidatedNotNull] string value, [ValidatedNotNull] string parameterName)
        {
            Exception e = null;
            if (ReferenceEquals(value, null))
            {
                e = new ArgumentNullException(parameterName);
            }
            else if (value.Trim().Length == 0)
            {
                e = new ArgumentException(CoreStrings.ArgumentIsEmpty(parameterName));
            }

            if (e != null)
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw e;
            }

            return value;
        }

        public static string NotNullOrWhiteSpace([ValidatedNotNull] string value, [ValidatedNotNull] string parameterName)
        {
            Exception e = null;
            if (ReferenceEquals(value, null))
            {
                e = new ArgumentNullException(parameterName);
            }
            else if (value.IsNullOrWhiteSpace())
            {
                e = new ArgumentException(CoreStrings.ArgumentIsEmpty(parameterName));
            }

            if (e != null)
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw e;
            }

            return value;
        }

        public static ICollection<T> HasNoNulls<T>([ValidatedNotNull] ICollection<T> value, [ValidatedNotNull] string parameterName) where T : class
        {
            NotNull(value, parameterName);

            if (value.Any(e => e == null))
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentException(parameterName);
            }

            return value;
        }
    }
}