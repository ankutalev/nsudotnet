using System;
using Attributes;
using BooknoteLogic;
using BooknoteLogic.Notes;

namespace Tests.TestFactories.Notes
{
    [ContainerElement]
    public class SimpleBooknoteRecordFactory : IFactory<IBooknoteRecord>
    {
        public IBooknoteRecord CreateProduct()
        {
            return new SimpleBooknoteRecord(new Random().Next().ToString());
        }

        public string GetCreatorName()
        {
            return "TestSimpleRecord";
        }
    }
}