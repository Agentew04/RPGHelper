using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            ViewModel = new FichaViewModel(
                WindowData.FichaData.Nome,
                WindowData.FichaData.Classe,
                WindowData.FichaData.Pacto,
                WindowData.FichaData.Mochila
                );

        }
        public FichaViewModel ViewModel;

        //muito trabalho pra fazer em mvvm, entao vou fazer aqui mesmo
        private void Addgoldbutton_Click(object sender, RoutedEventArgs e)
        {
            addmoneybutton.Flyout.Hide();
        }

        private void Removegoldbutton_Click(object sender, RoutedEventArgs e)
        {
            removemoneybutton.Flyout.Hide();
        }
    }
}
