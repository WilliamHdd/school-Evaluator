using System;
using Entities;

namespace Activities
{
	public class Activity
	{
		public Teacher Teacher { get; set; }
		public int ECTS { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }

		public Activity (string name, string code, Teacher teacher, int ects)
		{	
			this.Name = name;
			this.Code = code;
			this.ECTS = ects;
			this.Teacher = teacher;
		}
	}

	public abstract class Evaluation {
		public Activity Activity { get; set; }

		public Evaluation(Activity activity) {
			this.Activity = activity;
		}

		public abstract int Note();
	}

	public class Grade : Evaluation {
		private int grade;

		public Grade(Activity activity, int grade) : base(activity) {
			this.grade = grade;
		}

		public override int Note() {
			return grade;
		}

		public void setNote(int grade) {
			if (grade < 0) { 
				Console.WriteLine ("A grade can't be negative");
			}

			this.grade = grade;
		}
	}

	public class Appreciation : Evaluation {
		private string appreciation;

		public Appreciation(Activity activity, string appreciation) : base(activity) {
			this.appreciation = appreciation;
		}

		public override int Note() {
			// In the Appreciation class the grade is stored as a string (N, C, B, ...)
			// But the Note method has to return the grade as an int, we use a switch statement
			// to easily return the corresponding grade.
			switch (this.appreciation) {
				case "N":
					return 20;
				case "C":
					return 16;
				case "B":
					return 12;
				case "TB":
					return 8;
				case "X":
					return 4;
				default:
					return 0;
			}
		}

		public void setAppreciation(string appreciation) {
			this.appreciation = appreciation;
		}
	}
}

