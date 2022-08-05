using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace TestProject1.PageObjects
{
    public class CustomerPage
    {
        private IWebDriver driver;
        public CustomerPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@title='Log me out']")]
        private IWebElement signOutBtn; 

        public IWebElement getSignOutBtn()
        {
            return signOutBtn;
        }
      
    }
}
