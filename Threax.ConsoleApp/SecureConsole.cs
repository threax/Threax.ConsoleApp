using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.ConsoleApp
{
    public class SecureConsole
    {
        /// <summary>
        /// Gets the console password.
        /// </summary>
        /// <remarks>
        /// Thanks to huobazi from https://gist.github.com/huobazi/1039424 for this code.
        /// </remarks>
        /// <returns></returns>
        public static string ReadLineMasked()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.Write("\b\0\b");
                        sb.Length--;
                    }
                }

                if (!char.IsControl(cki.KeyChar))
                {
                    Console.Write('*');
                    sb.Append(cki.KeyChar);
                }
            }

            return sb.ToString();
        }
    }
}
