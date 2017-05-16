using Hunter_v2.Components.Interfaces;
using Hunter_v2.Components.PositionComponent;
using Hunter_v2.Components.SizeComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.GameObjects
{
    static class Collision
    {
        public static bool collisionCheck(IPositionComponent p1, ISizeComponent s1, 
                            IPositionComponent p2, ISizeComponent s2)
        {
            bool collision = false;

            if ((p1.posX <= p2.posX + s2.width)
                && (p1.posX + s1.width >= p2.posX)
                && (p1.posY <= p2.posY + s2.height)
                && (p1.posY + s1.height >= p2.posY))
            {
                collision = true;
            }

            return collision;
        }
    }
}
