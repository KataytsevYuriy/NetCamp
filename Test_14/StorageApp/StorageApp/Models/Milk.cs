using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace StorageApp.Models
{
    [Serializable]
    public class Milk : Product, IMilk, ISerializable, IXmlSerializable
    {
        private DateTime manufactured;
        private double volume;
        private string productFactory;
        public DateTime Manufactured
        {
            get => manufactured;
            private set
            {
                if (value > DateTime.Now) throw new ArgumentException("Дата не повинна перевищувати цей час");
                manufactured = value;
            }
        }
        public double Volume
        {
            get => volume; private set
            {
                if (value <= 0) throw new ArgumentException("Об'єм повинен бути більше 0");
                volume = value;
            }
        }
        public string Factory
        {
            get => productFactory;
            private set => productFactory = value;
        }
        public Milk()
        {

        }
        public Milk(string name, double price, string factory, double volume, DateTime manufactured, int count = 1)
            : base(name, price, count)
        {
            productFactory = factory;
            Volume = volume;
            Manufactured = manufactured;
        }
        protected Milk(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Manufactured = info.GetDateTime("manufactured");
            Volume = info.GetDouble("volume");
            Factory = info.GetString("Factory");
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("manufactured", Manufactured);
            info.AddValue("volume", Volume);
            info.AddValue("Factory", Factory);
        }
        public override string ToString()
        {
            return $"{base.ToString()}, об'єм - {Volume}, вироблено {Manufactured.ToShortDateString()} {Factory}";
        }
        public XmlSchema? GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            base.ReadXml(reader);
            Volume = reader.ReadElementContentAsDouble();
            Manufactured = reader.ReadElementContentAsDateTime();
            Factory = reader.ReadElementContentAsString();
        }

        public void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);
            writer.WriteElementString("volume", Volume.ToString(System.Globalization.CultureInfo.InvariantCulture));
            writer.WriteElementString("manufactured", Manufactured.ToString("yyyy-MM-dd"));
            writer.WriteElementString("factory", Factory);

        }
    }
}
