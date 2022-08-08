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

        public IWebElement getCreateFormHeading()
        {
            return createFormHeading;
        }


        [FindsBy(How = How.XPath, Using = "//input[@id='id_gender1']")]
        private IWebElement maleRadioBtn;
        public IWebElement getMaleRadioBtn()
        {
            return maleRadioBtn;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='id_gender2']")]
        private IWebElement femaleRadioBtn;
        public IWebElement getFemaleRadioBtn()
        {
            return femaleRadioBtn;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='customer_firstname']")]
        private IWebElement firstName;
        public IWebElement getFirstName()
        {
            return firstName;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='customer_lastname']")]
        private IWebElement lastName;
        public IWebElement getLastName()
        {
            return lastName;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement eMail;
        public IWebElement getEMail()
        {
            return eMail;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='passwd']")]
        private IWebElement password;
        public IWebElement getPassword()
        {
            return password;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='address1']")]
        private IWebElement address;
        public IWebElement getAddress()
        {
            return address;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='city']")]
        private IWebElement city;
        public IWebElement getCity()
        {
            return city;
        }

        [FindsBy(How = How.XPath, Using = "//select[@id='id_state']")]
        private IWebElement state;
             public IWebElement getState()
        {
            return state;
        }

        [FindsBy(How = How.XPath, Using = "//option[contains (text(),'California')]")]
        private IWebElement californiaState;
        public IWebElement getCaliforniaState()
        {
            return californiaState;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='postcode']")]
        private IWebElement postalCode;
        public IWebElement getPostalCode()
        {
            return postalCode;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='phone_mobile']")]
        private IWebElement mobilePhone;
        public IWebElement getMobilePhone()
        {
            return mobilePhone;
        }

        [FindsBy(How = How.XPath, Using = "//button[@id='submitAccount']")]
        private IWebElement registerBtn;
        public IWebElement getRegisterBtn()
        {
            return registerBtn;
        }

        public CustomerPage validAccCreation (string firstName, string lastName, string password, string address, string city, string postalCode, string mobileNumber)
        {
            getMaleRadioBtn().Click();
            getFirstName().SendKeys(firstName);
            getLastName().SendKeys(lastName);
            getPassword().SendKeys(password);
            getAddress().SendKeys(address);
            getCity().SendKeys(city);
            getCaliforniaState().Click();
            getPostalCode().SendKeys(postalCode);
            getMobilePhone().SendKeys(mobileNumber);
            getRegisterBtn().Click();
            return new CustomerPage(driver);

    
        }
    }
}
