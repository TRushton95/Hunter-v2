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
    class TalkingState : IGameActorControlState
    {
        private Stopwatch timer;
        private double timeLimit;

        public TalkingState()
        {
            timer = new Stopwatch();
            timeLimit = 3000;
        }

        public IGameActorControlState processInput(GameActor actor, Command c)
        {
            if (timer.ElapsedMilliseconds >= timeLimit)
            {
                c.execute(actor);
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
