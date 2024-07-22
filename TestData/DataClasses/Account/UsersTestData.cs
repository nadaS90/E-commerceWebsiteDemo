using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBasics.TestData.DataClasses.Account
{
    public class UsersTestData
    {
        private string _firstName;
        private string _lastName;
        private string _validEmailAddress;
        private string _inValidEmailAddress;
        private string _password;
        private string _invalidPassword;
        private string _country;
        private string _city;
        private string _postalCode;
        private string _mobileNumber;
        private string _address;
        private string _gender;




        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string ValidEmailAddress { get => _validEmailAddress; set => _validEmailAddress = value; }
        public string InValidEmailAddress { get => _inValidEmailAddress; set => _inValidEmailAddress = value; }
        public string Password { get => _password; set => _password = value; }
        public string InvalidPassword { get => _invalidPassword; set => _invalidPassword = value; }
        public string Country { get => _country; set => _country = value; }
        public string Address { get => _address; set => _address = value; }
        public string City { get => _city; set => _city = value; }
        public string PostalCode { get => _postalCode; set => _postalCode = value; }
        public string MobileNumber { get => _mobileNumber; set => _mobileNumber = value; }
        public string Gender { get => _gender; set => _gender = value; }

    }
}
