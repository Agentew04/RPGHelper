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
using System.Windows.Threading;
using System.IO;
using TesteCSharp.Assistant;
using Newtonsoft.Json.Linq;

namespace TesteCSharp
{
    /// <summary>
    /// Lógica interna para Config.xaml
    /// </summary>
    public partial class Config : Window
    {
        readonly string apppath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Rodrigo's_Stuff\Ficha";

        public Config()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(5)
            };
            timer.Tick += TimerTick;
            timer.Start();
        }
        void TimerTick(object sender, EventArgs e)
        {
            bool exist = File.Exists(apppath+@"\config.json");
            bool saved = CheckSum();
            if (exist)
            {
                if (saved)
                {
                    labelstatus.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1D, 0xB4, 0x0E));
                    labelstatus.Content = "Salvo";
                }
                else
                {
                    labelstatus.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                    labelstatus.Content = "Não salvo";
                }
            }
            else
            {
                labelstatus.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                labelstatus.Content = "Não salvo";
            }
        }
        bool CheckSum()
        {
            var x = TempData.habilidades["total"] + TempData.habilidades["forca"] + TempData.habilidades["labia"] +
                TempData.habilidades["fe"] + TempData.habilidades["trevas"] + TempData.habilidades["resistencia"]
                + TempData.habilidades["percepcao"];
            JObject y;
            if (File.Exists(apppath + @"\config.json"))
            {
                y = new Saving().GetJSONFromFile();
            }else
            {
                y = new Saving().CreateJSONFile();
            }
            var z = (ulong)y["ficha"]["habilidades"]["total"] + (ulong)y["ficha"]["habilidades"]["forca"] + (ulong)y["ficha"]["habilidades"]["labia"] +
                (ulong)y["ficha"]["habilidades"]["fe"] + (ulong)y["ficha"]["habilidades"]["trevas"] + (ulong)y["ficha"]["habilidades"]["resistencia"] +
                (ulong)y["ficha"]["habilidades"]["percepcao"];

            var w = TempData.mochila;
            var v = (string)y["ficha"]["character"]["mochila"];

            var a = TempData.VidaAtual;
            var b = (int)y["ficha"]["stats"]["vida_atual"];

            var c = TempData.experience;
            var d = (double)y["ficha"]["stats"]["xp"];
            if(x == z && w == v && a == b && c==d)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Saving s = new Saving();
            s.SaveToDisk(s.CreateJSONFile());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Saving s = new Saving();
            if (File.Exists(apppath + @"\config.json"))
            {
                s.LoadFromJSON(s.GetJSONFromFile());
            }
            else
            {
                s.SaveToDisk(s.CreateJSONFile());
            }
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (IsVisible)
            {
                Hide();
                e.Cancel = true;
            }
        }
    }
}
