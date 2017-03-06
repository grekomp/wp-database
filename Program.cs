using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP_Database
{
	class Program
	{
		static void Main(string[] args)
		{
			DatabaseHandler db = DatabaseHandler.getInstance();

			School school1 = new School();
			school1.setId(1);
			school1.setName("Uniwersytet Śląski");
			db.saveSchool(school1);

			Student student1 = new Student();
			student1.setId(1);
			student1.setFirstName("Grzegorz");
			student1.setLastName("Palian");
			student1.setSchoolId(1);

			db.saveStudent(student1);
			Student student2 = db.getStudent(1);
			Console.WriteLine(student2.getFirstName());
			student2.setFirstName("Piotr");
			db.saveStudent(student2);

			student1 = db.getStudent(1);
			Console.WriteLine(student1.getFirstName());

			Console.ReadKey();
		}
	}
}
