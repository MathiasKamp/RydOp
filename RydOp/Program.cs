using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Threading;

namespace RydOp
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiation of HardDrive object
            HardDrive hardDrive = new HardDrive();
            //instantiation of OperationSystem object
            OperatingSystem os = new OperatingSystem();
            //instantiation of Cpu object
            Cpu cpu = new Cpu();
            //call of GetDiskMetadata method
            hardDrive.GetDiskMetadata();
            //call of GetHardDiskSerialNumber method
            hardDrive.GetDiskSerialNumber();
            //wait 2 sekunds before continuing through the code
            Thread.Sleep(2000);
            //call GetCpuCore method
            cpu.GetCpuCore();
            //wait 2 sekunds before continuing through the code
            Thread.Sleep(2000);
            //call GetMainStorage method
            hardDrive.GetMainStorage();
            //wait 2 sekunds before continuing through the code
            Thread.Sleep(2000);
            // call GetOsInformation method
            os.GetOsInformation();
            //wait 2 sekunds before continuing through the code
            Thread.Sleep(2000);
            os.GetBootDevice();
            //wait 2 sekunds before continuing through the code
            Thread.Sleep(2000);
            Console.WriteLine("Process searching");
            //wait 4 sekunds before continuing through the code
            Thread.Sleep(4000);
            //call ListAllServices
            os.ListAllServices();
            Console.ReadKey();
        }
    }
}