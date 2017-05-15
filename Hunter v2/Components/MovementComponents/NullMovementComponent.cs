using Hunter_v2.Components.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.movementComponents
{
    class NullMovementComponent : IMovementComponent
    {
        public float velX { get; set; }
        public float velY { get; set; }

        public NullMovementComponent()
        {
            velX = 0;
            velY = 0;
        }

        public void move(IPositionComponent position)
        {

        }
    }
}
