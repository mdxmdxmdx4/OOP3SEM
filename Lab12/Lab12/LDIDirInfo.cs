using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public static class LDIFDirInfo
    {
        public static void DirectoryInfo(string path)
        {
            if(Directory.Exists(path))
            {
                string[] dirs = Directory.GetFiles(path);
                Console.WriteLine("Кол-во файлов: " + dirs.Length);
                Console.WriteLine("Время создания: " + Directory.GetCreationTime(path));
                string[] subdirs = Directory.GetDirectories(path);
                Console.WriteLine("Кол-во подпапок:" + subdirs.Length);
                var a =  Directory.GetParent(path);
                Console.WriteLine("Родительская папка: " + a);
                LDILog.WriteLogs("LDIFDirInfo.DirectoryInfo", "", path);
            }
            else
            {
                Console.WriteLine("Неверно задано имя или папка не существет");
            }
        }

    }
}
