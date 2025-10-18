using Airport_Kiosk_System.ViewModels.Base;
using Airport_Kiosk_System.Services;
using System.Windows;
using Airport_Kiosk_System.ViewModels;

namespace Airport_Kiosk_System {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public NavigationService navigationService;
        public bool isFullscreened = false;

        public MainWindow() {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            BaseViewModel.mainWindow = this;
            
            navigationService = new NavigationService(MainFrame);
            navigationService.navigateTo(new HomePageViewModel());
        }

        public void enterFullscreenMode() {
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;
            this.Topmost = true;
            this.isFullscreened = true;
        }

        public void exitFullscreenMode() {
            this.WindowState = WindowState.Normal;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            this.Topmost = false;
            this.isFullscreened = false;
        }
    }
}
