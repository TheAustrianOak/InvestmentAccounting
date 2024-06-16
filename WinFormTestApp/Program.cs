using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer.Services;
using BusinessLayer.Services.Abstractions;

namespace WinFormTestApp
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			var serviceProvider = new ServiceCollection()
							.AddSingleton<IRepository, LotRepository>()
							.AddSingleton<IShareService, ShareService>()
							.BuildServiceProvider();


			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1(serviceProvider.GetService<IShareService>()));
		}
	}
}
