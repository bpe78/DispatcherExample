using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatcherExample.Commands
{
    public class Command2 : BaseCommand
    {
        public Command2()
            : base(CommandTypes.Command2)
        {
        }
    }
}
