using System;
using Windows.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Ficha
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();

            //create file and load
            SavingUWP.AppInitializedAsync();

            //abre a ficha
            ContentFrame.Navigate(typeof(FichaPage));
            NavView.Header = "Ficha";
        }
        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(ConfigPage));
                NavView.Header = "Configurações";
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;
                switch (item.Tag.ToString())
                {
                    case "ficha":
                        ContentFrame.Navigate(typeof(FichaPage));
                        NavView.Header = "Ficha";
                        break;
                    case "dados":
                        ContentFrame.Navigate(typeof(DadosPage));
                        NavView.Header = "Dados";
                        break;
                    case "editlevels":
                        ContentFrame.Navigate(typeof(EditLevelsPage));
                        NavView.Header = "Editar níveis";
                        break;
                    default:
                        ContentFrame.Navigate(typeof(FichaPage));
                        NavView.Header = "Ficha";
                        break;
                }
            }
        }
    }
}
