using Hunter_v2.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.CollisionComponents
{
    interface CollisionAction
    {
        //BUG - inherent limitation that only damage can be processed
        //due to the combined nature of command pattern and states
        void execute(GameActor actor);

        string actionType();
    }
}
