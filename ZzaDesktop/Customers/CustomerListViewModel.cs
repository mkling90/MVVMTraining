using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using ZzaDesktop.Services;

namespace ZzaDesktop.Customers
{
    public class CustomerListViewModel : BindableBase
    {
        //Basic 3 steps for command handling - add expose Command property, construct the command in constructor,
        //          and define the handling method
        public RelayCommand<Customer> PlaceOrderCommand { get; private set; }
        public RelayCommand AddCustomerCommand { get; private set; }
        public RelayCommand<Customer> EditCustomerCommand { get; private set; }
        public RelayCommand ClearSearchCommand { get; private set; }

        //declare an event for parent to subscribe to, which command method will raise
        public event Action<Guid> PlaceOrderRequested = delegate { };
        public event Action<Customer> AddCustomerRequested = delegate { };
        public event Action<Customer> EditCustomerRequested = delegate { };
        public event Action ClearSearchRequested = delegate { };

        //Temporary before depend injection
        //Hard to unit test with this method, because the real repo goes to the database, would like to substitute a mock object
        //private ICustomersRepository _repo = new CustomersRepository();

        //after DI
        private ICustomersRepository _repo;

        private string _SearchInput;
        public string SearchInput
        {
            get => _SearchInput;
            set
            {
                SetProperty(ref _SearchInput, value);
                FilterCustomers(_SearchInput);
            }
        }

        public CustomerListViewModel(ICustomersRepository repo)
        {
            _repo = repo;
            PlaceOrderCommand = new RelayCommand<Customer>(OnPlaceOrder);
            AddCustomerCommand = new RelayCommand(OnAddCustomer);
            EditCustomerCommand = new RelayCommand<Customer>(OnEditCustomer);
            ClearSearchCommand = new RelayCommand(OnClearSearch);
        }
        private List<Customer> _allCustomers = new List<Customer>();
        private ObservableCollection<Customer> _customers;

        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set => SetProperty(ref _customers, value);
        }

        //Quickest way to hook up a loading method is via Blend, add Assets->Behaviors-> CallMethodAction to the control
        public async void LoadCustomers()
        {
            //wire up a loading method
            _allCustomers = await _repo.GetCustomersAsync();
            Customers = new ObservableCollection<Customer>(_allCustomers);
        }

       

        private void OnPlaceOrder(Customer customer)
        {
            //Raise event
            PlaceOrderRequested(customer.Id);
        }

        private void OnAddCustomer()
        {
            //Raise event
            AddCustomerRequested(new Customer() { Id = Guid.NewGuid() });
            
        }
        private void OnEditCustomer(Customer customer)
        {
            //Raise event
            EditCustomerRequested(customer);  
        }

        private void OnClearSearch()
        {
            SearchInput = null;
        }

        private void FilterCustomers(string searchInput)
        {
            if(String.IsNullOrWhiteSpace(searchInput))
            {
                Customers = new ObservableCollection<Customer>(_allCustomers);
                return;
            }
            else
            {
                Customers = new ObservableCollection<Customer>(_allCustomers.Where(c => c.FullName.ToLower().Contains(searchInput)));
            }
        }

    }
}
