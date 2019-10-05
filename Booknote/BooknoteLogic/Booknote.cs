using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Attributes;
using Newtonsoft.Json;

namespace BooknoteLogic
{
    [ContainerElement]
    public class Booknote
    {
        private List<BooknoteRecord> _records = new List<BooknoteRecord>();

        public void Deserialize(string path)
        {
            try
            {
                using (var tw = new StreamReader(path))
                {
                    var settings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All};
                    //bad practise
                    var serialized = tw.ReadToEnd();
                    var deserializedList = JsonConvert.DeserializeObject<List<BooknoteRecord>>(serialized, settings);
                    _records = deserializedList;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error during deserialization happened. Check filepath and file for validity");
            }
        }

        public void Serialize(string path)
        {
            try
            {
                using (var tw = new StreamWriter(path))
                {
                    var settings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All};
                    var serialized = JsonConvert.SerializeObject(_records, settings);
                    tw.WriteLine(serialized);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error during deserialization happened. Check filepath and file for validity");
            }
        }
        public List<BooknoteRecord> GetAllRecords()
        {
            return _records;
        }

        public void Add(BooknoteRecord booknoteRecord)
        {
            _records.Add(booknoteRecord);
        }

        public void Remove(int index)
        {
            try
            {
                _records.RemoveAt(index);
            }
            catch (Exception )
            {
                Console.WriteLine("Incorrect Index!");
            }
        }

        public BooknoteRecord Get(int i)
        {
            return _records[i];
        }

        public void Clear()
        {
            _records.Clear();
        }

        public Dictionary<int, BooknoteRecord> Search(string pattern)
        {
            var matched = new Dictionary<int,BooknoteRecord>();
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