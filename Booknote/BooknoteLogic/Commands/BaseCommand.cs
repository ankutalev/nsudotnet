namespace BooknoteLogic.Commands
{
    public  interface IBaseCommand
    {
        void Execute();
        string NameToString();
    }
}