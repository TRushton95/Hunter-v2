using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunter_v2.GameObjects;

namespace Hunter_v2.Components.CollisionComponents.CollisionActions
{
    class BlockCollisionAction : CollisionAction
    {
        public void execute(GameActor actor)
        {
            //MISSING - proper logic here, this is a test to check it works
            actor.positionComponent.posX = 0;
            actor.positionComponent.posY = 0;
        }

        public string actionType()
        {
            return "Block";
        }
    }
}
