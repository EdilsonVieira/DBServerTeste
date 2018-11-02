using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Testes
{
    public class Address
    {
        public Address(string anAddress1, string anAddress2, string aCity, string aState
            , string aZipoCode, string aCountry)
        {
            Address1 = anAddress1;
            Address2 = anAddress2;
            City = aCity;
            State = aState;
            ZipCode = aZipoCode;
            Country = aCountry;
        }
        public string Address1;
        public string Address2;
        public string City;
        public string State;
        public string ZipCode;
        public string Country;
    }
    public enum TitleEnum
    {
        Mr, Mrs
    }
    public class PersonalInfo
    {
        public PersonalInfo(TitleEnum aTitle, string aFirstName, string aLastName, string anEmail, string aPassword
            , DateTime aBirthDate, Boolean aNewsLetter, Boolean aSpecialOffers, string aCompany, Address anAddress
            , string anAddressAlias, string anAditionalInfo, string aHomePhone, string aMobilePhone)
        {
            Title = aTitle;
            FirstName = aFirstName;
            LastName = aLastName;
            Email = anEmail;
            Password = aPassword;
            BirthDate = aBirthDate;
            Newsletter = aNewsLetter;
            SpecialOffers = aSpecialOffers;
            Company = aCompany;
            Address = anAddress;
            AddressAlias = anAddressAlias;
            AdditionalInfo = anAditionalInfo;
            HomePhone = aHomePhone;
            MobilePhone = aMobilePhone;
        }
        public TitleEnum Title;
        public string FirstName;
        public string LastName;
        public string Email;
        public string Password;
        public DateTime BirthDate;
        public Boolean Newsletter;
        public Boolean SpecialOffers;
        public string Company;
        public Address Address;
        public string AddressAlias;
        public string AdditionalInfo;
        public string HomePhone;
        public string MobilePhone;
    }
}
