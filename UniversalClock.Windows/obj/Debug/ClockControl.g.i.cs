﻿

#pragma checksum "C:\Users\Matteo Vigoni\Documents\Visual Studio 2013\Projects\UniversalClock\UniversalClock\UniversalClock.Shared\ClockControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DB2482BF9C226C6B68572FBDABE33A57"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniversalClock
{
    partial class ClockControl : global::Windows.UI.Xaml.Controls.UserControl
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.UserControl control; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.Animation.Storyboard sClockAnimation; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.Animation.DoubleAnimation daSecondsAnimation; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.RotateTransform rtHours; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.RotateTransform rtMinutes; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.RotateTransform rtSeconds; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///ClockControl.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            control = (global::Windows.UI.Xaml.Controls.UserControl)this.FindName("control");
            sClockAnimation = (global::Windows.UI.Xaml.Media.Animation.Storyboard)this.FindName("sClockAnimation");
            daSecondsAnimation = (global::Windows.UI.Xaml.Media.Animation.DoubleAnimation)this.FindName("daSecondsAnimation");
            rtHours = (global::Windows.UI.Xaml.Media.RotateTransform)this.FindName("rtHours");
            rtMinutes = (global::Windows.UI.Xaml.Media.RotateTransform)this.FindName("rtMinutes");
            rtSeconds = (global::Windows.UI.Xaml.Media.RotateTransform)this.FindName("rtSeconds");
        }
    }
}



