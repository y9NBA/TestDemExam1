﻿#pragma checksum "..\..\StudentGroup.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8DA4D6C519DA88D77060E112B7272AFF4AAA2669059B03DD50DDE5711525C561"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using ДЭ1;


namespace ДЭ1 {
    
    
    /// <summary>
    /// StudentGroup
    /// </summary>
    public partial class StudentGroup : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\StudentGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FYO;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\StudentGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Groups;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\StudentGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Cancel;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\StudentGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Add;
        
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
            System.Uri resourceLocater = new System.Uri("/ДЭ1;component/window3.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StudentGroup.xaml"
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
            
            #line 9 "..\..\StudentGroup.xaml"
            ((ДЭ1.StudentGroup)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FYO = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.Groups = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.Btn_Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\StudentGroup.xaml"
            this.Btn_Cancel.Click += new System.Windows.RoutedEventHandler(this.Btn_Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Btn_Add = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\StudentGroup.xaml"
            this.Btn_Add.Click += new System.Windows.RoutedEventHandler(this.Btn_Add_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

