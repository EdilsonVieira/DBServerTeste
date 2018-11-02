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

        private void CreateAccount(PersonalInfo clientData)
        {
            _driver.SetText(By.Id(MyStorePageMap.EmailCreate), clientData.Email);
            _driver.Click(By.Id(MyStorePageMap.SubmitCreate));
            if (clientData.Title == TitleEnum.Mrs)
            {
                _driver.WaitNClick(10, By.Id(MyStorePageMap.PersonalInfoTitleMrs));
            }
            else
            {
                _driver.WaitNClick(10, By.Id(MyStorePageMap.PersonalInfoTitleMr));
            }
            _driver.SetText(By.Id(MyStorePageMap.PersonalInfoFirstName), clientData.FirstName);
            _driver.SetText(By.Id(MyStorePageMap.PersonalInfoLastName), clientData.LastName);
            _driver.SetText(By.Id(MyStorePageMap.PersonalInfoPassword), clientData.Password);
            _driver.FindElement(By.Id(MyStorePageMap.PersonalInfoPassword)).SendKeys(Keys.Tab);
            _driver.SetSelectionValue(By.Id(MyStorePageMap.PersonalInfoBirthDateDay), clientData.BirthDate.Day.ToString());
            _driver.SetSelectionValue(By.Id(MyStorePageMap.PersonalInfoBirthDateMonth), clientData.BirthDate.Month.ToString());
            _driver.SetText(By.Id(MyStorePageMap.PersonalInfoBirthDateYear), clientData.BirthDate.Year.ToString());
            if (clientData.Newsletter)
            {
                _driver.Click(By.Id(MyStorePageMap.PersonalInfoNewsLetter));
            }
            if (clientData.SpecialOffers)
            {
                _driver.Click(By.Id(MyStorePageMap.PersonalInfoSpecialOffers));
            }
            _driver.SetText(By.Id(MyStorePageMap.PersonalInfoCompany), clientData.Company);
            _driver.SetText(By.Id(MyStorePageMap.PersonalInfoAddress1), clientData.Address.Address1);
            _driver.SetText(By.Id(MyStorePageMap.PersonalInfoAddress2), clientData.Address.Address2);
            _driver.SetText(By.Id(MyStorePageMap.PersonalInfoCity), clientData.Address.City);
            _driver.SetText(By.Id(MyStorePageMap.PersonalInfoState), clientData.Address.State);
            _driver.SetText(By.Id(MyStorePageMap.PersonalInfoZipCode), clientData.Address.ZipCode);
            _driver.SetText(By.Id(MyStorePageMap.PersonalInfoCountry), clientData.Address.Country);
            _driver.SetText(By.Id(MyStorePageMap.PersonalInfoAdditional), clientData.AdditionalInfo);
            _driver.SetText(By.Id(MyStorePageMap.PersonalInfoHomePhone), clientData.HomePhone);
            _driver.SetText(By.Id(MyStorePageMap.PersonalInfoMobilePhone), clientData.MobilePhone);
            _driver.Click(By.Id(MyStorePageMap.PersonalInfoSubmitButton));
        }

        public void Login(PersonalInfo clientData)
        {
            _driver.WaitNSetText(10, By.Id(MyStorePageMap.Email), clientData.Email);
            IWebElement aTextInput = _driver.FindElement(By.Id(MyStorePageMap.Password));
            aTextInput.SendKeys(clientData.Password);
            aTextInput.SendKeys(Keys.Tab);
            aTextInput.SendKeys(Keys.Tab);
            aTextInput.SendKeys(Keys.Enter);
            // Se houve falha de autenticação, entrar na criação de conta
            if (_driver.IsElementPresent(15, By.XPath(MyStorePageMap.AuthFailedElement)))
            {
                string failedText = _driver.GetText(By.XPath(MyStorePageMap.AuthFailedElement));
                if (failedText == MyStorePageMap.AuthFailedText)
                {
                    CreateAccount(clientData);
                }
            }
        }

        public void Address(PersonalInfo clientData)
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
