using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.GameObjects.Quests
{
    class HealthQuest : Quest
    {
        public HealthQuest(int maxNumber, GameActor questGiver, GameActor questReciever) : base(maxNumber, questGiver, questReciever) { }

        public void complete()
        {
            completed = true;
            questGiver.conversationComponent.dialogueTree.next();
            questReciever.healthComponent.maxHealth += 5;
        }
    }
}
