using CassApp.Data;
using CassApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp
{
    internal class Cassa
    {
        PriorityQueue<Person, int> queuePersons;
        private Person? currentPerson;
        private bool isOpen;
        private bool isLock;
        private List<int> categories;
        public int Cordinate { get; }
        public int QueueCount { get { return queuePersons.Count + (currentPerson == null ? 0 : 1); } }
        public bool IsOpen { get => isOpen; private set => isOpen = value; }
        public bool IsEmpty { get => queuePersons.Count == 0 && currentPerson == null; }
        public bool IsLock { get => isLock; private set => isLock = value; }
        public List<int> Categories { get => categories; private set => categories = value; }

        public Cassa()
        {
            queuePersons = new();
            Cordinate = 0;
            IsOpen = true;
            Categories = new();
            isLock = false;
        }
        public Cassa(int cordinate) : this()
        {
            this.Cordinate = cordinate;
        }
        public Cassa(int cordinate, List<string> categories) : this(cordinate)
        {
            if (categories != null && categories.Count > 0)
            {
                foreach (string str in categories)
                {
                    if (Settings.Status.ContainsValue(str))
                    {
                        Categories.Add(Settings.Status.FirstOrDefault(x => x.Value == str).Key);
                    }
                }
            }
        }
        public void Enqueue(Person person)
        {
            if (currentPerson == null)
            {
                currentPerson = person;
            }
            else
            {
                queuePersons.Enqueue(person, StatusPolitics.GetUserPriority(person));
            }
        }
        public Person? Dequeue()
        {
            Person? dequeuePerson = currentPerson;
            currentPerson = queuePersons.Count > 0 ? queuePersons.Dequeue() : null;
            return dequeuePerson;
        }
        public Person? Peek()
        {
            return currentPerson;
        }
        public List<Person> Close()
        {
            IsOpen = false;
            List<Person> returnPerson = new();
            while (queuePersons.Count > 0)
            {
                returnPerson.Add(queuePersons.Dequeue());
            }
            return returnPerson;
        }
        public void Lock()
        {
            IsLock = true;
        }
        public void UnLock()
        {
            isLock = false;
        }
        public List<Person> ChangeCategory(List<int> categories)
        {
            Categories = categories;
            List<Person> toRemove = new();
            PriorityQueue<Person, int> newQqueuePersons = new();
            while (queuePersons.Count > 0)
            {
                Person person = queuePersons.Dequeue();
                if (IsAllowed(person))
                {
                    newQqueuePersons.Enqueue(person, StatusPolitics.GetUserPriority(person));
                }
                else
                {
                    toRemove.Add(person);
                }
            }
            queuePersons = newQqueuePersons;
            return toRemove;
        }
        public bool IsAllowed(Person person)
        {
            if (!isOpen) return false;
            if (isLock) return false;
            if (Categories.Count > 0 && !Categories.Contains(person.Status)) return false;
            return true;
        }
    }
}
