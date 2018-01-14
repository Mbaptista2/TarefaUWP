using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TarefaUWP.Data;
using TarefaUWP.Data.Servicos;
using TarefaUWP.Model;
using TarefaUWP.View.Configuracoes;
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
            ApplicationView.PreferredLaunchViewSize = new Size(1300, 800);
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(1300, 800));
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            this.InitializeComponent();

            ViewModel = new  LancamentosVM();
            ViewModel.Initialize();
            this.DataContext = ViewModel;

            VisualStateGroupScreenWidth.CurrentStateChanged += LancamentosView_CurrentStateChanged;
            UpdateViewModelState(VisualStateGroupScreenWidth.CurrentState);
        }

        public LancamentosView(int mes, int ano)
        {                
            ViewModel = new LancamentosVM();
            ViewModel.Initialize(mes, ano);
            this.DataContext = ViewModel;
        }

        private void UpdateViewModelState(VisualState currentState)
        {
            ViewModel.State = currentState == VisualStateMinWidth1 ? LancamentosVM.PageState.MinWidth0 : LancamentosVM.PageState.MinWidth1100;

            if (ViewModel.State == LancamentosVM.PageState.MinWidth1100)
            {
                SplitView1.IsPaneOpen = true;
                HamburgerButton.Visibility = Visibility.Collapsed;
                SplitView1.DisplayMode = SplitViewDisplayMode.Inline;
                Receitas.Width = Despesas.Width = Balanco.Width = 800;
            }
            else
            {
                SplitView1.IsPaneOpen = false;
                HamburgerButton.Visibility = Visibility.Visible;
                SplitView1.DisplayMode = SplitViewDisplayMode.CompactOverlay;
                Receitas.Width = Despesas.Width = Balanco.Width = 480;
            }
        }

        private void LancamentosView_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateViewModelState(e.NewState);
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
                ViewModel.Initialize(0, 0);
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

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate<ConfiguracaoView>();
        }

        private void MenuButton3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate<EditLancamentoView>();
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Model.Lancamentos item = (Model.Lancamentos)e.ClickedItem;
            NavigationService.Navigate<EditLancamentoView>(item);
        }
    }
}
