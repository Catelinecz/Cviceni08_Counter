using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni08_Counter
{
    internal class CounterValueItem : CounterItem
    {
        public int Value { get; private set; }
        public int? MaxValue { get; }
        public ICounterItem Predecessor { get; set; }

        public CounterValueItem(int value, int maxValue, ICounterItem predecessor = null)
        {
            this.MaxValue = maxValue;
            this.Predecessor = predecessor;
            this.Value = value;
        }

        public CounterValueItem(int maxValue, ICounterItem predecessor = null)
        {
            this.MaxValue = maxValue;
            this.Predecessor = predecessor;
            this.Value = 0;
        }

        public override void Increase()
        {
            this.Value = this.Value == this.MaxValue.Value ? 0 : this.Value + 1;
            this.Predecessor?.Increase();
        }

        public override void Reset()
        {
            this.Value = 0;
            this.Predecessor?.Reset();
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
