using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace TestProject1.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.PartialLinkText, Using = "Sign in")]
        private IWebElement signInBtn; 

        public IWebElement GetSignInBtn()
        {
            return signInBtn;
        }

        public AuthenticationPage SignIn()
        {
            GetSignInBtn().Click();
            return new AuthenticationPage(driver);

        }
      
    }
}
