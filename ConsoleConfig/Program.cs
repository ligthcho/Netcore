using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConsoleConfig
{
    class Program
    {
		static void Main(string[] args)
		{
			var builder = new ConfigurationBuilder()
					 .SetBasePath(Directory.GetCurrentDirectory())
					 .AddJsonFile("appsettings.json")
		             .AddJsonFile("appsettings.Test.json",true,reloadOnChange: true);
			var config = builder.Build();
			//foreach(var provider in config.Providers)
			//{
			//	provider.TryGet("Alipay:AppId",out string val);
			//	Console.WriteLine(val);
			//}
			Console.WriteLine(config["Alipay:AppId"]);
			Console.WriteLine(config["Alipay:PriviteKey"]);
			Console.WriteLine("更改文件之后，按下任意键");
			Console.ReadKey();
			Console.WriteLine("change:");
			//读取配置
			Console.WriteLine(config["Alipay:AppId"]);
			Console.WriteLine(config["Alipay:PriviteKey"]);
			Console.ReadKey();
		}
    }
}
