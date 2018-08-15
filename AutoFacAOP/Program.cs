using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;

namespace AutoFacAOP
{
    class Program
    {
        static void Main(string[] args)
        {
			var builder = new ContainerBuilder();
			// 命名注入
			//builder.Register(c => new CallLogger(Console.Out)).Named<IInterceptor>("log-calls");

			//启用类代理拦截
			builder.RegisterType<Circle>().EnableClassInterceptors();
			//启用接口代理拦截
			//builder.RegisterType<Circle>().EnableInterfaceInterceptors();

			builder.RegisterType<Circle>().As<IShape>().EnableInterfaceInterceptors();//注册cat并为其添加拦截器
			//注入拦截器到容器																										//类型注入
			builder.Register(c => new CallLogger(Console.Out));
			//创建容器
			var container = builder.Build();
			//从容器获取类型
			var circle = container.Resolve<IShape>();

			circle.Area();

			Console.ReadKey();
		}
    }
}
