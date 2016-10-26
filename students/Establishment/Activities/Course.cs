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
	}
}
