using System;
using OpenQA.Selenium;

namespace singlewave_.Navigation.Abstraction
{
	public interface iDriverMaster
	{
		public IWebDriver Init();

		public void Dispose(IWebDriver wd);
	}
}

