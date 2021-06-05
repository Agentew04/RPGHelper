using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Ficha
{
    public class EditLevelsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public List<LevelXPDefinition> LevelDataTable { get; set; }

        public SolidColorBrush Color1 { get; } = new SolidColorBrush(Color.FromArgb(255, 0, 120, 215));
        public SolidColorBrush Color2 { get; } = new SolidColorBrush(Color.FromArgb(255, 236, 19, 19));
        public SolidColorBrush Color3 { get; } = new SolidColorBrush(Color.FromArgb(255, 0, 153, 0));
        public SolidColorBrush Color4 { get; } = new SolidColorBrush(Color.FromArgb(255, 153, 0, 204));
        public SolidColorBrush Color5 { get; } = new SolidColorBrush(Color.FromArgb(255, 255, 204, 0));


        public EditLevelsViewModel()
        {
            this.LevelDataTable = new List<LevelXPDefinition>()
            {
                new LevelXPDefinition()
                {
                    Level = 1,
                    Experience = 10,
                    Recompensas = "nada",
                    Gold = 5
                },
                new LevelXPDefinition()
                {
                    Level = 2,
                    Experience = 20,
                    Recompensas = "ainda nada",
                    Gold = 15
                },
                new LevelXPDefinition()
                {
                    Level = 3,
                    Experience = 30,
                    Recompensas = "algoo",
                    Gold = 45
                },
                new LevelXPDefinition()
                {
                    Level = 1,
                    Experience = 10,
                    Recompensas = "nada",
                    Gold = 5
                },
                new LevelXPDefinition()
                {
                    Level = 2,
                    Experience = 20,
                    Recompensas = "ainda nada",
                    Gold = 15
                },
                new LevelXPDefinition()
                {
                    Level = 3,
                    Experience = 30,
                    Recompensas = "algoo",
                    Gold = 45
                },
                                new LevelXPDefinition()
                {
                    Level = 1,
                    Experience = 10,
                    Recompensas = "nada",
                    Gold = 5
                },
                new LevelXPDefinition()
                {
                    Level = 2,
                    Experience = 20,
                    Recompensas = "ainda nada",
                    Gold = 15
                },
                new LevelXPDefinition()
                {
                    Level = 3,
                    Experience = 30,
                    Recompensas = "algoo",
                    Gold = 45
                }
            };

            Color1 = new SolidColorBrush(Color.FromArgb(255, 0, 120, 215));
            Color2 = new SolidColorBrush(Color.FromArgb(255, 236, 19, 19));
        }

    }
}
