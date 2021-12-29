using System;
using Stef.Validation;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var actions = new Action[]
            {
                () =>
                {
                    Program? p = null;
                    Guard.NotNull(p);
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
                    Guard.NotNullOrEmpty("");
                },
                () =>
                {
                    string s = "";
                    Guard.NotNullOrWhiteSpace(s);
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
                }
            };

            foreach (var action in actions)
            {
                try
                {
                    action();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine();
                }
            }
        }
    }
}