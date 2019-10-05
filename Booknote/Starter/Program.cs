using BooknoteLogic;

namespace Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            var cont = new Container.Container();
            var processor =  cont.Resolve<CommandProcessor>();
            processor.Process();
        }
    }
}