using System;
using OpenQA.Selenium;
using singlewave_.Navigation;

class Program
{
    static MOSDriver macdriver = new MOSDriver();
    static RPIDriver rpidriver = new RPIDriver();
    static IWebDriver webDriver = null;

    static void Main(string[] args)
    {
        Console.WriteLine("singlewave.");
        Console.WriteLine($"OS: {Environment.OSVersion}");
        Console.WriteLine($"Is Mac OS? : {singlewave_SBE.SystemBasedEvents.isMacOS()}");

        try
        {
            if (singlewave_SBE.SystemBasedEvents.isMacOS())
            {
                Console.WriteLine("MacDriver");
                webDriver = macdriver.Init();
            }
            else
            {
                Console.WriteLine("RPIDriver");
                webDriver = rpidriver.Init();
            }

            if (webDriver == null)
            {
                Console.WriteLine("Failed to initialize the web driver.");
                return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception occurred: {ex.Message}");
        }

        AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        Console.CancelKeyPress += OnConsoleCancelKeyPress;

        webDriver.Navigate().GoToUrl("https://www.silentwave.cc");

        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }

    static void DisposingProc()
    {
        if (singlewave_SBE.SystemBasedEvents.isMacOS())
        {
            macdriver.Dispose(webDriver);
        }
        else
        {
            rpidriver.Dispose(webDriver);
        }
    }

    static void OnProcessExit(object sender, EventArgs e)
    {
        DisposingProc();
    }

    static void OnConsoleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
    {
        DisposingProc();
    }
}