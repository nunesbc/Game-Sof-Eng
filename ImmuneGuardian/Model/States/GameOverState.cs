using ImmuneGuardian.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmuneGuardian.Model.States
{
    internal class GameOverState : ICellState
    {
        public string Name { get; } = "Game over";
    }
}
