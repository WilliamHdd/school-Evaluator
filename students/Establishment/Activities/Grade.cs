using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluator.Activities
{
	[Serializable]
	public class Grade
	{
        protected double points;

		//Compares a grade to max grade and sets it on 100.
		public Grade (double points, double max) {
			if (points < 0 || max < 1 || max < points) {
                throw new ArgumentException();
            }

            this.points = points * 100 / max;
		}

		public double Points () {
            return points;
        }

        public override string ToString() {
            return this.points + "%";
        }
    }
}
