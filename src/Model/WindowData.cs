using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ficha
{
    public static class WindowData
    {
        public static class FichaData
        {
            //char info
            public static string Nome { get; set; } = "";
            public static string Classe { get; set; } = "";
            public static string Pacto { get; set; } = "";
            public static string Mochila { get; set; } = "";

            //vida
            public static int MaxLife { get; set; } = 10;
            public static int Life { get; set; } = 10;

            //xp
            public static int Experience { get; set; } = 0;
            public static int Level { get; set; } = 1;

            //money
            public static int Money { get; set; } = 0;

            //habilidades
            public static ObservableDictionary<string, int> Habilidades { get; set; } = new ObservableDictionary<string, int>
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

            //jogabilidade

            public static List<int> Levelxp { get; set; } = new List<int>()
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
            public static bool IsLevelProgressionStopped { get; set; } = false;

        }
        public static class DadosData
        {
            public static ObservableCollection<int> Historicod20 { get; set; } = new ObservableCollection<int>()
            {
                12,9,7,20,15,4
            };
            public static ObservableCollection<int> Historico { get; set; } = new ObservableCollection<int>()
            {
                12,9,7,20,15,4
            };
        }
        public static class ConfigData
        {
            public static bool AutoLoadOnStartup { get; set; } = true;
            public static bool AutoSave { get; set; } = false;
            //nao sei se uso enum ou int :/
            /* 0 -> 10s
             * 1 -> 30s
             * 2 -> 1min
             * 3 -> 5min
             */
            public static int AutoSaveInterval { get; set; } = 1;
        }
    }
}
