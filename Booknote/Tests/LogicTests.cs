using System.Collections.Generic;
using System.IO;
using System.Linq;
using BooknoteLogic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private TestCommandProducer _producer;
        private Booknote _booknote;
        private const int Iterations = 351;

        [SetUp]
        public void Setup()
        {
            var kunteynir = new Container.Container(new List<string> {"BooknoteLogic", "Tests"});
            _producer = kunteynir.Resolve<TestCommandProducer>();
            _booknote = kunteynir.Resolve<Booknote>();
        }

        [Test]
        public void AddCommand()
        {
            Assert.AreEqual(_booknote.GetAllRecords().Count, 0);
            var addCommand = _producer.GetCommand("TestAddRecord");
            addCommand.Execute();
            Assert.AreEqual(_booknote.GetAllRecords().Count, 1);
            for (var i = 0; i < Iterations; i++)
            {
                addCommand = _producer.GetCommand("TestAddRecord");
                addCommand.Execute();
            }

            Assert.AreEqual(_booknote.GetAllRecords().Count, Iterations + 1);
        }

        [Test]
        public void CLearCommand()
        {
            var clearCommand = _producer.GetCommand("TestClear");
            clearCommand.Execute();
            Assert.AreEqual(_booknote.GetAllRecords().Count, 0);

            for (var i = 0; i < Iterations; i++)
            {
                var addCommand = _producer.GetCommand("TestAddRecord");
                addCommand.Execute();
            }

            clearCommand.Execute();
            Assert.AreEqual(_booknote.GetAllRecords().Count, 0);
        }

        [Test]
        public void RemoveCommand()
        {
            Assert.AreEqual(_booknote.GetAllRecords().Count, 0);
            var addCommand = _producer.GetCommand("TestAddRecord");
            addCommand.Execute();
            var removeCommand = _producer.GetCommand("TestRemove");
            removeCommand.Execute();
            Assert.AreEqual(_booknote.GetAllRecords().Count, 0);

            addCommand = _producer.GetCommand("TestAddRecord");
            addCommand.Execute();
            addCommand = _producer.GetCommand("TestAddRecord");
            addCommand.Execute();
            var fRecord = _booknote.GetAllRecords().First();
            removeCommand.Execute();
            Assert.AreEqual(_booknote.GetAllRecords().Count, 1);
            Assert.False(_booknote.GetAllRecords().Contains(fRecord));
        }

        
        [Test]
        public void Serializations()
        {
            for (var i = 0; i < Iterations; i++)
            {
                var addCommand = _producer.GetCommand("TestAddRecord");
                addCommand.Execute();
            }
            
            var serCommand = _producer.GetCommand("TestSerialize");
            serCommand.Execute();
            Assert.True(File.Exists("test_serialize.json"));
            
            var clearCommand = _producer.GetCommand("TestClear");
            clearCommand.Execute();
            
            var desCommand = _producer.GetCommand("TestDeserialize");
            desCommand.Execute();
            Assert.AreEqual(_booknote.GetAllRecords().Count, Iterations);
        }
    }
}