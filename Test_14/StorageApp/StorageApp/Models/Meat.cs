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
    //[DataContract]
    public class Meat : Product, IMeat, ISerializable, IXmlSerializable
    {
        private Enums.Kind kind;
        private double weight;
        private DateTime useBefore;
        private Enums.Category category;
        //[DataMember]
        public Enums.Kind Kind { get => kind; private set => kind = value; }
        //[DataMember]
        public double Weight
        {
            get => weight; private set
            {
                if (value <= 0) throw new ArgumentException("Вага повинна бути більше 0");
                weight = value;
            }
        }
        //[DataMember]
        public DateTime UseBefore
        {
            get => useBefore; private set
            {
                if (value < DateTime.Now) throw new ArgumentException("Введіть коректну дату");
                useBefore = value;
            }
        }
        //[DataMember]
        public Enums.Category Category { get => category; private set => category = value; }
        public Meat() : base()
        {

        }
        public Meat(string name, double price, double weight, DateTime useBefore, Enums.Kind kind, Enums.Category category, int count = 1)
            : base(name, price, count)
        {
            Weight = weight;
            UseBefore = useBefore;
            Kind = kind;
            Category = category;
        }
        protected Meat(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Weight = info.GetDouble("weight");
            UseBefore = info.GetDateTime("useBefore");
            Kind = (Enums.Kind)info.GetValue("kind", typeof(Enums.Kind));
            Category = (Enums.Category)info.GetValue("category", typeof(Enums.Category));
        }
        public override string ToString()
        {
            return $"{base.ToString()}, вага - {Weight}, вжити до - {UseBefore.ToShortDateString()}, вид - {Kind.ToString()}, Категорія - {Category.ToString()}";
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("weight", Weight);
            info.AddValue("useBefore", UseBefore);
            info.AddValue("kind", Kind);
            info.AddValue("category", Category);
        }

        public XmlSchema? GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            base.ReadXml(reader);
            Weight = reader.ReadElementContentAsDouble();
            UseBefore = reader.ReadElementContentAsDateTime();
            Kind = (Enums.Kind)Enum.Parse(typeof(Enums.Kind), reader.ReadElementContentAsString());
            Category = (Enums.Category)Enum.Parse(typeof(Enums.Category), reader.ReadElementContentAsString());
        }

        public void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);
            writer.WriteElementString("weight", Weight.ToString(System.Globalization.CultureInfo.InvariantCulture));
            writer.WriteElementString("useBefore", UseBefore.ToString("yyyy-MM-dd"));
            writer.WriteElementString("kind", Kind.ToString());
            writer.WriteElementString("category", Category.ToString());
        }
    }
}
