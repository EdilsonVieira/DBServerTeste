using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Xunit;
using Selenium.Utils;

namespace MyStore.Testes
{
    public class TestesComprasOnline
    {
        private IConfiguration _configuration;

        public TestesComprasOnline()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            _configuration = builder.Build();
        }

        [Theory]
        //[InlineData(Browser.Firefox, 100, 160.9)]
        //[InlineData(Browser.Firefox, 230.05, 370.1505)]
        [InlineData(Browser.Firefox, "http://automationpractice.com/index.php?controller=cart&add=1&id_product=1&token=e817bb0705dd58da8db074c69f729fd8", "vieira.edilson@gmail.com", "canada", "R Bahia, 288")]
        //[InlineData(Browser.Chrome, 100, 160.9)]
        //[InlineData(Browser.Chrome, 230.05, 370.1505)]
        //[InlineData(Browser.Chrome, 250.5, 403.0545)]
        public void TestarCompra(
            Browser browser, string targetProduct, string clientEmail, string clientPass, string clientAddress)
        {
            MyStorePage aPage =  new MyStorePage(_configuration, browser);
            Boolean result = false;

            aPage.LoadPage();
            aPage.Summary(targetProduct);
            aPage.Login(clientEmail, clientPass);
            aPage.Address(clientAddress);
            aPage.Shipping();
            aPage.Payment();
            result = aPage.Confirm();
            aPage.Close();
            Assert.True(result);
        }
    }
}