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
    class WalkingState : IGameActorControlState
    {

        public WalkingState()
        {

        }

        public IGameActorControlState processInput(GameActor actor, Command c)
        {
            c.execute(actor);

            if (c.commandType() == "Fire")
            {
                return new FiringState();
            }

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
