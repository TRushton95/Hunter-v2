using Hunter_v2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.Interfaces
{
    interface IInputComponent
    {
        List<Command> processInput();
    }
}
