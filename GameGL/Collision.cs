using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace tom.GameGL
{
    public static class Collision
    {
        public static bool CheckCollision(GameCell cell)
        {
            if (cell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
            {
                return true;
            }

            return false;
        }
    }
}
