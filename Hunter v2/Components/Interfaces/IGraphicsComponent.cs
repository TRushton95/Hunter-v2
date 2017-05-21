using Hunter_v2.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.Interfaces
{
    interface IGraphicsComponent
    {
        SpriteFont font { get; set; }
        Texture2D texture { get; set; }
        SpriteBatch spriteBatch { get; set; }

        void draw(Vector2 position);
        void draw(Vector2 position, string namePlate);
    }
}
