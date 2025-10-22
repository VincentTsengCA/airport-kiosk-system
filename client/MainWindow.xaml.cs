using Airport_Kiosk_System.ViewModels.Base;
using Airport_Kiosk_System.ViewModels;
using System.Windows;

namespace Airport_Kiosk_System {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            BaseViewModel.mainWindow = this;

            this.DataContext = new MainWindowViewModel();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
