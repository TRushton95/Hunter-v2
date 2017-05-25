using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunter_v2.GameObjects;
using System.IO;

namespace Hunter_v2.Components.ConversationComponents
{
    class ConversationComponent : IConversationComponent
    {
        public IObserver<Tuple<float, float, float, float>> observer { get; set; }
        public DialogueTree dialogueTree { get; set; }

        public ConversationComponent()
        {
            dialogueTree = new DialogueTree(File.ReadAllText("C:/GitHub/Hunter-v2/Hunter v2/Components/ConversationComponents/Dialogue/NPCDialogue.txt"));
        }

        public void Initiate(GameActor actor)
        {
            float posX = actor.positionComponent.posX - 10;
            float posY = actor.positionComponent.posY - 10;
            float width = actor.sizeComponent.width + 20;
            float height = actor.sizeComponent.height + 20;


            observer.OnNext(Tuple.Create(posX, posY, width, height));
        }

        public IDisposable Subscribe(IObserver<Tuple<float, float, float, float>> observer)
        {
            if (this.observer == null)
            {
                this.observer = observer;
            }

            return new Unsubscriber<Tuple<float, float, float, float>>(observer);
        }

        internal class Unsubscriber<GameActor> : IDisposable
        {
            private IObserver<GameActor> observer;

            internal Unsubscriber(IObserver<GameActor> observer)
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
