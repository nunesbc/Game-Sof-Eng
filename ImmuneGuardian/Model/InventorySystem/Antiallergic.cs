using ImmuneGuardian.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmuneGuardian.Model
{
    internal class Antiallergic : ICollectibleItem
    {
        private int power = 20;
        public string Name { get; } = "Antiallergic";

        public int Use()
        {
            return power;
        }
    }
}
