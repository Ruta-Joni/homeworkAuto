using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class RegistrationPage : WebDriver
    {
            IWebElement firstName_txt = Driver.FindElement(By.Id("customer_firstname"));
            IWebElement lastName_txt = Driver.FindElement(By.Id("customer_lastname"));
            IWebElement password_txt = Driver.FindElement(By.Id("passwd"));
            IWebElement address_txt = Driver.FindElement(By.Id("address1"));
            IWebElement city_txt = Driver.FindElement(By.Id("city"));
            SelectElement state_select = new SelectElement(Driver.FindElement(By.Id("id_state")));
            IWebElement post_txt = Driver.FindElement(By.Id("postcode"));
            SelectElement country_select = new SelectElement(Driver.FindElement(By.Id("id_country")));
            IWebElement phone_txt = Driver.FindElement(By.Id("phone_mobile")); 
            IWebElement registerButton = Driver.FindElement(By.Id("submitAccount"));
        

        public void FillFormAndRegister(string firstname, string lastname, string password, string address, string city, string state, string post, string country, string phone)
        {

            firstName_txt.SendKeys(firstname);
            lastName_txt.SendKeys(lastname);
            password_txt.SendKeys(password);
            address_txt.SendKeys(address);
            city_txt.SendKeys(city);
            state_select.SelectByText(state);
            post_txt.SendKeys(post);
            country_select.SelectByText(country);
            phone_txt.SendKeys(phone);
            registerButton.Click();
        }

    }
}
