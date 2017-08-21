namespace cpuUsageMonitor.Utilities
{
    using System;
    using System.Diagnostics;
    using System.Timers;

    public class RamUtil
    {
        public EventHandler<PerformanceCounterEventArgs> PerformanceCounterEventHandler;

        private readonly PerformanceCounter _ramPerfCounter = new PerformanceCounter("Memory", "Available MBytes", true);

        private readonly Timer t = new Timer();

        public RamUtil(int interval = 500)
        {
            this.t.Elapsed += PerfCounterUpdate;
            this.t.Interval = interval;
            this.t.Start();
        }

        ~RamUtil()
        {
            this.t.Stop();
            this.t.Dispose();

            this._ramPerfCounter.Close();
            this._ramPerfCounter.Dispose();
        }

        protected virtual void OnPerfCounterUpdate(PerformanceCounterEventArgs e)
        {
            PerformanceCounterEventHandler?.Invoke(this, e);
        }

        private void PerfCounterUpdate(object sender, ElapsedEventArgs e)
        {
            PerformanceCounterEventArgs ea = new PerformanceCounterEventArgs()
            {
                RAMValue = _ramPerfCounter.NextValue()
            };

            OnPerfCounterUpdate(ea);
        }
    }
}