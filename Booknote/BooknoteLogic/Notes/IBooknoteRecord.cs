namespace BooknoteLogic.Notes

{
    public interface IBooknoteRecord
    {
        bool Match(string searchPattern);

        void FillFields();

        //can't make interface which require override toString function
        string GetRecordName();
    }
}