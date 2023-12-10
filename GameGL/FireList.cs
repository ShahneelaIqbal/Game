using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tom.GameGL
{
    public abstract class FireList : GameObject
    {
        GameGrid gameGrid;
        GameCell CurrentCell;
        GameDirection currentDirection;

        public GameDirection CurrentDirection { get => currentDirection; set => currentDirection = value; }
        public GameGrid GameGrid { get => gameGrid; set => gameGrid = value; }
        public GameCell CurrentCell1 { get => CurrentCell; set => CurrentCell = value; }

        public FireList(char displayCharacter, GameCell startCell) : base(GameObjectType.FIRE, displayCharacter)
        {
            this.CurrentCell = startCell;
        }

        public FireList(Image image, GameCell startCell) : base(GameObjectType.FIRE, image)
        {
            this.CurrentCell = startCell;
        }

        public void RemoveCurrentFire(GameCell currentCell)
        {
            Form1.fireLists.Clear();
        }

        public abstract GameCell FireMove();
    }
}
