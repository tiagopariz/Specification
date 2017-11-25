using Specification.Notifications;
using Specifications.Domain.Contracts;
using Specifications.Domain.Entities;

namespace Specifications.Domain.ValueObjects
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

        public string Address { get; private set; }

        #endregion

        #region Private Methods

        private bool IsValid(string address)
        {
            Contract.IsEmail(address, "Email", "Email inválido");
            return Contract.IsValid();
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return Address;
        }

        #endregion

        #region Constructors

        public Email(string address)
        {

            AddNotification(new Notification("General", "Mail", SeverityType.Information));

            if (IsValid(address))
            {
                return;
            }

            Address = address.ToLower();
        }

        #endregion
    }
}