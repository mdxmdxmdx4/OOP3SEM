 
namespace Program
{
    public partial class Airline
    {

        /*        Пункт назначения,
                  Номер рейса,
                  Тип самолета, 
                  Время вылета,
                  Дни недели
        */
        /*  private static int minimumAge;
          private string? last;
          private string? first;
          public Airline(string last, string first) 
          { }

          static Airline()
          {
              minimumAge = 18;
          }

  */
        private string destination;
        private int numberAirline;
        private string? model;

        public Airline(string destination, int numberAirline, string model)
        {
            this.destination = destination;
            this.numberAirline = numberAirline;
            this.model = model;
        }

        public Airline(string destination, int numberAirline)
        {
            this.destination = destination;
            this.numberAirline = numberAirline;
            model = null;
        }

        public Airline()
        {

        }
 
    
    }

    public class Programm
    {
        public static void Main()
        {
            var a1 = new Airline();
            var a2 = new Airline("dawd", 313);
            var a3 = new Airline("dwadw", 2131, "car");
        }
    }
}