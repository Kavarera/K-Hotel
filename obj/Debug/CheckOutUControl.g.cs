﻿#pragma checksum "..\..\CheckOutUControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "70DCD46CEA56047247691CEEF9816A5D0810F997C9D0CDF23853B063AE8289F3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HotelApp;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace HotelApp {
    
    
    /// <summary>
    /// CheckOutUControl
    /// </summary>
    public partial class CheckOutUControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\CheckOutUControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HotelApp.CheckOutUControl COUControl;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\CheckOutUControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_RoomNumber;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\CheckOutUControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_RoomType;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\CheckOutUControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Name;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\CheckOutUControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_CheckIn;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\CheckOutUControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_CheckOut;
        
        #line default
        #line hidden
        
        
        #line 165 "..\..\CheckOutUControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Submit_btn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HotelApp;component/checkoutucontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CheckOutUControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.COUControl = ((HotelApp.CheckOutUControl)(target));
            return;
            case 2:
            this.tb_RoomNumber = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\CheckOutUControl.xaml"
            this.tb_RoomNumber.KeyDown += new System.Windows.Input.KeyEventHandler(this.tb_RoomNumber_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tb_RoomType = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tb_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tb_CheckIn = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tb_CheckOut = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Submit_btn = ((System.Windows.Controls.Button)(target));
            
            #line 166 "..\..\CheckOutUControl.xaml"
            this.Submit_btn.Click += new System.Windows.RoutedEventHandler(this.Submit_btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
