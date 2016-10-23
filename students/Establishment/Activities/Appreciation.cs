using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluator.Activities
{
    public class Appreciation : Evaluation
    {
        private string appreciation;

        public Appreciation(Course activity, string appreciation) : base(activity)
        {
            this.appreciation = appreciation;
        }

        public override int Note()
        {
            // In the Appreciation class the grade is stored as a string (N, C, B, ...)
            // But the Note method has to return the grade as an int, we use a switch statement
            // to easily return the corresponding grade.
            switch (this.appreciation)
            {
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

        public void setAppreciation(string appreciation)
        {
            this.appreciation = appreciation;
        }
    }
}
