﻿using Hunter_v2.Components.Interfaces;
using Hunter_v2.Components.SizeComponents;
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

        public ISizeComponent sizeComponent { get; set; }
        public IPositionComponent positionComponent { get; set; }
        public ICollisionComponent collisionComponent { get; set; }
        public TileImg flyweightTile { get; set; }
        public int tiletype { get; set; }

        //BUG - LOGIC OF LINKING TILETYPE TO FLYWEIGHTTILE DOESNT SEEM QUITE RIGHT HERE, NOT SURE WHY YET

        public Tile(ISizeComponent sizeComponent, IPositionComponent positionComponent, ICollisionComponent collisionComponent, TileImg flyweightTile, int tiletype)
        {
            this.sizeComponent = sizeComponent;
            this.positionComponent = positionComponent;
            this.collisionComponent = collisionComponent;
            this.flyweightTile = flyweightTile;
            this.tiletype = tiletype;
        }

        public int getTileSize()
        {
            return TILE_SIZE;
        }

        public void draw(Vector2 offset)
        {
            flyweightTile.draw(positionComponent.position() - offset);
        }
    }
}
