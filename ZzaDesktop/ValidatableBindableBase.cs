using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZzaDesktop
{
    //Class to be used to bring validation logic for all viewmodels
    // INotifyDataErrorInfo is the interface to inherit from for validation
    public class ValidatableBindableBase : BindableBase, INotifyDataErrorInfo
    {
        // Key of String = property name, with a list of string per property - all the errors per property
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public bool HasErrors
        { 
            get =>  _errors.Count > 0;
        }
        //need the  = delegate{} to not get null error
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
                return _errors[propertyName];
            else return null;
        }
        //Need a trigger to specify WHEN it evaluates errors
        protected override void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            // call base to set property, then call validation
            base.SetProperty(ref member, val, propertyName);
            ValidateProperty(propertyName, val);
        }

        private void ValidateProperty<T>(string propertyName, T val)
        {
            // use data annotations for validation.  
            var results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(this);
            //point at what member is being validated
            context.MemberName = propertyName;
            //goes to that object, and looks for data annotation properties for validation
            Validator.TryValidateProperty(val, context, results);
            if(results.Any())
            {
                _errors[propertyName] = results.Select(c => c.ErrorMessage).ToList();
            }
            else
            {
                _errors.Remove(propertyName);
            }
            //raise event
            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
