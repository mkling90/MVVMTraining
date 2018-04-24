using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZzaDesktop.Customers
{
    public class SimpleEditableCustomer : ValidatableBindableBase
    {
        private Guid _id;

        public Guid Id
        {
            get => _id;
            set
            {
                SetProperty(ref _id, value);
            }
        }

        private string _firstname;
        //add data annotation attributes for validation
        [Required]
        public string FirstName
        {
            get => _firstname;
            set
            {
                SetProperty(ref _firstname, value);
            }
        }

        private string _lastname;
        [Required]
        public string LastName
        {
            get => _lastname;
            set
            {
                SetProperty(ref _lastname, value);
            }
        }

        private string _email;
        [EmailAddress]
        public string Email
        {
            get => _email;
            set
            {
                SetProperty(ref _email, value);
            }
        }
        private string _phone;

        [Phone]
        public string Phone
        {
            get => _phone;
            set
            {
                SetProperty(ref _phone, value);
            }
        }
    }
}
