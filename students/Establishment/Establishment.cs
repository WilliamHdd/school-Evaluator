using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

using Evaluator.Entities;
using Evaluator.Activities;


namespace Evaluator
{
	[Serializable]
	public class Establishment
	{
		private string name;

		private HashSet<Student> students;
		private HashSet<Teacher> teachers;
		private HashSet<Course> courses;

		public Establishment (string name) {
			this.name = name;

			this.students = new HashSet<Student> ();
			this.teachers = new HashSet<Teacher> ();
			this.courses = new HashSet<Course> ();
		}

		// Tries to add a student to the establishment
		// returns false if the student is already present
		public bool add_student (Student s) {
			return this.students.Add (s);
		}

		// Tries to add a teacher to the establishment
		// returns false if the teacher is already present
		public bool add_teacher (Teacher t) {
			return this.teachers.Add (t);
		}

		// Tries to add a course
		// returns false if the course is already present
		public bool add_course (Course c) {
			return this.courses.Add (c);
		}


		// Copies the students to an array and returns the array
		public Student[] get_list_of_students () {
			return this.students.ToArray<Student> ();
		}

		// Copies the students to an array and returns the array
		public Teacher[] get_list_of_teachers () {
			return this.teachers.ToArray<Teacher> ();
		}

		// Copies the students to an array and returns the array
		public Course[] get_list_of_courses () {
			return this.courses.ToArray<Course> ();
		}

		// Imports all the data from a file
		// This allows to import all the entries at once istead
		// of having to encode them one by one
		public static Establishment import () {
			IFormatter formatter = new BinaryFormatter ();
			Stream stream = new FileStream ("target.bin",
				                FileMode.Open,
				                FileAccess.Read,
				                FileShare.Read);
			Establishment Establishment = (Establishment)formatter.Deserialize (stream);
			stream.Close ();
			return Establishment;

		}

		// Exports all the data to a file
		// This allows to make backups and use them later
		public bool export () {
			IFormatter formatter = new BinaryFormatter ();
			Stream stream = new FileStream ("target.bin",
				                FileMode.Create,
				                FileAccess.Write, FileShare.None);
			formatter.Serialize (stream, this);
			stream.Close ();
			return false;
		}
	}
}
