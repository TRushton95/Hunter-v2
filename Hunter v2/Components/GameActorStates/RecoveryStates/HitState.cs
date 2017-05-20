using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hunter_v2.Commands;
using System.Diagnostics;
using Hunter_v2.GameObjects;
using Hunter_v2.Components.GameActorStates.ControlStates;
using Hunter_v2.Components.GameActorStates.RecoveryStates;
using Hunter_v2.Components.CollisionComponents;

namespace Hunter_v2.Components.GameActorStates
{
    class HitState : IGameActorRecoveryState
    {
        private Stopwatch timer;
        double recoveryTime;

        public HitState()
        {
            timer = new Stopwatch();
            recoveryTime = 1000; //1 seconds
        }

        public IGameActorRecoveryState processInput(GameActor actor, CollisionAction action)
        {
            return null;
        }

        public void update(GameActor actor)
        {
            if (timer.ElapsedMilliseconds >= recoveryTime)
            {
                exit(actor);
                actor.recoveryState = new UnharmedState();
                enter(actor);
            }
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
