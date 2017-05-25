using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.GameObjects
{
    class QuestManager : IObserver<Quest>, IObserver<GameActor>
    {
        List<Quest> quests;

        public QuestManager()
        {
            quests = new List<Quest>();
        }

        public void OnNext(GameActor actor)
        {
            foreach (Quest q in quests)
            {
                //MISSING - put quest objective checking here with actor
                q.progress++;
                if (q.progress == q.maxNumber)
                {
                    q.Complete();
                    quests.Remove(q);
                }
            }
        }

        public void OnError(Exception error)
        {

        }

        public void OnCompleted()
        {

        }

        public void OnNext(Quest quest)
        {
            if (quests.IndexOf(quest) == -1)
            {
                quests.Add(quest);
            }
        }
    }
}
