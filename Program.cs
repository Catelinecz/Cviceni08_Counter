using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Cviceni08_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            ICounterItem root = CounterItem.GetRoot(input);

            while (true)
            {
                Console.WriteLine(CounterItem.GetCounterString(root));
                root.Increase();
                Thread.Sleep(1000);
            }
        }
    }
}
