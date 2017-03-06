using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP_Database
{
	class RowNotFoundException : DatabaseHandlerException
	{
		public RowNotFoundException()
		{

		}

		public RowNotFoundException(string message)
			: base(message)
		{

		}

		public RowNotFoundException(string message, Exception inner) 
			: base(message, inner)
		{

		}
	}
}
