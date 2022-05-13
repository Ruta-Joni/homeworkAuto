using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework
{
    public class HomePage : WebDriver
    {
        IWebElement signInButton = Driver.FindElement(By.ClassName("login"));

        public void Login(string email, string password)
        {
            signInButton.Click();
            IWebElement email_txt = Driver.FindElement(By.Id("email")); 
            IWebElement password_txt = Driver.FindElement(By.Id("passwd"));
            IWebElement signButton = Driver.FindElement(By.Id("SubmitLogin"));
            
            email_txt.SendKeys(email);
            password_txt.SendKeys(password); 
            signButton.Click();
           
            Thread.Sleep(2000);
        }

        public void GoToRegistrationPage(string email)
        {
            signInButton.Click();
            IWebElement email_txt = Driver.FindElement(By.Id("email_create"));
            IWebElement createButton = Driver.FindElement(By.CssSelector("#SubmitCreate>span"));
            email_txt.SendKeys(email);
            createButton.Click();
        }
    }
}
