using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatcherExample.Commands
{
    public abstract class BaseCommand
    {
        protected BaseCommand(CommandTypes commandType)
        {
            CommandType = commandType;
        }

        public CommandTypes CommandType { get; private set; }
    }
}
