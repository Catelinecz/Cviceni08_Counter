using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni08_Counter
{
    class CounterSeparatorItem : CounterItem
    {
        public string Value { get; }

        public CounterSeparatorItem(string value, ICounterItem predecessor = null)
        {
            this.Value = value;
            this.Predecessor = predecessor;
        }

        public override void Increase()
        {
            this.Predecessor?.Increase();
        }

        public override void Reset()
        {
            this.Predecessor?.Reset();
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
