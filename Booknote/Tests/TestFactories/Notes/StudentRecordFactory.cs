using System;
using Attributes;
using BooknoteLogic;
using BooknoteLogic.Notes;

namespace Tests.TestFactories.Notes
{
    [ContainerElement]
    public class StudentRecordFactory : IFactory<IBooknoteRecord>
    {
        public IBooknoteRecord CreateProduct()
        {
            return new StudentRecord(new Random().Next().ToString(),new Random().Next().ToString());
        }

        public string GetCreatorName()
        {
            return "TestStudentRecord";
        }
    }
}