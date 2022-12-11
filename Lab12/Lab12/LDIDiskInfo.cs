using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public static class LDIDiskInfo
    {
        public static void DiskInfo()
        {
            var allDrivers = DriveInfo.GetDrives();
            foreach(var el in allDrivers)
            {
                Console.WriteLine($"Имя диска: {el.Name}");
                if (!el.IsReady) continue;
                Console.WriteLine($"Метка тома: {el.VolumeLabel}");
                Console.WriteLine($"Файловая система:{el.DriveFormat}");
                Console.WriteLine($"Общая ёмкость  {el.TotalSize}");
                Console.WriteLine($"Свободно места: {el.TotalFreeSpace}");
                Console.WriteLine($"Доступно: {el.AvailableFreeSpace}");
            }
        }

    }
}
