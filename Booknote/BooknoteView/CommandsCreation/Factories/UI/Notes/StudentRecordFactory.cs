using System;
using System.Collections.Generic;
using System.Linq;
using Attributes;
using BooknoteLogic;
using BooknoteLogic.Notes;

namespace BooknoteView.CommandsCreation.Factories.UI.Notes
{
    [ContainerElement]
    public class StudentRecordFactory : IFactory<IBooknoteRecord>
    {
        private readonly List<string> _words = new List<string>{"Write name", "Write phone"}; 
        public IBooknoteRecord CreateProduct()
        {
            var inputDialog = new CreationForm(_words);
            if (inputDialog.ShowDialog() != true)
            {
                throw new ArgumentException(" User close input form!");
            }
            var data = inputDialog.GetInputs().ToList();
            return new StudentRecord(data[0],data[1]);
        }

        public string GetCreatorName()
        {
            return "UIStudentRecord";
        }
    }
}