using Hunter_v2.Components.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.PositionComponent
{
    //THIS WHOLE COMPONENT NEEDS ADDRESSING
    class NullPositionComponent : IPositionComponent
    {
        public float posX { get; set; }
        public float posY { get; set; }

        public NullPositionComponent()
        {
            posX = -1;
            posY = -1;
        }

        public Vector2 position()
        {
            return new Vector2(posX, posY);
        }
    }
}
