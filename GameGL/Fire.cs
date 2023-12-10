using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tom.GameGL
{
    public class Fire : FireList
    {
        private int lineCount = 0;
        private GameCell initialCell;
        public Fire(Image image, GameCell startCell) : base(image, startCell)
        {
            this.CurrentCell = startCell;
            this.initialCell = startCell;
        } 

        public override GameCell FireMove()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(GameDirection.Up);

            if(nextCell == currentCell && nextCell.CurrentGameObject.GameObjectType == GameObjectType.FIRE)
            {
                this.CurrentCell = nextCell;
                currentCell.setGameObject(Game.getBlankGameObject());
            }
            else if (nextCell == currentCell && nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
            {
                currentCell.setGameObject(Game.getBlankGameObject());
                this.CurrentCell = this.initialCell;
                nextCell = this.initialCell.nextCell(GameDirection.Down);

                if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
                {
                    Form1.increaseScore();
                    this.CurrentCell = nextCell;
                    currentCell.setGameObject(Game.getBlankGameObject());
                }
            }
            else if (currentCell != nextCell)
            {
                if(nextCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
                {
                    Form1.increaseScore();
                    this.CurrentCell = nextCell;
                    currentCell.setGameObject(Game.getBlankGameObject());
                }
                else if(nextCell.CurrentGameObject.GameObjectType == GameObjectType.LINE)
                {
                    nextCell.setGameObject(Game.getLine());
                    this.CurrentCell = nextCell;
                    currentCell.setGameObject(Game.getBlankGameObject());
                    lineCount = lineCount + 1;
                }
                else if (lineCount > 0)
                {
                    nextCell.setGameObject(Game.getBlankGameObject());
                    this.CurrentCell = nextCell;
                    currentCell.setGameObject(Game.getLine());
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
