using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluator.Entities
{
	[Serializable]
	public class Person
	{
		public Person (string lastName, string firstName) {
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		public string FirstName {
			get;
			set;
		}

		public string LastName {
			get;
			set;
		}

		public void DisplayName () {
			Console.WriteLine (this.LastName + " " + this.FirstName);
		}
	}
}
