using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace tom.GameGL
{
    public class Game
    {
        public static GameObject getBlankGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, tom.Properties.Resources.sample);
            return blankGameObject;
        }

        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = tom.Properties.Resources.sample;
            if (displayCharacter == '|')
            {
                img = tom.Properties.Resources.verticalLine;
            }

            if (displayCharacter == '_')
            {
                img = tom.Properties.Resources.horizontalLine;
            }

            if (displayCharacter == 'T' || displayCharacter == 't')
            {
                img = tom.Properties.Resources.playerShip2_red;
            }

            if (displayCharacter == '@')
            {
                img = tom.Properties.Resources.reward;
            }

            if (displayCharacter == '-')
            {
                img = tom.Properties.Resources.centralLine__2_;
            }

            if (displayCharacter == 'G')
            {
                img = tom.Properties.Resources.turtle;
            }

            if (displayCharacter == 'g')
            {
                img = tom.Properties.Resources.cheeta;
            }

            if (displayCharacter == 'b')
            {
                img = tom.Properties.Resources.bouncy;
            }

            if (displayCharacter == 'f')
            {
                img = tom.Properties.Resources.fire;
            }
            return img;
        }

        public static GameObject getLine()
        {
            GameObject line = new GameObject(GameObjectType.LINE, tom.Properties.Resources.centralLine__2_);
            return line;
        }

        public static GameObject getReward()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.REWARD, tom.Properties.Resources.reward);
            return blankGameObject;
        }
    }
}
