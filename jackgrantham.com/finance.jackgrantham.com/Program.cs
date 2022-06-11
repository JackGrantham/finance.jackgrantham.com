using finance.jackgrantham.com.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace finance.jackgrantham.com
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration(config =>
					config.AddJsonFile(
							path: "appsettings.json",
							optional: true,
							reloadOnChange: false
						  )
						  .AddJsonFile(
							path: "secrets.json",
							optional: true,
							reloadOnChange: false
						  )
				)
				.UseStartup<Startup>()
				.Build();
	}
}
