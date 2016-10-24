using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluator.Entities
{
	[Serializable]
    public class Teacher : Person
    {

        public Teacher(string lastName, string firstName, int salary) : base(lastName, firstName)
        {
            this.Salary = salary;
        }

        public int Salary
        {
            get;
            set;
        }
    }
}
