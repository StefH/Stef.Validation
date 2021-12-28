using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "";
            s = null;

            try
            {
                new Class1().Test(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("\r\n------------------------------------------------------\r\n");

            try
            {
                new Class1().TestNotNullOrEmpty("");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}