using Hunter_v2.Components.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.MovementComponents
{
    class MovementComponent : IMovementComponent
    {
        public float velX { get; set; }
        public float velY { get; set; }

        public MovementComponent()
        {
            this.velX = 0;
            this.velY = 0;
        }

        public void move(IPositionComponent position)
        {
            position.posX += velX;
            position.posY += velY;
        }
    }
}
