using Newtonsoft.Json;
using System;
using TarefaUWP.Data.Servicos;
using TarefaUWP.View.Configuracoes;
using TarefaUWP.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Model.Lancamentos lancamento = null;

            if (e.Parameter != null)
                lancamento = JsonConvert.DeserializeObject<Model.Lancamentos>(e.Parameter.ToString());
            else
                DeleteButton.Visibility = Visibility.Collapsed;

            ViewModel.Lancamento = lancamento ?? new Model.Lancamentos();
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbTipo.Items[CbTipo.SelectedIndex] is ComboBoxItem comboBoxItem)
            {
                ViewModel.Lancamento.Tipo = comboBoxItem.Tag.ToString();
            }
        }

        private void Data_Loaded(object sender, RoutedEventArgs e)
        {
            Data.Date = System.DateTimeOffset.Now;
        }

        private void CbTipo_Loaded(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(ViewModel.Lancamento.Id))
            {
                ViewModel.Lancamento.Tipo = ((ComboBoxItem) CbTipo.Items[0]).Tag.ToString();
            }
            else
            {
                CbTipo.SelectedIndex = ViewModel.Lancamento.Tipo == "D" ? 0 : 1;
            }
        }
      
        private void txtValor_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.Key.ToString(), "[0-9]"))
                e.Handled = false;
            else e.Handled = true;
        }
        private bool _dialogTriggered;

        private void ShowAppResetMessage()
        {
            if (_dialogTriggered)
            {
                return;
            }

            _dialogTriggered = true;

            var dialog = new ContentDialog
            {
                Title = "Aviso",
                Content = "Favor preencher um valor válido.",
                PrimaryButtonText = "OK"
            };

            dialog.PrimaryButtonClick += (s, e) =>
            {
                _dialogTriggered = false;
            };

            dialog.ShowAsync();
        }

        private void txtValor_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {                
                if (txtValor.Text != string.Empty)
                    txtValor.Text = string.Format("{0:0.00}", double.Parse(txtValor.Text));
                else
                    txtValor.Text = "0";
            }
            catch 
            {
                txtValor.Text = "0";
                ShowAppResetMessage();
            }
        }
    }
}
