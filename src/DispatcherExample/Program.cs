using System;
using System.Diagnostics;
using System.Threading;
using DispatcherExample.CommandHandlers;
using DispatcherExample.Commands;

namespace DispatcherExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var dispatcher = new CommandDispatcher();

            dispatcher.Register(new Command1Handler());
            dispatcher.Register(new Command2Handler());
            dispatcher.Register(new Command3Handler());

            for (int i = 0; i < 100000; i++)
            {
                dispatcher.Dispatch(new Command1());
                dispatcher.Dispatch(new Command2());
                dispatcher.Dispatch(new Command3());
            }
            var t = dispatcher.Dispatch(new Command1());

            var cts = new CancellationTokenSource();
            var sw = Stopwatch.StartNew();
            dispatcher.Run(cts.Token);
            t.Wait();
            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds);
            cts.Cancel();
            Console.ReadLine();
        }
    }
}
