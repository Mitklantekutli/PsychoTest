using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Tester
{
    class PersonManager
    {
        public const string Path = "Persons.txt";
        public List<PersonInfo> Load()
        {
            if (File.Exists(Path))
            {
                var content = File.ReadAllText(Path);
                var persons = JsonConvert.DeserializeObject<List<PersonInfo>>(content);
                return persons;
            }
            else
            {
                return new List<PersonInfo>();
            }
        }
        public void Save(List<PersonInfo> persons)
        {
            var content = JsonConvert.SerializeObject(persons);
            File.WriteAllText(Path, content);
        }
    }
}
