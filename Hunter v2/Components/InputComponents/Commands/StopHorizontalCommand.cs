using Hunter_v2.Commands;
using Hunter_v2.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.InputComponents.Commands
{
    class StopHorizontalCommand : Command
    {
        public void execute(GameActor gameObject)
        {
            gameObject.movementComponent.velX = 0;
        }

        public string commandType()
        {
            return "StopHorizontal";
        }
    }
}
