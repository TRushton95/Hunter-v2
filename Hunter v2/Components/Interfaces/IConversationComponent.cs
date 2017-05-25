using Hunter_v2.Components.ConversationComponents;
using Hunter_v2.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components
{
    interface IConversationComponent : IObservable<Tuple<float, float, float, float>>
    {
        IObserver<Tuple<float, float, float, float>> observer { get; set; }
        DialogueTree dialogueTree { get; set; }

        void Initiate(GameActor actor);
    }
}
