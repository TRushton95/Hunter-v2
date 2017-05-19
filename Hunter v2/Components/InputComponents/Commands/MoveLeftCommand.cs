using Hunter_v2.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Commands
{
    class MoveLeftCommand : ICommand
    {
        public void execute(GameActor gameObject)
        {
            gameObject.positionComponent.posX += -5;
        }

        public string commandType()
        {
            return "MoveLeft";
        }
    }
}
