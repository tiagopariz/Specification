using Specification.Notifications;
using Specification.Domain.Contracts;
using Specification.Domain.Entities;

namespace Specification.Domain.ValueObjects
{
    public class Email : ValueObjectBase<EmailContract, Notification>
    {
        #region Constants

        public const int AddressMaxLength = EmailContract.AddressMaxLength;
        public const int AddressMinLength = EmailContract.AddressMinLength;

        #endregion

        #region Private properties

        #endregion

        #region Public properties

        public string Address { get; }
        public override bool Required { get; }

        #endregion

        #region Private Methods

        private void IsValid(string address)
        {
            
            foreach (var notification in Contract.IsEmail(address, "Email", "Email inválido").Notifications)
                AddNotification(notification);

            if (Required)
                Contract.IsEmailOrEmpty(address, "Email", "Email inválido: " + address);

            Contract.IsValid();
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return Address;
        }

        #endregion

        #region Constructors

        public Email(string address, bool required = false)
        {
            IsValid(address);

            Address = address.ToLower();
            Required = required;
        }

        #endregion
    }
}