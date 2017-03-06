using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP_Database
{
	class Student
	{
		int idStudent;
		String firstName;
		String lastName;
		int schoolId;

		int createdAt;
		int modifiedAt;
		int createdById;
		int modifiedById;

		School school;

		public Student()
		{
			idStudent = 0;
			firstName = "";
			lastName = "";
			schoolId = 0;
			createdAt = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
			modifiedAt = createdAt;
			createdById = 0;
			modifiedById = 0;

			school = new School();
		}

		public Student(int idStudent, String firstName, String lastName, int schoolId, int createdAt, int modifiedAt, int createdById, int modifiedById)
		{
			this.idStudent = idStudent;
			this.firstName = firstName;
			this.lastName = lastName;
			this.schoolId = schoolId;
			this.createdAt = createdAt;
			this.modifiedAt = modifiedAt;
			this.createdById = createdById;
			this.modifiedById = modifiedById;

		}

		public int getId()
		{
			return idStudent;
		}

		public String getFirstName()
		{
			return firstName;
		}

		public String getLastName()
		{
			return lastName;
		}

		public int getSchoolId()
		{
			return schoolId;
		}

		public School getSchool()
		{
			return school;
		}

		public String getSchoolName()
		{
			return school.getName();
		}

		public int getCreatedAt()
		{
			return createdAt;
		}

		public int getCreatedById()
		{
			return createdById;
		}

		public int getModifiedAt()
		{
			return modifiedAt;
		}

		public int getModifiedById()
		{
			return modifiedById;
		}

		public Student setId(int idStudent)
		{
			this.idStudent = idStudent;

			return this;
		}

		public Student setFirstName(String name)
		{
			if (name.Length == 0) {
					throw new Exception("Name too short");
				}else {
					firstName = name;
				}
		
			return this;
		}

		public Student setLastName(String name)
		{
			if (name.Length == 0) {
					throw new Exception("Name too short");
				}else {
					lastName = name;
				}
		
			return this;
		}

		public Student setSchoolId(int schoolId)
		{
			if (schoolId < 0) {
					throw new Exception("Id must not be lower than 0");
				} else {
					this.schoolId = schoolId;
				}
		
			return this;
		}

		public Student setSchool(School school)
		{
			this.school = school;
			return this;
		}

		public Student setCreatedAt(int createdAt)
		{
			this.createdAt = createdAt;

			return this;
		}

		public Student setModifiedAt(int modifiedAt)
		{
			this.modifiedAt = modifiedAt;

			return this;
		}
	}
}
