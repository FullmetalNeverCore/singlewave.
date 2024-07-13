using System;
namespace singlewave_SBE
{
	public static class SystemBasedEvents
	{
		public static bool isMacOS()
		{
			return Directory.Exists("/Applications");
		} 
	}
}

