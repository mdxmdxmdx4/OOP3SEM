using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public static class LDIFileInfo
    {
        public static void FileInfo(string path)
        {
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                Console.WriteLine("Полный путь: " + fi.FullName);
                Console.WriteLine("Размер: " + fi.Length);
                Console.WriteLine("Расширение: " + fi.Extension);
                Console.WriteLine("Название: " + fi.Name);
                Console.WriteLine("Дата создания:" + fi.CreationTime);
                Console.WriteLine("Дата последнего изменения: " + fi.LastWriteTime);

            }


        }

    }
}
