using Act.Wpf.Commands;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Act.Wpf
{
    public class MyClass : INotifyPropertyChanged
    {
        public MyClass(string name)
        {
            this._canExecute = true;
            this.Name = name;

            this.ClickCommand = new CommandHandler(MyAction, true);
            ClickRelayCommand = new RelayCommand(a => MyAction(), b => !string.IsNullOrEmpty(this.Name));
        }

        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public void MyAction()
        {
            throw new Exception("test exception");
        }

        private bool _canExecute;
        public ICommand ClickCommand { get; set; }
        public ICommand ClickRelayCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CommandHandler : ICommand
    {
        public CommandHandler(Action action, bool canExecute)
        {
            _action = action;
        }

        private Action _action;
        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return true;// _canExecute;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }

}
