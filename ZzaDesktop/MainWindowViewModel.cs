using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZzaDesktop.Customers;
using ZzaDesktop.Orders;
using ZzaDesktop.OrderPrep;
using System.ComponentModel;
using ZzaDesktop.Services;
using Unity;

namespace ZzaDesktop
{
    //Need to support INPC whenever you set a property you are bound to after the initialization
    public class MainWindowViewModel : BindableBase
    {
        //could declare here, but now parent has concrete dependency on an object it doesn't use directly.  Need an IOC container instead
        //Will use Unity container  instead
        //private ICustomersRepository _repo = new CustomersRepository();
       
        //Allow Main Window to act as a parent in a hierarchy of ViewModels
        private CustomerListViewModel _customerListViewModel;
        private OrderPrepViewModel _orderPrepViewModel = new OrderPrepViewModel();
        private OrderViewModel _orderViewModel = new OrderViewModel();
        private AddEditCustomerViewModel _addEditCustomerViewModel;

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);
            //after DI changes, without IOC container..
            //_customerListViewModel = new CustomerListViewModel(_repo);
            //_addEditCustomerViewModel = new AddEditCustomerViewModel(_repo);

            //DI with IOC Unity
            _customerListViewModel = ContainerHelper.Container.Resolve<CustomerListViewModel>();
            _addEditCustomerViewModel = ContainerHelper.Container.Resolve<AddEditCustomerViewModel>();


            //subscribe to event from child viewmodel
            _customerListViewModel.PlaceOrderRequested += _customerListView_PlaceOrderRequested;
            //adding the add/edit, created events, need to subscribe to them
            _customerListViewModel.AddCustomerRequested += _customerListViewModel_AddCustomerRequested;
            _customerListViewModel.EditCustomerRequested += _customerListViewModel_EditCustomerRequested;
            //Done event from add/edit
            _addEditCustomerViewModel.Done += _addEditCustomerViewModel_Done;
        }

        private void _addEditCustomerViewModel_Done()
        {
            CurrentViewModel = _customerListViewModel;
        }

        private void _customerListViewModel_EditCustomerRequested(Zza.Data.Customer cust)
        {
            _addEditCustomerViewModel.EditMode = true;
            _addEditCustomerViewModel.SetCustomer(cust);
            CurrentViewModel = _addEditCustomerViewModel;
        }

        private void _customerListViewModel_AddCustomerRequested(Zza.Data.Customer cust)
        {
            _addEditCustomerViewModel.EditMode = false;
            _addEditCustomerViewModel.SetCustomer(cust);
            CurrentViewModel = _addEditCustomerViewModel;
        }

        private void _customerListView_PlaceOrderRequested(Guid customerId)
        {
            _orderViewModel.CustomerId = customerId;
            CurrentViewModel = _orderViewModel;
        }

        private BindableBase _CurrentViewModel;
        public BindableBase CurrentViewModel
        { 
           get  { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        //relay command takes an action(method) as a parameter
        public RelayCommand<string> NavCommand { get; private set; }

        //Setup navigation between view models.  We can setup a command to call this
        private void OnNav(string destination)
        {
            switch(destination)
            {
                case "orderPrep" :
                    CurrentViewModel = _orderPrepViewModel;
                    break;
                case "customers":
                default:
                    CurrentViewModel = _customerListViewModel;
                    break;
            }
                

            
        }
    }


}
