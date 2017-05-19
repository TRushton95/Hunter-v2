﻿using Hunter_v2.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Commands
{
    interface ICommand
    {
        void execute(GameActor gameObject);

        string commandType();
    }
}
