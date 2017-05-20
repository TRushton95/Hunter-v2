using Hunter_v2.Components.Interfaces;
using Hunter_v2.Components.MovementComponents;
using Hunter_v2.Components.PositionComponents;
using Hunter_v2.Components.SizeComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.GameObjects
{
    class Camera
    {
        public ISizeComponent sizeComponent { get; set; }
        public IPositionComponent positionComponent { get; set; }
        public IMovementComponent movementComponent { get; set; }

        //UNSURE - maybe only needs PositionComponent instead of entire GameActor
        GameActor target;
        int worldWidth, worldHeight;

        public Camera(int posX, int posY, int width, int height, int worldWidth, int worldHeight)
        {
            sizeComponent = new SizeComponent(width, height);
            positionComponent = new PositionComponent(posX, posY);
            movementComponent = new MovementComponent();

            this.worldWidth = worldWidth;
            this.worldHeight = worldHeight;
        }

        public void setTarget(GameActor gameActor)
        {
            target = gameActor;
        }

        public void removeTarget()
        {
            target = null;
        }

        public void update()
        {
            if (target != null)
            {
                positionComponent.posX = (target.positionComponent.posX + (target.sizeComponent.width/2)) - (sizeComponent.width/2);
                positionComponent.posY = (target.positionComponent.posY + (target.sizeComponent.height/2)) - (sizeComponent.height/2);
            }
            else
            {
                positionComponent.posX += movementComponent.velX;
                positionComponent.posY += movementComponent.velY;
            }

            if (positionComponent.posX < 0)
            {
                positionComponent.posX = 0;
            }
            if (positionComponent.posY < 0)
            {
                positionComponent.posY = 0;
            }
            if (positionComponent.posX > worldWidth - sizeComponent.width)
            {
                positionComponent.posX = worldWidth - sizeComponent.width;
            }
            if (positionComponent.posY > worldHeight - sizeComponent.height)
            {
                positionComponent.posY = worldHeight - sizeComponent.height;
            }
        }
    }
}
