using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.GameObjects
{
    class Tile
    {
        public const int TILE_SIZE = 20;

        public Vector2 position { get; set; }
        public TileImg flyweightTile { get; set; }
        public int tiletype { get; set; }

        //MISSING - SOME LOGIC TO LINK TILES TO TILEIMG

        public Tile(Vector2 position, TileImg flyweightTile, int tiletype)
        {
            this.position = position;
            this.flyweightTile = flyweightTile;
            this.tiletype = tiletype;
        }

        public int getTileSize()
        {
            return TILE_SIZE;
        }

        public void draw()
        {
            flyweightTile.draw(position);
        }
    }
}
