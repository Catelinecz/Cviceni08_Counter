using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cviceni08_Counter
{
    public abstract class CounterItem : ICounterItem
    {
        public abstract void Increase();
        public abstract void Reset();
        public ICounterItem Predecessor { get; }

        public static string GetCounterString(ICounterItem root)
        {
            string result = root.ToString();

            if (root.Predecessor != null)
            {
                result += root.Predecessor.ToString();
            }

            return result;
        }

        public static ICounterItem GetFirstItem(ICounterItem item)
        {
            ICounterItem current = item;

            while (current.Predecessor != null)
            {
                current = current.Predecessor;
            }

            return current;
        }

        public static ICounterItem GetRoot(string input)
        {
            List<CounterValueItem> values =
                Regex.Split(input, @"\D+").Select(x => new CounterValueItem(int.Parse(x))).ToList();
            List<CounterSeparatorItem> separators =
                Regex.Split(input, @"\d+").Select(x => new CounterSeparatorItem(x)).ToList();

            List<ICounterItem> items = new List<ICounterItem>();

            if (char.IsNumber(input[0]))
            {
                items.AddRange(values);
                for (int i = 0; i < separators.Count; i++)
                {
                    int index = (i + 1)*2 - 1;
                    items.Insert(index, separators[i]);
                }
            }
            else
            {
                items.AddRange(separators);
                for (int i = 0; i < values.Count; i++)
                {
                    int index = (i + 1)*2 - 1;
                    items.Insert(index, values[i]);
                }
            }
        }

        public abstract override string ToString();
    }
}
