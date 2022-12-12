using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class LDILog
    {
        public static StreamWriter? LogF;
        public static void WriteLogs(string action, string filename, string path)
        {
            using (LogF = new StreamWriter(@"C:\Users\mdxbu\Labs\OOP\Lab12\LDIlog.txt", true))
            {
                LogF.WriteLine("-_-_-_-_-_-_-_-_-_-_-\n");
                var time = DateTime.Now;
                LogF.WriteLine($"Действие: {action}");
                if (filename.Length != 0)
                    LogF.WriteLine($"Файл: {filename}");
                if (path.Length != 0)
                    LogF.WriteLine($"Путь: {path}");
                LogF.WriteLine($"Дата и время: {time.ToLocalTime()}");
            }

        }

        public static void FindByDateTime(DateTime date)
        {
            using (var reader = new StringReader(File.ReadAllText(@"C:\Users\mdxbu\Labs\OOP\Lab12\LDIlog.txt")))
            {
                bool y = false;
                var strs = reader.ReadToEnd().Split("-_-_-_-_-_-_-_-_-_-_-\n");
                foreach(var a in strs)
                {
                    if (a.Contains(date.ToString()))
                    {
                        Console.WriteLine("Найдена запись : " + a);
                        y = true;
                    }
                    else if (a.Contains(date.Date.ToString()) && a.Contains(date.Hour.ToString()) && a.Contains(date.Minute.ToString()))
                    {
                        y = true;
                        Console.WriteLine("Найдена запись : " + a);
                    }
                    else if (a.Contains(date.Day.ToString()) && a.Contains(date.Month.ToString()) && a.Contains(date.Year.ToString()))
                    {
                        Console.WriteLine("Найдена запись : " + a);
                    }
                }
                if (y == false)
                {
                    Console.WriteLine("Для заданной даты записи отсутствуют");
                }

            }
        }

    }
}
