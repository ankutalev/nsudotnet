using System;
using System.Collections.Generic;
using System.IO;
using Attributes;
using BooknoteLogic.Exceptions;
using BooknoteLogic.Notes;
using Newtonsoft.Json;

namespace BooknoteLogic
{
    [ContainerElement]
    public class Booknote
    {
        private List<IBooknoteRecord> _records = new List<IBooknoteRecord>();

        public void Deserialize(string path)
        {
            try
            {
                using var tw = new StreamReader(path);
                var settings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All};
                //bad practise
                var serialized = tw.ReadToEnd();
                var deserializedList = JsonConvert.DeserializeObject<List<IBooknoteRecord>>(serialized, settings);
                _records = deserializedList;
            }
            catch (Exception)
            {
                throw new BooknoteLogicException("Error during deserialization happened. Check filepath and file for validity");
            }
        }

        public void Serialize(string path)
        {
            try
            {
                using var tw = new StreamWriter(path);
                var settings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All};
                var serialized = JsonConvert.SerializeObject(_records, settings);
                tw.WriteLine(serialized);
            }
            catch (Exception)
            {
                throw new BooknoteLogicException(
                    "Error during serialization happened. Check filepath and file for validity");
            }
        }

        public List<IBooknoteRecord> GetAllRecords()
        {
            return _records;
        }

        public void Add(IBooknoteRecord booknoteRecord)
        {
            _records.Add(booknoteRecord);
        }

        public void Remove(int index)
        {
            try
            {
                _records.RemoveAt(index);
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect Index!");
            }
        }

        public IBooknoteRecord Get(int i)
        {
            return _records[i];
        }

        public void Clear()
        {
            _records.Clear();
        }

        public Dictionary<int, IBooknoteRecord> Search(string pattern)
        {
            var matched = new Dictionary<int, IBooknoteRecord>();
            for (var index = 0; index < _records.Count; index++)
            {
                var record = _records[index];
                if (record.Match(pattern))
                    matched[index] = record;
            }

            return matched;
        }
    }
}