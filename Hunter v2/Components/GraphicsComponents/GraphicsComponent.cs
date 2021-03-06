﻿using Hunter_v2.Components.Interfaces;
using Hunter_v2.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components
{
    class GraphicsComponent : IGraphicsComponent
    {
        public Texture2D texture { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public SpriteFont font { get; set; }

        public GraphicsComponent(Texture2D texture, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
        }

        public GraphicsComponent(Texture2D texture, SpriteBatch spriteBatch, SpriteFont font)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            this.font = font;
        }

        public void draw(Vector2 position)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }

        public void draw(Vector2 position, string namePlate)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, namePlate, new Vector2(position.X, position.Y - 20), Color.Black);
        }
    }
}
