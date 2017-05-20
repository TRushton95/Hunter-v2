using Hunter_v2.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunter_v2.Components.CollisionComponents;
using Hunter_v2.GameObjects;

namespace Hunter_v2.Components
{
    class NullCollisionComponent : ICollisionComponent
    {
        public CollisionAction collisionAction { get; set; }

        public NullCollisionComponent()
        {
            //MISSING - needs to be a null component
            collisionAction = null;
        }

        public void RecieveCollisionAction(CollisionAction action, GameActor actor)
        {
            
        }

        public CollisionAction SendCollisionAction()
        {
            //MISSING - needs to return 
            return null;
        }
    }
}
