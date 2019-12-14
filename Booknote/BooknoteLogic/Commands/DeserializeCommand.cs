
using JetBrains.Annotations;

namespace BooknoteLogic.Commands
{
    public class DeserializeCommand : IBaseCommand
    {
        [NotNull]private readonly Booknote _booknote;
        [NotNull]private readonly string _path;

        public DeserializeCommand([NotNull]Booknote booknote, [NotNull]string path)
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