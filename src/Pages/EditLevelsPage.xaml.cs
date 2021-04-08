using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ficha
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class EditLevelsPage : Page
    {
        public EditLevelsPage()
        {
            this.InitializeComponent();
            viewModel = new EditLevelsViewModel();


            DataTable dt = new DataTable();
            dt.Columns.Add("Nível", typeof(int));
            dt.Columns.Add("Experiência", typeof(int));
            dt.Columns.Add("Recompensa", typeof(string));
            dt.Rows.InsertAt(dt.NewRow(), 0);
            dt.Rows.InsertAt(dt.NewRow(), 1);
            dt.Rows.InsertAt(dt.NewRow(), 2);
            dt.Rows[0]["Nível"] = 1;
            dt.Rows[0]["Experiência"] = 50;
            dt.Rows[0]["Recompensa"] = "";
            dt.Rows[1]["Nível"] = 2;
            dt.Rows[1]["Experiência"] = 70;
            dt.Rows[1]["Recompensa"] = "cu";
            dt.Rows[2]["Nível"] = 3;
            dt.Rows[2]["Experiência"] = 120;
            dt.Rows[2]["Recompensa"] = "bolacha";
            List<Level> dataList = new List<Level>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Level ListData = new Level();
                ListData.nivel =(int)dt.Rows[i]["Nível"];
                ListData.xp = (int)dt.Rows[i]["Experiência"];
                ListData.reward = dt.Rows[i]["Recompensa"].ToString();
                dataList.Add(ListData);
            }

            lvdatagrid.ItemsSource = dataList;
        }
        public EditLevelsViewModel viewModel;

        public ObservableCollection<object> levels = new ObservableCollection<object>();
    }
    public class Level
    {
        public int nivel { get; set; }
        public int xp { get; set; }
        public string reward { get; set; }
    }
}
