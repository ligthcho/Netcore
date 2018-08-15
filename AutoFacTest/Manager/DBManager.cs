using AutoFacIDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacTest.Manager
{
	public class DBManager
	{
		IDAL _dal;

		public string Name
		{
			get;
		    set;
		}
		public IDAL dal
		{
			get;
		    set;
		}

		public DBManager(IDAL dal)
		{
			_dal = dal;
		}
		public void Add(string commandText)
		{
			_dal.Insert(commandText);
		}

		public DBManager(string name,IDAL _dal)
		{
			Name = name;
			dal = _dal;
		}
	}
}
