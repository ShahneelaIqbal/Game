using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace tom.GameGL
{
    public class GameObject
    {
        char displayCharacter;
        GameObjectType gameObjectType;
        GameCell currentCell;
        Image image;

        public char DisplayCharacter { get => displayCharacter; set => displayCharacter = value; }
        public GameObjectType GameObjectType { get => gameObjectType; set => gameObjectType = value; }
        public Image Image { get => image; set => image = value; }

        public GameObject(GameObjectType type, Image image)
        {
            this.gameObjectType = type;
            this.Image = image;
        }
        public GameObject(GameObjectType type, char displayCharacter)
        {
            this.gameObjectType = type;
            this.displayCharacter = displayCharacter;
        }

        public static GameObjectType getGameObjectType(char displayCharacter)
        {

            if (displayCharacter == '|' || displayCharacter == '_')
            {
                return GameObjectType.WALL;
            }

            if (displayCharacter == '@')
            {
                return GameObjectType.REWARD;
            }

            if (displayCharacter == '-')
            {
                return GameObjectType.LINE;
            }

            if (displayCharacter == 'G')
            {
                return GameObjectType.ENEMY;
            }

            if (displayCharacter == 'g')
            {
                return GameObjectType.ENEMY;
            }
            return GameObjectType.NONE;
        }

        public GameCell CurrentCell
        {
            get => currentCell;
            set
            {
                currentCell = value;
                currentCell.setGameObject(this);
            }
        }
    }
}
