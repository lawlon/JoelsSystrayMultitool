namespace cpuUsageMonitor.Utilities
{
    using System;
    using System.Diagnostics;
    using System.Timers;

    public class CpuUtil
    {
        public EventHandler<PerformanceCounterEventArgs> PerformanceCounterEventHandler;

        private readonly PerformanceCounter _cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);

        private readonly Timer t = new Timer();

        public CpuUtil(int interval = 500)
        {
            this.t.Elapsed += PerfCounterUpdate;
            this.t.Interval = interval;
            this.t.Start();
        }

        ~CpuUtil()
        {
            this.t.Stop();
            this.t.Dispose();

            this._cpuUsage.Close();
            this._cpuUsage.Dispose();
        }

        protected virtual void OnPerfCounterUpdate(PerformanceCounterEventArgs e)
        {
            PerformanceCounterEventHandler?.Invoke(this, e);
        }

        private void PerfCounterUpdate(object sender, ElapsedEventArgs e)
        {
            PerformanceCounterEventArgs ea = new PerformanceCounterEventArgs()
            {
                CPUValue = _cpuUsage.NextValue()
            };

            OnPerfCounterUpdate(ea);
        }
    }
}