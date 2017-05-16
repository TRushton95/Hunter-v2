using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.SizeComponents
{
    interface ISizeComponent
    {
        int width { get; set; }
        int height { get; set; }

        Vector2 size();
    }
}
