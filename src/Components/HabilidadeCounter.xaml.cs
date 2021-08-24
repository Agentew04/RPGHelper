using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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


        public string TipoDeHabilidade
        {
            get { return (string)GetValue(TipoDeHabilidadeProperty); }
            set { SetValue(TipoDeHabilidadeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TipoDeHabilidadeProperty =
            DependencyProperty.Register("Tipo", typeof(string), typeof(HabilidadeCounter), new PropertyMetadata("forca"));



        public FichaViewModel ViewModel
        {
            get { return (FichaViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(FichaViewModel), typeof(HabilidadeCounter), new PropertyMetadata(new FichaViewModel("","","","")));



    }
}
