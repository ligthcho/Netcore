using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoFacDAL;
using AutoFacIDAL;
using Castle.DynamicProxy;
using FacProxy;
using System;

namespace AutoFacConsole
{
	class Program
    {
		static void Main(string[] args)
		{
			// 11111111111111
			//ICat icat = new Cat();

			//var catProxy = new CatProxy(icat);

			//catProxy.Eat();

			//Console.Read();

			var builder = new ContainerBuilder();
			builder.RegisterType<CatInterceptor>();//注册拦截器
			//InterceptedBy 注册扩展
			//builder.RegisterType<Cat>().As<ICat>().InterceptedBy(typeof(CatInterceptor)).EnableInterfaceInterceptors();//注册cat并为其添加拦截器

			//动态载入代理
			//builder.RegisterType<Cat>().As<ICat>().EnableInterfaceInterceptors();
			//var container = builder.Build();
			//var cat = container.Resolve<ICat>();
			//cat.Eat();

			builder.RegisterType<CatInterceptor>();//注册拦截器
			builder.RegisterType<Cat>().As<ICat>();//注册Cat
			builder.RegisterType<CatOwner>().InterceptedBy(typeof(CatInterceptor)).EnableClassInterceptors(ProxyGenerationOptions.Default,additionalInterfaces:typeof(ICat));
			//注册CatOwner并为其添加拦截器和接口
			var container = builder.Build();
			var cat = container.Resolve<CatOwner>();//获取CatOwner的代理类

			cat.GetType().GetMethod("Eat").Invoke(cat,null);//因为我们的代理类添加了ICat接口，所以我们可以通过反射获取代理类的Eat方法来执行
			
			Console.Read();
		}
	}
}
