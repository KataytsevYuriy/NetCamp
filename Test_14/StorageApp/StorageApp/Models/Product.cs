using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace StorageApp.Models
{
    [Serializable]
    [DataContract]
    public class Product : IProduct, ISerializable, IXmlSerializable
    {
        [DataMember]
        private string id;
        [DataMember]
        private string name;
        private double price;
        private int count;
        [DataMember]
        public string Id { get => id; private set => id = value; }
        [DataMember]
        public string Name { get => name; private set => name = value; }
        [DataMember]
        public double Price
        {
            get => price;
            private set
            {
                if (value < 0) throw new ArgumentException("Ціна повинна бути вище 0");
                price = value;
            }
        }
        public int Count
        {
            get => count;
            private set
            {
                if (value < 0) throw new ArgumentException("Кількість повинна бути вище 0");
                count = value;
            }
        }
        public Product()
        {
            id = Guid.NewGuid().ToString();
            name = String.Empty;
            count = 1;
        }
        public Product(string name, double price, int count) : this()
        {
            Name = name;
            Price = price;
            Count = count;
        }
        protected Product(SerializationInfo info, StreamingContext context) : base()
        {
            Id = info.GetString("id");
            name = info.GetString("name");
            price = info.GetDouble("price");
            count = info.GetInt32("count");
        }
        public virtual void IncreasePrice(double increment)
        {
            price += increment;
        }
        public virtual string ToString()
        {
            return $"Name - {name}, price - {price}";
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", Id);
            info.AddValue("name", Name);
            info.AddValue("price", Price);
            info.AddValue("count", Count);
        }

        public XmlSchema? GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadToFollowing("id");
            Id = reader.ReadElementContentAsString();
            Name = reader.ReadElementContentAsString();
            Price = reader.ReadElementContentAsDouble();
            Count = reader.ReadElementContentAsInt();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("id", Id);
            writer.WriteElementString("name", Name);
            writer.WriteElementString("price", Price.ToString(System.Globalization.CultureInfo.InvariantCulture));
            writer.WriteElementString("count", Count.ToString());
        }
    }
}
