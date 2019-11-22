namespace BooknoteLogic.Commands
{
    public class DeserializeCommand : IBaseCommand
    {
        private readonly Booknote _booknote;
        private readonly string _path;

        public DeserializeCommand(Booknote booknote, string path)
        {
            _booknote = booknote;
            _path = path;
        }

        public void Execute()
        {
            _booknote.Deserialize(_path);
        }
    }
}