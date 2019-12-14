using System;
using Attributes;
using BooknoteLogic;
using BooknoteLogic.Notes;

namespace Tests.TestFactories.Notes
{
    [ContainerElement]
    public class WantedRecordFactory : IFactory<IBooknoteRecord>
    {
        public IBooknoteRecord CreateProduct(){
            return new WantedRecord(new Random().Next().ToString(), new Random().Next().ToString(), new Random().Next().ToString());
        }

        public string GetCreatorName()
        {
            return "TestWantedRecord";
        }
    }
}