using System;
using System.Collections.Generic;
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
using Newtonsoft.Json;
using TarefaUWP.Data.Servicos;
using TarefaUWP.ViewModel;
using TarefaUWP.Model;
using TarefaUWP.View.Configuracoes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TarefaUWP.View.Lancamentos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditLancamentoView : Page
    {
        public LancamentosVM ViewModel { get; } = new LancamentosVM();

        public static readonly DependencyProperty EditLancamentoProperty =
            DependencyProperty.Register("EditLancamento", typeof(Model.Lancamentos), typeof(EditLancamentoView), new PropertyMetadata(new Model.Lancamentos()));

        public EditLancamentoView()
        {
            this.InitializeComponent();
        }
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView1.IsPaneOpen = !SplitView1.IsPaneOpen;
        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate<ConfiguracaoView>();
        }

        private void MenuButton3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate<EditLancamentoView>();
        }

        public Model.Lancamentos EditTodoItem
        {
            get => (Model.Lancamentos)GetValue(EditLancamentoProperty);
            set
            {
                SetValue(EditLancamentoProperty, value);
                ViewModel.Lancamento = value;
                ViewModel.Initialize();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Model.Lancamentos lancamento = null;

            if(e.Parameter != null)
                lancamento = JsonConvert.DeserializeObject<Model.Lancamentos>(e.Parameter.ToString());

            ViewModel.Lancamento = lancamento ?? new Model.Lancamentos();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbTipo.Items[CbTipo.SelectedIndex] is ComboBoxItem comboBoxItem)
            {
                ViewModel.Lancamento.Tipo = comboBoxItem.Tag.ToString();
            }
        }
    }
}
