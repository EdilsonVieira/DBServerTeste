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
            //_driver.LoadPage(TimeSpan.FromSeconds(15),
            //    _configuration.GetSection("Selenium:UrlMyStore").Value);
        }

        public void Summary(string product)
        {
            IWebElement aLinkBtn;
            //_driver.Submit(By.CssSelector(product));
            _driver.Url = product;
            //aLinkBtn = _driver.FindElement(By.LinkText("Add to cart"));            
            //aLinkBtn.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.LinkText("Proceed to checkout")) != null);
            aLinkBtn = _driver.FindElement(By.LinkText("Proceed to checkout"));
            aLinkBtn .Click();
        }

        public void Login(string clientEmail, string clientPass)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Id("email")) != null);
            IWebElement aTextInput = _driver.FindElement(By.Id("email"));
            aTextInput.SendKeys(clientEmail);
            aTextInput = _driver.FindElement(By.Id("passwd"));
            aTextInput.SendKeys(clientPass);
            aTextInput.SendKeys(Keys.Tab);
            aTextInput.SendKeys(Keys.Tab);
            aTextInput.SendKeys(Keys.Enter);
        }

        public void Address(string address)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Name("processAddress")) != null);
            IWebElement aLinkBtn = _driver.FindElement(By.Name("processAddress"));
            aLinkBtn.Click();
            //return Convert.ToDouble(
            //    _driver.GetText(By.Id("DistanciaKm")));
        }

        public void Shipping()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Id("cgv")) != null);
            IWebElement aCheckbox = _driver.FindElement(By.Id("cgv"));
            aCheckbox.Click();
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Name("processCarrier")) != null);
            IWebElement aLinkBtn = _driver.FindElement(By.Name("processCarrier"));
            aLinkBtn.Click();
        }

        public void Payment()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.ClassName("bankwire")) != null);
            IWebElement aLinkBtn = _driver.FindElement(By.ClassName("bankwire"));
            aLinkBtn.Click();
        }

        public Boolean Confirm()
        {
            ///html/body/div/div[2]/div/div[3]/div/form/p/button
            IWebElement aLinkBtn = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/form/p/button"));
            aLinkBtn.Click();
            IWebElement aP = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/p/strong"));
            return (aP.Text == "Your order on My Store is complete.");
        }

        public void Close()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
