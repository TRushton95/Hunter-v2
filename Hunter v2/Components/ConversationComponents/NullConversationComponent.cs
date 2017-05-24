using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunter_v2.GameObjects;

namespace Hunter_v2.Components.ConversationComponents
{
    class NullConversationComponent : IConversationComponent
    {
        public IObserver<Tuple<float, float, float, float>> observer { get; set; }

        public void Initiate(GameActor actor)
        {

        }

        public IDisposable Subscribe(IObserver<Tuple<float, float, float, float>> observer)
        {
            return null;
        }
    }
}
