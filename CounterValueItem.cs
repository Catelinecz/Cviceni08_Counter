﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni08_Counter
{
    internal class CounterValueItem : CounterItem
    {
        public int Value { get; private set; }
        public int MaxValue { get; }

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
            if (this.Value == this.MaxValue - 1)
            {
                this.Value = 0;
                this.Predecessor?.Increase();
            }
            else
            {
                this.Value++;
            }
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
