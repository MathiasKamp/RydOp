using System;
using System.Management;

namespace RydOp
{
    public class Cpu
    {
        // GetCpuCore method prints out the core number and its current usage value
        public void GetCpuCore()
        {
            // create cpuCoreQuery that selects all from Win32_PerfFormattedData_PerfOS_Processor
            ObjectQuery cpuCoreQuery = new ObjectQuery("select * from Win32_PerfFormattedData_PerfOS_Processor");
            // create cpuCoreSearcher that takes cpuCoreQuery as parameter
            ManagementObjectSearcher cpuCoreSearcher = new ManagementObjectSearcher(cpuCoreQuery);
            ManagementObjectCollection cpuCoreCollector = cpuCoreSearcher.Get();
            // enumerate through cpuCore
            foreach (ManagementObject cpuCore in cpuCoreCollector)
            {
                // variable usage that stores the percentProcessortime
                var usage = cpuCore["PercentProcessorTime"];
                // variable name that stores the cpu core name (core number)
                var name = cpuCore["Name"];
                // print out the core number and usage
                Console.WriteLine("CPU " + name + " : " + "Usage " + usage);
            }
        }
    }
}