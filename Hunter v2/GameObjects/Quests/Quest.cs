using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.GameObjects
{
    class Quest
    {
        public int maxNumber { get; set; }
        public int progress { get; set; }

        public Quest(int maxNumber)
        {
            this.maxNumber = maxNumber;
        }
    }
}
