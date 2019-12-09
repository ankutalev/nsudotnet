using System;
using System.Collections.Generic;
using Attributes;
using BooknoteLogic;
using BooknoteLogic.Commands;
using BooknoteLogic.Notes;

namespace BooknoteView.CommandsCreation.Factories.UI
{
    [ContainerElement]
    public class AddRecordFactory : IFactory<IBaseCommand>
    {
        private readonly Booknote _booknote;

        private readonly Dictionary<string, IFactory<IBooknoteRecord>> _records;


        public AddRecordFactory(Booknote booknote, List<IFactory<IBooknoteRecord>> recordTypes)
        {
            _booknote = booknote;
            _records = new Dictionary<string, IFactory<IBooknoteRecord>>(recordTypes.Count);

            foreach (var factory in recordTypes)
            {
                var name = factory.GetCreatorName();
                if (name.StartsWith("UI"))
                {
                    _records.Add(name,factory);
                }
            }
        }

        public IBaseCommand CreateProduct()
        {
            var inputDialog = new RecordTypeChooser(_records.Keys);
            if (inputDialog.ShowDialog() != true) return new NopeCommand();
            try
            {
                return new AddRecordCommand(_booknote, _records[inputDialog.GetInput()].CreateProduct());
            }
            catch (Exception)
            {
                return  new NopeCommand();
            }
        }

        public string GetCreatorName()
        {
            return "UIAddRecord";
        }
    }
}