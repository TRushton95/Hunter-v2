using Hunter_v2.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.Interfaces
{
    interface IWeaponComponent : IObservable<GameActor>
    {
        IGraphicsComponent graphicsComponent { get; set; }
        IObserver<GameActor> observer { get; set; }

        void Fire(GameActor gameObject);
    }
}
