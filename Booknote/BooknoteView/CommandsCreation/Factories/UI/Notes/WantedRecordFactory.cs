using System;
using System.Collections.Generic;
using System.Linq;
using Attributes;
using BooknoteLogic;
using BooknoteLogic.Notes;

namespace BooknoteView.CommandsCreation.Factories.UI.Notes
{
    [ContainerElement]
    public class WantedRecordFactory : IFactory<IBooknoteRecord>
    {
        private readonly List<string> _words = new List<string>{"Write first name", "Write last name", "Special signs"}; 
        public IBooknoteRecord CreateProduct()
        {
            var inputDialog = new CreationForm(_words);
            if (inputDialog.ShowDialog() != true)
            {
                throw new ArgumentException(" User close input form!");
            }
            var data = inputDialog.GetInputs().ToList();
            return new WantedRecord(data[0],data[1],data[2]);
        }
        public string GetCreatorName()
        {
            return "UIWantedRecord";
        }
    }
}