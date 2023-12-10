using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace tom.GameGL
{
    public abstract class Ghost : GameObject
    {
        GameGrid gameGrid;
        GameCell CurrentCell;
        GameDirection currentDirection;

        public GameDirection CurrentDirection { get => currentDirection; set => currentDirection = value; }
        public GameGrid GameGrid { get => gameGrid; set => gameGrid = value; }
        public GameCell CurrentCell1 { get => CurrentCell; set => CurrentCell = value; }

        public Ghost(char displayCharacter, GameCell startCell) : base(GameObjectType.ENEMY, displayCharacter)
        {
            this.CurrentCell = startCell;
        }

        public Ghost(Image image, GameCell startCell) : base(GameObjectType.ENEMY, image)
        {
            this.CurrentCell = startCell;
        }

        public abstract GameCell Move();
    }
}
