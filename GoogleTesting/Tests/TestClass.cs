using GoogleTesting.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTesting.Tests
{
    [TestClass]
    public class TestClass
    {
        IWebDriver driver;

        [TestInitialize] 
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com/";
        }

        [TestMethod]
        public void GoogleTest()
        {
            string searchWord = "mattelsa";

            var page = new GooglePage(driver);
            page.ClickOnTextBox();
            page.SearchWord(searchWord);
            page.ClickOnSeachButton();

            var result = page.GetResult();
            Console.WriteLine(result.ToLower());
            Assert.IsTrue(result.ToLower().Contains(searchWord), "The result did not bring the expected");         
        }

        [TestCleanup] 
        public void TestCleanUp()
        {
            driver.Quit(); 
        }
    }
}
