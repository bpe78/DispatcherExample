using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DispatcherExample.Commands;

namespace DispatcherExample.Interfaces
{
    public interface ICommandDispatcher
    {
        void Register<T>(IHandleCommand<T> handler) where T : BaseCommand;
        Task Run(CancellationToken cts);
        Task<CommandResult> Dispatch<T>(T command) where T : BaseCommand;
    }
}
