using System;
using System.Management;

namespace RydOp
{
    public class OperatingSystem
    {
        // Method GetOsInformation returns the information about which user is logged into the pc
        // it will return which operation system that is installed and on what location.
        public void GetOsInformation()
        {
            // create a wqlQuery to select all from win32_OperationSystem
            ObjectQuery wqlQuery = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            // Create a osInformationSearcher to search with the wqlQuery 
            ManagementObjectSearcher osInformationSearcher = new ManagementObjectSearcher(wqlQuery);
            // create a osInformationCollector that stores the information from osInformationSearcher
            ManagementObjectCollection osInformationCollector = osInformationSearcher.Get();
            // enumerate the osInformationCollector 
            foreach (ManagementObject osInformation in osInformationCollector)
            {
                // acrss properties of the osInformationCollector object
                Console.WriteLine("User:\t{0}", osInformation["RegisteredUser"]);
                Console.WriteLine("Org.:\t{0}", osInformation["Organization"]);
                Console.WriteLine("O/S :\t{0}", osInformation["Name"]);
            }
        }

        // method GetBootDevice returns the information about which hardDrive is the boot device
        public void GetBootDevice()
        {
            Console.WriteLine("GetBootDevice start");
            // create scope for bootDevice
            ManagementScope bootDeviceScope = new ManagementScope("\\\\.\\ROOT\\cimv2");

            //create bootDeviceQuery to select boot device
            ObjectQuery bootDeviceQuery = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");

            //create bootDeviceSearcher searcher
            ManagementObjectSearcher bootDeviceSearcher =
                new ManagementObjectSearcher(bootDeviceScope, bootDeviceQuery);

            //get a collection of WMI objects
            ManagementObjectCollection bootDeviceCollector = bootDeviceSearcher.Get();

            //enumerate the collection.
            foreach (ManagementObject bootDevice in bootDeviceCollector)
            {
                // access properties of the WMI object
                Console.WriteLine("BootDevice : {0}", bootDevice["BootDevice"]);
            }

            Console.WriteLine("GetBootDevice end");
        }

        // method to show all services
        public void ListAllServices()
        {
            // create scope listServicesScope
            ManagementScope listServicesScope = new ManagementScope("\\\\.\\ROOT\\cimv2");
            //create Query listServicesQuery that selects all from win32_services
            ObjectQuery listServicesQuery = new ObjectQuery("SELECT * FROM Win32_Service");
            // create windowsServiceSearcher that uses listServicesScope and listServicesQuery as parameter
            ManagementObjectSearcher windowsServicesSearcher =
                new ManagementObjectSearcher(listServicesScope, listServicesQuery);
            // create windowsServiceCollector that stores the objects that the windowsServicesSearcher has found
            ManagementObjectCollection windowsServiceCollector = windowsServicesSearcher.Get();
            // prints out how many services that are stored in the windowsServiceCollector
            Console.WriteLine("There are {0} Windows services: ", windowsServiceCollector.Count);
            // this line sets the Bufferheight of console to 32766 = its maximum value. so that i can print out all information
            // on console without it cutting the first lines that it prints out.
            Console.BufferHeight = 32766;
            // enumerate through windowsServiceColletor
            foreach (ManagementObject windowsService in windowsServiceCollector)
            {
                // takes the properties of windowsService and stores it in serviceProperties dataCollection
                PropertyDataCollection serviceProperties = windowsService.Properties;
                // enumerate  through serviceProperties
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    // checks if theres still properties left in the serviceProperty dataCollection
                    if (serviceProperty.Value != null)
                    {
                        // print out the properties
                        Console.WriteLine("Windows service property name: {0}", serviceProperty.Name);
                        Console.WriteLine("Windows service property value: {0}", serviceProperty.Value);
                    }
                }

                Console.WriteLine("---------------------------------------");
            }
        }
    }
}