using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluator.Activities
{
	[Serializable]
    public class Grade : Evaluation
    {
        private int grade;

        public Grade(Course activity, int grade) : base(activity)
        {
            this.grade = grade;
        }

        public override int Note()
        {
            return grade;
        }

        public void setNote(int grade)
        {
            if (grade < 0)
            {
                Console.WriteLine("A grade can't be negative");
            }

            this.grade = grade;
        }
    }
}
