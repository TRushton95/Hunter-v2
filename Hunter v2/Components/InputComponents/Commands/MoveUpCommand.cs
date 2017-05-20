using Hunter_v2.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Commands
{
    class MoveUpCommand : Command
    {
        public void execute(GameActor gameObject)
        {
            gameObject.directionComponent.faceUp();
            gameObject.movementComponent.velY = -5;
        }

        public string commandType()
        {
            return "MoveUp";
        }
    }
}
