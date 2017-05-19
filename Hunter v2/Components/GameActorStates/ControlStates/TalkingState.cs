using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunter_v2.Commands;
using Hunter_v2.GameObjects;

namespace Hunter_v2.Components.GameActorStates.ControlStates
{
    class TalkingState : IGameActorState
    {
        public IGameActorState processInput(GameActor actor, ICommand c)
        {
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
