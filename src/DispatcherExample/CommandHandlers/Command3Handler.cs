using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatcherExample.Commands;
using DispatcherExample.Interfaces;

namespace DispatcherExample.CommandHandlers
{
    class Command3Handler : IHandleCommand<Command3>
    {
        public Command3Handler()
        {
        }

        public CommandResult Handle(Command3 command)
        {
            return new CommandResult();
        }
    }
}
