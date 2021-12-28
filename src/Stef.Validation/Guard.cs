﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Based on https://github.com/dotnet/efcore/blob/main/src/Shared/Check.cs
namespace Stef.Validation
{
    [DebuggerStepThrough]
    public static class Guard
    {
        public static T Condition<T>(T? value, Predicate<T?> predicate, [CallerArgumentExpression("value")] string? parameterName = null) where T : struct
        {
            NotNull(predicate, nameof(predicate));
            var result = NotNull(value, parameterName);

            if (!predicate(value))
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentOutOfRangeException(parameterName);
            }

            return result;
        }

        public static T Condition<T>(T value, Predicate<T> predicate, [CallerArgumentExpression("value")] string? parameterName = null) where T : class , struct
        {
            NotNull(predicate, nameof(predicate));
            var result = NotNull(value, parameterName);

            if (!predicate(value))
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentOutOfRangeException(parameterName);
            }

            return result;
        }

        public static T NotNull<T>(T? value, [CallerArgumentExpression("value")] string? parameterName = null) where T : struct
        {
            if (value is null)
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentNullException(parameterName);
            }

            return value.Value;
        }

        public static T NotNull<T>(T value, [CallerArgumentExpression("value")] string? parameterName = null) where T : class
        {
            if (value is null)
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        public static T NotNull<T>(T value, string parameterName, string propertyName)
        {
            if (value is null)
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));
                NotNullOrEmpty(propertyName, nameof(propertyName));

                throw new ArgumentException(CoreStrings.ArgumentPropertyNull(propertyName, parameterName));
            }

            return value;
        }

        public static IEnumerable<T> NotNullOrEmpty<T>(IEnumerable<T> value, [CallerArgumentExpression("value")] string? parameterName = null)
        {
            IEnumerable<T> result = NotNull(value, parameterName);

            // ReSharper disable once PossibleMultipleEnumeration
            if (!result.Any())
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentException(CoreStrings.CollectionArgumentIsEmpty(parameterName));
            }

            // ReSharper disable once PossibleMultipleEnumeration
            return result;
        }

        public static string NotNullOrEmpty(string? value, [CallerArgumentExpression("value")] string? parameterName = null)
        {
            if (value is null)
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentNullException(parameterName);
            }

            string result = NotNull(value, parameterName);

            if (string.IsNullOrEmpty(result))
            {
                throw new ArgumentException(CoreStrings.ArgumentIsEmpty(parameterName));
            }

            return result;
        }

        public static string NotNullOrWhiteSpace(string value, [CallerArgumentExpression("value")] string? parameterName = null)
        {
            string result = NotNull(value, parameterName);

            if (result.IsNullOrWhiteSpace())
            {
                throw new ArgumentException(CoreStrings.ArgumentIsEmpty(parameterName));
            }

            return result;
        }

        public static IEnumerable<T> HasNoNulls<T>(IEnumerable<T> value, [CallerArgumentExpression("value")] string? parameterName = null)
        {
            IEnumerable<T> nonNullValue = NotNull(value, parameterName);

            // ReSharper disable once PossibleMultipleEnumeration
            if (nonNullValue.Any(e => e is null))
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentException(parameterName);
            }

            // ReSharper disable once PossibleMultipleEnumeration
            return nonNullValue;
        }
    }
}