using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.GameObjects
{
    abstract class Quest : IObservable<Quest>
    {
        public int maxNumber { get; set; }
        public int progress { get; set; }
        public bool completed { get; set; }
        public int dialogueId { get; set; }
        public GameActor questGiver { get; set; }
        public GameActor questReciever { get; set; }
        public IObserver<Quest> observer { get; set; }

        public Quest(int maxNumber, GameActor questGiver, GameActor questReciever)
        {
            this.maxNumber = maxNumber;
            this.progress = 0;
            this.completed = false;
            this.questGiver = questGiver;
            this.questReciever = questReciever;
        }

        public void Start() {
            observer.OnNext(this);
        }

        public virtual void Complete() { }

        public IDisposable Subscribe(IObserver<Quest> observer)
        {
            if (this.observer == null)
            {
                this.observer = observer;
            }

            return new Unsubscriber<Quest>(observer);
        }

        internal class Unsubscriber<Quest> : IDisposable
        {
            private IObserver<Quest> observer;

            internal Unsubscriber(IObserver<Quest> observer)
            {
                this.observer = observer;
            }

            public void Dispose()
            {
                if (observer != null)
                    observer = null;
            }
        }
    }
}
