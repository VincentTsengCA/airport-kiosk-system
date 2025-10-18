using Airport_Kiosk_System.ViewModels.Base;
using Airport_Kiosk_System.Views;
using System.Windows;
using System.Windows.Controls;

namespace Airport_Kiosk_System.ViewModels {
    public partial class HomePageViewModel : BaseViewModel {
        public RelayCommand exitCommand { get; private set; }
        public RelayCommand fullscreenCommand { get; private set; }

        public HomePageViewModel() {
            exitCommand = new RelayCommand(execute => { exitApplication(); }, canExecute => { return true; });
            fullscreenCommand = new RelayCommand(execute => { toggleFullscreenMode(); }, canExecute => { return true; });
        }

        public override Page getView() {
            return new HomePage();
        }

        private void exitApplication() {
            Application.Current.Shutdown(0);
        }

        private void toggleFullscreenMode() {
            if (mainWindow.isFullscreened) {
                mainWindow.exitFullscreenMode();
            }

            else {
                mainWindow.enterFullscreenMode();
            }
        }
    }
}
