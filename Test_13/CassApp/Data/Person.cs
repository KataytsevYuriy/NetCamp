using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp.Data
{
    internal class Person
    {
        public Guid Id { get; }
        string name;
        int timeServise;
        int age;
        int coordinate;
        int status;

        public string Name { get => name; private set => name = String.IsNullOrWhiteSpace(value) ? "guest" : value; }
        public int TimeServise { get => timeServise; set => timeServise = value; }
        public int Age { get => age; private set => age = value; }
        public int Coordinate { get => coordinate; private set => coordinate = value; }
        public int Status { get => status; private set => status = value; }

        public Person() : this(Settings.Status[0], "", default, default, default) { }

        public Person(string status, string name, int age, int coordinate, int timeServise)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Coordinate = coordinate;
            Status = Settings.Status.FirstOrDefault(x => x.Value == status).Key;
            TimeServise = timeServise;
        }

        public override string ToString()
        {
            return $"{Settings.Status[Status]} {Name} {Age} {Coordinate} {TimeServise}";
        }
    }
}
