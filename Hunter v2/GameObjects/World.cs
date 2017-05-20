﻿using Hunter_v2.Components.CollisionComponents;
using Hunter_v2.Components.CollisionComponents.CollisionActions;
using Hunter_v2.Components.Interfaces;
using Hunter_v2.Components.movementComponents;
using Hunter_v2.Components.MovementComponents;
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
            //MISSING - proper logic to assign width and height of world and camera
            this.camera = new Camera(0, 0, 800, 480 ,1200, 800);
            this.camera.setTarget(this.gameActors[0]);

            cancelObservation = new List<IDisposable>();
            foreach (GameActor g in gameActors)
            {
                cancelObservation.Add(g.weaponComponent.Subscribe(this));
            }
        }

        public void update()
        {
            //UNSURE - for some reason adding ToList() removes a null exception I do not yet understand
            foreach (GameActor gameActor in gameActors.ToList())
            {
                gameActor.update();
                boundaryCheck(gameActor);
            }

            //collision check - avoids duplicate detections
            for (int i = 0; i < gameActors.Count(); i++)
            {
                for (int j = i+1; j < gameActors.Count(); j++)
                {
                    if (i != j)
                    {
                        if (Collision.collisionCheck(gameActors[i].positionComponent, gameActors[i].sizeComponent,
                            gameActors[j].positionComponent, gameActors[j].sizeComponent)) {
                            //logic here
                        }

                    }
                }
            }

            //REMOVE - test to check CollisionActions work
            if (Collision.collisionCheck(gameActors[0].positionComponent, gameActors[0].sizeComponent, map[0,0].positionComponent, map[0,0].sizeComponent))
            {
                //gameActors[0].collisionComponet.RecieveCollisionAction(map[0,0].collisionComponent.SendCollisionAction(), gameActors[0]); //player recieving collisionAction from top-left tile

                resolveCollision(gameActors[0].positionComponent, gameActors[0].movementComponent, gameActors[0].sizeComponent,
                            map[0,0].positionComponent, new NullMovementComponent(), map[0, 0].sizeComponent);
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
                    t.draw(camera.positionComponent.position());
                }
            }

            foreach (GameActor a in gameActors)
            {
                a.draw(camera.positionComponent.position());
            }
        }


        //world building functions
        private Tile[,] loadMap()
        {
            Tile[,] map = new Tile[(int)mapSize.X, (int)mapSize.Y];

            SizeComponent sizeComponent = new SizeComponent(50, 50);


            for (int i = 0; i < mapSize.X; i++)
            {
                for (int j = 0; j < mapSize.Y; j++)
                {
                    //MISSING - proper assignment logic here
                    map[i, j] = new Tile(sizeComponent, new PositionComponent(i * 50, j * 50), new CollisionComponent(new DamageCollisionAction(5)), matchTileImg(tileSet, mapSource[i, j]), mapSource[i, j]);
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

        private void boundaryCheck(GameActor gameActor)
        {
            if (gameActor.positionComponent.posX < 0)
            {
                gameActor.positionComponent.posX = 0;
            }
            if (gameActor.positionComponent.posY < 0)
            {
                gameActor.positionComponent.posY = 0;
            }
            if (gameActor.positionComponent.posX > mapSize.X - gameActor.sizeComponent.width)
            {
                gameActor.positionComponent.posX = mapSize.X - gameActor.sizeComponent.width;
            }
            if (gameActor.positionComponent.posY > mapSize.Y - gameActor.sizeComponent.height)
            {
                gameActor.positionComponent.posY = mapSize.Y - gameActor.sizeComponent.height;
            }
        }

        private void resolveCollision(IPositionComponent p1, IMovementComponent m1, ISizeComponent s1, IPositionComponent p2, IMovementComponent m2, ISizeComponent s2)
        {
            int side = calculateRelativePosition(p1, s1, p2, s2);
            float overlap = 0;

            if (side == 0) //top
            {
                overlap = (p2.posY + s2.height) - p1.posY;
                if (overlap != 0)
                {
                    p1.posY += (overlap / m1.velY + m2.velY) * m1.velY;
                    p2.posY -= (overlap / m1.velY + m2.velY) * m2.velY;
                }
            }
            else if (side == 1) //left
            {
                overlap = (p1.posX + s1.width) - p2.posX;
                if (overlap != 0)
                {
                    p1.posX += (overlap / m1.velX + m2.velX) * m1.velX;
                    p2.posX -= (overlap / m1.velX + m2.velX) * m2.velX;
                }
            }
            else if (side == 2) //bottom
            {
                overlap = (p1.posY + s1.height) - p2.posY;
                if (overlap != 0)
                {
                    p1.posY += (overlap / m1.velY + m2.velY) * m1.velY;
                    p2.posY -= (overlap / m1.velY + m2.velY) * m2.velY;
                }
            }
            else if (side == 3) //right
            {
                overlap = (p2.posX + s2.width) - p1.posX;
                if (overlap != 0)
                {
                    p1.posX += (overlap / m1.velX + m2.velX) * m1.velX;
                    p2.posX -= (overlap / m1.velX + m2.velX) * m2.velX;
                }
            }
        }

        private int calculateRelativePosition(IPositionComponent p1, ISizeComponent s1, IPositionComponent p2, ISizeComponent s2)
        {
            int direction = 0;

            Vector2 center = p1.position() + (s1.size() / 2); //center of p1
            Vector2 a = p2.position() + (new Vector2(0, s2.height));         //bottom-left corner of p2
            Vector2 b = p2.position() + (new Vector2(s2.width, 0));         //top-right corner of p2
            Vector2 c = p2.position();                                      //top-left corner of p2
            Vector2 d = p2.position() + (new Vector2(s2.width, s2.height)); //bottom-right corner of p2

            float sigma1 = ((center.X - a.X) * (b.Y - a.Y)) - ((center.Y - a.Y) * (b.X - a.X));
            float sigma2 = ((center.X - c.X) * (d.Y - c.Y)) - ((center.Y - c.Y) * (d.X - c.X));

            if (sigma1 < 0)
            {
                if (sigma2 < 0)
                {
                    direction = 0; //top
                }
                else
                {
                    direction = 3; //right
                }
            }
            else
            {
                if (sigma2 < 0)
                {
                    direction = 1; //left
                }
                else
                {
                    direction = 2; //bottom
                }
            }

            return direction;
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
