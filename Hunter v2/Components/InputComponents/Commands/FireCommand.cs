using Hunter_v2.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Commands
{
    class FireCommand : Command
    {
        public override void execute(GameActor gameObject)
        {
            gameObject.weaponComponent.Fire(gameObject);
        }
    }
}
