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

        private void LancamentosView_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.Initialize();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView1.IsPaneOpen = !SplitView1.IsPaneOpen;
        }
        
    }
    
}
