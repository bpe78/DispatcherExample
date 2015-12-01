using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatcherExample.Commands
{
    public class Command1 : BaseCommand
    {
        public Command1()
            : base(CommandTypes.Command1)
        {
        }
    }
}
