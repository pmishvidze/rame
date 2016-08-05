using HomeWork.NET.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    int x = Int32.Parse(Console.ReadLine());
                    NumberHandler.NumberInWords(x);
                }
                catch (Exception)
                {
                    Console.WriteLine("ricxvi arasworadaa shetanili");
                }
            }
        }
    }
}
