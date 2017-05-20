using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunter_v2.GameObjects;

namespace Hunter_v2.Components.CollisionComponents.CollisionActions
{
    class DamageCollisionAction : CollisionAction
    {
        public int damage { get; set; }

        public DamageCollisionAction(int damage)
        {
            this.damage = damage;
        }

        public void execute(GameActor actor)
        {
            actor.healthComponent.currentHealth -= damage;
        }
        public string actionType()
        {
            return "Damage";
        }
    }
}
