using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.GameObjects.Quests
{
    class QuestManager : IObserver<GameActor>
    {
        public List<Quest> activeQuests { get; set; }

        public QuestManager()
        {
            activeQuests = new List<Quest>();
        }

        public void newQuest(Quest quest)
        {
            activeQuests.Add(quest);
        }

        public void OnNext(GameActor actor)
        {
            foreach (Quest q in activeQuests)
            {
                //MISSING - proper discerning logic
                //requires mob typing that doesn't exist in this program to use this properly
                q.progress++;
            }
        }

        public void OnCompleted()
        {

        }

        public void OnError(Exception error)
        {

        }

    }
}
