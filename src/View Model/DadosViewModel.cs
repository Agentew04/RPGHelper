using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Ficha
{
    public class DadosViewModel : INotifyPropertyChanged
    {

        #region Variaveis
        private readonly Random rnd = new Random();
        private readonly Random rnd2 = new Random();

        public ObservableCollection<int> Historicod20
        {
            get { return WindowData.DadosData.Historicod20; }
            set
            {
                if (WindowData.DadosData.Historicod20 != value)
                {
                    WindowData.DadosData.Historicod20 = value;
                }
            }
        }
        public ObservableCollection<int> Historico
        {
            get { return WindowData.DadosData.Historico; }
            set
            {
                if(WindowData.DadosData.Historico != value)
                {
                    WindowData.DadosData.Historico = value;
                }
            }
        }
#pragma warning disable IDE1006 // Estilos de Nomenclatura
        public int selecionado { get; set; } = 1;
#pragma warning restore IDE1006 // Estilos de Nomenclatura
        public Dados DadoSelecionado { get; set; }
        #endregion

        #region Constructors
        public DadosViewModel(ObservableCollection<int> historicod20, ObservableCollection<int> historico)
        {
            this.Historicod20 = historicod20;
            Historico = historico;
        }

        #endregion

        #region Commands

        public ICommand CSortd20 { get { return new RelayCommand(SortD20); } }
        public ICommand CSortCustom { get { return new RelayCommand(SortDCustom); } }

        #endregion

        #region Methods
        private void SortD20()
        {
            Historicod20[5] = Historicod20[4];
            Historicod20[4] = Historicod20[3];
            Historicod20[3] = Historicod20[2];
            Historicod20[2] = Historicod20[1];
            Historicod20[1] = Historicod20[0];
            Historicod20[0] = rnd.Next(1,21);
        }
        private void SortDCustom()
        {
            Dados x;
            if (selecionado == 0)
            {
                x = Dados.D10;
            }else if (selecionado == 1)
            {
                x = Dados.D6;
            }else if (selecionado == 2)
            {
                x = Dados.D3;
            }
            else
            {
                x = Dados.D2;
            }
            int sorteado;
            switch (x)
            {
                case Dados.D10:
                    sorteado = rnd2.Next(1, 11);
                    break;
                case Dados.D6:
                    sorteado = rnd2.Next(1, 7);
                    break;
                case Dados.D3:
                    sorteado = rnd2.Next(1, 4);
                    break;
                case Dados.D2:
                    sorteado = rnd2.Next(1, 3);
                    break;
                default:
                    sorteado= rnd2.Next(1, 7);
                    break;
            }
            UpdateCustomDado(sorteado);
        }
        private void UpdateCustomDado(int newvalue)
        {
            Historico[5] = Historico[4];
            Historico[4] = Historico[3];
            Historico[3] = Historico[2];
            Historico[2] = Historico[1];
            Historico[1] = Historico[0];
            Historico[0] = newvalue;
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged = (sender,e) => { };
    }
}
