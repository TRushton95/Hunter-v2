using Hunter_v2.Components.Interfaces;
using Hunter_v2.Components.PositionComponents;
using Hunter_v2.Components.SizeComponents;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.GameObjects
{
    class World : IObserver<GameActor>
    {
        public Vector2 mapSize { get; set; }
        public TileImg[] tileSet { get; set; }
        public int[,] mapSource { get; set; }
        public List<GameActor> gameActors { get; set; }
        public Tile[,] map { get; set; }
        public Camera camera { get; set; }

        List<IDisposable> cancelObservation;

        public World(Vector2 mapSize, TileImg[] tileSet, int[,] mapSource, List<GameActor> gameActors)
        {
            this.mapSize = mapSize; //can probably be determined by tileSet?
            this.tileSet = tileSet;
            this.mapSource = mapSource;
            map = loadMap();

            this.gameActors = gameActors;
            //MISSING - proper logic to assign width and height of window and camera
            this.camera = new Camera(0, 0, 800, 480 ,10000, 10000);
            this.camera.setTarget(this.gameActors[0]);

            cancelObservation = new List<IDisposable>();
            foreach (GameActor g in gameActors)
            {
                cancelObservation.Add(g.weaponComponent.Subscribe(this));
            }
        }


        private Tile[,] loadMap()
        {
            Tile[,] map = new Tile[(int)mapSize.X, (int)mapSize.Y];

            SizeComponent sizeComponent = new SizeComponent(50, 50);


            for (int i = 0; i < mapSize.X; i++)
            {
                for (int j = 0; j < mapSize.Y; j++)
                {
                    map[i, j] = new Tile(sizeComponent, new PositionComponent(i*50,j*50), matchTileImg(tileSet, mapSource[i,j]), mapSource[i, j]);
                }
            }

            return map;
        }

        private TileImg matchTileImg(TileImg[] tileSet, int tileTypeRequired)
        {
            TileImg matchingTileImg;
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

        public void update()
        {
            //UNSURE - for some reason adding ToList() removes a null exception I do not yet understand
            foreach (GameActor a in gameActors.ToList())
            {
                a.update();
            }
            camera.update();
        }

        public void draw()
        {

            foreach (Tile t in map)
            {
                if (Collision.collisionCheck(t.positionComponent, t.sizeComponent,
                    camera.positionComponent, camera.sizeComponent))
                {
                    t.draw();
                }
            }

            foreach (GameActor a in gameActors)
            {
                a.draw();
            }
        }

        //MISSING
        public void OnNext(GameActor gameActor)
        {
            gameActors.Add(gameActor);
            cancelObservation.Add(gameActor.weaponComponent.Subscribe(this));
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            
        }
    }
}
