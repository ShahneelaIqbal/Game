using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace tom.GameGL
{
    public class Cheeta : Ghost
    {
        private GameCell initialCell;
        private int lineCount = 0;
        public Cheeta(Image image, GameCell startCell) : base(image, startCell)
        {
            this.CurrentCell = startCell;
            this.initialCell = startCell;
        }

        public override GameCell Move()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(GameDirection.Right);  
            if ((nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL && nextCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER) || nextCell == currentCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());
                this.CurrentCell = this.initialCell;
                nextCell = this.initialCell.nextCell(GameDirection.Left);
            }
            else if (currentCell != nextCell)
            {
                if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
                {
                    nextCell.setGameObject(Game.getReward());
                    this.CurrentCell = nextCell;
                    currentCell.setGameObject(Game.getBlankGameObject());
                    lineCount = lineCount + 1;
                }
                else if (lineCount == 1)
                {
                    nextCell.setGameObject(Game.getBlankGameObject());
                    this.CurrentCell = nextCell;
                    currentCell.setGameObject(Game.getReward());
                    lineCount = 0;
                }
                else
                {
                    this.CurrentCell = nextCell;
                    currentCell.setGameObject(Game.getBlankGameObject());
                }
               
            }
            return nextCell;
        }
    }
}
