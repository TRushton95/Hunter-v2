using Hunter_v2.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.HealthComponents
{
    class NullHealthComponent : IHealthComponent
    {
        public int currentHealth { get; set; }
        public int maxHealth { get; set; }
        public bool isDead { get; set; }

        public NullHealthComponent()
        {
            currentHealth = -1;
            maxHealth = -1;
            isDead = false;
        }

        public void deathCheck()
        {

        }
    }
}
