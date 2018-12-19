using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace @object
{
    class Program
    {
        static void Main(string[] args)
        {
            Print(1, 2);
            Print("a", 'b');
            Print(1, "a");
            Print(true, "a", 1);
            Console.ReadKey();
        }

        public static void Print(params object[] obj)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                if (i > 0)
                    Console.Write(", ");
                Console.Write(obj[i]);
            }
            Console.WriteLine();
        }
    }
}
