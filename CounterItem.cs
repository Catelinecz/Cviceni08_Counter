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
        public ICounterItem Predecessor { get; set; }

        public abstract override string ToString();

        public static string GetCounterString(ICounterItem root)
        {
            string result = root.ToString();

            if (root.Predecessor != null)
            {
                result = result.Insert(0, CounterItem.GetCounterString(root.Predecessor));
            }

            return result;
        }
        public static ICounterItem GetRoot(string input)
        {
            var splittedValues = Regex.Split(input, @"\D+").ToList();
            splittedValues.RemoveAll(string.IsNullOrEmpty);
            List<CounterValueItem> values = splittedValues.Select(x => new CounterValueItem(int.Parse(x))).ToList();

            var splittedSeparators = Regex.Split(input, @"\d+").ToList();
            splittedSeparators.RemoveAll(string.IsNullOrEmpty);
            List<CounterSeparatorItem> separators = splittedSeparators.Select(x => new CounterSeparatorItem(x)).ToList();

            List<CounterItem> items = new List<CounterItem>();

            if (char.IsNumber(input[0]))
            {
                items.AddRange(values);
                for (int i = 0; i < separators.Count; i++)
                {
                    int index = (i + 1) * 2 - 1;
                    if (index >= items.Count)
                    {
                        items.Add(separators[i]);
                    }
                    else
                    {
                        items.Insert(index, separators[i]);
                    }
                }
            }
            else
            {
                items.AddRange(separators);
                for (int i = 0; i < values.Count; i++)
                {
                    int index = (i + 1) * 2 - 1;
                    if (index >= items.Count)
                    {
                        items.Add(values[i]);
                    }
                    else
                    {
                        items.Insert(index, values[i]);
                    }
                }
            }

            for (int i = items.Count - 1; i > 0; i--)
            {
                items[i].Predecessor = items[i - 1];
            }

            return items.Last();
        }
    }
}
