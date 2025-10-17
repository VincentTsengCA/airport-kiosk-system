using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Airport_Kiosk_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool isFullscreened = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void onExitButtonClicked(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown(0);
        }

        private void onFullscreenClicked(object sender, RoutedEventArgs e) {
            if (isFullscreened) {
                exitFullscreenMode();
            }

            else {
                enterFullscreenMode();
            }
        }

        private void enterFullscreenMode() {
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;
            this.Topmost = true;
            this.isFullscreened = true;
        }

        private void exitFullscreenMode() {
            this.WindowState = WindowState.Normal;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            this.Topmost = false;
            this.isFullscreened = false;
        }
    }
}