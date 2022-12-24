using System.Diagnostics.Metrics;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace Lab13
{
    public class Program
    {
        static void Main()
        {
            Water salted = new Water(1234, "солёная");
            Water presnaya = new Water(4567, "пресная");
            Sea sea = new Sea("Саргассово море", 12, presnaya);
            Sea sea2 = new Sea("Красное море", 15, salted);
            Sea[] seasarray = { sea, sea2 };
            Continent c1 = new Continent("Австралия", 32456712);
            c1.PrecOfC = 17;
            Continent c2 = new Continent("Африка", 12313413);
            c2.PrecOfC = 14;
            Continent c3 = new Continent("Евразия", 754874);
            c3.PrecOfC = 21;
            Continent[] arr = { c1, c2, c3 };

            CustomSerializer.Serialize("seas.bin", seasarray);
            CustomSerializer.Deserialize("seas.bin");
            CustomSerializer.Serialize("seas.xml", seasarray);
            CustomSerializer.Deserialize("seas.xml");
            CustomSerializer.Serialize("continents.json", arr);
            CustomSerializer.Deserialize("continents.json");

            Console.WriteLine("Структура XML-документа continents:");
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("seas.xml");
            XmlElement? xRoot = xdoc.DocumentElement;
            XmlNodeList? nodes = xRoot.SelectNodes("*");
            Console.WriteLine();
            if (nodes is not null)
            {
                foreach (XmlElement node in nodes)
                {
                    Console.WriteLine(node.OuterXml);
                }
            }
            Console.WriteLine();

            XmlNodeList? waterNodes = xRoot.SelectNodes("Sea");
            Console.WriteLine("Кол-во вложенных узлов в элемент water");
            if (waterNodes is not null)
            {
                foreach (XmlElement node in waterNodes)
                {
                    Console.WriteLine(node.ChildNodes.Count);
                    break;
                }
            }

            Console.WriteLine("Атрибут тега water:");
            var docforquery = XDocument.Load("seas.xml");
            var items = from item
                        in docforquery.Descendants("water")
                        select item.Attribute("square");
            Console.WriteLine();
            foreach (var el in items)
            {
                Console.WriteLine(el);
            }
        }




    }
    }


































/* 
                   //#BIN
                  BinaryFormatter bf = new BinaryFormatter();
                  using (FileStream fs = new FileStream("seas.dat", FileMode.OpenOrCreate))
                  {
                      bf.Serialize(fs, seasarray);
                  }

                  using (FileStream fs = new FileStream("seas.dat", FileMode.OpenOrCreate))
                  {
                      Sea[] sd = (Sea[])bf.Deserialize(fs);
                      foreach (Sea el in sd)
                          Console.WriteLine(el.ToString());
                  }

                  //#XML
                  XmlSerializer xml = new XmlSerializer(typeof(Sea[]));
                  using (FileStream fx = new FileStream("seas.xml", FileMode.OpenOrCreate))
                  {
                      xml.Serialize(fx, seasarray);
                  }
                  using (FileStream fx = new FileStream("seas.xml", FileMode.OpenOrCreate))
                  {
                      Sea sxmld = xml.Deserialize(fx) as Sea;
                      Console.WriteLine(sxmld);
                  }
                  //#JSON
                  DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Continent[]));
                  using (FileStream fs = new FileStream("seas.json", FileMode.OpenOrCreate))
                  {
                      jsonSerializer.WriteObject(fs,arr);
                  }
                  using (FileStream qq = new FileStream("seas.json", FileMode.OpenOrCreate))
                  {
                      Continent[] newseas = (Continent[])jsonSerializer.ReadObject(qq);
                      foreach(var el in newseas)
                      {
                          Console.WriteLine(el);
                      }
                  }
                  //#task 3,4
                  XmlDocument xdoc = new XmlDocument();
                  xdoc.Load("seas.xml");
                  XmlElement? xRoot = xdoc.DocumentElement;
                  XmlNodeList? nodes = xRoot.SelectNodes("*");
                  Console.WriteLine();
                  if (nodes is not null)
                  {
                      foreach(XmlElement node in nodes)
                      {
                          Console.WriteLine(node.OuterXml);
                      }
                  }
                  Console.WriteLine();
                  XmlNodeList? waterNodes = xRoot.SelectNodes("Sea");
                  Console.WriteLine("Кол-во вложенных узлов в элемент water");
                  if (waterNodes is not null)
                  {
                      foreach (XmlElement node in waterNodes)
                      {
                          Console.WriteLine(node.ChildNodes.Count);
                          break;
                      }
                  }

                  Console.WriteLine("Атрибут тега water:");
                  var docforquery = XDocument.Load("seas.xml");
                  var items = from item
                              in docforquery.Descendants("water")
                              select item.Attribute("square");
                  Console.WriteLine();
                  foreach(var el in items)
                  {
                      Console.WriteLine(el);
                  }
       */