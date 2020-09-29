using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    class ConsoleHelper
    {

        public static int ReadInt()
        {
            var value = Console.ReadLine();

            if (int.TryParse(value, out var intValue))
            {
                return intValue;
            }

            return ReadInt();
        }


        public static DateTime ReadDate()
        {
            var day = ReadInt();
            var month = ReadInt();
            var year = ReadInt();

            // validation

            return new DateTime(year, month, day);

        }
    }
}
