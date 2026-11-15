using ImmuneGuardian.Interfaces;
using ImmuneGuardian.Model.InventorySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmuneGuardian.Model
{
    internal class Player
    {
        private int _level = 1;
        private int _power = 1;
        public Inventory inventory; 
        public Cell Character { get; private set; }
        public ICellState State { get; private set; }
        public Player(Cell initialCharacter)
        {
            Character = initialCharacter;
        }
        public void Jump() { }
        public void SetCell(Cell newCell)
        {
            Character = newCell;
        }
        public void SetCellState(ICellState state)
        {
            State = state;
        }
        public void Attack()
        {
            Character.Attack();
        }
    }
}
