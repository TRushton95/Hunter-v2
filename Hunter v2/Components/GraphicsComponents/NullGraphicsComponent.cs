using Hunter_v2.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hunter_v2.Components.GraphicsComponents
{
    class NullGraphicsComponent : IGraphicsComponent
    {
        public Texture2D texture { get; set; }
        public SpriteBatch spriteBatch { get; set; }

        public NullGraphicsComponent()
        {
            texture = null;
            spriteBatch = null;
        }

        public void draw(Vector2 position)
        {
            
        }
    }
}
