using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evaluator.Entities;

namespace Evaluator.Activities
{
	[Serializable]
	public class Course
	{
		public Teacher Teacher { get; set; }

		public int ECTS { get; set; }

		public string Name { get; set; }

		public string Code { get; set; }

		public Course(string name, string code, Teacher teacher, int ects) {
			this.Name = name;
			this.Code = code;
			this.ECTS = ects;
			this.Teacher = teacher;
		}
		public override string ToString() {
			return this.Name + " [" +this.Code + "] given by " + this.Teacher + " (" + this.ECTS + " ects) ";
		}
		public override bool Equals(Object obj) {
			Course CourseObj = obj as Course;

			if (CourseObj == null) {
				return false;
			} else {
				return this.Name == CourseObj.Name && this.Code == CourseObj.Code && this.ECTS == CourseObj.ECTS && this.Teacher == CourseObj.Teacher;
			}
		}

		public override int GetHashCode() {
			int hash = 13;
			hash = (hash * 7) + this.Name.GetHashCode();
			hash = (hash * 7) + this.Code.GetHashCode();
			hash = (hash * 7) + this.ECTS.GetHashCode();
			hash = (hash * 7) + this.Teacher.GetHashCode();

			return hash;
		}

	}
}
