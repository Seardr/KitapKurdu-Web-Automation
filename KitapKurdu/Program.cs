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

    class Program
    {


        static void Main(string[] args)
        {
          // Chrome Tarayıcısı Oluşturma
            IWebDriver driver = new ChromeDriver();

            // Kitapyurdu Sitesine Giriş
            SeleniumSetMethods.AnaSayfa(driver, "https://www.kitapyurdu.com/");

            // Arama Çubuğuna "roman" Yazımı ve Aratma
            SeleniumSetMethods.TextGirisi(driver, "roman", "search_keyword", "Name");
            SeleniumSetMethods.BtnClick(driver, "#search > span", "CssSelector");

            // Listelenen Romanlar Arasından Rastgele Birinin Sepete Eklenmesi
            SeleniumSetMethods.Rastgele(driver, "div.product-cr > div.grid_2.alpha.omega.relative > div.hover-menu > a.add-to-cart");
            var deger = SeleniumSetMethods.VeriKontrol(driver, "/html/body/div[1]/div[3]/div/div[4]/div[1]/div[1]/span", "XPath");
            if (deger == "1")
            {
                Console.WriteLine("Sepette 1 Ürün Bulunmaktadır.");
                Thread.Sleep(2000);
            };

            // Sepetim Butonuna Tıklanması
            SeleniumSetMethods.BtnClick(driver, "/html/body/div[1]/div[3]/div/div[4]/div[1]/div[2]/h4", "XPath");

            // Sepete Git Butonuna Tıklanması
            SeleniumSetMethods.BtnClick(driver, "/html/body/div[1]/div[3]/div/div[4]/div[2]/div[2]/div[2]/div/a", "XPath");

            // Seçilen Romanın Miktarını 1 Arttırma
            SeleniumSetMethods.TextGirisi(driver, "2", "#cart_module > div.cart-info > table > tbody > tr > td.quantity > form > input[type=text]:nth-child(1)", "CssSelector");
            SeleniumSetMethods.BtnClick(driver, "#cart_module > div.cart-info > table > tbody > tr > td.quantity > form > i", "CssSelector");

            // Sepetin Güncellenmesi
            var guncelleme = SeleniumSetMethods.VeriKontrol(driver, "#swal2-title", "CssSelector");

            if (guncelleme == "Sepetiniz güncelleniyor!")
            {
                Console.WriteLine("Sepetimiz Güncellenmiştir!");
            };

            // Sepetteki Romanın Çıkarılması
            SeleniumSetMethods.BtnClick(driver, "#cart_module > div.cart-info > table > tbody > tr > td.remove > a", "CssSelector");

            var sepetMiktarı = SeleniumSetMethods.VeriKontrol(driver, "#cart-items-empty", "CssSelector");

            if (sepetMiktarı == "Sepetiniz boş")
            {
                Console.WriteLine("Sepetimiz boş durumdadır.");
                Thread.Sleep(2500);
            };

            // Tarayıcının Kapatılması
            SeleniumSetMethods.Close(driver);

        }



      
    }
    
}   
