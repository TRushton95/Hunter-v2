using Hunter_v2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunter_v2.GameObjects;

namespace Hunter_v2.Components.InputComponents.Commands
{
    class TalkCommand : Command
    {
        public void execute(GameActor gameObject)
        {
            gameObject.conversationComponent.Initiate(gameObject);
        }

        public string commandType()
        {
            return "Talk";
        }

    }
}
