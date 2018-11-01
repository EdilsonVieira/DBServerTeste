using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Testes
{
    class Address
    {
        string Address1;
        string Address2;
        string City;
        string State;
        string ZipCode;
        string Country;
    }
    public enum TitleEnum
    {
        Mr, Mrs
    }
    class PersonalInfo
    {
        TitleEnum Title;
        string FirstName;
        string LastName;
        string Email;
        string Password;
        DateTime BirthDate;
        Boolean Newsletter;
        Boolean SpecialOffers;
        string Company;
        Address Address;
        string AddressAlias;
        string AdditionalInfo;
        string HomePhone;
        string MobilePhone;
    }
}
