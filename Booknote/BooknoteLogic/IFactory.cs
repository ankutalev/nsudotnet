namespace BooknoteLogic

{
    public interface IFactory<out T>
    {
        T CreateRecord();
        string GetCreatorName();
    }
}