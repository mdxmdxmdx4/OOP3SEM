using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace Lab13
{
    public static class CustomSerializer
    {
        public static void Serialize(string file, Continent[] obj)
        {
            var format = file.Split('.').Last();
            switch (format)
            {
                case "bin":
                    var bf = new BinaryFormatter();
                    using (var fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        bf.Serialize(fs, obj);
                    }
                    Console.WriteLine("Выполнена cериализация в BIN");

                    break;

                /*case "soap":
                    SoapFormatter sf = new SoapFormatter();
                    using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        sf.Serialize(fs, human);
                    }
                    break;*/

                case "xml":
                    var xs = new XmlSerializer(typeof(Sea[]));
                    using (var fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        xs.Serialize(fs, obj);
                    }
                    Console.WriteLine("\nВыполнена Сериализация в XML");

                    break;

                case "json":
                    var json = new DataContractJsonSerializer(typeof(Continent[]));
                    using (var fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        json.WriteObject(fs, obj);
                    }
                    Console.WriteLine("\nВыполнена сериализация в JSON");
                    break;
            }
        }

        public static void Deserialize(string file)
        {
            var format = file.Split('.').Last();
            switch (format)
            {
                case "bin":
                    Console.WriteLine("Десериализация из BIN:");
                    var bf = new BinaryFormatter();
                    using (var fs = new FileStream(file, FileMode.Open))
                    {
                        var human = (Sea[])bf.Deserialize(fs);
                        foreach (var h in human)
                        {
                            Console.WriteLine(h.ToString());
                        }
                    }

                    break;

                /*case "soap":
                    SoapFormatter sf = new SoapFormatter();
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        Human human = (Human)sf.Deserialize(fs);
                    }
                    break;*/

                case "xml":
                    Console.WriteLine("Десериализация из XML:");
                    var xml = new XmlSerializer(typeof(Sea[]));
                    using (var fx = new FileStream(file, FileMode.Open))
                    {
                        var human = (Sea[])xml.Deserialize(fx)!;
                        foreach (var h in human)
                        {
                            Console.WriteLine(h);
                        }
                    }

                    break;

                case "json":
                    Console.WriteLine("Десериализация из JSON:");
                    var json = new DataContractJsonSerializer(typeof(Continent[]));
                    using (var fs = new FileStream(file, FileMode.Open))
                    {
                        var human = (Continent[])json.ReadObject(fs)!;
                        foreach (var h in human)
                        {
                            Console.WriteLine(h.ToString());
                        }
                    }

                    break;
            }
        }
    }
}

