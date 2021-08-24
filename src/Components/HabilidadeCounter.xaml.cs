using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Controle de Usuário está documentado em https://go.microsoft.com/fwlink/?LinkId=234236

namespace Ficha
{
    public sealed partial class HabilidadeCounter : UserControl
    {
        public HabilidadeCounter()
        {
            this.InitializeComponent();
        }

        public int Points
        {
            get { return (int)GetValue(PointsProperty); }
            set { SetValue(PointsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Points.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PointsProperty =
            DependencyProperty.Register("Points", typeof(int), typeof(HabilidadeCounter), new PropertyMetadata(0));



        public ICommand AddPointCommand
        {
            get { return (ICommand)GetValue(AddPointCommandProperty); }
            set { SetValue(AddPointCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddPointCommandProperty =
            DependencyProperty.Register("AddPointCommand", typeof(ICommand), typeof(HabilidadeCounter), new PropertyMetadata(new RelayCommand(null)));

        public ICommand RemovePointCommand
        {
            get { return (ICommand)GetValue(RemovePointCommandProperty); }
            set { SetValue(RemovePointCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemovePointCommandProperty =
            DependencyProperty.Register("AddPointCommand", typeof(ICommand), typeof(HabilidadeCounter), new PropertyMetadata(null));



        public string HabilidadeTitle
        {
            get {
                return (string)GetValue(HabilidadeTitleProperty);
            }
            set {
                SetValue(HabilidadeTitleProperty, value+": "); 
            }
        }

        // Using a DependencyProperty as the backing store for HabilidadeTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HabilidadeTitleProperty =
            DependencyProperty.Register("HabilidadeTitle", typeof(string), typeof(HabilidadeCounter), new PropertyMetadata(""));


    }
}
