using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Selenium.Utils;

namespace MyStore.Testes
{
    public class MyStoreTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
           new object[] {Browser.Firefox, new PersonalInfo(TitleEnum.Mr, "Edilson", "Vieira", "vieira.edilson.br@gmail.com"
               , "canada", DateTime.ParseExact("10/07/1969", "dd/MM/yyyy", CultureInfo.InvariantCulture), false, false
               , "DBServer", new Address("Rua Bahia, 288", "Sobrado - Brasilândia", "São Gonçalo", "Rio de Janeiro"
               , "24465", "Brazil"), "MyAddress", "", "", "992454633"), MyStorePageMap.PaymentByBankWire}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
