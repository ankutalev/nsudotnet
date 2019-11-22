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
            if (!_isExit)
            {
                return;
            }

            if (_sc is null)
            {
                _sc.Execute();
            }

            Console.WriteLine("Bye!");
            Environment.Exit(0);
        }
    }
}