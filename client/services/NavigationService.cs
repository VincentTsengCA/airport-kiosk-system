using Airport_Kiosk_System.ViewModels.Base;
using System.Windows.Controls;

namespace Airport_Kiosk_System.Services {
    public partial class NavigationService {
        private readonly Frame frame;

        public NavigationService(Frame frame) {
            this.frame = frame;
        }

        public void navigateTo(BaseViewModel viewModel) {
            frame.Navigate(viewModel.getView());
        }
    }
}
