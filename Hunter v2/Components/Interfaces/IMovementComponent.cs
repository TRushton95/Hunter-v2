using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.Interfaces
{
    interface IMovementComponent
    {
        float velX { get; set; }

        float velY { get; set; }

        void move(IPositionComponent position);
    }
}
