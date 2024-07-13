using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using singlewave_.Navigation.Abstraction;

namespace singlewave_.Navigation
{
    public class RPIDriver : iDriverMaster
    {
        private readonly string _binaryl = "/usr/bin/chromium-browser";
        private readonly string _chromepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Drivers/macos/chromedriver");

        public void Dispose(IWebDriver wd)
        {
            if (wd == null)
            {
                throw new ArgumentNullException(nameof(wd), "Driver instance cannot be null.");
            }

            Console.WriteLine("Disposing of driver..");
            try
            {
                wd.Quit();
            }
            catch (WebDriverException ex)
            {
                Console.WriteLine($"WebDriverException occurred while quitting driver: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred while quitting driver: {ex.Message}");
            }
            finally
            {
                wd.Dispose();
            }
        }

        public IWebDriver Init()
        {
            ChromeOptions opts = new ChromeOptions();
            opts.BinaryLocation = _binaryl;
            //creating driver
            try
            {
                IWebDriver wd = new ChromeDriver(_chromepath, opts);
                return wd;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occured while creating wdriver: {ex.Message}");
                return null;
            }

        }


    }
}

