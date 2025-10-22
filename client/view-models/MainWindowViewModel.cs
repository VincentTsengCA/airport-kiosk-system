using Airport_Kiosk_System.Models;
using Airport_Kiosk_System.Services;
using Airport_Kiosk_System.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Airport_Kiosk_System.ViewModels {
    public partial class MainWindowViewModel : BaseViewModel {
        public ObservableCollection<User> users;
        public NavigationService navigationService;
        public TcpClientService tcpClientService;

        public bool isFullscreened = false;

        public RelayCommand exitCommand { get; private set; }
        public RelayCommand fullscreenCommand { get; private set; }

        public MainWindowViewModel() {
            mainWindowViewModel = this;

            exitCommand = new RelayCommand(execute => { exitApplication(); }, canExecute => { return true; });
            fullscreenCommand = new RelayCommand(execute => { toggleFullscreenMode(); }, canExecute => { return true; });

            navigationService = new NavigationService(mainWindow.MainFrame);
            navigationService.navigateTo(new HomePageViewModel());

            tcpClientService = new TcpClientService();
        }

        public override Page getView() {
            return null;
        }

        private void exitApplication() {
            Application.Current.Shutdown(0);
        }

        private void toggleFullscreenMode() {
            tcpClientService.getUserInfoFromServer(new User(), ["firstName", "lastName", "id"]);
            if (isFullscreened) {
                exitFullscreenMode();
            }

            else {
                enterFullscreenMode();
            }
        }

        public void enterFullscreenMode() {
            mainWindow.WindowState = WindowState.Maximized;
            mainWindow.WindowStyle = WindowStyle.None;
            mainWindow.Topmost = true;
            isFullscreened = true;
        }

        public void exitFullscreenMode() {
            mainWindow.WindowState = WindowState.Normal;
            mainWindow.WindowStyle = WindowStyle.SingleBorderWindow;
            mainWindow.Topmost = false;
            isFullscreened = false;
        }
    }
}
