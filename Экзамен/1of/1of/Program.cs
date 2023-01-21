using System;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace oneof
{
    public class MuchMoneyException: Exception { 
        public MuchMoneyException(string message): base(message)  
        { }
    }
    public class NoToDeleteFromWalletException : Exception { 
    public NoToDeleteFromWalletException(string message): base(message)
        {

        }
    }

    public interface Inumber
    {
        public int Number
        {
            get;
            set;

        }
    }
    [Serializable]
    public class Bill : Inumber
    {

        public Bill(int n) {
            Number = n;
            }
        private int number = 0;
        public int Number
        {
            get
            {
               return number;
            }
            set
            {
                if (value == 10 || value == 50 || value == 100 || value == 20)
                    number = value;
                else
                    Console.WriteLine("Неверный номинал!");
            }
        }

    }
    [Serializable]
    public class Wallet<Т>
    {

        public List<Bill> BillList = new List<Bill>();

        public Wallet(Bill b ){
            BillList.Add(b);
            }
        public void AddBill(Bill b) {
            int sum = 0;
            var coll = BillList.ToArray();
            foreach(var el in coll)
            {
                sum += el.Number;
            }
            if (sum > 100)
            {
                throw new MuchMoneyException("Избыток денег");
            }
            else
                BillList.Add(b);
        }
        public void RemoveBill(Bill b) {
            if (!BillList.Contains(b))
            {
                throw new NoToDeleteFromWalletException("Такие купюры отсутствуют");
            }
            else
                BillList.Remove(b);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var bill = new Bill(10);
            bill.Number = 60;
            Console.WriteLine(bill.Number);
            Console.WriteLine();
            var bill2 = new Bill(50);
            var bill3 = new Bill(20);
            var billcoll = new Wallet<Bill>(bill2);
            try
            {
                billcoll.AddBill(bill3);
                billcoll.AddBill(bill);
                billcoll.AddBill(bill);
                billcoll.AddBill(bill2);
                billcoll.AddBill(bill2);
            }
            catch(MuchMoneyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                billcoll.RemoveBill(bill3);
                billcoll.RemoveBill(bill3);
            }
            catch (NoToDeleteFromWalletException ex)
            {
                Console.WriteLine(ex.Message);
            }

            var bf = new BinaryFormatter();
            using (FileStream fx = new FileStream("arxxxx.bin",FileMode.OpenOrCreate))
            {
                bf.Serialize(fx, billcoll);

            }
            Console.WriteLine("Сериализация выполнена!");
            var el1 = billcoll.BillList
                .Where(b => b.Number == 10)
                .Sum(b => b.Number);
            var el2 = billcoll.BillList
               .Where(b => b.Number == 20)
               .Sum(b => b.Number);
            var el3 = billcoll.BillList
               .Where(b => b.Number == 50)
               .Sum(b => b.Number);
            var el4 = billcoll.BillList
               .Where(b => b.Number == 100)
               .Sum(b => b.Number);
            Console.WriteLine("Сумма 10 = " + el1 + ", Сумма 20 = " + el2 + ", Сумма 50 = " + el3 + ", Сумма 100 = " + el4);

        }
    }
}
