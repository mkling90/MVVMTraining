using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using MVVMTraining.Services;
using System.ComponentModel;


namespace MVVMTraining.Customers
{
    // View model should implement INotifyPropertyChanged so controls can be aware when the underlying data changes
    public class CustomerListViewModel: INotifyPropertyChanged
    {
        //public ObservableCollection<Customer> Customers { get => _customers; set => _customers = value; }
        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                if(_customers != value)
                {
                    _customers = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Customers"));
                }
            }
        }
        private ICustomersRepository _repo = new CustomersRepository();
        private ObservableCollection<Customer> _customers;
        //private setter, only the viewmodel itself on construction should set this, ICommand implementation
        public RelayCommand DeleteCommand { get; private set; }
        //property to bind to for deletion, etc..
        private Customer _selectedCustomer;

        //add the '= delegate { }' anonymous method as a subscriber so we don't worry about it being null
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    DeleteCommand.RaiseCanExecuteChanged();
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedCustomer"));
                }
            }
        }

        public CustomerListViewModel()
        {
            //Loading the data in the constructor, forcing it to be synchronous.
            //removed to move it to the async loaded method (purposed of the loaded method name)
            /*
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;
            Customers = new ObservableCollection<Customer>(_repo.GetCustomersAsync().Result); 
            */
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        }

        public async void LoadCustomers()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;
            Customers = new ObservableCollection<Customer>(await _repo.GetCustomersAsync()); //remove 'result' which forced it to be synchronous
            //note will need to attach property changed events to display 
        }

        private void OnDelete()
        {
            Customers.Remove(SelectedCustomer);
        }
        private bool CanDelete()
        {
            return SelectedCustomer != null;
        }
    }
}
