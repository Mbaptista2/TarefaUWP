using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TarefaUWP.Data;
using TarefaUWP.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TarefaUWP.View.Lancamentos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LancamentosView : Page
    {
        public LancamentosVM ViewModel { get; set; }

        public LancamentosView()
        {
            this.InitializeComponent();
         
            ApplicationView.PreferredLaunchViewSize = new Size(1000, 800);
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(1000, 800));           
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            ViewModel = new  LancamentosVM();
            ViewModel.Initialize();
            this.DataContext = ViewModel;
        }

        public LancamentosView(int mes, int ano)
        {                
            ViewModel = new LancamentosVM();
            ViewModel.Initialize(mes, ano);
            this.DataContext = ViewModel;
        }
        

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView1.IsPaneOpen = !SplitView1.IsPaneOpen;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] mesano = cbMesAno.SelectedItem.ToString().Split('/');

            if (mesano.Length > 1)
                ViewModel.Initialize(RetornaMes(mesano[0]), Convert.ToInt32(mesano[1]));
            else
                ViewModel.Initialize();
            this.DataContext = ViewModel;
        }
        private int RetornaMes(string mes)
        {
            switch (mes)
            {
                case "Janeiro": return 1;
                case "Fevereiro": return 2;
                case "Março": return 3;
                case "Abril": return 4;
                case "Maio": return 5;
                case "Junho": return 6;
                case "Julho": return 7;
                case "Agosto": return 8;
                case "Setembro": return 9;
                case "Outubro": return 10;
                case "Novembro": return 11;
                case "Dezembro": return 12;
                default: return 99;
            }
        }
    }
    
}
