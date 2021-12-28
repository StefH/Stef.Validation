using System.Collections.Generic;
using Stef.Validation;

namespace ConsoleApp
{
    internal class Class1
    {
        public void TestCondition(string? strValue)
        {
            string? s = Guard.Condition(strValue, s => s != null && s.Contains("a"));
        }

        public void TestString(string strValue)
        {
            string s = Guard.NotNullOrEmpty(strValue, nameof(strValue));
        }

        public void TestString2(string? strValue)
        {
            string s = Guard.NotNullOrEmpty(strValue, nameof(strValue));
        }

        public void Test(long? nullableLong)
        {
            long l = Guard.NotNull(nullableLong);
        }

        public void Test(int intValue, string strValue)
        {
            int i = Guard.Condition(intValue, v => v > 0, nameof(intValue));
            string s = Guard.NotNullOrWhiteSpace(strValue, nameof(strValue));
        }

        public void Test(Class1 value)
        {
            Class1 c = Guard.NotNull(value, nameof(value));
        }

        public void Test(Class1?[] array)
        {
            IEnumerable<Class1> a = Guard.HasNoNulls(array, nameof(array));
        }

        public void Test(Class1 value, int[] array)
        {
            Class1 c = Guard.NotNull(value, nameof(value), "test");
            IEnumerable<int> a = Guard.NotNullOrEmpty(array, nameof(array));
        }
    }
}
