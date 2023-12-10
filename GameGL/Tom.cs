using System.Drawing;

namespace tom.GameGL
{
    public class Tom : GameObject
    {
        private int lineCount = 0;
        private int rewardCount = 0;
        public Tom(Image image, GameCell startCell) : base(GameObjectType.PLAYER, image)
        {
            this.CurrentCell = startCell;
        }

        public void move(GameDirection direction)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            if (nextCell != currentCell && nextCell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                if (Collision.CheckCollision(nextCell))
                {
                    if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
                    {

                        Form1.DecreaseHealth();
                        nextCell.setGameObject(Game.getBlankGameObject());
                        return; 
                    }
                    else if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.LINE)
                    {
                        nextCell.setGameObject(Game.getLine());
                        this.CurrentCell = nextCell;
                        currentCell.setGameObject(Game.getBlankGameObject());
                        lineCount = lineCount + 1;
                    }
                    else if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
                    {
                        nextCell.setGameObject(Game.getReward());
                        this.CurrentCell = nextCell;
                        currentCell.setGameObject(Game.getBlankGameObject());
                        rewardCount = rewardCount + 1;
                    }
                    else if (rewardCount == 1)
                    {
                        nextCell.setGameObject(Game.getBlankGameObject());
                        this.CurrentCell = nextCell;
                        currentCell.setGameObject(Game.getReward());
                        rewardCount = 0;
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
                else if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.LINE)
                {
                    nextCell.setGameObject(Game.getLine());
                    this.CurrentCell = nextCell;
                    currentCell.setGameObject(Game.getBlankGameObject());
                    lineCount = lineCount + 1;
                }
                else if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
                {
                    nextCell.setGameObject(Game.getReward());
                    this.CurrentCell = nextCell;
                    currentCell.setGameObject(Game.getBlankGameObject());
                    rewardCount = rewardCount + 1;
                }
                else if(rewardCount == 1)
                {
                    nextCell.setGameObject(Game.getBlankGameObject());
                    this.CurrentCell = nextCell;
                    currentCell.setGameObject(Game.getReward());
                    rewardCount = 0;
                }
                else if (lineCount > 0 )
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
        }

        public void fire(GameDirection direction)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            if (nextCell != currentCell && nextCell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                if (Collision.CheckCollision(nextCell))
                {
                    if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
                    {

                        Form1.DecreaseHealth();
                        nextCell.setGameObject(Game.getBlankGameObject());
                        return;
                    }
                    else if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.LINE)
                    {
                        nextCell.setGameObject(Game.getLine());
                        this.CurrentCell = nextCell;
                        currentCell.setGameObject(Game.getBlankGameObject());
                        lineCount = lineCount + 1;
                    }
                    else if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
                    {
                        nextCell.setGameObject(Game.getReward());
                        this.CurrentCell = nextCell;
                        currentCell.setGameObject(Game.getBlankGameObject());
                        rewardCount = rewardCount + 1;
                    }
                    else if (rewardCount == 1)
                    {
                        nextCell.setGameObject(Game.getBlankGameObject());
                        this.CurrentCell = nextCell;
                        currentCell.setGameObject(Game.getReward());
                        rewardCount = 0;
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
                else if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.LINE)
                {
                    nextCell.setGameObject(Game.getLine());
                    this.CurrentCell = nextCell;
                    currentCell.setGameObject(Game.getBlankGameObject());
                    lineCount = lineCount + 1;
                }
                else if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
                {
                    nextCell.setGameObject(Game.getReward());
                    this.CurrentCell = nextCell;
                    currentCell.setGameObject(Game.getBlankGameObject());
                    rewardCount = rewardCount + 1;
                }
                else if (rewardCount == 1)
                {
                    nextCell.setGameObject(Game.getBlankGameObject());
                    this.CurrentCell = nextCell;
                    currentCell.setGameObject(Game.getReward());
                    rewardCount = 0;
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
        }
    }
}
