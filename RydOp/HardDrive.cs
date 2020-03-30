using System;
using System.Management;
using System.Runtime.CompilerServices;

namespace RydOp
{
    public class HardDrive
    {
        // GetDiskMetaData gets the values of the c drive 
        // and prints out the disk name, free space and disk size.
        public void GetDiskMetadata()
        {
            // create diskMetaDataScope
            ManagementScope diskMetaDataScope = new ManagementScope();
            // create diskMetaDataQuery to select freeSpace size and name from win32_LogicalDisk where DriveType=3
            ObjectQuery diskMetaDataQuery =
                new ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");
            // create diskMetaDataSearcher that takes diskMetaDataScope and diskMetaDataQuery as parameter
            ManagementObjectSearcher diskMetaDataSearcher =
                new ManagementObjectSearcher(diskMetaDataScope, diskMetaDataQuery);
            // create diskMetaDataCollector that collects the data from diskMetaDataSearcher
            ManagementObjectCollection diskMetaDataCollector = diskMetaDataSearcher.Get();
            // enumerate through diskMetaDataCollector
            foreach (ManagementObject diskMetaData in diskMetaDataCollector)

            {
                // print out diskMetaData properties of name, freeSpace and size
                Console.WriteLine("Disk Name : " +
                                  diskMetaData["Name"]); // .toString() was unnecessary and has been deleted

                Console.WriteLine("FreeSpace: " +
                                  diskMetaData["FreeSpace"]); // .toString() was unnecessary and has been deleted

                Console.WriteLine("Disk Size: " +
                                  diskMetaData["Size"]); // .toString() was unnecessary and has been deleted

                Console.WriteLine("---------------------------------------------------");
            }
        }

        // method GetDiskSerialNumber returns the serial number of c drive
        public string GetDiskSerialNumber(string drive = "C")

        {
            // create mainHardDrive object that has the path of c drive as parameter
            ManagementObject mainHardDrive = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");
            // call method mainHardDrive.get() 
            mainHardDrive.Get();
            // print out the serial number of c drive
            Console.WriteLine(mainHardDrive["VolumeSerialNumber"].ToString());
            // return the seriel number
            return mainHardDrive["VolumeSerialNumber"].ToString();
        }

        // method GetMainStorage returns the total free visible memory and physical memory, total virtual Memory, and free virtual memory
        public void GetMainStorage()
        {
            // create a wqlMainStorage Query that selects all from win32_OperationSystem
            ObjectQuery wqlMainStorage = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            // create mainStorageSearcher that takes wqlMainStorage as parameter
            ManagementObjectSearcher mainStorageSearcher = new ManagementObjectSearcher(wqlMainStorage);
            // create mainStorageCollector that stores the information from mainStorageSearcher
            ManagementObjectCollection mainStorageCollector = mainStorageSearcher.Get();
            // enumerate through mainStorageCollector 
            foreach (ManagementObject mainStorageInformation in mainStorageCollector)
            {
                // acess the visible memory, physical memory, virtual memory properties and print out the values.
                Console.WriteLine("Total Visible Memory: {0}KB", mainStorageInformation["TotalVisibleMemorySize"]);
                Console.WriteLine("Free Physical Memory: {0}KB", mainStorageInformation["FreePhysicalMemory"]);
                Console.WriteLine("Total Virtual Memory: {0}KB", mainStorageInformation["TotalVirtualMemorySize"]);
                Console.WriteLine("Free Virtual Memory: {0}KB", mainStorageInformation["FreeVirtualMemory"]);
            }
        }
    }
}