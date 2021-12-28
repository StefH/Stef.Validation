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
            string s = Guard.NotNullOrEmpty(strValue);
        }

        public void TestString2(string? strValue)
        {
            string s = Guard.NotNullOrEmpty(strValue);
        }

        public void Test(int intValue, string strValue)
        {
            int i = Guard.Condition(intValue, v => v > 0, nameof(intValue));
            string s = Guard.NotNullOrWhiteSpace(strValue);
        }

        public void Test(string strValue)
        {
            var s = Guard.NotNull(strValue);
        }

        public void TestNotNullOrEmpty(string strValue)
        {
            var s = Guard.NotNullOrEmpty(strValue);
        }

        public void Test(Class1 value)
        {
            Class1 c = Guard.NotNull(value);
        }

        public void Test(Class1[] array)
        {
            IEnumerable<Class1> a = Guard.HasNoNulls(array);
        }

        public void Test(int[] array)
        {
            IEnumerable<int> a = Guard.HasNoNulls(array);
        }

        public void Test(Class1 value, int[] array)
        {
            Class1 c = Guard.NotNull(value, nameof(value), "test");
            IEnumerable<int> a = Guard.NotNullOrEmpty(array);
        }
    }
}
