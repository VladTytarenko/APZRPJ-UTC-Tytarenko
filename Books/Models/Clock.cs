using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace UTC.Models
{
    public class Clock : INotifyPropertyChanged
    {
        
        private string _currentTime;
        private string _utcZone;

        private static List<string> _utcZoneList;

        static Clock()
        {
            _utcZoneList = new HashSet<string>(TimeZoneInfo.GetSystemTimeZones().Select(z => z.Id).ToList()).ToList();
        }

        public string CurrentTime
        {
            get
            {
                return _currentTime;
            }
            set
            {
                if (_currentTime == value)
                    return;
                _currentTime = value;
                OnPropertyChanged("CurrentTime");
            }
        }

        public string SelectedZone
        {
            get { return _utcZone; }
            set
            {
                _utcZone = value;
                var disTimer = new DispatcherTimer(DispatcherPriority.Render);
                disTimer.Interval = TimeSpan.FromSeconds(1);
                disTimer.Tick += (sender, args) =>
                {
                    CurrentTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(_utcZone)).ToLongTimeString();
                };
                disTimer.Start();
                OnPropertyChanged("SelectedZone");
            }
        }

        public static List<string> UtcZoneList
        {
            get
            {
                return _utcZoneList;  
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
