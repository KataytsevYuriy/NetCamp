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
    public class Storage : ISerializable, IXmlSerializable
    {
        public List<IProduct> products;
        private static readonly Storage storage = new Storage();
        public Storage()
        {
            products = new();
        }
        public Storage(List<IProduct> products) : this()
        {
            this.products.AddRange(products);
        }
        public Storage(SerializationInfo info, StreamingContext context) : base()
        {
            products = (List<IProduct>)info.GetValue("products", typeof(List<IProduct>));
        }
        public static Storage GetStorage()
        {
            return storage;
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void AddProduct(List<IProduct> products)
        {
            this.products.AddRange(products);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("products", products);
        }

        public XmlSchema? GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            while (reader.IsStartElement("IProduct"))
            {
                Type type = Type.GetType(reader.GetAttribute("Type"));
                reader.ReadStartElement("IProduct");
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                products.Add((IProduct)xmlSerializer.Deserialize(reader));
                reader.ReadEndElement();
                reader.ReadEndElement();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (IProduct product in products)
            {
                writer.WriteStartElement("IProduct");
                writer.WriteAttributeString("Type", product.GetType().ToString());
                XmlSerializer serializer = new XmlSerializer(product.GetType());
                serializer.Serialize(writer, product);
                writer.WriteEndElement();
            }
        }
    }
}
