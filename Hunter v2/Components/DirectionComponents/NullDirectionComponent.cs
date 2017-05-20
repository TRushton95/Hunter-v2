using Hunter_v2.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.DirectionComponents
{
    class NullDirectionComponent : IDirectionComponent
    {
        public int currentDirection { get; set; }

        public NullDirectionComponent()
        {
            currentDirection = -1;
        }

        public void faceUp()
        {
        }

        public void faceLeft()
        {
        }

        public void faceDown()
        {
        }

        public void faceRight()
        {
        }
    }
}
