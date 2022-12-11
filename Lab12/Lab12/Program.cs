

namespace Lab12
{
    class Program
    {
        static void Main()
        {
            LDIDiskInfo.DiskInfo();
            Console.WriteLine();
            LDIFDirInfo.DirectoryInfo("C://Users/mdxbu/Labs");
            Console.WriteLine();
            LDIFileInfo.FileInfo("C://Users/mdxbu/Downloads/Genesis Xenon 200 rev.2.0 software v1.3.zip");
            LDIFileManager.taskA("C://");
            LDIFileManager.taskB("C://Users/mdxbu/Labs/OOP/Лекции", "*.pdf");
        }
    }
}