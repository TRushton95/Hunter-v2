using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.Interfaces
{
    interface IPositionComponent
    {
        float posX { get; set; }
        float posY { get; set; }

        Vector2 position();
    }
}
