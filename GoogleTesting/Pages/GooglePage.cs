using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTesting.Pages
{
    class GooglePage
    {
        private IWebDriver driver;

        #region Locators
        private By textBoxLocator = By.Name("q");  
        private By writeOnTextAreaLocator = By.Name("q");  
        private By searchButtonLocator = By.Name("btnK"); 
        private By searchResultLocator = By.CssSelector(".g h3");
        #endregion

        #region WebElements
        private IWebElement TextBox => driver.FindElement(textBoxLocator); 
        private IWebElement TextArea => driver.FindElement(writeOnTextAreaLocator); 
        private IWebElement SearchButton => driver.FindElement(searchButtonLocator); 
        private IWebElement Result => driver.FindElement(searchResultLocator);
        #endregion

        #region Methods
        public GooglePage(IWebDriver parentDriver)
        {
            driver = parentDriver;
        }

        public void ClickOnTextBox()
        {
            TextBox.Click();
        }

        public void SearchWord(string word)
        {
            TextArea.SendKeys(word);
        }

        private void WaitClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("btnK")));
        }

        public void ClickOnSeachButton()
        {
            WaitClickable();
            SearchButton.Click();
        }

        public string GetResult()
        {
            return Result.Text;
        }
        #endregion
    }
}
