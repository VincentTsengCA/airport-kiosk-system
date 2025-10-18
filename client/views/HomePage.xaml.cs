using Airport_Kiosk_System.ViewModels;
using System.Windows.Controls;

namespace Airport_Kiosk_System.Views {
    public partial class HomePage : Page {
        public HomePage() {
            InitializeComponent();
            this.DataContext = new HomePageViewModel();
        }
    }
}
