using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Ficha
{
    public class FichaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Variaveis
        //char vars
        public string Nome
        {
            get { return WindowData.FichaData.Nome; }
            set
            {
                if (WindowData.FichaData.Nome != value)
                {
                    WindowData.FichaData.Nome = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(WindowData.FichaData.Nome)));
                }
            }
        }
        public string Classe {
            get { return WindowData.FichaData.Classe; }
            set
            {
                if (WindowData.FichaData.Classe != value)
                {
                    WindowData.FichaData.Classe = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(WindowData.FichaData.Classe)));
                }
            }
        }
        public string Pacto {
            get { return WindowData.FichaData.Pacto; }
            set
            {
                if (WindowData.FichaData.Pacto != value)
                {
                    WindowData.FichaData.Pacto = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(WindowData.FichaData.Pacto)));
                }
            }
        }
        public string Mochila {
            get { return WindowData.FichaData.Mochila; }
            set
            {
                if (WindowData.FichaData.Mochila != value)
                {
                    WindowData.FichaData.Mochila = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(WindowData.FichaData.Mochila)));
                }
            }
        }

        //life
        public int MaxLife
        {
            get { return WindowData.FichaData.MaxLife; }
            set{
                if (WindowData.FichaData.MaxLife != value)
                {
                    WindowData.FichaData.MaxLife = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(WindowData.FichaData.MaxLife)));
                }}
        }
        public int Life
        {
            get { return WindowData.FichaData.Life; }
            set
            {
                if (WindowData.FichaData.Life != value)
                {
                    WindowData.FichaData.Life = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(WindowData.FichaData.Life)));
                }
            }
        }

        //xp
        public int Experience
        {
            get { return WindowData.FichaData.Experience; }
            set
            {
                if (WindowData.FichaData.Experience != value)
                {
                    WindowData.FichaData.Experience = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(WindowData.FichaData.Experience)));
                }
            }
        }
        public int Level
        {
            get { return WindowData.FichaData.Level; }
            set
            {
                if (WindowData.FichaData.Level != value)
                {
                    WindowData.FichaData.Level = value;
                    Maxxp = Levelxp[Level];
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Maxxp)));
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(WindowData.FichaData.Level)));
                }
            }
        }
        public List<int> Levelxp
        {
            get { return WindowData.FichaData.Levelxp; }
            set
            {
                if(WindowData.FichaData.Levelxp!= value)
                {
                    WindowData.FichaData.Levelxp = value;
                }
            }
        }
        public int Maxxp
        {
            get { return Levelxp[Level]; }
            set
            {
                IncreaseLevel(value);
            }
        }

        //gold
        public int Money
        {
            get { return WindowData.FichaData.Money; }
            set
            {
                if (WindowData.FichaData.Money != value)
                {
                    WindowData.FichaData.Money = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(WindowData.FichaData.Money)));
                }
            }
        }

        //habilidades
        public ObservableDictionary<string, int> Habilidades
        {
            get { return WindowData.FichaData.Habilidades; }
            set
            {
                if (WindowData.FichaData.Habilidades != value)
                {
                    WindowData.FichaData.Habilidades = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(WindowData.FichaData.Habilidades)));
                }
            }
        }
        #endregion

        #region Icommands

        public ICommand CAddGold { get { return new RelayCommand<int>(AddGold);} }
        public ICommand CRemoveGold { get { return new RelayCommand<int>(RemoveGold); } }
        public ICommand CAddTotal { get { return new RelayCommand(AddTotal); } }
        public ICommand CRemoveTotal { get { return new RelayCommand(RemoveTotal); } }
        public ICommand CAddTrevas { get { return new RelayCommand(AddTrevas); } }
        public ICommand CRemoveTrevas { get { return new RelayCommand(RemoveTrevas); } }
        public ICommand CAddFe { get { return new RelayCommand(AddFe); } }
        public ICommand CRemoveFe { get { return new RelayCommand(RemoveFe); } }
        public ICommand CAddLabia { get { return new RelayCommand(AddLabia); } }
        public ICommand CRemoveLabia { get { return new RelayCommand(RemoveLabia); } }
        public ICommand CAddMemoria { get { return new RelayCommand(AddMemoria); } }
        public ICommand CRemoveMemoria { get { return new RelayCommand(RemoveMemoria); } }
        public ICommand CAddPercepcao { get { return new RelayCommand(AddPercepcao); } }
        public ICommand CRemovePercepcao { get { return new RelayCommand(RemovePercepcao); } }
        public ICommand CAddDestreza { get { return new RelayCommand(AddDestreza); } }
        public ICommand CRemoveDestreza { get { return new RelayCommand(RemoveDestreza); } }
        public ICommand CAddResistencia { get { return new RelayCommand(AddResistencia); } }
        public ICommand CRemoveResistencia { get { return new RelayCommand(RemoveResistencia); } }
        public ICommand CAddVitalidade { get { return new RelayCommand(AddVitalidade); } }
        public ICommand CRemoveVitalidade { get { return new RelayCommand(RemoveVitalidade); } }
        public ICommand CAddForca { get { return new RelayCommand(AddForca); } }
        public ICommand CRemoveForca { get { return new RelayCommand(RemoveForca); } }
        public ICommand CSetMaxLife { get { return new RelayCommand<int>(SetMaxLife); } }
        public ICommand CSetCurrentLife { get { return new RelayCommand<int>(SetCurrentLife); } }
        public ICommand CAddXp { get { return new RelayCommand<int>(AddXp); } }

        #endregion

        #region Methods
        private void SetMaxLife(int desiredLife)
        {
            if(desiredLife >= Life && desiredLife > 0)
            {
                MaxLife = desiredLife;
            }
        }
        private void SetCurrentLife(int desiredLife)
        {
            if(desiredLife <= MaxLife && desiredLife >= 0)
            {
                Life = desiredLife;
            }
        }
        private void AddGold(int numberToAdd)
        {
            Money += numberToAdd;
        }
        private void RemoveGold(int numbertToRemove)
        {
            Money -= numbertToRemove;
        }
        private void AddTotal()
        {
            ++Habilidades["total"];
        }
        private void RemoveTotal()
        {
            if (CanAdd())
            {
                --Habilidades["total"];
            }
        }
        private void AddTrevas()
        {
            if (CanAdd())
            {
                ++Habilidades["trevas"];
                --Habilidades["total"];
            }
        }
        private void RemoveTrevas()
        {
            if (CanRem("trevas"))
            {
                --Habilidades["trevas"];
                ++Habilidades["total"];
            }
        }
        private void AddFe()
        {
            if (CanAdd())
            {
                ++Habilidades["fe"];
                --Habilidades["total"];
            }
        }
        private void RemoveFe()
        {
            if (CanRem("fe"))
            {
                --Habilidades["fe"];
                ++Habilidades["total"];
            }
        }
        private void AddLabia()
        {
            if (CanAdd())
            {
                ++Habilidades["labia"];
                --Habilidades["total"];
            }
        }
        private void RemoveLabia()
        {
            if (CanRem("labia"))
            {
                --Habilidades["labia"];
                ++Habilidades["total"];
            }
        }
        private void AddMemoria()
        {
            if (CanAdd())
            {
                ++Habilidades["memoria"];
                --Habilidades["total"];
            }
        }
        private void RemoveMemoria()
        {
            if (CanRem("memoria"))
            {
                --Habilidades["memoria"];
                ++Habilidades["total"];
            }
        }
        private void AddPercepcao()
        {
            if (CanAdd())
            {
                ++Habilidades["percepcao"];
                --Habilidades["total"];
            }
        }
        private void RemovePercepcao()
        {
            if (CanRem("percepcao"))
            {
                --Habilidades["percepcao"];
                ++Habilidades["total"];
            }
        }
        private void AddDestreza()
        {
            if (CanAdd())
            {
                ++Habilidades["destreza"];
                --Habilidades["total"];
            }
        }
        private void RemoveDestreza()
        {
            if (CanRem("destreza"))
            {
                --Habilidades["destreza"];
                ++Habilidades["total"];
            }
        }
        private void AddResistencia()
        {
            if (CanAdd())
            {
                ++Habilidades["resistencia"];
                --Habilidades["total"];
            }
        }
        private void RemoveResistencia()
        {
            if (CanRem("resistencia"))
            {
                --Habilidades["resistencia"];
                ++Habilidades["total"];
            }
        }
        private void AddVitalidade()
        {
            if (CanAdd())
            {
                ++Habilidades["vitalidade"];
                --Habilidades["total"];
            }
        }
        private void RemoveVitalidade()
        {
            if (CanRem("vitalidade"))
            {
                --Habilidades["vitalidade"];
                ++Habilidades["total"];
            }
        }
        private void AddForca()
        {
            if (CanAdd())
            {
                ++Habilidades["forca"];
                --Habilidades["total"];
            }
        }
        private void RemoveForca()
        {
            if (CanRem("forca"))
            {
                --Habilidades["forca"];
                ++Habilidades["total"];
            }
        }
        #endregion
        #region functions

        private bool CanAdd()
        {
            if(Habilidades["total"] > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CanRem(string habilidade)
        {
            if (Habilidades[habilidade] > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region xp
        public void AddXp(int xpadicionado)
        {
            int xpfaltando = Maxxp - Experience;
            int xpsobrando;
            bool vaiupar = xpadicionado >= xpfaltando;
            if (vaiupar)
            {
                xpsobrando = xpadicionado - xpadicionado;
                Level += 1;
                Experience = xpsobrando;
                //update max
                return;
            }
            Experience += xpadicionado;
            return;

        }
        public void IncreaseLevel(int newmaxxpvalue)
        {
            var i = 0;
            foreach(int valor in Levelxp)
            {
                if(valor == 0) { continue; }
                i++;
                if (valor == newmaxxpvalue)
                {
                    Level = i;
                }
            }
        }
        #endregion
        public FichaViewModel(string nome, string classe, string pacto, string mochila)
        {
            this.Nome = nome;
            this.Classe = classe;
            this.Pacto = pacto;
            this.Mochila = mochila;
        }
    }
}
