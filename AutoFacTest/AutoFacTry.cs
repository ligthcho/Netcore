using Autofac;
using AutoFacDAL;
using AutoFacIDAL;
using AutoFacTest.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacTest
{
    public class AutoFacTry
    {
		public void Test1()
		{
			#region
			///builder.RegisterType<Object>().As<Iobject>()：注册类型及其实例。
			///例如下面就是注册接口IDAL的实例SqlDAL
			///IContainer.Resolve<IDAL>()：解析某个接口的实例
			#endregion
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterType<SqlDAL>().As<IDAL>();
			IContainer container = builder.Build();
			SqlDAL sqlDAL = (SqlDAL)container.Resolve<IDAL>();
		}

		public void Test2()
		{
			#region
			//builder.RegisterType<Object>().Named<Iobject>(string name)：
			//为一个接口注册不同的实例。有时候难免会碰到多个类映射同一个接口，
			//比如SqlDAL和OracleDAL都实现了IDAL接口，为了准确获取想要的类型，就必须在注册时起名字。
			//IContainer.ResolveNamed<IDAL>(string name):
			//解析某个接口的“命名实例”。
			//例如上面的最后一行代码就是解析IDAL的命名实例OracleDAL
			#endregion
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterType<SqlDAL>().Named<IDAL>("sql");
			builder.RegisterType<OracleDAL>().Named<IDAL>("oracle");
			IContainer container = builder.Build();
			SqlDAL sqlDAL = (SqlDAL)container.ResolveNamed<IDAL>("sql");
			OracleDAL oracleDAL = (OracleDAL)container.ResolveNamed<IDAL>("oracle");
		}
		public void Test3()
		{
			#region
			//builder.RegisterType<Object>().Keyed<Iobject>(Enum enum)：
			//以枚举的方式为一个接口注册不同的实例。
			//有时候我们会将某一个接口的不同实现用枚举来区分，而不是字符串
			#endregion
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterType<SqlDAL>().Keyed<IDAL>(DBType.Sql);
			builder.RegisterType<OracleDAL>().Keyed<IDAL>(DBType.Oracle);
			IContainer container = builder.Build();
			SqlDAL sqlDAL = (SqlDAL)container.ResolveKeyed<IDAL>(DBType.Sql);
			OracleDAL oracleDAL = (OracleDAL)container.ResolveKeyed<IDAL>(DBType.Oracle);
		}
		public void Test4()
		{
			#region
			//在解析实例T时给其赋值
			#endregion
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterType<SqlDAL>().Keyed<IDAL>(DBType.Sql);
			builder.RegisterType<OracleDAL>().Keyed<IDAL>(DBType.Oracle);
			IContainer container = builder.Build();
			DBManager manager = container.Resolve<DBManager>(new NamedParameter("name","SQL"));
		}
		public enum DBType
		{
			Sql, Oracle
		}
	}
}
