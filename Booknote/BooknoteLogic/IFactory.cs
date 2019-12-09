namespace BooknoteLogic

{
    public interface IFactory<out T>
    {
        T CreateProduct();
        string GetCreatorName();
    }
}