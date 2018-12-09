using UTC.Models;
using UTC.Tools;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Books.ViewModels
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        
        private User _user;
        private Clock _selectedClock;

        public MainWindowViewModel()
        {
            List<Clock> clockList = new List<Clock>
            {
               new Clock(),
               new Clock()
            };

            _user = new User
            {
                Username = "TestName",
                Password = "1234",
                ClockList = clockList
            };

            AddCommand = new DelegateCommand(AddClock);
            RemoveCommand = new DelegateCommand(RemoveClock, CanRemoveClock);

            ClockList = new ObservableCollection<Clock>(_user.ClockList);
        }

        public Clock SelectedClock
        {
            get { return _selectedClock; }
            set
            {
                _selectedClock = value;
                OnPropertyChanged("SelectedClock");
            }
        }

        public ObservableCollection<Clock> ClockList
        {
            get;
            private set;
        }

        public ICommand AddCommand
        {
            get;
            private set;
        }

        public ICommand RemoveCommand
        {
            get;
            private set;
        }

        public void AddClock(object obj)
        {
            ClockList.Add(new Clock());
        }

        public void RemoveClock(object obj)
        {
           ClockList.Remove((Clock)obj);
        }

        public bool CanRemoveClock(object arg)
        {
            return (arg as Clock) != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
