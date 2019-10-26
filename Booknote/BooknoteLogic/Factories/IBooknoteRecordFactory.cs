using BooknoteLogic.Notes;

namespace BooknoteLogic.Factories

{
    public interface IBooknoteRecordFactory
    {
        IBooknoteRecord CreateRecord();
        string GeCreatorName();
    }
}