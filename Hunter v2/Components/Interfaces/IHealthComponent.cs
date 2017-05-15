using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.Interfaces
{
    interface IHealthComponent
    {
        int currentHealth { get; set; }
        int maxHealth { get; set; }
        bool isDead { get; set; }

        void deathCheck();
    }
}
