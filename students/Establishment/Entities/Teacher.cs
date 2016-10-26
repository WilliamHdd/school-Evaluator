using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evaluator.Activities;

namespace Evaluator.Entities
{
	[Serializable]
	public class Teacher : Person
	{
		private List<Course> courses;

		public Teacher(string lastName, string firstName, int salary) : base(lastName, firstName) {
			this.Salary = salary;
			this.courses = new List<Course>();

		}

		public int Salary {
			get;
			set;
		}

		public void Add(Course course) {
			this.courses.Add(course);
		}

		public List<Course> Courses() {
			return this.courses;
		}
	}
}
