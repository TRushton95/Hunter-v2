using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.SizeComponents
{
    class SizeComponent : ISizeComponent
    {
        public int width { get; set; }
        public int height { get; set; }

        public SizeComponent(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public Vector2 size()
        {
            return new Vector2(width, height);
        }
    }
}
