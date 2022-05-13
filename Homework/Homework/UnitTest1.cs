using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Homework
{
    class Tests: WebDriver
    {
        private IWebDriver Driver;
        private string URL = "http://automationpractice.com/index.php";

        string loginEmail = "adminas@mail.com";
        string loginPassword = "password";

        string firstName = "Name";
        string lastName = "Surnname";
        string password = "password";
        string email = "testas@testas.testas";
        string address = "address";
        string city = "City";
        string state = "Alaska";
        string post = "11111";
        string coutry = "United States";
        string phone = "811111111";

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(URL);
        }

        [Test]
        public void CreateAccount()
        {
            NewAccount();
            IWebElement logoutButton = Driver.FindElement(By.ClassName("logout"));
            string txt = logoutButton.Text;
            Assert.AreEqual(txt, "Sign out", "Error message");
            
        }

        [Test]
        public void FindItem()
        {
            LoginIn();
            Thread.Sleep(2000);
            searchItem("dress");
            Thread.Sleep(2000);

            IWebElement resultSpan = Driver.FindElement(By.ClassName("heading-counter"));
            string result_txt = resultSpan.Text;
            Assert.AreNotEqual(result_txt, "0 results have been found.", "Error message");

        }

        [Test]
        public void ItemBuy()
        {
            LoginIn();
            searchItem("dress");

            procceed("#center_column > ul > li:nth-child(1) > div > div.right-block > div.button-container > a.button.ajax_add_to_cart_button.btn.btn-default");
            procceed("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a");
            procceed("#center_column > p.cart_navigation.clearfix > a.button.btn.btn-default.standard-checkout.button-medium");
            procceed("#center_column > form > p > button");
            Driver.FindElement(By.Id("cgv")).Click();
            procceed("#form > p > button");
            procceed("#HOOK_PAYMENT > div:nth-child(1) > div > p > a");
            procceed("#cart_navigation > button");

            IWebElement completeOrder = Driver.FindElement(By.ClassName("cheque-indent"));
            string order_txt = completeOrder.Text;
            Assert.AreEqual(order_txt, "Your order on My Store is complete.", "Error message");

            
        }
        public void procceed(string selector)
        {
            IWebElement proceedButton = Driver.FindElement(By.CssSelector(selector));
            proceedButton.Click(); 
            Thread.Sleep(2000);
        }
        public void searchItem(string name)
        { 
            IWebElement search_txt = Driver.FindElement(By.Id("search_query_top"));
            search_txt.SendKeys(name);

            IWebElement searchButton = Driver.FindElement(By.CssSelector("#searchbox > button"));
            searchButton.Click();
        }

            public void NewAccount()
        {
            IWebElement loginButton = Driver.FindElement(By.ClassName("login"));
            loginButton.Click();

            IWebElement email_txt = Driver.FindElement(By.Id("email_create"));
            email_txt.SendKeys(email);

            IWebElement createButton = Driver.FindElement(By.CssSelector("#SubmitCreate>span"));
            createButton.Click();
            Thread.Sleep(4000);

            IWebElement firstName_txt = Driver.FindElement(By.Id("customer_firstname"));
            firstName_txt.SendKeys(firstName);

            IWebElement lastName_txt = Driver.FindElement(By.Id("customer_lastname"));
            lastName_txt.SendKeys(lastName);
            
            IWebElement password_txt = Driver.FindElement(By.Id("passwd"));
            password_txt.SendKeys(password);

            IWebElement address_txt = Driver.FindElement(By.Id("address1"));
            address_txt.SendKeys(address);

            IWebElement city_txt = Driver.FindElement(By.Id("city"));
            city_txt.SendKeys(city);

            SelectElement state_select = new SelectElement(Driver.FindElement(By.Id("id_state")));
            state_select.SelectByText(state);

            IWebElement post_txt = Driver.FindElement(By.Id("postcode"));
            post_txt.SendKeys(post);

            SelectElement country_select = new SelectElement(Driver.FindElement(By.Id("id_country")));
            country_select.SelectByText(coutry);

            IWebElement phone_txt = Driver.FindElement(By.Id("phone_mobile"));
            phone_txt.SendKeys(phone);

            IWebElement registerButton = Driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();
        }

        public void LoginIn()
        {
            IWebElement loginButton = Driver.FindElement(By.ClassName("login"));
            loginButton.Click();

            IWebElement email_txt = Driver.FindElement(By.Id("email"));
            email_txt.SendKeys(loginEmail);

            
            IWebElement password_txt = Driver.FindElement(By.Id("passwd"));
            password_txt.SendKeys(loginPassword);

            IWebElement signButton = Driver.FindElement(By.Id("SubmitLogin"));
            signButton.Click();
            Thread.Sleep(2000);

        }
    }
}



