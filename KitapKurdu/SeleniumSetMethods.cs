using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NUnit.Framework;


namespace KitapKurdu
{
    class SeleniumSetMethods 
    {
        
        public static void AnaSayfa(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2500);
            Console.WriteLine("Kitapyurdu Sitesi Açılmıştır.");
        }

        // Sorgulanan elemente veri girişi
        public static void TextGirisi(IWebDriver driver, string text, string element, string elementtype)
        {
         
            if (elementtype == "Name")
            {
                IWebElement textSpace = driver.FindElement(By.Name(element));
                textSpace.Clear();
                textSpace.SendKeys(text);
            }
            if (elementtype == "CssSelector")
            {
                IWebElement textSpace = driver.FindElement(By.CssSelector(element));
                textSpace.Clear();
                textSpace.SendKeys(text);
            }
            if (elementtype == "XPath")
            {
                IWebElement textSpace = driver.FindElement(By.XPath(element));
                textSpace.Clear();
                textSpace.SendKeys(text);
            }
        }

        // Sorgulanan buton elementine tıklanılması
        public static void BtnClick(IWebDriver driver, string element, string elementtype)
        {
            if (elementtype == "Name")
            {
                IWebElement btn = driver.FindElement(By.Name(element));
                btn.Click();
                Thread.Sleep(2500);
            }
            if (elementtype == "CssSelector")
            {
                IWebElement btn = driver.FindElement(By.CssSelector(element));
                btn.Click();
                Thread.Sleep(2500);

            }
            if (elementtype == "XPath")
            {
                IWebElement btn = driver.FindElement(By.XPath(element));
                btn.Click();
                Thread.Sleep(2500);

            }

        }

        // Listelenen Romanlardan Rastgele Seçim
        public static void Rastgele(IWebDriver driver, string element)
        {
            IReadOnlyCollection<IWebElement> productName = driver.FindElements(By.CssSelector(element));
            Console.Clear();
            var sayac = 0;
            List<IWebElement> bookNames = new List<IWebElement>();

            foreach (IWebElement bookName in productName)
            {
                bookNames.Add(bookName);
                sayac++;
            };

            Random rdm = new Random();
            int sayi = rdm.Next(sayac);

            bookNames[sayi].Click();
            Thread.Sleep(2500);

        }

        // Sorgulanan verinin kontrolü
        public static string VeriKontrol(IWebDriver driver, string element, string elementtype)
        {
            if (elementtype == "Name")
            {
                string textdeger = driver.FindElement(By.Name(element)).Text;
                return textdeger;
            }
            else if (elementtype == "CssSelector")
            {
                string textdeger = driver.FindElement(By.CssSelector(element)).Text;
                return textdeger;
            }
            else if (elementtype == "XPath")
            {
                string textdeger = driver.FindElement(By.XPath(element)).Text;
                return textdeger;
            }
            else
            {
                return "0";
            }
            
          
        }
        // Tarayıcının Kapatılması
        public static void Close(IWebDriver driver)
        {
            driver.Close();
        }


     


    }
}
