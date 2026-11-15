using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmuneGuardian.Interfaces
{
    internal interface ICollectibleItem
    {
        public string Name { get; }
        public int Use();
    }
}
