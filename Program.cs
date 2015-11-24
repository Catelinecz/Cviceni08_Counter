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
            Console.WriteLine("Enter your clock parameters in format like '24:60:60.100' for digital clock counter or for example '2 2 2 2' for binary counter (numbers mean maximum values): ");
            string input = Console.ReadLine();

            Console.Write("\nEnter the speed of counter in milliseconds: ");
            int speed = int.Parse(Console.ReadLine());

            ICounterItem root = CounterItem.GetRoot(input);

            while (true)
            {
                Console.WriteLine(CounterItem.GetCounterString(root));
                root.Increase();
                Thread.Sleep(speed);
            }
        }
    }
}
