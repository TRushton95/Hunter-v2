using Hunter_v2.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunter_v2.Commands;

namespace Hunter_v2.Components.InputComponents
{
    class NullInputComponent : IInputComponent
    {
        public NullInputComponent()
        {

        }

        public List<Command> processInput()
        {
            List<Command> commands = new List<Command>();
            commands.Add(new NullCommand());
            return commands;
        }
    }
}
