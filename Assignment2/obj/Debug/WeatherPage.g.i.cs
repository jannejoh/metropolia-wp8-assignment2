﻿

#pragma checksum "C:\Users\Janne\Documents\Visual Studio 2013\Projects\Assignment2\Assignment2\WeatherPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8CAE4F59F751D93444711A0BABF10F60"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment2
{
    partial class WeatherPage : global::Windows.UI.Xaml.Controls.Page
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock TitleNow; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock ConditionNow; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock TitleTomorrow; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock ConditionTomorrow; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///WeatherPage.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            TitleNow = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("TitleNow");
            ConditionNow = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("ConditionNow");
            TitleTomorrow = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("TitleTomorrow");
            ConditionTomorrow = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("ConditionTomorrow");
        }
    }
}



