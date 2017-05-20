using Hunter_v2.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.DirectionComponents
{
    class DirectionComponent : IDirectionComponent
    {
        public int currentDirection { get; set; }
        public enum directions { UP, LEFT, DOWN, RIGHT };

        public DirectionComponent()
        {
            currentDirection = (int)directions.UP;
        }

        public DirectionComponent(int direction)
        {
            if (direction >= 0 && direction <= 4)
            {
                currentDirection = direction;
            }
        }

        //MISSING - can later add sprite changes here
        public void faceUp()
        {
            currentDirection = (int)directions.UP;
        }

        public void faceLeft()
        {
            currentDirection = (int)directions.LEFT;
        }

        public void faceDown()
        {
            currentDirection = (int)directions.DOWN;
        }

        public void faceRight()
        {
            currentDirection = (int)directions.RIGHT;
        }
    }
}
