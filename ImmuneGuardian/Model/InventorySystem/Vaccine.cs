using ImmuneGuardian.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmuneGuardian.Model.InventorySystem
{
    internal class Vaccine : ICollectibleItem
    {
        private int power = 50;
        public string Name { get; } = "Antibiotic";

        public int Use()
        {
            return power;
        }
    }
}
