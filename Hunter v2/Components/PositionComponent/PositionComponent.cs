using Hunter_v2.Components.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.PositionComponent
{
    class PositionComponent : IPositionComponent
    {
        public float posX { get; set; }
        public float posY { get; set; }

        //REMOVE - NO NEED FOR AN EMPTY CONSTRUCTOR? FIX LOGIC LATER
        public PositionComponent()
        {
        }

        public PositionComponent(float posX, float posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public Vector2 position()
        {
            return new Vector2(posX, posY);
        }
    }
}
