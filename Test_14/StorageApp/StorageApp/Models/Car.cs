using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp.Models
{
    internal class Car : Product, ICar
    {
        private string factory;
        private DateTime manufactured;
        public string Factory
        {
            get => factory;
            private set => factory = value;
        }

        public DateTime Manufactured
        {
            get => manufactured;
            private set
            {
                if (value > DateTime.Now) throw new ArgumentException("Дата не повинна перевищувати цей час");
                manufactured = value;
            }
        }
        public Car(string name, double price, string factory, DateTime manufactured, int count = 1) : base(name, price, count)
        {
            Factory = factory;
            Manufactured = manufactured;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, вироблено {Manufactured.ToShortDateString()} {Factory}";
        }
    }
}
