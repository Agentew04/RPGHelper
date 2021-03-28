using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TesteCSharp.Assistant;
using TesteCSharp.Windows;
using Newtonsoft.Json.Linq;

namespace TesteCSharp
{
    /// <summary>
    /// Lógica interna para Dados.xaml
    /// </summary>
    public partial class Dados : Window
    {

        Random rnd;
        Random rnd2;
#pragma warning disable IDE0044
        private List<int> historicod20 = new List<int>(6);
        private List<int> historico = new List<int>(6);
#pragma warning restore IDE0044
        public Dados()
        {
            InitializeComponent();
        }
        public void UpdateDados()
        {
            //d20
            d201num.Content = historicod20[0];
            d202num.Content = historicod20[1];
            d203num.Content = historicod20[2];
            d204num.Content = historicod20[3];
            d205num.Content = historicod20[4];
            d206num.Content = historicod20[5];

            // d outros
            d1.Content = historico[0];
            d2l.Content = historico[1];
            d3.Content = historico[2];
            d4.Content = historico[3];
            d5l.Content = historico[4];
            d6l.Content = historico[5];

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!this.IsVisible)
            {
            }
            else
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            rnd = new Random();
            rnd2 = new Random();
            //d20
            historicod20.Add(rnd.Next(1, 21));
            historicod20.Add(rnd.Next(1, 21));
            historicod20.Add(rnd.Next(1, 21));
            historicod20.Add(rnd.Next(1, 21));
            historicod20.Add(rnd.Next(1, 21));
            historicod20.Add(rnd.Next(1, 21));

            //d outros
            historico.Add(rnd.Next(1, 16));
            historico.Add(rnd.Next(1, 51));
            historico.Add(rnd.Next(1, 3));
            historico.Add(rnd.Next(1, 11));
            historico.Add(rnd.Next(1, 101));
            historico.Add(rnd.Next(1, 7));
            
            UpdateDados();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            historicod20[5] = historicod20[4];
            historicod20[4] = historicod20[3];
            historicod20[3] = historicod20[2];
            historicod20[2] = historicod20[1];
            historicod20[1] = historicod20[0];
            historicod20[0] = rnd.Next(1, 21);
            UpdateDados();
        }
        private int EvaluateChoice()
        {
            int result;
            if (d100.IsChecked == true)
            {
                result = 100;
            }else if(d50.IsChecked == true)
            {
                result = 50;
            }else if(d10.IsChecked == true)
            {
                result = 10;
            }else if(d5.IsChecked == true)
            {
                result = 5;
            }else if(d6.IsChecked == true)
            {
                result = 6;
            }else
            {
                result = 2;
            }
            return result;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int choice = EvaluateChoice();
            int sorteado = choice switch
            {
                100 => rnd2.Next(1, 101),
                50 => rnd2.Next(1, 51),
                10 => rnd2.Next(1, 11),
                5 => rnd2.Next(1, 6),
                6 => rnd2.Next(1, 7),
                _ => rnd2.Next(1, 3),
            };
            historico[5] = historico[4];
            historico[4] = historico[3];
            historico[3] = historico[2];
            historico[2] = historico[1];
            historico[1] = historico[0];
            historico[0] = sorteado;
            UpdateDados();
        }
    }
}
