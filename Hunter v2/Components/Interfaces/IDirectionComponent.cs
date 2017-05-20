using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.Interfaces
{
    interface IDirectionComponent
    {
        int currentDirection { get; set; }

        void faceUp();

        void faceLeft();

        void faceDown();

        void faceRight();
    }
}
