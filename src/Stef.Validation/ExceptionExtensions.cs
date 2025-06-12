using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Stef.Validation;

namespace System;

public static class ArgumentExceptionExtensions
{
    extension(ArgumentException)
    {
        public static void ThrowIfNullOrEmpty(string? value, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
        {
            _ = Guard.NotNullOrEmpty(value, parameterName);
        }

        public static void ThrowIfNullOrEmpty<T>(IEnumerable<T?>? value, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
        {
            _ = Guard.NotNullOrEmpty(value!, parameterName);
        }

        public static void ThrowIfNullOrWhiteSpace(string? value, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
        {
            _ = Guard.NotNullOrWhiteSpace(value, parameterName);
        }

        public static void ThrowIfHasNulls<T>(IEnumerable<T?>? value, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
        {
            _ = Guard.HasNoNulls(value!, parameterName);
        }

        public static void ThrowIfNotCondition<T>(T value, Predicate<T> predicate, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
        {
            _ = Guard.Condition(value, predicate, parameterName);
        }
    }

    extension(ArgumentNullException)
    {
        public static void ThrowIfNull(object? argument, [CallerArgumentExpression(nameof(argument))] string? parameterName = null)
        {
            _ = Guard.NotNull(argument, parameterName);
        }
    }

    extension(ArgumentOutOfRangeException)
    {
        public static void ThrowIfEqual<T>(T value, T other, [CallerArgumentExpression(nameof(value))] string? parameterName = null) where T : IEquatable<T>?
        {
            _ = Guard.Condition(value, v => !v!.Equals(other), parameterName);
        }

        public static void ThrowIfGreaterThan<T>(T value, T other, [CallerArgumentExpression(nameof(value))] string? parameterName = null) where T : IComparable<T>
        {
            _ = Guard.Condition(value, v => v.CompareTo(other) <= 0, parameterName);
        }

        public static void ThrowIfGreaterThanOrEqual<T>(T value, T other, [CallerArgumentExpression(nameof(value))] string? parameterName = null) where T : IComparable<T>
        {
            _ = Guard.Condition(value, v => v.CompareTo(other) < 0, parameterName);
        }

        public static void ThrowIfLessThan<T>(T value, T other, [CallerArgumentExpression(nameof(value))] string? parameterName = null) where T : IComparable<T>
        {
            _ = Guard.Condition(value, v => v.CompareTo(other) >= 0, parameterName);
        }

        public static void ThrowIfLessThanOrEqual<T>(T value, T other, [CallerArgumentExpression(nameof(value))] string? parameterName = null) where T : IComparable<T>
        {
            _ = Guard.Condition(value, v => v.CompareTo(other) > 0, parameterName);
        }

        public static void ThrowIfNotEqual<T>(T value, T other, [CallerArgumentExpression(nameof(value))] string? parameterName = null) where T : IEquatable<T>?
        {
            _ = Guard.Condition(value, v => v!.Equals(other), parameterName);
        }
    }
}