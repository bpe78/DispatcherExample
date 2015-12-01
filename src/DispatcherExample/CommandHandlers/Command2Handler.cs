using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatcherExample.Commands;
using DispatcherExample.Interfaces;

namespace DispatcherExample.CommandHandlers
{
    class Command2Handler : IHandleCommand<Command2>
    {
        public Command2Handler()
        {
        }

        public CommandResult Handle(Command2 command)
        {
            return new CommandResult();
        }
    }
}
