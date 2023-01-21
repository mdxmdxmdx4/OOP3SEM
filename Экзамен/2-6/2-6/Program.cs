using System.Runtime.Serialization.Formatters.Binary;

namespace lastone
{
    [Serializable]
    public enum fStatus
    {
        signin,
        signout
    }
    [Serializable]
    public class User : IComparable<User> 
    {
        public User(string passw, string e, fStatus st)
        {
            email = e;
            password = passw;
            status = st;

        }
    private string email;
        private string password;
        public fStatus status;
        public override bool Equals(object? obj)
        {
            var el = obj as User;
            return el.email == this.email && el.password == this.password;

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return this.email + ' ' + status.ToString(); 
        }

        public int CompareTo(User? other)
        {
            if (other.email == this.email)
                return 0;
            if (other.email.Length == this.email.Length)
                return -1;
            return 1;
        }
    }
    [Serializable]
    public class WebNet
    {
        public LinkedList<User> coll = new LinkedList<User>();
        public void Add(User el)
        {
            coll.AddLast(el);
        }
        public void Delete(User el)
        {
            coll.Remove(el);
        }
    }

    public class Program {
    public static void Main()
        {
            var user1 = new User("123141","drach@mail.ru", fStatus.signout);
            var user2 = new User("qwerrty", "parts@gmail.com", fStatus.signout);
            var user3 = new User("ju#qwn%4A3", "IGNno-reply@mail.com", fStatus.signin);
            var user4 = new User("NSDOUCNU13", "drach@mail.ru", fStatus.signin);
            var user5 = new User("123NO%^&DFA", "finargot@dota2.vo", fStatus.signout);
            Console.WriteLine(user1.CompareTo(user2));
            Console.WriteLine(user1.CompareTo(user4));
            Console.WriteLine(user1.CompareTo(user4));
            Console.WriteLine(user1);
            Console.WriteLine(user1.Equals(user3));
            var github = new WebNet();
            github.Add(user1);
            github.Add(user2);
            github.Add(user3);
            github.Add(user4);
            github.Add(user5);
            var res = github.coll
                .Count(n => n.Equals(n));
            Console.WriteLine(Convert.ToInt32(res));
            var bf = new BinaryFormatter();
            using(var fs = new FileStream("asda.txt", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, github);
            }
                


        }
    
    }





}