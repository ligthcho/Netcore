using Autofac.Extras.DynamicProxy;
using AutoFacIDAL;
using FacProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoFacDAL
{
	[Intercept(typeof(CatInterceptor))]//动态载入代理

	[UnitOfWork("猫")]
	public class Cat:ICat
	{
		public void Eat()
		{
			Console.WriteLine("猫在吃东西");
		}
	}
}
