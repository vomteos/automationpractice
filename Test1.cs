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
            string ActualBtn = homePage.getSignInBtn().GetAttribute("title");
            string ExpectedBtn = "Log in to your customer account";
            Assert.That(ActualBtn, Is.EqualTo(ExpectedBtn));  //assert that "SignIn" button is displayed

            AuthenticationPage authPage = homePage.signIn();
            Assert.That(authPage.getLogInPageTitle().Displayed, Is.True);
        }

        [Test]
        public void Test2()
        {
            //TEST CASE - CREATE ACC. WITH INVALID CREDENTIALS
            HomePage homePage = new HomePage(getDriver());
            AuthenticationPage authPage = homePage.signIn();
            authPage.createAccount("nnnnn");
            var alarm = authPage.getInvalidEmailMsg();
            Assert.That(alarm.Displayed, Is.True); //assert that an error message is displayed
            authPage.getCreateAccEmailInput().Clear();
        }

        [Test]
        public void Test3()
        {
            //TEST CASE - CREATE ACC. WITH VALID EMAIL
            HomePage homePage = new HomePage(getDriver());
            AuthenticationPage authPage = homePage.signIn();

            CreateAccountPage createPage = authPage.createAccount("nnn@nn.nnn");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.UrlContains("account-creation"));
            string ActualForm = createPage.getCreateFormHeading().Text;
            string ExpectedForm = "CREATE AN ACCOUNT";
            Assert.That(ActualForm, Is.EqualTo(ExpectedForm));  //assert that account creation form is displayed
            Assert.That(driver.Url, Is.EqualTo("http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation")); 
        }

        [Test]
        public void Test4()
        {
            HomePage homePage = new HomePage(getDriver());
            AuthenticationPage authPage = homePage.signIn();
            
            CreateAccountPage createPage = authPage.createAccount("nnn@nn.nnn");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.UrlContains("account-creation"));
            Assert.That(createPage.getCreateFormHeading().Text, Is.EqualTo("CREATE AN ACCOUNT"));
            IWebElement maleBtn = createPage.getMaleRadioBtn();
            Assert.That(maleBtn.Enabled, Is.EqualTo(true));
            Assert.That(maleBtn.Selected, Is.EqualTo(false));

            CustomerPage customerPage = createPage.validAccCreation("pera", "peric", "12345", "ILR 55", "LA", "55555", "555-444");
            Assert.That(customerPage.getSignOutBtn().Displayed, Is.True);
        }
    }
}