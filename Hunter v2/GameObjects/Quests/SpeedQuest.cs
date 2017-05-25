using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.GameObjects.Quests
{
    class SpeedQuest : Quest
    {
        public SpeedQuest(int maxNumber, GameActor questGiver, GameActor questReciever) : base(maxNumber, questGiver, questReciever) { }

        public void complete()
        {
            questGiver.conversationComponent.dialogueTree.next();
            questReciever.movementComponent.velX += 5;
            questReciever.movementComponent.velY += 5;
        }
    }
}
