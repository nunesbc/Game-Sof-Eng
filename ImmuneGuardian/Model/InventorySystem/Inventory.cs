using ImmuneGuardian.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmuneGuardian.Model.InventorySystem
{
    internal class Inventory
    {
        List<ICollectibleItem> itens = new List<ICollectibleItem>();

        public void Add(ICollectibleItem item)
        {
            if (item != null)
            {
                itens.Add(item);
            }
        }

        public int Use(ICollectibleItem item)
        {
            if (item == null || !itens.Contains(item))
            {
                return 0;
            }
            this.Delete(item);
            return item.Use();
        }
        private void Delete(ICollectibleItem item)
        {
            itens.Remove(item);
        }
    }
}
