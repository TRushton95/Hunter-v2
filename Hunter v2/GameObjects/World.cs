using Hunter_v2.Components.PositionComponent;
using Hunter_v2.Components.SizeComponents;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.GameObjects
{
    class World
    {
        public Vector2 mapSize { get; set; }
        public TileImg[] tileSet { get; set; }
        public int[,] mapSource { get; set; }
        public List<GameActor> gameActors { get; set; }
        public Tile[,] map { get; set; }

        public World(Vector2 mapSize, TileImg[] tileSet, int[,] mapSource, List<GameActor> gameActors)
        {
            this.mapSize = mapSize;
            this.tileSet = tileSet;
            this.mapSource = mapSource;
            map = loadMap();

            this.gameActors = gameActors;
        }


        private Tile[,] loadMap()
        {
            Tile[,] map = null;

            map = new Tile[(int)mapSize.X, (int)mapSize.Y];
            //copy the mapSource to the map to know what tiletypes belong where
            //also assign appropriate positionComponents
            for (int i = 0; i < mapSize.X; i++)
            {
                for (int j = 0; j < mapSize.Y; j++)
                {
                    map[i, j].tiletype = mapSource[i, j];
                    map[i, j].positionComponent = new PositionComponent(i*50, j*50);
                }
            }

            //fill out the flyweight tile using the mapped tiletype and the template tileImgs
            //also assign appropriate positionComponents
            SizeComponent sizeComponent = new SizeComponent(50, 50);
            foreach (Tile t in map)
            {
                t.flyweightTile = matchTileImg(tileSet, t);
                t.sizeComponent = sizeComponent;
            }

            return map;
        }

        private TileImg matchTileImg(TileImg[] tileSet, Tile t)
        {
            TileImg matchingTileImg;
            int tileTypeRequired = t.tiletype;
            foreach (TileImg i in tileSet)
            {
                if (tileTypeRequired == i.tiletype)
                {
                    matchingTileImg = i;
                    return matchingTileImg;
                }
            }

            return null;
        }

    }
}
