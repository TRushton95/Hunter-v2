using Hunter_v2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunter_v2.GameObjects;

namespace Hunter_v2.Components.InputComponents.Commands
{
    class StopVerticalCommand : Command
    {
        public void execute(GameActor gameObject)
        {
            gameObject.movementComponent.velY = 0;
        }

        public string commandType()
        {
            return "StopVertical";
        }
    }
}
