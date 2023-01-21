

using System.Collections;

namespace ofeight
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Item(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public void OnSale()
        {
            Price /= 2;
            Console.WriteLine("Цена на скидке "  + Price);
        }
    }

    public class Shop : IEnumerable<Item>
    {
        public Queue<Item> queue = new Queue<Item>();
        public void Add(Item item)
        {
            queue.Enqueue(item);
        }
        public void Delete(Item it)
        {
            var el = queue.ToList();
            el.Remove(it);
            Queue<Item> asd = new Queue<Item>(el);
            queue = asd;

        }
        public void Clear()
        {
            queue.Clear();
        }
        public override string ToString()
        {
            return $"Коллекция Queue<Item>, кол-во элементов {this.queue.Count} ";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Queue<Item> == true)
            {
                var a = obj as Queue<Item>;
                if (this.queue.Count == a.Count)
                    return true;
                else return false;
            }
            return false;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static Shop operator +(Shop s1, Item el)
        {
            s1.Add(el);
            Console.WriteLine("Переопределение +");
            return s1;

        }
        public static Shop operator -(Shop s1, Item el)
        {
            s1.Delete(el);
            Console.WriteLine("Переопределение -");
            return s1;

        }
    }
    public delegate void SaleEventHandler();
    public class Manager { 
    public event SaleEventHandler Sale;
    public void StartSale()
        {
            Sale.Invoke();
            Console.WriteLine("Скидка началась!");
        }

    }



    public class Program
    {
        public static void Main()
        {
            var s1 = new Item(1, "Door", 2000);
            var s2 = new Item(2, "Pen", 5);
            var s3 = new Item(3, "Yeezy boost", 799);
            var s4 = new Item(4, "MP-5", 34500);
            var shop = new Shop();
            shop.Add(s1);
            shop.Add(s2);
            shop.Add(s3);
            shop.Add(s4);
            foreach (var item in shop)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(shop.ToString());
            shop.Clear();
            Console.WriteLine(shop.ToString());
            shop += s2;
            shop -= s2;
            Console.WriteLine(shop.ToString());
            shop.Add(s1);
            shop.Add(s2);
            shop.Add(s3);
            shop.Add(s4);
            var Manager = new Manager();
            Manager.Sale += s2.OnSale;
            Manager.Sale += s4.OnSale;
            Manager.StartSale();

            var res = shop
                .Where(n => n.Name == "MP-5")
                .Select(n => n.Price);
            int n = res.ToList().ElementAt(0);
            Console.WriteLine("Стоимость MP-5 = " + n);


            




        }
    }

}