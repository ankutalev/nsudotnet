using System;
using Attributes;

namespace BooknoteLogic
{
    [ContainerElement] 
    public class CommandProcessor
    {
        private readonly CommandProducer _commandProducer;

        public CommandProcessor(CommandProducer commandProducer)
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
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}