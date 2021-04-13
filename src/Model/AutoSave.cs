using System;
using Windows.UI.Xaml;

namespace Ficha
{
    /*
    public static class AutoSave
    {
        public static DispatcherTimer Timer { get; set; } = new DispatcherTimer();

        
        public static void SetInverval(AutoSaveInterval interval)
        {
            switch (interval)
            {
                case AutoSaveInterval.ten_seconds:
                    Timer.Interval = TimeSpan.FromSeconds(10);
                    break;
                case AutoSaveInterval.thirty_seconds:
                    Timer.Interval = TimeSpan.FromSeconds(30);
                    break;
                case AutoSaveInterval.one_minute:
                    Timer.Interval = TimeSpan.FromMinutes(1);
                    break;
                case AutoSaveInterval.five_minutes:
                    Timer.Interval = TimeSpan.FromMinutes(5);
                    break;
            }
        }
        public static void StartTimer()
        {
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        private static void Timer_Tick(object sender, object e)
        {
            ConfigViewModel.Save();
        }
    }
    public enum AutoSaveInterval
    {
        ten_seconds,
        thirty_seconds,
        one_minute,
        five_minutes
    }*/
}
