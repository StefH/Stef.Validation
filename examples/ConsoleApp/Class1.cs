using System.Collections.Generic;
using Stef.Validation;

namespace ConsoleApp
{
    internal class Class1
    {
        public Class1(string strValue)
        {
            string s = Guard.NotNullOrEmpty(strValue, nameof(strValue));
        }

        public Class1(int intValue, string strValue)
        {
            int i = Guard.Condition(intValue, v => v > 0, nameof(intValue));
            string s = Guard.NotNullOrWhiteSpace(strValue, nameof(strValue));
        }

        public Class1(Class1 value)
        {
            Class1 c = Guard.NotNull(value, nameof(value));
        }

        public Class1(Class1?[] array)
        {
            IEnumerable<Class1> a = Guard.HasNoNulls(array, nameof(array));
        }

        public Class1(Class1 value, int[] array)
        {
            Class1 c = Guard.NotNull(value, nameof(value), "test");
            IEnumerable<int> a = Guard.NotNullOrEmpty(array, nameof(array));
        }
    }
}
