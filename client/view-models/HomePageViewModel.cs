using Airport_Kiosk_System.ViewModels.Base;
using Airport_Kiosk_System.Views;
using System.Windows.Controls;

namespace Airport_Kiosk_System.ViewModels {
    public partial class HomePageViewModel : BaseViewModel {
        public HomePageViewModel() {}

        public override Page getView() {
            return new HomePage(this);
        }
    }
}
