using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatcherExample.Commands;

namespace DispatcherExample.Interfaces
{
    public interface IHandleCommand<T> where T : BaseCommand
    {
        CommandResult Handle(T command);
    }
}
