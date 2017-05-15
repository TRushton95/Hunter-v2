using Hunter_v2.Components.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.GameObjects
{
    class TileImg
    {
        public int tiletype { get; set; }
        public IGraphicsComponent graphicsComponent { get; set; }

        public TileImg(int tiletype, IGraphicsComponent graphicsComponent)
        {
            this.tiletype = tiletype;
            this.graphicsComponent = graphicsComponent;
        }
    }
}
