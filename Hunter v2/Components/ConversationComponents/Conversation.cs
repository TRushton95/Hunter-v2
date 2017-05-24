using Hunter_v2.Components.GameActorStates;
using Hunter_v2.Components.GameActorStates.ControlStates;
using Hunter_v2.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.ConversationComponents
{
    class Conversation
    {
        GameActor g1, g2;

        public Conversation(GameActor g1, GameActor g2)
        {
            this.g1 = g1;
            this.g2 = g2;
        }

        public void start()
        {
            g1.controlState.exit(g1);
            g1.controlState = new TalkingState();
            g1.controlState.enter(g1);

            g2.controlState.exit(g2);
            g2.controlState = new TalkingState();
            g2.controlState.enter(g2);
        }

        public void end()
        {
            g1.controlState.exit(g1);
            g1.controlState = new WalkingState();
            g1.controlState.enter(g1);

            g2.controlState.exit(g2);
            g2.controlState = new WalkingState();
            g2.controlState.enter(g2);
        }
    }
}
