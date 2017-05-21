using Hunter_v2.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunter_v2.GameObjects;
using Hunter_v2.Components.GameActorStates.RecoveryStates;

namespace Hunter_v2.Components.CollisionComponents
{
    class PlayerCollisionComponent : ICollisionComponent
    {
        public bool transient { get; set; }

        public CollisionAction collisionAction { get; set; }

        //constructor
        public PlayerCollisionComponent(CollisionAction collisionAction)
        {
            this.collisionAction = collisionAction;
            this.transient = false;
        }

        //MISSING - what to do with collision action once recieved
        public void RecieveCollisionAction(CollisionAction collisionAction, GameActor actor)
        {

            IGameActorRecoveryState newRecoveryState = actor.recoveryState.processInput(actor, collisionAction);
            if (newRecoveryState != null)
            {
                actor.recoveryState.exit(actor);
                actor.recoveryState = newRecoveryState;
                actor.recoveryState.enter(actor);
            }
        }

        public CollisionAction SendCollisionAction()
        {
            return collisionAction;
        }

        public void onCollide(GameActor actor)
        {

        }
    }
}
