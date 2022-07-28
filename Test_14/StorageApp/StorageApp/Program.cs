// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using StorageApp.Cactory;
using StorageApp.Models;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

Console.WriteLine("Hello, World!");
List<IProduct> products = new List<IProduct>()
{
    new Meat("pork", 25, 1, new DateTime(2022,09,08), Enums.Kind.pork, Enums.Category.firstSort),
    new Product("pork", 25.56, 1),
    new Product("pork", 25, 1),
    new Meat("pork1", 25, 1, new DateTime(2022,09,08), Enums.Kind.pork, Enums.Category.firstSort),
    new Milk("milk", 12, "Agromol",0.95,new DateTime(2022,06,08))
};
string flName = "test";
string flNameXML = "testXML";
Storage storage = new Storage(products);
XmlSerializer xmlSerializer = new XmlSerializer(typeof(Storage));
using (FileStream stream = new FileStream(flNameXML, FileMode.OpenOrCreate))
{
    xmlSerializer.Serialize(stream, storage);
}
BinaryFormatter binarySerializer = new BinaryFormatter();
using (FileStream stream = new FileStream(flName, FileMode.OpenOrCreate))
{
    binarySerializer.Serialize(stream, storage);
}

Storage newStorageXML;
using (Stream stream = new FileStream(flNameXML, FileMode.Open))
{
    newStorageXML = (Storage)xmlSerializer.Deserialize(stream);
}
Storage newStorage;
using (Stream stream = new FileStream(flName, FileMode.Open))
{
    newStorage = (Storage)binarySerializer.Deserialize(stream);
}
IMeatCreator creator = new ChickenMeatCreator();
MeatCooperative coop = new (creator);
storage.AddProduct(coop.SendToSuperMarket());
creator = new PorkMeatCreator();
coop = new(creator);
storage.AddProduct(coop.SendToSuperMarket());
