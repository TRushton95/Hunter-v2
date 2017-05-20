using Hunter_v2.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Commands
{
    class MoveDownCommand : Command
    {
        public void execute(GameActor gameObject)
        {
            gameObject.directionComponent.faceDown();
            gameObject.movementComponent.velY = 5;
        }

        public string commandType()
        {
            return "MoveDown";
        }
    }
}
