using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunter_v2.Commands;
using Hunter_v2.GameObjects;
using System.Diagnostics;

namespace Hunter_v2.Components.GameActorStates.ControlStates
{
    class FiringState : IGameActorControlState
    {
        private Stopwatch timer;
        double recoveryTime;

        public FiringState()
        {
            //MISSING - proper logic for assigning recovery time based on attack type
            timer = new Stopwatch();
            recoveryTime = 500;
        }

        public IGameActorControlState processInput(GameActor actor, ICommand c)
        {
            if (c.commandType() != "Fire")
            {
                c.execute(actor);
            }

            if (timer.ElapsedMilliseconds >= recoveryTime)
            {
                return new WalkingState();
            }

            return null;
        }

        public void update(GameActor actor)
        {

        }

        public void enter(GameActor actor)
        {
            timer.Start();
        }

        public void exit(GameActor actor)
        {
            timer.Stop();
        }
    }
}
