using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmuneGuardian.Model
{
    internal class Lymphocytes : Cell
    {
        public override void Attack()
        {
            Phagocytosis();
        }

        private void Phagocytosis() { }
    }
}
