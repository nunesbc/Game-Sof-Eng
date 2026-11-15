using ImmuneGuardian.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ImmuneGuardian.Model.InventorySystem
{
    internal class Antibiotic : ICollectibleItem
    {
        private int power = 10;
        public string Name { get; } = "Antibiotic";

        public int Use()
        {
            return power;
        }
    }
}
