﻿#pragma checksum "..\..\..\..\..\MVVM\Views\MainWindowView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5727CE4E7104D5406CEA931173864AABDCA16180"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.Sharp;
using FontAwesome.WPF;
using PresentationLayer.MVVM.ViewModels;
using PresentationLayer.MVVM.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace PresentationLayer.MVVM.Views {
    
    
    /// <summary>
    /// MainWindowView
    /// </summary>
    public partial class MainWindowView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 89 "..\..\..\..\..\MVVM\Views\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel WindowControlPanel;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\..\MVVM\Views\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonClose;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\..\..\MVVM\Views\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonMaximize;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\..\..\MVVM\Views\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonMinimize;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\..\..\MVVM\Views\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer ScrollviewerMenuPanelbuttons;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\..\..\MVVM\Views\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridHeaderMenuPanelButtons;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\..\..\MVVM\Views\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ButtonConnection;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\..\..\MVVM\Views\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ButtonServerUsers;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\..\..\..\MVVM\Views\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ButtonChatRooms;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\..\..\..\MVVM\Views\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl ContentControlChildViews;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PresentationLayer;component/mvvm/views/mainwindowview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\Views\MainWindowView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.WindowControlPanel = ((System.Windows.Controls.StackPanel)(target));
            
            #line 95 "..\..\..\..\..\MVVM\Views\MainWindowView.xaml"
            this.WindowControlPanel.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.WindowControlPanel_MouseLeftButtonDown_1);
            
            #line default
            #line hidden
            
            #line 96 "..\..\..\..\..\MVVM\Views\MainWindowView.xaml"
            this.WindowControlPanel.MouseEnter += new System.Windows.Input.MouseEventHandler(this.WindowControlPanel_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ButtonClose = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\..\..\..\MVVM\Views\MainWindowView.xaml"
            this.ButtonClose.Click += new System.Windows.RoutedEventHandler(this.ButtonClose_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ButtonMaximize = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\..\..\..\MVVM\Views\MainWindowView.xaml"
            this.ButtonMaximize.Click += new System.Windows.RoutedEventHandler(this.ButtonMaximize_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\..\..\..\MVVM\Views\MainWindowView.xaml"
            this.ButtonMinimize.Click += new System.Windows.RoutedEventHandler(this.ButtonMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ScrollviewerMenuPanelbuttons = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 6:
            this.GridHeaderMenuPanelButtons = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.ButtonConnection = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.ButtonServerUsers = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.ButtonChatRooms = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 10:
            this.ContentControlChildViews = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
