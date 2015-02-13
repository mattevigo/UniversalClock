using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UniversalClock
{
    public sealed partial class ClockControl : UserControl
    {
        public static DependencyProperty AnalogClockEnabledProperty = DependencyProperty.Register("AnalogClockEnabled", typeof(bool), typeof(ClockControl), new PropertyMetadata(true));
        public static DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(ClockControl), new PropertyMetadata("Clock"));
        public static DependencyProperty TimeProperty = DependencyProperty.Register("Time", typeof(DateTime), typeof(ClockControl), new PropertyMetadata(DateTime.Now, new PropertyChangedCallback(Time_Callback)));

        public bool AnalogClockEnabled
        {
            get { return (bool)GetValue(AnalogClockEnabledProperty); }
            set { SetValue(AnalogClockEnabledProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public DateTime Time
        {
            get { return (DateTime)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public ClockControl()
        {
            this.InitializeComponent();
        }

        private static void Time_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DateTime dt = (DateTime)e.NewValue;
            double angle = CalculateSecondsAngle(dt);

 	        Debug.WriteLine("({0} -> {1}) Angle: {2}", e.OldValue, e.NewValue, angle);

            ClockControl cc = (ClockControl)d;
            if(angle == 0)
            {
                Debug.WriteLine("Zero!");

                cc.daSecondsAnimation.From = 354;
                cc.daSecondsAnimation.To = 360;

                // Animazione Minuti
                var mAngle = CalculateMinutesAngle((DateTime) e.NewValue);

                Debug.WriteLine("Minutes: {0}, Angle: {1}", dt.Minute, mAngle);

                cc.daMinutesAnimation.From = mAngle == 0 ? 354 : mAngle - 6;
                cc.daMinutesAnimation.To = mAngle == 0 ? 360 : mAngle;

                // Animazione Ore
                var hAngle = CalculateHoursAngle(dt);

                Debug.WriteLine("Hours: {0}, Angle: {1}", dt.Hour, hAngle);

                cc.daHoursAnimation.From = hAngle == 0 ? 0 : cc.daHoursAnimation.From;
                cc.daHoursAnimation.To = hAngle;  
            }
            else if(angle >= 6)
            {
                cc.daSecondsAnimation.From = angle - 6;
                cc.daSecondsAnimation.To = angle;

                cc.daMinutesAnimation.From = cc.daMinutesAnimation.To;
            }

            cc.sClockAnimation.Begin();
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            // Posizione Lancette
            var dt = DateTime.Now;

            Debug.WriteLine("Inizializzazione orologio: {0}", dt);

            var sAngle = CalculateSecondsAngle(dt);
            var mAngle = CalculateMinutesAngle(dt);
            var hAngle = CalculateHoursAngle(dt);

            Debug.WriteLine("sAngle: {0}", sAngle);
            Debug.WriteLine("mAngle: {0}", mAngle);
            Debug.WriteLine("hAngle: {0}", hAngle);

            daSecondsSetupAnimation.From = 0;
            daSecondsSetupAnimation.To = sAngle;

            daMinutesSetupAnimation.From = 0;
            daMinutesSetupAnimation.To = mAngle;
            daMinutesAnimation.To = mAngle;

            daHoursSetupAnimation.From = 0;
            daHoursSetupAnimation.To = hAngle;
            daHoursAnimation.To = hAngle;

            sClockSetupAnimation.Begin();

            DispatcherTimer t = new DispatcherTimer();
            t.Tick += t_Tick;
            t.Interval = new TimeSpan(0, 0, 1);
            t.Start();
        }

        void t_Tick(object sender, object e)
        {
            Debug.WriteLine("{0}", DateTime.Now);
            //Time = Time.Add(new TimeSpan(0, 0, 1));
            Time = DateTime.Now;
        }

        #region Calculation

        private static double CalculateSecondsAngle(DateTime dt)
        {
            return dt.Second == 0 ? 0D : ((double)dt.Second) * 6;
        }

        private static double CalculateMinutesAngle(DateTime dt)
        {
            return dt.Minute == 0 ? 0D : ((double)dt.Minute) * 6;
        }

        private static double CalculateHoursAngle(DateTime dt)
        {
            return (((double)dt.Hour) % 12) * 30 + (((double)dt.Minute) / 60) * 30;
        }

        #endregion
    }
}
