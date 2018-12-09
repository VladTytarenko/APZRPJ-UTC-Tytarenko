using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace UTC.Models
{
    public class User : INotifyPropertyChanged
    {
        private string username;
        private string password;
        private List<Clock> clockList;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public List<Clock> ClockList
        {
            get
            {
                return clockList;
            }
            set
            {
                clockList = value;
                OnPropertyChanged("ClockList");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
