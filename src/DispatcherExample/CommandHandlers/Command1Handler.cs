using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatcherExample.Commands;
using DispatcherExample.Interfaces;

namespace DispatcherExample.CommandHandlers
{
    public class Command1Handler : IHandleCommand<Command1>
    {
        public Command1Handler()
        {
        }

        public CommandResult Handle(Command1 command)
        {
            return new CommandResult();
        }
    }
}
