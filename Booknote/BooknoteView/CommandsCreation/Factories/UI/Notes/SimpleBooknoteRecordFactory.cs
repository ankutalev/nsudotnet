using System;
using System.Collections.Generic;
using System.Linq;
using Attributes;
using BooknoteLogic;
using BooknoteLogic.Notes;

namespace BooknoteView.CommandsCreation.Factories.UI.Notes
{
    [ContainerElement]
    public class SimpleBooknoteRecordFactory : IFactory<IBooknoteRecord>
    {
        private readonly List<string> _words = new List<string>{"Type something!"}; 
        public IBooknoteRecord CreateProduct()
        {
            var inputDialog = new CreationForm(_words);
            if (inputDialog.ShowDialog() != true)
            {
                throw new ArgumentException(" User close input form!");
            }
            var data = inputDialog.GetInputs();
            return new SimpleBooknoteRecord(data.First());
        }

        public string GetCreatorName()
        {
            return "UISimpleRecord";
        }
    }
}