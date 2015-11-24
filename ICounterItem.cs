using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni08_Counter
{
    public interface ICounterItem
    {
        void Increase();
        void Reset();

        ICounterItem Predecessor { get; }
    }
}
