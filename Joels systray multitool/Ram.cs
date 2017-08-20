namespace cpuUsageMonitor
{
    public class Ram
    {
        public static ulong GetTotalMemoryInBytes()
        {
            return new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
        }
    }
}