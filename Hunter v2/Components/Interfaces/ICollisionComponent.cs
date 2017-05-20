using Hunter_v2.Components.CollisionComponents;
using Hunter_v2.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.Interfaces
{
    interface ICollisionComponent
    {
        CollisionAction collisionAction { get; set; }

        void RecieveCollisionAction(CollisionAction action, GameActor actor);

        CollisionAction SendCollisionAction();
    }
}
