using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Ficha
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FichaPage : Page
    {
        public FichaPage()
        {
            this.InitializeComponent();

            this.color1 = (SolidColorBrush)this.Resources["Color1"];
            this.color2 = (SolidColorBrush)this.Resources["Color2"];
            this.color3 = (SolidColorBrush)this.Resources["Color3"];
            this.color4 = (SolidColorBrush)this.Resources["Color4"];
            this.color5 = (SolidColorBrush)this.Resources["Color5"];
            this.color6 = (SolidColorBrush)this.Resources["Color6"];

            ViewModel = new FichaViewModel(
                WindowData.FichaData.Nome,
                WindowData.FichaData.Classe,
                WindowData.FichaData.Pacto,
                WindowData.FichaData.Mochila
                );

        }
        public FichaViewModel ViewModel;
        SolidColorBrush color1 { get; }
        SolidColorBrush color2 { get; }
        SolidColorBrush color3 { get; }
        SolidColorBrush color4 { get; }
        SolidColorBrush color5 { get; }
        SolidColorBrush color6 { get; }

        //muito trabalho pra fazer em mvvm, entao vou fazer aqui mesmo
        private void Addgoldbutton_Click(object sender, RoutedEventArgs e)
        {
            addmoneybutton.Flyout.Hide();
        }

        private void Removegoldbutton_Click(object sender, RoutedEventArgs e)
        {
            removemoneybutton.Flyout.Hide();
        }

        //JUST FOR UI COLORS ON BAR
        private void UpdateColors(object sender, RoutedEventArgs e)
        {
            foreach (var x in this.ViewModel.Habilidades)
            {
                switch (x.Key)
                {
                    case "total":
                        break;
                    case "forca":
                        //if (x.Value);
                        break;
                    case "vitalidade":
                        break;
                    case "resistencia":
                        break;
                    case "destreza":
                        break;
                    case "percepcao":
                        break;
                    case "memoria":
                        break;
                    case "labia":
                        break;
                    case "fe":
                        break;
                    case "trevas":
                        break;
                }
            }
        }
    }
}
