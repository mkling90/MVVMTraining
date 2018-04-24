using MVVMTraining.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MVVMTraining
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //Timer to trigger the notifications
        private Timer _timer = new Timer(5000);


        public object CurrentViewModel { get; set; }

        public MainWindowViewModel()
        {
            //static, could use the view model locator
            //allows for implicit data templates
            CurrentViewModel = new CustomerListViewModel();
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            NotificationMessage = $"At the tone the time will be:  {DateTime.Now.ToLocalTime()}";
        }

        private string _NotificationMessage;
        public String NotificationMessage
        {
            get => _NotificationMessage;
            set
            {
                if(value != _NotificationMessage)
                {
                    _NotificationMessage = value;
                    PropertyChanged(this, new PropertyChangedEventArgs( "NotificationMessage"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
