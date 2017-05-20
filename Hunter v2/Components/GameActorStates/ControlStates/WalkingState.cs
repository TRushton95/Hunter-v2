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

        public IGameActorControlState processInput(GameActor actor, ICommand c)
        {
            c.execute(actor);

            if (c.commandType() == "Fire")
            {
                return new FiringState();
            }
            else if (c.commandType() == "MoveUp")
            {
                actor.directionComponent.currentDirection = 0;
            }
            else if (c.commandType() == "MoveLeft")
            {
                actor.directionComponent.currentDirection = 1;
            }
            else if (c.commandType() == "MoveDown")
            {
                actor.directionComponent.currentDirection = 2;
            }
            else if (c.commandType() == "MoveRight")
            {
                actor.directionComponent.currentDirection = 3;
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
