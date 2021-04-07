using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ficha
{
    public class SaveReadyClass
    {
        public string Nome { get; set; }
        public string Classe { get; set; }
        public string Pacto { get; set; }
        public string Mochila { get; set; }
        public int MaxLife { get; set; }
        public int Life { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public int Money { get; set; }
        public ObservableDictionary<string, int> Habilidades { get; set; }
        public List<int> Levelxp { get; set; }
        public bool IsLevelProgressionStopped { get; set; }
        public ObservableCollection<int> Historicod20 { get; set; }
        public ObservableCollection<int> Historico { get; set; }
        public bool AutoSave { get; set; }
        public int AutoSaveInterval { get; set; }
        public SaveReadyClass() { }
    }
}
