using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestProject1.PageObjects
{
    public class AuthenticationPage
    {
        private IWebDriver driver;
        public AuthenticationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "/html/head/title")]
        private IWebElement logInPageTitle;

        public string GetLogInPageTitle()
        {
            return driver.Title;
        }


        //ATHENTICATION HEADING
        [FindsBy(How = How.XPath, Using = "//h1[@class='page-heading']")]
        private IWebElement authenticationHeading; 

        public IWebElement GetAuthenticationHeading()
        {
            return authenticationHeading;
        }

        //CREATE ACC. INPUT FIELD
        [FindsBy(How = How.XPath, Using = "//input[@id='email_create']")]
        private IWebElement createAccEmailInput;

        public IWebElement GetCreateAccEmailInput()
        {
            return createAccEmailInput;
        }

        //CREATE ACC. BUTTON
        [FindsBy(How = How.XPath, Using = "//button[@id='SubmitCreate']")]
        private IWebElement createAccBtn;

        public IWebElement GetCreateAccBtn()
        {
            return createAccBtn;
        }

        //CREATE ACC. ERROR MESSAGE
        [FindsBy(How = How.XPath, Using = "//li[contains(text(),'Invalid email')]")]
        private IWebElement invalidEmailMsg;

        public IWebElement GetInvalidEmailMsg()
        {
            return invalidEmailMsg;
        }

        //SIGN IN EMAIL INPUT FIELD
        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement signInEmailInput;

        public IWebElement GetSignInEmailInput()
        {
            return signInEmailInput;
        }

        //SIGN IN PASSWORD INPUT FIELD
        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        private IWebElement signInPasswordInput;

        public IWebElement GetSignInPasswordInput()
        {
            return signInPasswordInput;
        }

        //SIGN IN BUTTON
        [FindsBy(How = How.XPath, Using = "//button[@id='SubmitLogin']")]
        private IWebElement signInBtn;

        public IWebElement GetSignInBtn()
        {
            return signInBtn;
        }

        public CreateAccountPage CreateAccount(string email)
        {
            GetCreateAccEmailInput().SendKeys(email);
            GetCreateAccBtn().Click();
            return new CreateAccountPage(driver);
        }


    }
}
