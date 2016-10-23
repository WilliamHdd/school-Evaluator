using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluator.Activities
{
    public abstract class Evaluation
    {
        public Course Activity { get; set; }

        public Evaluation(Course activity)
        {
            this.Activity = activity;
        }

        public abstract int Note();
    }

}
