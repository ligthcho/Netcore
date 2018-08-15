using Attri;
using AutoFacIDAL;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FacProxy
{
	public class CatInterceptor:IInterceptor
	{
		private readonly ICat _cat;
		/// <summary>
		/// 通过依赖注入 注入ICat的具体实现
		/// </summary>
		/// <param name="cat"></param>
		public CatInterceptor(ICat cat)
		{
			_cat = cat;
		}
		public void Intercept(IInvocation invocation)
		{
			Console.WriteLine("喂猫吃东西");

			MethodInfo methodInfo = invocation.MethodInvocationTarget;
			if(methodInfo == null)
				methodInfo = invocation.Method;
		    //方法过滤器
			UnitOfWorkAttribute transaction = methodInfo.GetCustomAttributes<UnitOfWorkAttribute>(true).FirstOrDefault();
			if(transaction != null)
			{
				invocation.Proceed();
			}
			invocation.Method.Invoke(_cat,invocation.Arguments);//调用Cat的指定方法
			//Console.WriteLine("猫吃东西之前");
			//invocation.Proceed();
			//Console.WriteLine("猫吃东西之后");
		}
	}
}
