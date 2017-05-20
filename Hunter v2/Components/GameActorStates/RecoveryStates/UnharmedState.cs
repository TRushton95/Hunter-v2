using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunter_v2.Commands;
using Hunter_v2.GameObjects;
using Hunter_v2.Components.GameActorStates.ControlStates;

namespace Hunter_v2.Components.GameActorStates.RecoveryStates
{
    class UnharmedState : IGameActorRecoveryState
    {

        public IGameActorRecoveryState processInput(GameActor actor)
        {
            return null;
        }

        public void update(GameActor actor)
        {

        }

        public void enter(GameActor actor)
        {

        }

        public void exit(GameActor actor)
        {

        }
    }
}
