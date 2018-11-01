using System;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Utils;

namespace MyStore.Testes
{
    public class MyStorePage
    {
        private IConfiguration _configuration;
        private Browser _browser;
        private IWebDriver _driver;

        public MyStorePage(
            IConfiguration configuration, Browser browser)
        {
            _configuration = configuration;
            _browser = browser;

            string caminhoDriver = null;
            if (browser == Browser.Firefox)
            {
                caminhoDriver =
                    _configuration.GetSection("Selenium:CaminhoDriverFirefox").Value;
            }
            else if (browser == Browser.Chrome)
            {
                caminhoDriver =
                    _configuration.GetSection("Selenium:CaminhoDriverChrome").Value;
            }

            _driver = WebDriverFactory.CreateWebDriver(
                browser, caminhoDriver);
        }
        public void LoadPage()
        {
            _driver.Url = _configuration.GetSection("Selenium:UrlMyStore").Value;
        }

        public void Summary()
        {
            _driver.Click(By.XPath(MyStorePageMap.FirstProductImage));
            _driver.WaitNClick(15, By.Name(MyStorePageMap.AddToCartButton));
            _driver.WaitNClick(10, By.LinkText(MyStorePageMap.ProceedToCheckout));
            _driver.WaitNClick(10, By.LinkText(MyStorePageMap.ProceedToCheckout));
        }

        public void Login(string clientEmail, string clientPass)
        {
            _driver.WaitNSetText(10, By.Id(MyStorePageMap.Email), clientEmail);
            IWebElement aTextInput = _driver.FindElement(By.Id(MyStorePageMap.Password));
            aTextInput.SendKeys(clientPass);
            aTextInput.SendKeys(Keys.Tab);
            aTextInput.SendKeys(Keys.Tab);
            aTextInput.SendKeys(Keys.Enter);
            //todo: se houve falha de autenticação, entrar na criação de conta
            /*if (By.XPath(MyStorePageMap.AuthFailedElement) != null)
            {
                string failedText = _driver.GetText(By.XPath(MyStorePageMap.AuthFailedElement));
                if (failedText == MyStorePageMap.AuthFailedText)
                {
                    // todo: create account
                    _driver.SetText(By.Id(MyStorePageMap.EmailCreate), clientEmail);
                    _driver.Click(By.Id(MyStorePageMap.SubmitCreate));

                }
            }*/
        }

        public void Address(string address)
        {
            _driver.WaitNClick(10, By.Name(MyStorePageMap.ProcessAddress));
        }

        public void Shipping()
        {
            _driver.WaitNClick(10, By.Id(MyStorePageMap.TermsOfService));
            _driver.WaitNClick(10, By.Name(MyStorePageMap.ProcessShipping));
        }

        public void Payment(string paymentBy)
        {
            _driver.WaitNClick(10, By.ClassName(paymentBy));
        }

        public Boolean Confirm()
        {
            _driver.Click(By.XPath(MyStorePageMap.OrderConfirmationButton));
            string orderConfirmationText = _driver.GetText(By.XPath(MyStorePageMap.OrderConfirmationTextElement));
            return (orderConfirmationText == MyStorePageMap.OrderConfirmationText);
        }

        public void Close()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
