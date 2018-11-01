using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Testes
{
    public class MyStorePageMap
    {
        public const string FirstProductImage = "/html/body/div/div[2]/div/div[2]/div/div[1]/ul[1]/li[1]/div/div[1]/div/a[1]/img";
        public const string AddToCartButton = "Submit";
        public const string ProceedToCheckout = "Proceed to checkout";
        public const string Email = "email";
        public const string Password = "passwd";
        public const string AuthFailedElement = "/html/body/div/div[2]/div/div[3]/div/div[1]/ol/li";
        public const string AuthFailedText = "Authentication failed.";
        public const string EmailCreate = "email_create";
        public const string SubmitCreate = "SubmitCreate";
        public const string ProcessAddress = "processAddress";
        public const string TermsOfService = "cgv";
        public const string ProcessShipping = "processCarrier";
        public const string PaymentByBankWire = "bankwire";
        public const string PaymentByCheck = "cheque";
        public const string OrderConfirmationButton = "/html/body/div/div[2]/div/div[3]/div/form/p/button";
        public const string OrderConfirmationTextElement = "/html/body/div/div[2]/div/div[3]/div/div/p/strong";
        public const string OrderConfirmationText = "Your order on My Store is complete.";
    }
    public enum PaymentMethod
    {
        
    }
}
