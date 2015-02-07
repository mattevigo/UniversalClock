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
            double angle = ((DateTime)e.NewValue).Second * 6;

 	        Debug.WriteLine("({0} -> {1}) Angle: {2}", e.OldValue, e.NewValue, angle);

            ClockControl cc = (ClockControl)d;
            if(angle == 0)
            {
                Debug.WriteLine("Zero!");
                cc.daSecondsAnimation.From = 354;
                cc.daSecondsAnimation.To = 360;
            }
            else if(angle >= 6)
            {
                cc.daSecondsAnimation.From = angle - 6;
                cc.daSecondsAnimation.To = angle;
            }

            cc.sClockAnimation.Begin();
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer t = new DispatcherTimer();
            t.Tick += t_Tick;
            t.Interval = new TimeSpan(0, 0, 1);
            t.Start();
        }

        void t_Tick(object sender, object e)
        {
            Debug.WriteLine("{0}", DateTime.Now);
            Time = Time.Add(new TimeSpan(0, 0, 1));
        }

        private async void Tick(object state)
        {
            //Debug.WriteLine("{0}", DateTime.Now);
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () => { Time = Time.Add(new TimeSpan(0, 0, 1)); });
        }
    }
}
