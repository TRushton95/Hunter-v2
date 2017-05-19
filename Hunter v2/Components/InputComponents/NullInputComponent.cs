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

        public List<ICommand> processInput()
        {
            List<ICommand> commands = new List<ICommand>();
            commands.Add(new NullCommand());
            return commands;
        }
    }
}
