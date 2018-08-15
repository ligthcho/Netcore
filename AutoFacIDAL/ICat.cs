using Attri;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoFacIDAL
{
	[UnitOfWork("接口猫")]
	public interface ICat
    {
		[UnitOfWork("吃猫")]
		void Eat();
    }
}
