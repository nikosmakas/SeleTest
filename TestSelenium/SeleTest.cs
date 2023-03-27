using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestSelenium
{
    [TestClass]
    public class SeleTest
    {
        [TestMethod]
        public void TestSelenium()
        {
            //create a new instance of the chrome driver named driver
            IWebDriver driver = new ChromeDriver();
            
            //navigate to the web page
            driver.Navigate().GoToUrl("C:\\Users\\Makas\\source\\repos\\TestSelenium\\index.html");

            //find the text field and enter some text
            try
            {
            IWebElement textField = driver.FindElement(By.Id("nameInput"));
            textField.SendKeys("Hello, World!"); 
            }
            catch(NoSuchElementException ex)
            {
                Console.WriteLine("Element not found"+ ex.Message);
            }

            // Find the button and click it
            try
            {
            IWebElement button = driver.FindElement(By.Id("submitButton"));
            button.Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Element not found" + ex.Message);
            }

            // Find the result element and assert that it contains the expected text
            try
            {
                IWebElement result = driver.FindElement(By.Id("output"));
                Assert.AreEqual("Hello, World!", result.Text);
                Console.WriteLine(result.Text);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Element not found" + ex.Message);
            }

            // Close the browser
            driver.Close();
        }
    }
}
