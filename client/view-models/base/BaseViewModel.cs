using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace Airport_Kiosk_System.ViewModels.Base {
    public abstract class BaseViewModel : INotifyPropertyChanged {
        public static MainWindow mainWindow { get; set; }
        public static MainWindowViewModel mainWindowViewModel { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void onPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract Page getView();
    }

    public class RelayCommand : ICommand {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public event EventHandler? CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null) {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object? parameter) {
            execute(parameter);
        }
    }
}
