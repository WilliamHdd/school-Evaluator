using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluator.Activities
{
	[Serializable]
	public class LetterGrade : Grade
	{
		//Converts a string grade into an int grade.
		public LetterGrade(string letter_grade) : base(0, 100) {
			switch (letter_grade) {
				case "A+":
					this.points = 97;
					break;
				case "A":
					this.points = 94;
					break;
				case "A-":
					this.points = 91;
					break;
				case "B+":
					this.points = 88;
					break;
				case "B":
					this.points = 84;
					break;
				case "B-":
					this.points = 81;
					break;
				case "C+":
					this.points = 78;
					break;
				case "C":
					this.points = 74;
					break;
				case "C-":
					this.points = 71;
					break;
				case "D+":
					this.points = 68;
					break;
				case "D":
					this.points = 64;
					break;
				case "D-":
					this.points = 61;
					break;
				case "F":
					this.points = 30;
					break;
				default:
					throw new ArgumentException();
			}
		}
	}
}
