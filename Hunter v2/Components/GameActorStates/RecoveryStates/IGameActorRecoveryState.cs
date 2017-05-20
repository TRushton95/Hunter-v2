using Hunter_v2.Components.CollisionComponents;
using Hunter_v2.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.GameActorStates.RecoveryStates
{
    interface IGameActorRecoveryState
    {
        IGameActorRecoveryState processInput(GameActor actor, CollisionAction action);

        void update(GameActor actor);

        void enter(GameActor actor);

        void exit(GameActor actor);
    }
}
