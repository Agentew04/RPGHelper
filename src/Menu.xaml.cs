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
using TesteCSharp;
using TesteCSharp.Assistant;

namespace TesteCSharp
{
/// <summary>
/// Lógica interna para Menu.xaml
/// </summary>
public partial class Menu : Window
    {
        Window ficha = new Windows.Ficha();
        public Window Ficha { get => ficha; set => ficha = value; }
        Window dados = new Dados();
        public Window Dados { get => dados; set => dados = value; }
        Window config = new Config();
        public Window Config { get => config; set => config = value; }

        public Menu()
        {
            InitializeComponent();
        }

        //Abre e fecha a ficha
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Ficha.IsVisible)
            {
                Ficha.Hide();
            } else
            {
                Ficha.Show();
            }
        }

        //Força a fechada do aplicativo
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Saving s = new Saving();
            s.SaveToDisk(s.CreateJSONFile());
            //SaveConfig();
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Dados.IsVisible)
            {
                Dados.Hide();
            }
            else
            {
                Dados.Show();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Config.IsVisible)
            {
                Config.Hide();
            }
            else
            {
                Config.Show();
            }
        }
    }
}
