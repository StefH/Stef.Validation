using System;
using System.Collections.Generic;
using AwesomeAssertions;
using Stef.Validation;

namespace ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        var actionsWhichShouldThrow = new Action[]
        {
            () =>
            {
                Program? p = null;
                Guard.NotNull(p);
            },
            () =>
            {
                Program? p = null;
                ArgumentNullException.ThrowIfNull(p);
            },
            () =>
            {
                Guard.NotNull((Program?)null);
            },
            () =>
            {
                string s = "";
                Guard.NotNullOrEmpty(s);
            },
            () =>
            {
                string s = "";
                ArgumentException.ThrowIfNullOrEmpty(s);
            },
            () =>
            {
                Guard.NotNullOrEmpty("");
            },
            () =>
            {
                string s = "";
                Guard.NotNullOrWhiteSpace(s);
            },
            () =>
            {
                string s = "";
                ArgumentException.ThrowIfNullOrWhiteSpace(s);
            },
            () =>
            {
                Guard.NotNullOrWhiteSpace("");
            },
            () =>
            {
                int intValue = 1;
                Guard.Condition(intValue, i => i > 5);
            },
            () =>
            {
                Guard.Condition(1, i => i > 5);
            },
            () =>
            {
                int[] intValues = Array.Empty<int>();
                Guard.NotNullOrEmpty(intValues);
            },
            () =>
            {
                Guard.NotNullOrEmpty(Array.Empty<int>());
            },
           
            () =>
            {
                var intValuesWithNullValue = new[] { (int?) 1, null };
                Guard.HasNoNulls(intValuesWithNullValue);
            },
            () =>
            {
                Guard.HasNoNulls(new[] { (int?) 1, null });
            },
            () =>
            {
                IEnumerable<int?> intValuesWithNullValue = new[] { (int?) 1, null };
                ArgumentException.ThrowIfHasNulls(intValuesWithNullValue);
            },
            () =>
            {
                int? intValue = 0;
                Guard.Condition(intValue, value => value == null || value > 0);
            }
        };

        var actionsWhichShouldNotThrow = new Action[]
        {
            () =>
            {
                int? intValue = null;
                Guard.Condition(intValue, value => value == null || value > 0);
            }
        };

        foreach (var action in actionsWhichShouldThrow)
        {
            action.Should().Throw<Exception>();
        }

        foreach (var action in actionsWhichShouldNotThrow)
        {
            action.Should().NotThrow<Exception>();
        }
    }
}