using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Xunit;
using Selenium.Utils;

namespace MyStore.Testes
{
    public class ComprasOnline
    {
        private IConfiguration _configuration;

        public ComprasOnline()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            _configuration = builder.Build();
        }

        [Theory]
        [ClassData(typeof(MyStoreTestData))]
        public void Compra_Completa(
            Browser browser, PersonalInfo clientData, string paymentBy)
        {
            Boolean result = false;

            MyStorePage aPage =  new MyStorePage(_configuration, browser);

            aPage.LoadPage();
            aPage.Summary();
            aPage.Login(clientData);
            aPage.Address(clientData);
            aPage.Shipping();
            aPage.Payment(paymentBy);
            result = aPage.Confirm();
            aPage.Close();
            Assert.True(result);
        }
    }
}