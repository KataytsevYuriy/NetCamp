using CassApp.Data;
using CassApp.Services;
using Task12_3;

namespace CassApp
{
    internal class PersonGenerator
    {
        Random random = new Random();
        int loadsNumber=0;

        public List<Person> Load(string fileName = Settings.PersonsFileName)
        {
            List<Person> persons = new List<Person>();
            List<string> otherPersons = FileService.Load(fileName);
            foreach (var item in otherPersons)
            {
                persons.Add(PersonsParser.Parse(item));
            }
            return persons;
        }
        public List<Person> LoadPart(string fileName)
        {
            List<Person> persons = new List<Person>();
            List<string> otherPersons = FileService.Load(fileName,loadsNumber++);
            foreach (var item in otherPersons)
            {
                persons.Add(PersonsParser.Parse(item));
            }
            return persons;
        }
        public List<Person> Genereate(int count)
        {
            List<Person> res = new();
            for (int i = 0; i < count; i++)
            {
                res.Add(new Person(Settings.Status[random.Next(Settings.Status.Count)], $"User{random.Next(500)}",
                    random.Next(20, 80), random.Next(Settings.MaxCoordinate), random.Next(6, 20)));
            }
            return res;
        }
        public void Save(List<Person> people)
        {
            List<string> peopleStr = new();
            foreach (Person person in people) peopleStr.Add(person.ToString());
            FileService.Save(Settings.PersonsFileName, peopleStr, false);
        }
    }
}
