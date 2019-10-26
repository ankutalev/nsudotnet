namespace BooknoteLogic.Notes

{
    public interface IBooknoteRecord
    {
        bool Match(string searchPattern);
    }
}