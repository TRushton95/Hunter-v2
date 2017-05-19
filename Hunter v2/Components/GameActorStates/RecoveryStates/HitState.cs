using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hunter_v2.Commands;
using System.Diagnostics;
using Hunter_v2.GameObjects;
using Hunter_v2.Components.GameActorStates.ControlStates;
using Hunter_v2.Components.GameActorStates.RecoveryStates;

namespace Hunter_v2.Components.GameActorStates
{
    class HitState : IGameActorState
    {
        Stopwatch timer;
        int recoveryTime;

        public HitState()
        {
            timer = new Stopwatch();
            recoveryTime = 2000; //2 seconds
        }

        public IGameActorState processInput(GameActor actor, ICommand c)
        {
            if (timer.ElapsedMilliseconds >= recoveryTime)
            {
                return new UnharmedState();
            }
            return null;
        }

        public void update(GameActor actor)
        {
            //should be state specific logic here
        }

        public void enter()
        {
            timer.Start();
        }

        public void exit()
        {
            timer.Stop();
        }
    }
}
