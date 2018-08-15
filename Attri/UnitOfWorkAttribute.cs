using System;
using System.Collections.Generic;
using System.Text;

namespace Attri
{
	[AttributeUsage(AttributeTargets.All)]
	public sealed class UnitOfWorkAttribute:Attribute
    {
		private readonly string _name;

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public UnitOfWorkAttribute(string name)
		{
			_name = name;
		}

	}
}
