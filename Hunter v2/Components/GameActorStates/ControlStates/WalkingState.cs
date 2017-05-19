using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunter_v2.Commands;
using Hunter_v2.GameObjects;
using Hunter_v2.Components.GameActorStates.ControlStates;

namespace Hunter_v2.Components.GameActorStates
{
    class WalkingState : IGameActorState
    {

        public WalkingState()
        {

        }

        public IGameActorState processInput(GameActor actor, ICommand c)
        {
            c.execute(actor);

            return null;
        }

        public void update(GameActor actor)
        {

        }

        public void enter()
        {

        }

        public void exit()
        {

        }
    }
}
