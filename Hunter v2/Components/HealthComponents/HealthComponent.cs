using Hunter_v2.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.HealthComponents
{
    class HealthComponent : IHealthComponent
    {
        public int currentHealth { get; set; }
        public int maxHealth { get; set; }
        public bool isDead { get; set; }

        public HealthComponent(int maxHealth)
        {
            this.maxHealth = maxHealth;
            this.currentHealth = maxHealth;
            this.isDead = false;
        }

        public void deathCheck()
        {
            if (currentHealth <= 0)
            {
                isDead = true;
            }
        }
    }
}
