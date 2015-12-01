using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DispatcherExample.Commands;
using DispatcherExample.Interfaces;

namespace DispatcherExample
{
    public delegate CommandResult DelegateHandler(BaseCommand command);

    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly BlockingCollection<Item> _queue;
        private readonly Dictionary<Type, DelegateHandler> _registrations;

        public CommandDispatcher()
        {
            _queue = new BlockingCollection<Item>(new ConcurrentQueue<Item>());
            _registrations = new Dictionary<Type, DelegateHandler>(25);
        }

        public Task<CommandResult> Dispatch<T>(T command) where T : BaseCommand
        {
            var tcs = new TaskCompletionSource<CommandResult>();
            _queue.Add(new Item(command, tcs));
            return tcs.Task;
        }

        public void Register<T>(IHandleCommand<T> handler) where T : BaseCommand
        {
            _registrations.Add(typeof(T), cmd => handler.Handle((T)cmd));
        }

        public Task Run(CancellationToken token)
        {
            return Task.Run(() =>
            {
                try
                {
                    foreach (var item in _queue.GetConsumingEnumerable(token))
                    {
                        DelegateHandler handler;
                        if (_registrations.TryGetValue(item.Command.GetType(), out handler))
                        {
                            try
                            {
                                var result = handler(item.Command);
                                item.CompletionSource.SetResult(result);
                            }
                            catch (Exception ex)
                            {
                                //TODO: log
                                item.CompletionSource.SetException(ex);
                            }
                        }
                        else
                        {
                            //TODO: log
                        }
                    }
                }
                catch (OperationCanceledException ex)
                {
                    //TODO: log
                }
            }, token);
        }

        class Item
        {
            public Item(BaseCommand command, TaskCompletionSource<CommandResult> completionSource)
            {
                Command = command;
                CompletionSource = completionSource;
            }
            public BaseCommand Command { get; private set; }
            public TaskCompletionSource<CommandResult> CompletionSource { get; private set; }
        }
    }
}
