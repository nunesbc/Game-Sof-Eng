using ImmuneGuardian.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmuneGuardian.Model.States
{
    internal class NormalState : ICellState
    {
        public string Name { get; } = "Normal";
    }
}
