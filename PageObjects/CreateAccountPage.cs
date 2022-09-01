using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestProject1.PageObjects
{
    public class CreateAccountPage
    {
        private IWebDriver driver;
        public CreateAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //CREATE ACC. FORM HEADING
        [FindsBy(How = How.XPath, Using = "//h1[@class='page-heading']")]
        private IWebElement createFormHeading;

        public IWebElement GetCreateFormHeading()
        {
            return createFormHeading;
        }


        [FindsBy(How = How.XPath, Using = "//input[@id='id_gender1']")]
        private IWebElement maleRadioBtn;
        public IWebElement GetMaleRadioBtn()
        {
            return maleRadioBtn;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='id_gender2']")]
        private IWebElement femaleRadioBtn;
        public IWebElement GetFemaleRadioBtn()
        {
            return femaleRadioBtn;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='customer_firstname']")]
        private IWebElement firstName;
        public IWebElement GetFirstName()
        {
            return firstName;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='customer_lastname']")]
        private IWebElement lastName;
        public IWebElement GetLastName()
        {
            return lastName;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement eMail;
        public IWebElement GetEMail()
        {
            return eMail;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='passwd']")]
        private IWebElement password;
        public IWebElement GetPassword()
        {
            return password;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='address1']")]
        private IWebElement address;
        public IWebElement GetAddress()
        {
            return address;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='city']")]
        private IWebElement city;
        public IWebElement GetCity()
        {
            return city;
        }

        [FindsBy(How = How.XPath, Using = "//select[@id='id_state']")]
        private IWebElement state;
             public IWebElement GetState()
        {
            return state;
        }

        [FindsBy(How = How.XPath, Using = "//option[contains (text(),'California')]")]
        private IWebElement californiaState;
        public IWebElement GetCaliforniaState()
        {
            return californiaState;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='postcode']")]
        private IWebElement postalCode;
        public IWebElement GetPostalCode()
        {
            return postalCode;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='phone_mobile']")]
        private IWebElement mobilePhone;
        public IWebElement GetMobilePhone()
        {
            return mobilePhone;
        }

        [FindsBy(How = How.XPath, Using = "//button[@id='submitAccount']")]
        private IWebElement registerBtn;
        public IWebElement GetRegisterBtn()
        {
            return registerBtn;
        }

        public CustomerPage ValidAccCreation (string firstName, string lastName, string password, string address, string city, string postalCode, string mobilePhone)
        {
            GetMaleRadioBtn().Click();
            GetFirstName().SendKeys(firstName);
            GetLastName().SendKeys(lastName);
            GetPassword().SendKeys(password);
            GetAddress().SendKeys(address);
            GetCity().SendKeys(city);
            GetCaliforniaState().Click();
            GetPostalCode().SendKeys(postalCode);
            GetMobilePhone().SendKeys(mobilePhone);
            GetRegisterBtn().Click();
            return new CustomerPage(driver);

    
        }
    }
}
