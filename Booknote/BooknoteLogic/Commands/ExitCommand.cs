using System;

namespace BooknoteLogic.Commands
{
    public class ExitCommand : IBaseCommand
    {
        private readonly bool _isExit;
        private readonly IBaseCommand _sc;

        public ExitCommand(bool isExit, IBaseCommand sc)
        {
            _isExit = isExit;
            _sc = sc;
        }

        public void Execute()
        {
            if (!_isExit || _sc == null)
            {
                return;
            }
            Console.WriteLine("Bye!");
            Environment.Exit(0);
        }
    }
}