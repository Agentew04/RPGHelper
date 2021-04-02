using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using TesteCSharp.Assistant;


namespace TesteCSharp.Windows
{
    /// <summary>
    /// Lógica interna para Ficha.xaml
    /// </summary>
    public partial class Ficha : Window
    {
        #region variaveis
        public UInt64 money = 0;

        public int VidaTotal = 0;
        public int VidaAtual = 0;

        public double experience = 0;
        public int level = 1;

        #endregion

        public Ficha()
        {
            InitializeComponent();
            UpdateXp();
            UpdateHabilidades();
            UpdateVida();
            UpdateTextBoxes();
            SyncMoney();
            DispatcherTimer timerrefresh = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timerrefresh.Tick += RefreshDesign;
            timerrefresh.Start();

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!this.IsVisible)
            {
            }
            else
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        #region timer
        public void RefreshDesign(object sender, EventArgs e)
        {

            UpdateTextBoxes();
            UpdateVida();
            UpdateXp();
            UpdateHabilidades();
            SyncMoney();
        }
        #endregion
        #region Updates and Textboxes

        private void MochilaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TempData.mochila = MochilaTextBox.Text;
        }

        private void PactoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TempData.pacto = PactoTextBox.Text;
        }

        private void ClasseTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TempData.classe = ClasseTextBox.Text;
        }

        private void NomeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TempData.nome = NomeTextBox.Text;
        }
        public void UpdateTextBoxes()
        {
            NomeTextBox.Text = TempData.nome;
            ClasseTextBox.Text = TempData.classe;
            PactoTextBox.Text = TempData.pacto;
            MochilaTextBox.Text = TempData.mochila;
        }
        #endregion
        #region xp
        //xps
        private void AddXpButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateXp();
            //fail safe
            if(TempData.level >= (TempData.levelxp.Count-1))
            {
                addXpButton.IsEnabled = false;
                addxpTxt.IsEnabled = false;
                levelprogressbar.Value = levelprogressbar.Maximum;
                TempData.isLevelProgressionStopped = true;
            }
            //metodo 2
            if (!TempData.isLevelProgressionStopped)
            {
                double ExperienciaFaltando = TempData.levelxp[TempData.level] - TempData.experience;
                double ExperienciaAdicionada = 0; try { ExperienciaAdicionada = double.Parse(addxpTxt.Text); } catch (Exception ex) { MessageBox.Show("Erro de conversão" + Environment.NewLine + "Código: " + ex.Message); }
                double ExperienciaMaxima = TempData.levelxp[TempData.level];
                //add from zero pra meio
                if (ExperienciaFaltando - ExperienciaAdicionada != 0
                    && TempData.experience + ExperienciaAdicionada < ExperienciaMaxima)
                {
                    TempData.experience += ExperienciaAdicionada;
                }
                //add from zero pra up
                else if (ExperienciaFaltando == ExperienciaMaxima 
                    && ExperienciaAdicionada >= ExperienciaFaltando)
                {
                    TempData.experience = 0;
                    TempData.level += 1;
                    double ExperienciaSobrando = ExperienciaAdicionada - ExperienciaFaltando;
                    TempData.experience = ExperienciaSobrando;
                }
                //add from meio para up
                else if (ExperienciaFaltando != ExperienciaMaxima 
                    && ExperienciaAdicionada >= ExperienciaFaltando)
                {
                    TempData.experience = 0;
                    TempData.level += 1;
                    double ExperienciaSobrando = ExperienciaAdicionada - ExperienciaFaltando;
                    TempData.experience = ExperienciaSobrando;
                }
                //add from meio para meio
                else if (ExperienciaFaltando != ExperienciaMaxima 
                    && ExperienciaAdicionada < ExperienciaFaltando)
                {
                    TempData.experience += ExperienciaAdicionada;
                }
                UpdateXp();
            }
        }

        public void UpdateXp()
        {
            levelprogressbar.Maximum = TempData.levelxp[level];
            levelprogressbar.Value = TempData.experience;
            nivelLabel.Content = TempData.level;
        }
        #endregion
        #region money
        //money
        private void RemMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            string addmoney = new InputBox("Digite o número a ser removido da sua carteira: ", "Remover Dinheiro", "Consolas", 25).ShowDialog();
            ulong addmoneyint = 0;
            bool suc;
            try
            {
                addmoneyint = ulong.Parse(addmoney);
                suc = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro");
                suc = false;
            }
            if (suc)
            {
                if (TempData.money >= addmoneyint)
                {
                    TempData.money -= addmoneyint;
                    SyncMoney();
                } else
                {
                    MessageBox.Show("Erro, número muito alto", "Remover");
                }
            }
        }
        private void AddMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            string addmoney = new InputBox("Digite o número a ser adicionado a sua carteira: ", "Adicionar Dinheiro", "Consolas", 25).ShowDialog();
            ulong addmoneyint = 0;
            bool suc;
            try
            {
                addmoneyint = ulong.Parse(addmoney);
                suc = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro");
                suc = false;
            }
            if (suc)
            {
                TempData.money += addmoneyint;
                SyncMoney();
            }
        }
        public void SyncMoney()
        {
            currencyLabel.Content = TempData.money;
        }
        #endregion
        #region habilidades
        public void UpdateHabilidades()
        {
            LabelForca.Content = TempData.habilidades["forca"];
            LabelVitalidade.Content = TempData.habilidades["vitalidade"];
            LabelResistencia.Content = TempData.habilidades["resistencia"];
            LabelDestreza.Content = TempData.habilidades["destreza"];
            LabelPercepcao.Content = TempData.habilidades["percepcao"];
            LabelMemoria.Content = TempData.habilidades["memoria"];
            LabelLabia.Content = TempData.habilidades["labia"];
            LabelFe.Content = TempData.habilidades["fe"];
            LabelTrevas.Content = TempData.habilidades["trevas"];
            LabelTotal.Content = TempData.habilidades["total"];
        }

        private void AddTotal_Click(object sender, RoutedEventArgs e)
        {
            TempData.habilidades["total"] += 1; UpdateHabilidades();
        }

        private void RemoveTotal_Click(object sender, RoutedEventArgs e)
        {
            if(TempData.habilidades["total"] > 0) { TempData.habilidades["total"] -= 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void AddForca_Click(object sender, RoutedEventArgs e)
        {
            if(TempData.habilidades["total"] > 0) { TempData.habilidades["forca"] += 1; TempData.habilidades["total"] -= 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void RemoveForca_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["forca"] > 0) { TempData.habilidades["forca"] -= 1; TempData.habilidades["total"] += 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void AddVitalidade_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["total"] > 0) { TempData.habilidades["vitalidade"] += 1; TempData.habilidades["total"] -= 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void RemoveVitalidade_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["vitalidade"] > 0) { TempData.habilidades["vitalidade"] -= 1; TempData.habilidades["total"] += 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void AddResistencia_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["total"] > 0) { TempData.habilidades["resistencia"] += 1; TempData.habilidades["total"] -= 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void RemoveResistencia_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["resistencia"] > 0) { TempData.habilidades["resistencia"] -= 1; TempData.habilidades["total"] += 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void AddDestreza_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["total"] > 0) { TempData.habilidades["destreza"] += 1; TempData.habilidades["total"] -= 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void RemoveDestreza_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["destreza"] > 0) { TempData.habilidades["destreza"] -= 1; TempData.habilidades["total"] += 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void AddPercepcao_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["total"] > 0) { TempData.habilidades["percepcao"] += 1; TempData.habilidades["total"] -= 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void RemovePercepcao_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["percepcao"] > 0) { TempData.habilidades["percepcao"] -= 1; TempData.habilidades["total"] += 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void AddMemoria_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["total"] > 0) { TempData.habilidades["memoria"] += 1; TempData.habilidades["total"] -= 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void RemoveMemoria_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["memoria"] > 0) { TempData.habilidades["memoria"] -= 1; TempData.habilidades["total"] += 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void AddLabia_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["total"] > 0) { TempData.habilidades["labia"] += 1; TempData.habilidades["total"] -= 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void RemoveLabia_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["labia"] > 0) { TempData.habilidades["labia"] -= 1; TempData.habilidades["total"] += 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void AddFe_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["total"] > 0) { TempData.habilidades["fe"] += 1; TempData.habilidades["total"] -= 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void RemoveFe_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["fe"] > 0) { TempData.habilidades["fe"] -= 1; TempData.habilidades["total"] += 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void AddTrevas_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["total"] > 0) { TempData.habilidades["trevas"] += 1; TempData.habilidades["total"] -= 1; UpdateHabilidades(); } else { e.Handled = false; }
        }

        private void RemoveTrevas_Click(object sender, RoutedEventArgs e)
        {
            if (TempData.habilidades["trevas"] > 0) { TempData.habilidades["trevas"] -= 1; TempData.habilidades["total"] += 1; UpdateHabilidades(); } else { e.Handled = false; }
        }
        #endregion
        #region vida
        public void UpdateVida()
        {
            vidaProgressBar.Value = TempData.VidaAtual;
            vidaProgressBar.Maximum = TempData.VidaTotal;
            vidaLabel.Content = TempData.VidaAtual + "/" + TempData.VidaTotal;
        }
        private void SetAtualVida_Click(object sender, RoutedEventArgs e)
        {
            bool b = true;
            try
            {
                int.Parse(atualVidaTxt.Text);
            }catch(Exception ex)
            {
                MessageBox.Show("Erro de conversão de valores! Certifique-se que não digitou nenhuma vírgula." + Environment.NewLine + "Código de Erro: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                b = false;
            }
            if (b)
            {
                if (int.Parse(atualVidaTxt.Text) > TempData.VidaTotal)
                {
                    return;
                }
                else
                {
                    TempData.VidaAtual = Math.Abs(int.Parse(atualVidaTxt.Text));
                }
            }
            UpdateVida();
        }

        private void SetTotalVida_Click(object sender, RoutedEventArgs e)
        {
            bool b = true;
            try
            {
                int.Parse(totalVidaTxt.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conversão de valores! Certifique-se que não digitou nenhuma vírgula." + Environment.NewLine + "Código de Erro: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                b = false;
            }
            if (b)
            {
                if (int.Parse(totalVidaTxt.Text) < TempData.VidaAtual)
                {
                    return;
                }
                else
                {
                    TempData.VidaTotal =Math.Abs(int.Parse(totalVidaTxt.Text));
                }
            }
            UpdateVida();
        }


    }
    #endregion

    public class InputBox
    {
#pragma warning disable IDE0044 // Adicionar modificador somente leitura
        Window Box = new Window();//window for the inputbox

        FontFamily font = new FontFamily("Consolas");//font for the whole inputbox
        int FontSize = 15;//fontsize for the input
        StackPanel sp1 = new StackPanel();// items container
        string title = "InputBox";//title as heading
        string boxcontent;//title
        string defaulttext = "";//default textbox content
        string errormessage = "Mensagem Inválida";//error messagebox content
        string errortitle = "Error";//error messagebox heading title
        string okbuttontext = "OK";//Ok button content
        Brush BoxBackgroundColor = Brushes.White;// Window Background
        Brush InputBackgroundColor = Brushes.Ivory;// Textbox Background
        //bool clicked = false;
        TextBox input = new TextBox();
        Button ok = new Button();
        bool inputreset = false;
#pragma warning restore IDE0044 // Adicionar modificador somente leitura

        public InputBox(string content)
        {
            try
            {
                boxcontent = content;
            }
            catch { boxcontent = "Error!"; }
            Windowdef();
        }

        public InputBox(string content, string Htitle, string DefaultText)
        {
            try
            {
                boxcontent = content;
            }
            catch { boxcontent = "Error!"; }
            try
            {
                title = Htitle;
            }
            catch
            {
                title = "Error!";
            }
            try
            {
                defaulttext = DefaultText;
            }
            catch
            {
            }
            Windowdef();
        }

        public InputBox(string content, string Htitle, string Font, int Fontsize)
        {
            try
            {
                boxcontent = content;
            }
            catch { boxcontent = "Error!"; }
            try
            {
                font = new FontFamily(Font);
            }
            catch { font = new FontFamily("Tahoma"); }
            try
            {
                title = Htitle;
            }
            catch
            {
                title = "Error!";
            }
            if (Fontsize >= 1)
                FontSize = Fontsize;
            Windowdef();
        }

        private void Windowdef()// window building - check only for window size
        {
            Box.Height = 250;// Box Height
            Box.Width = 250;// Box Width
            Box.Background = BoxBackgroundColor;
            Box.Title = title;
            Box.Content = sp1;
            Box.Closing += Box_Closing;
            TextBlock content = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                Background = null,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = boxcontent,
                FontFamily = font,
                FontSize = FontSize
            };
            sp1.Children.Add(content);

            input.Background = InputBackgroundColor;
            input.FontFamily = font;
            input.FontSize = FontSize;
            input.HorizontalAlignment = HorizontalAlignment.Center;
            input.Text = defaulttext;
            input.MinWidth = 200;
            input.MouseEnter += Input_MouseDown;
            sp1.Children.Add(input);
            ok.Width = 70;
            ok.Height = 30;
            ok.Click += Ok_Click;
            ok.Content = okbuttontext;
            ok.HorizontalAlignment = HorizontalAlignment.Center;
            sp1.Children.Add(ok);

        }

        void Box_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (!clicked)
            //{
            //    e.Cancel = true;
            //}
        }

        private void Input_MouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TextBox).Text == defaulttext && inputreset == false)
            {
                (sender as TextBox).Text = null;
                inputreset = true;
            }
        }

        void Ok_Click(object sender, RoutedEventArgs e)
        {
            //clicked = true;
            if (input.Text == defaulttext || input.Text == "")
                MessageBox.Show(errormessage, errortitle);
            else
            {
                Box.Close();
            }
            //clicked = false;
        }

        public string ShowDialog()
        {
            Box.ShowDialog();
            return input.Text;
        }
    }
}
