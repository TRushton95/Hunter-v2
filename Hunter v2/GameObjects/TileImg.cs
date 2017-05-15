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
        Texture2D texture { get; set; }
        int tiletype { get; set; }

        public TileImg(Texture2D texture, int tiletype)
        {
            this.texture = texture;
            this.tiletype = tiletype;
        }
    }
}
