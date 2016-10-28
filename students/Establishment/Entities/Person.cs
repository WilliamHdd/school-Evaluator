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
		public Person(string lastName, string firstName) {
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

		public override string ToString() {
			return this.LastName + " " + this.FirstName;
		}

		public override bool Equals(Object obj) {
			Person personObj = obj as Person; 

			if (personObj == null) {
				return false;
			} else {
				return this.FirstName == personObj.FirstName && this.LastName == personObj.LastName;
			}
		}
		/*Sets an unique HashCode to a person. 
		Permits to have different person with same name or whatever and still be different.*/
		public override int GetHashCode() {
			int hash = 13;
			hash = (hash * 7) + this.LastName.GetHashCode();
			hash = (hash * 7) + this.FirstName.GetHashCode();
				
			return hash;
		}
	}
}
