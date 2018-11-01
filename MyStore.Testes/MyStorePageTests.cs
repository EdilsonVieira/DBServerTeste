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
        //[InlineData(Browser.Firefox, 100, 160.9)]
        //[InlineData(Browser.Firefox, 230.05, 370.1505)]
        [InlineData(Browser.Firefox, "vieira.edilson@gmail.com", "canada", "R Bahia, 288", MyStorePageMap.PaymentByBankWire)]
        //[InlineData(Browser.Firefox, "vieira.edilson@gmail.com", "canada", "R Bahia, 288", MyStorePageMap.PaymentByCheck)]
        //[InlineData(Browser.Chrome, 100, 160.9)]
        //[InlineData(Browser.Chrome, 230.05, 370.1505)]
        //[InlineData(Browser.Chrome, 250.5, 403.0545)]
        public void Compra_Completa(
            Browser browser, string clientEmail, string clientPass, string clientAddress, string paymentBy)
        {
            MyStorePage aPage =  new MyStorePage(_configuration, browser);
            Boolean result = false;

            aPage.LoadPage();
            aPage.Summary();
            aPage.Login(clientEmail, clientPass);
            aPage.Address(clientAddress);
            aPage.Shipping();
            aPage.Payment(paymentBy);
            result = aPage.Confirm();
            aPage.Close();
            Assert.True(result);
        }
    }
}