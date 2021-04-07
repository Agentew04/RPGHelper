using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Ficha
{
    public class ConfigViewModel : INotifyPropertyChanged
    {
#pragma warning disable 
        public event PropertyChangedEventHandler PropertyChanged;
        #region properties
        public bool AutoSave
        {
            get { return WindowData.ConfigData.AutoSave; }
            set
            {
                if(WindowData.ConfigData.AutoSave != value)
                {
                    WindowData.ConfigData.AutoSave = value;
                }
            }
        }
        public int AutoSaveInterval
        {
            get { return WindowData.ConfigData.AutoSaveInterval; }
            set
            {
                if (WindowData.ConfigData.AutoSaveInterval != value)
                {
                    WindowData.ConfigData.AutoSaveInterval = value;
                }
            }
        }
        private static readonly string savefolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Rodrigo's_Stuff\Ficha";
        #endregion
        #region constructors
        public ConfigViewModel()
        {

        }
        #endregion
        #region icommands
        public ICommand CSave { get { return new RelayCommand(Save); } }
        public ICommand CLoad { get { return new RelayCommand(Load); } }
        public ICommand CCreateNewProfile { get { return new RelayCommand(CreateNewProfile); } }
        #endregion
        #region saving methods
        public static void Save()
        {
            //create object with all data
            SaveReadyClass save = new SaveReadyClass()
            {
                Nome = WindowData.FichaData.Nome,
                Classe = WindowData.FichaData.Classe,
                Pacto = WindowData.FichaData.Pacto,
                Mochila = WindowData.FichaData.Mochila,
                Money = WindowData.FichaData.Money,
                MaxLife = WindowData.FichaData.MaxLife,
                Life = WindowData.FichaData.Life,
                Experience = WindowData.FichaData.Experience,
                Level = WindowData.FichaData.Level,
                Habilidades = WindowData.FichaData.Habilidades,
                Levelxp = WindowData.FichaData.Levelxp,
                IsLevelProgressionStopped = WindowData.FichaData.IsLevelProgressionStopped,
                Historicod20 = WindowData.DadosData.Historicod20,
                Historico = WindowData.DadosData.Historico,
                AutoSave = WindowData.ConfigData.AutoSave,
                AutoSaveInterval = WindowData.ConfigData.AutoSaveInterval
            };
            string json = SavingUWP.ObjectToString(save);
            SavingUWP.SaveToDisk(json);
        }

        public async static void Load()
        {
            SaveReadyClass x = SavingUWP.FileToObject<SaveReadyClass>();
            WindowData.FichaData.Nome = x.Nome;
            WindowData.FichaData.Classe = x.Classe;
            WindowData.FichaData.Pacto = x.Pacto;
            WindowData.FichaData.Mochila = x.Mochila;
            WindowData.FichaData.Money = x.Money;
            WindowData.FichaData.Experience = x.Experience;
            WindowData.FichaData.Level = x.Level;
            WindowData.FichaData.Habilidades = x.Habilidades;
            WindowData.FichaData.Levelxp = x.Levelxp;
            WindowData.FichaData.IsLevelProgressionStopped = x.IsLevelProgressionStopped;
            WindowData.DadosData.Historico = x.Historico;
            WindowData.DadosData.Historicod20 = x.Historicod20;
            WindowData.ConfigData.AutoSave = x.AutoSave;
            WindowData.ConfigData.AutoSaveInterval = x.AutoSaveInterval;
        }
        public static void CreateNewProfile()
        {
            Save();
            //var x = File.ReadAllText(savefolder + @"\config.json");
            var x = SavingUWP.ObjectToString(SavingUWP.FileToJObject());
            SavingUWP.WriteOldSave(x);
            WindowData.FichaData.Nome = "";
            WindowData.FichaData.Classe = "";
            WindowData.FichaData.Pacto = "";
            WindowData.FichaData.Mochila = "";
            WindowData.FichaData.Money = 0;
            WindowData.FichaData.Experience = 0;
            WindowData.FichaData.Level = 1;
            WindowData.FichaData.Habilidades = new ObservableDictionary<string, int>()
            {
                { "total", 0 },
                { "forca", 0 },
                { "vitalidade", 0 },
                { "resistencia", 0 },
                { "destreza", 0 },
                { "percepcao", 0 },
                { "memoria", 0 },
                { "labia", 0 },
                { "fe", 0 },
                { "trevas", 0 }
            };
            WindowData.FichaData.Levelxp = new List<int>()
            {
                0,
                50,
                70,
                120,
                160,
                200,
                250,
                270,
                300,
                400,
                500,
                600,
                850,
                900,
                950,
                1000
            };
            WindowData.FichaData.IsLevelProgressionStopped = false;
            WindowData.DadosData.Historico = new ObservableCollection<int>()
            {
                12,9,7,20,15,4
            }; ;
            WindowData.DadosData.Historicod20 = new ObservableCollection<int>()
            {
                12,9,7,20,15,4
            }; ;
            WindowData.ConfigData.AutoSave = false;
            WindowData.ConfigData.AutoSaveInterval = 1;
            Save();
        }
        #endregion
    }
}
