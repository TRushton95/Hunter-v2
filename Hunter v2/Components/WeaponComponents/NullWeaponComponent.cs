using Hunter_v2.Components.Interfaces;
using Hunter_v2.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.WeaponComponents
{
    class NullWeaponComponent : IWeaponComponent
    {
        public GameActor Fire(GameActor gameObject)
        {
            return null;
        }
    }
}
