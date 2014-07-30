/*
 * Created by SharpDevelop.
 * User: MindContact
 * Date: 30/07/2014
 * Time: 08.54
 * 
 * Nancy Datatables Example
 */
using System;
using System.Configuration;
using System.Linq;
using System.Threading;
using Nancy.Hosting.Self;

namespace MindContact.Nancy.Datatables.Example
{
	class Program
	{
		static void Main(string[] args)
		{
			// https://github.com/NancyFx/Nancy/issues/1226
			var hostConfiguration = new HostConfiguration
            {				
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };

			string HOST_URL = ConfigurationManager.AppSettings.Get("HOST_URL");
			string HOST_PORT = ConfigurationManager.AppSettings.Get("HOST_PORT");
			string HOST_URI = string.Format("http://{0}:{1}", HOST_URL, HOST_PORT);

            // initialize an instance of NancyHost (found in the Nancy.Hosting.Self package)
			var host = new NancyHost(new Uri(HOST_URI));
            host.Start();  // start hosting

			//Under mono if you deamonize a process a Console.ReadLine with cause an EOF
			//so we need to block another way
			if (args.Any(s => s.Equals("-d", StringComparison.CurrentCultureIgnoreCase)))
				while (true) Thread.Sleep(10000000);
			else
			{
				Console.WriteLine("Nancy now listening to {0}\nPress any key to stop", HOST_URI);
				//Process.Start(HOST_URI);
				Console.ReadKey();
			}

			host.Stop();  // stop hosting
			Console.WriteLine("Stopped. Good bye!");
			Console.ReadKey();
		}
	}
}