using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Ficha.Pages;
using Ficha.Models;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Ficha
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            MyPages = new()
            {
                { "Ficha", (typeof(FichaPage),"Ficha") },
                { "Dados", (typeof(DadosPage),"Dados")},
                { "Editor", (typeof(EditorPage),"Editor")}
            };
            ContentFrame.Navigate(typeof(FichaPage));
            NavView.Header = "Ficha";
        }
        public Dictionary<string,(Type,string)> MyPages { get; set; }

        private void NavViewSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(SettingsPage));
                NavView.Header = "Configurações";
                //TODO select settings screen
                return;
            }
            var tagselected = (string)args.SelectedItemContainer.Tag;
            if (tagselected != null)
            {
                //there is a tag, now check if user is already on the page, just in case
                if((string)sender.Tag == tagselected)
                {
                    return;
                }
                //navigate to page
                if (MyPages.ContainsKey(tagselected))
                {
                    ContentFrame.Navigate(MyPages[tagselected].Item1);
                    NavView.Header = MyPages[tagselected].Item2;
                }
            }

        }

    }
}
