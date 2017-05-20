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
        void execute(GameActor actor);

        string actionType();
    }
}
