using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using WebDriverManager.DriverConfigs.Impl;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject1.Utilities;
using TestProject1.PageObjects;

namespace TestProject1 
{
    public class Tests : Base
    {
        [Test]
        public void Test1()
        {
            HomePage homePage = new HomePage(getDriver());
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement ActualBtn = homePage.GetSignInBtn();
            Assert.IsTrue(ActualBtn.Displayed);  //assert that "SignIn" button is displayed

            AuthenticationPage authPage = homePage.SignIn();
            Assert.AreEqual(authPage.GetLogInPageTitle(), "Login - My Store");
        }

        [Test]
        public void Test2()
        {
            //TEST CASE - CREATE ACC. WITH INVALID CREDENTIALS
            HomePage homePage = new HomePage(getDriver());
            AuthenticationPage authPage = homePage.SignIn();
            authPage.CreateAccount("nnnnn");
            var alarm = authPage.GetInvalidEmailMsg();
            Assert.IsTrue(alarm.Displayed); //assert that an error message is displayed
            authPage.GetCreateAccEmailInput().Clear();
        }

        [Test]
        public void Test3()
        {
            //TEST CASE - CREATE ACC. WITH VALID EMAIL
            HomePage homePage = new HomePage(getDriver());
            AuthenticationPage authPage = homePage.SignIn();

            CreateAccountPage createPage = authPage.CreateAccount("2nnn@nn.nnn");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.UrlContains("account-creation"));
            string ActualForm = createPage.GetCreateFormHeading().Text;
            string ExpectedForm = "CREATE AN ACCOUNT";
            Assert.AreEqual(ActualForm, ExpectedForm);  //assert that account creation form is displayed
            Assert.AreEqual(driver.Url, "http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation"); 
        }

        [Test]
        public void Test4()
        {
            HomePage homePage = new HomePage(getDriver());
            AuthenticationPage authPage = homePage.SignIn();
            
            CreateAccountPage createPage = authPage.CreateAccount("2nnn@nn.nnn");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.UrlContains("account-creation"));
            Assert.AreEqual("CREATE AN ACCOUNT", createPage.GetCreateFormHeading().Text);
            IWebElement maleBtn = createPage.GetMaleRadioBtn();
            Assert.IsTrue(maleBtn.Enabled);
            Assert.IsFalse(maleBtn.Selected);

            CustomerPage customerPage = createPage.ValidAccCreation("pera", "peric", "12345", "ILR 55", "LA", "55555", "555-444");
            Assert.IsTrue(customerPage.GetSignOutBtn().Displayed);
        }
    }
}