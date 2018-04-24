using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using ZzaDesktop.Services;

namespace ZzaDesktop.Customers
{
    public class AddEditCustomerViewModel : BindableBase
    {
        //Use the dependency injection model
        private ICustomersRepository _repo;

        public AddEditCustomerViewModel(ICustomersRepository repo)
        {
            _repo = repo;  
            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        private bool CanSave()
        {
            //since we subscribed to the errorschanged, we can check.  This method is the 'canExecute' part of the command
            return !Customer.HasErrors;
        }

        private async void OnSave()
        {
            UpdateCustomer(Customer, _editingCustomer);
            if (EditMode)
                await _repo.UpdateCustomerAsync(_editingCustomer);
            else
                await _repo.AddCustomerAsync(_editingCustomer);

            Done();
        }

        private void OnCancel()
        {
            Done();
        }

        private void UpdateCustomer(SimpleEditableCustomer source, Customer target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.Phone = source.Phone;
            target.Email = source.Email;
        }

        private Boolean _EditMode;
        private Customer _editingCustomer;
        private SimpleEditableCustomer _Customer;

        public SimpleEditableCustomer Customer
        {
            get => _Customer;
            set
            {
                SetProperty(ref _Customer, value);
            }
        }
        public Boolean EditMode
        {
            get => _EditMode;
            set
            { SetProperty(ref _EditMode, value); }
        }
        public void SetCustomer(Customer cust)
        {
            _editingCustomer = cust;
            //unsubscribe if there is an existing customer
            if (Customer != null)
                Customer.ErrorsChanged -= Customer_ErrorsChanged;
            Customer = new SimpleEditableCustomer();
            //To disable the save when there are errors, subscribe to the errors changed event
            Customer.ErrorsChanged += Customer_ErrorsChanged;
            CopyCustomer(cust, Customer);
        }

        private void Customer_ErrorsChanged(object sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyCustomer(Customer source, SimpleEditableCustomer target)
        {
            target.Id = source.Id;
            if(EditMode)
            {
                target.FirstName = source.FirstName;
                target.LastName = source.LastName;
                target.Phone = source.Phone;
                target.Email = source.Email;
            }
        }


        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        //Need to signal parent viewmodel when completed
        public event Action Done = delegate { };
    }
}
