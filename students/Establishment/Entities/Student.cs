using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evaluator.Activities;

namespace Evaluator.Entities
{
	[Serializable]
	public class Student : Person
	{
        private Dictionary<Course, List<Grade>> grades;

		public Student (string lastName, string firstName) : base (lastName, firstName) {
            this.grades = new Dictionary<Course, List<Grade>>();
		}

        public void AddEvaluation(Course course, Grade eval) {
            if (!this.grades.ContainsKey(course)) {
                this.grades.Add(course, new List<Grade>());  
            }

            this.grades[course].Add(eval);
        }

		// Returns the average of all the evaluations from all activities
		public double Average() {

			return this.grades.Select(kv => kv.Value.Average(eval => eval.Points()))
							  .Average();
		}

		// Constructs a string representing the average score for each activity of the student
		public string Bulletin() {

			var bulletin = "\nRapport: " + this + "\n\n";

            Console.WriteLine("Number of courses: " + this.grades.Count);

			// And a line for every activity with the code, name, ects and score
			foreach (KeyValuePair<Course, List<Grade>> course in this.grades) {
				var avarage = course.Value.Average(grade => grade.Points());
				bulletin += course.Key.Code + "\t" + course.Key.Name + "\t" + course.Key.ECTS + "\t" + avarage + "%\n";
			}

			bulletin += "\n\n";

			return bulletin;
		}
	}
}
