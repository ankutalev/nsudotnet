using System;
using System.Collections.Generic;
using Attributes;
using BooknoteLogic.Producers;
using JetBrains.Annotations;

namespace BooknoteLogic
{
    [ContainerElement] 
    public class CommandProcessor
    {
        [NotNull]private readonly ICommandProducer _commandProducer;

        public CommandProcessor([NotNull]CommandConsoleProducer commandProducer)
        {
            _commandProducer = commandProducer;
        }

        public void Process()
        {
            while (true)
            {
                var available = _commandProducer.GetAvailableCommands();
                Console.WriteLine("Available commands: ");
                foreach (var command in available)
                {
                    Console.WriteLine(command);
                }

                Console.WriteLine("Enter command name to execute it");
                var name = Console.ReadLine();
                try
                {
                    _commandProducer.GetCommand(name).Execute();
                    Console.WriteLine();
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Command doesnt exist!");
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}