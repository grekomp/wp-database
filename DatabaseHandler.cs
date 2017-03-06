using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP_Database
{
	class DatabaseHandler
	{
		static DatabaseHandler instance;
		SQLiteConnection dbConnection;
		string dbFile = "db.sqlite";

		DatabaseHandler()
		{
			if (File.Exists(dbFile) == false)
			{
				SQLiteConnection.CreateFile("db.sqlite");
			}

			dbConnection = new SQLiteConnection("Data Source=" + dbFile + ";");
			dbConnection.Open();

			string sql = "create table if not exists schools (id_school integer primary key, name text not null)";
			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			command.ExecuteNonQuery();

			sql = "create table if not exists students (id_student integer primary key not null, first_name text not null, last_name text not null, school_id integer not null, created_at integer not null, modified_at integer not null, created_by integer not null default 0, modified_by integer not null default 0, foreign key(school_id) references schools(id_school))";
			command = new SQLiteCommand(sql, dbConnection);
			command.ExecuteNonQuery();

		}

		public static DatabaseHandler getInstance()
		{
			if (instance == null) instance = new DatabaseHandler();
			return instance;
		}

		public School getSchool(int idSchool)
		{
			string sql = "select * from schools where id_school=" + idSchool;
			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			SQLiteDataReader reader = command.ExecuteReader();

			if (reader.Read())
			{
				School school = new School();
				school.setId(reader.GetInt32(0));
				school.setName(reader.GetString(1));
			}
			else
			{
				throw new RowNotFoundException("A school with id=" + idSchool + " was not found");
			}

			return new School();
		}

		public Student getStudent(int idStudent)
		{
			string sql = "select * from students where id_student=" + idStudent;
			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			SQLiteDataReader reader = command.ExecuteReader();

			if (reader.Read())
			{
				Student student = new Student();
				student.setId(reader.GetInt32(0));
				student.setFirstName(reader.GetString(1));
				student.setLastName(reader.GetString(2));
				student.setSchoolId(reader.GetInt32(3));
				student.setCreatedAt(reader.GetInt32(4));
				student.setModifiedAt(reader.GetInt32(5));

				student.setSchool(getSchool(student.getSchoolId()));

				return student;
			}
			else
			{
				throw new RowNotFoundException("A student with id=" + idStudent + " was not found");
			}
		}

		public DatabaseHandler saveSchool(School school)
		{
			string sql;

			try
			{
				getSchool(school.getId());
				sql = "update schools set name = '" + school.getName() + "' where id_school=" + school.getId();
			}
			catch (RowNotFoundException e)
			{
				sql = "insert into schools (id_school, name) values ( " + school.getId() + ", '" + school.getName() + "')";
			}

			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			command.ExecuteNonQuery();

			return this;
		}

		public DatabaseHandler saveStudent(Student student)
		{
			string sql;

			try
			{
				getStudent(student.getId());
				sql = "update students set first_name='" + student.getFirstName() + "', last_name='" + student.getLastName() + "', school_id=" + student.getSchoolId() + ", modified_at=" + unixTimestamp() + " where id_student=" + student.getId();
			}
			catch(RowNotFoundException e)
			{
				sql = "insert into students (first_name, last_name, school_id, created_at, modified_at) values ('" + student.getFirstName() + "', '" + student.getLastName() + "', " + student.getSchoolId() + ", " + unixTimestamp() + ", " + unixTimestamp() + ")";
			}

			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			command.ExecuteNonQuery();

			return this;
		}
		
		int unixTimestamp()
		{
			return (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
		}
	}
}
