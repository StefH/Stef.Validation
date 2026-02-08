using System;
using Xunit;

namespace Stef.Validation.Tests;

public class GuardRangeTests
{
    [Fact]
    public void Range_ReturnsValue_WhenWithinBounds()
    {
        var value = 5;

        var result = Guard.Range(value, 1, 10);

        Assert.Equal(value, result);
    }

    [Fact]
    public void Range_ReturnsValue_WhenMinIsNull()
    {
        var value = 5;

        var result = Guard.Range(value, null, 10);

        Assert.Equal(value, result);
    }

    [Fact]
    public void Range_ReturnsValue_WhenMaxIsNull()
    {
        var value = 5;

        var result = Guard.Range(value, 1, null);

        Assert.Equal(value, result);
    }

    [Fact]
    public void Range_ReturnsValue_WhenMinAndMaxNull()
    {
        var value = 5;

        var result = Guard.Range(value, null, null);

        Assert.Equal(value, result);
    }

    [Fact]
    public void Range_Throws_WhenBelowMin()
    {
        var value = 0;

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Range(value, 1, 10));

        Assert.Equal("value", exception.ParamName);
    }

    [Fact]
    public void Range_Throws_WhenAboveMax()
    {
        var value = 11;

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Range(value, 1, 10));

        Assert.Equal("value", exception.ParamName);
    }

    [Fact]
    public void Range_ReturnsValue_ForComparableClass_WhenWithinBounds()
    {
        var value = new ComparableValue(5);

        var result = Guard.Range(value, new ComparableValue(1), new ComparableValue(10));

        Assert.Equal(value, result);
    }

    [Fact]
    public void Range_ReturnsValue_ForComparableClass_WithNullBounds()
    {
        var value = new ComparableValue(5);

        var result = Guard.Range(value, null, null);

        Assert.Equal(value, result);
    }

    [Fact]
    public void Range_ReturnsValue_ForComparableClass_WhenMaxIsNull()
    {
        var value = new ComparableValue(5);

        var result = Guard.Range(value, new ComparableValue(1), null);

        Assert.Equal(value, result);
    }

    [Fact]
    public void Range_ReturnsValue_ForComparableClass_WhenMinIsNull()
    {
        var value = new ComparableValue(5);

        var result = Guard.Range(value, null, new ComparableValue(10));

        Assert.Equal(value, result);
    }

    [Fact]
    public void Range_Throws_ForComparableClass_WhenBelowMin()
    {
        var value = new ComparableValue(0);

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Range(value, new ComparableValue(1), new ComparableValue(10)));

        Assert.Equal("value", exception.ParamName);
    }

    [Fact]
    public void Range_Throws_ForComparableClass_WhenAboveMax()
    {
        var value = new ComparableValue(11);

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Range(value, new ComparableValue(1), new ComparableValue(10)));

        Assert.Equal("value", exception.ParamName);
    }

    private sealed class ComparableValue : IComparable<ComparableValue>
    {
        public ComparableValue(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public int CompareTo(ComparableValue other)
        {
            if (other is null)
            {
                return 1;
            }

            return Value.CompareTo(other.Value);
        }
    }
}