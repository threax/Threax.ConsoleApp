using System;
using Threax.ConsoleApp;

namespace KeyReadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter something");
            var password = SecureConsole.ReadLineMasked();
            Console.WriteLine($"You entered: {password}");
        }
    }
}
