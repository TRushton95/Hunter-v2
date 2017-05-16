using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.SizeComponents
{
    class NullSizeComponent : ISizeComponent
    {
        public int width { get; set; }
        public int height { get; set; }

        public NullSizeComponent()
        {
            this.width = -1;
            this.height = -1;
        }

        public Vector2 size()
        {
            return new Vector2(width, height);
        }
    }
}
