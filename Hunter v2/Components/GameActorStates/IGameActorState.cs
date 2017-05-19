using Hunter_v2.Commands;
using Hunter_v2.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.GameActorStates.ControlStates
{
    interface IGameActorState
    {
        IGameActorState processInput(GameActor actor, ICommand c);

        void update(GameActor actor);

        void enter();

        void exit();
    }
}
