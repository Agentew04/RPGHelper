using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TesteCSharp;
using TesteCSharp.Assistant;
using System.Windows.Media;
using System.Windows.Controls;
using Microsoft.VisualBasic;

namespace TesteCSharp.Assistant
{
     public class Popup
    {
        //Controles
        Window window = new Window();
        TextBlock prompt = new TextBlock();
        TextBox inputBox = new TextBox();
        Button okButton = new Button();
        StackPanel stackPanel = new StackPanel();

        //vars
        string windowtitle = "Digite";
        string PlaceholderInput = "Digite Aqui";
        FontFamily fonte = new FontFamily("Consolas");
        int fontsize = 15;

        int resultint =0;
        string resultstr = "";
        string wants = "";

        bool truequit = false;
        bool errored = false;

        public Popup(string question)
        {
            stackPanel.Children.Add(prompt);
            stackPanel.Children.Add(inputBox);
            stackPanel.Children.Add(okButton);
            
            window.Width = 250;
            window.Height = 200;
            window.FontFamily = fonte;
            window.FontSize = fontsize;
            window.ResizeMode = ResizeMode.CanMinimize;
            window.Title = windowtitle;
            window.Content = stackPanel;
            window.Closing += closedd;

            this.prompt.Text = question;
            this.prompt.FontFamily = fonte;
            this.prompt.FontSize = fontsize;
            prompt.HorizontalAlignment = HorizontalAlignment.Center;
            prompt.TextWrapping = TextWrapping.Wrap;


            inputBox.Text = PlaceholderInput;
            inputBox.FontSize = fontsize;
            inputBox.FontFamily = fonte;
            inputBox.HorizontalAlignment = HorizontalAlignment.Stretch;

            okButton.Content = "Confirmar";
            okButton.Width = 75;
            okButton.Height = 50;
            okButton.HorizontalAlignment = HorizontalAlignment.Center;
            okButton.Click += okked;
        }

        public int GetIntInput()
        {
            wants = "int";
            window.ShowDialog();
            return resultint;
        }
        public string GetStringInput()
        {
            wants = "str";
            window.ShowDialog();
            return resultstr;
        }
        private void okked(object sender, RoutedEventArgs e)
        {
            resultstr = inputBox.Text;            
            if (wants == "int")
            {
                try
                {
                    resultint = int.Parse(resultstr);
                }
                catch (FormatException ex)
                {

                    MessageBox.Show("Erro de Conversão" + Environment.NewLine + "Código de Erro: " + ex.Message);
                    errored = true;
                }
            }
            truequit = true;
            window.Close();
        }
        private void closedd(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (truequit && !errored)
            {
                e.Cancel = false;
                truequit = false;
            } else
            {
                e.Cancel = true;
                errored = false;
            }
        }
    }
}
