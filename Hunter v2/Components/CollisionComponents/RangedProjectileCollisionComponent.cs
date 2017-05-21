using Hunter_v2.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunter_v2.GameObjects;

namespace Hunter_v2.Components.CollisionComponents
{
    class RangedProjectileCollisionComponent : ICollisionComponent
    {
        public bool transient { get; set; }

        public CollisionAction collisionAction { get; set; }

        public RangedProjectileCollisionComponent(CollisionAction collisionAction)
        {
            this.collisionAction = collisionAction;
            this.transient = true;
        }

        public void RecieveCollisionAction(CollisionAction action, GameActor actor)
        {

        }

        public CollisionAction SendCollisionAction()
        {
            return collisionAction;
        }

        public void onCollide(GameActor actor)
        {
            actor.healthComponent.isDead = true;
        }
    }
}
