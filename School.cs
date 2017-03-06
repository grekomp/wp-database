using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP_Database
{
	class School
	{
		int idSchool;
		String name;

		public String getName()
		{
			return name;
		}

		public int getId()
		{
			return idSchool;
		}

		public School setId(int id)
		{
			if (id < 0) {
					throw new Exception("Id must not be lower than 0");
				} else {
					this.idSchool = id;
				}
		
			return this;
		}

		public School setName(String name)
		{
			if (name.Length == 0) {
					throw new Exception("Name too short");
				} else {
					this.name = name;
				}
			return this;
		}
	}
}
