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
		public string Name { get; set; }

		// You can't retrieve a value in a HashSet, that's why we use a dictionary here.
		// The key will be a hash of the last and first name of the student, while the value
		// will store the whole students with grades and all
		private Dictionary<Student, Student> students;
		private Dictionary<Teacher,Teacher> teachers;
		private Dictionary<string, Course> courses;

		public Establishment(string name) {
			this.Name = name;

			this.students = new Dictionary<Student, Student>();
			this.teachers = new Dictionary<Teacher, Teacher>();
			this.courses = new Dictionary<string, Course>();

		}

		// Tries to add a student to the establishment
		// returns false if the student is already present
		public bool add_student(Student s) {
			if (this.students.ContainsKey(s)) {
				return false;
			}

			this.students.Add(s, s);
			return true;
		}

		public bool remove_student(Student s) {
			return this.students.Remove(s);
		}

		public bool get_student(Student s) {
			return this.students.TryGetValue(s, out s);
		}

		// Tries to add a teacher to the establishment
		// returns false if the teacher is already present
		public bool add_teacher(Teacher t) {
			if (this.teachers.ContainsKey(t)) {
				return false;
			}

			this.teachers.Add(t,t);
			return true;
		}

		public bool remove_teacher(Teacher t) {
			return this.teachers.Remove(t);
		}

		public bool get_teacher(Teacher t) {
			return this.teachers.TryGetValue(t, out t);
		}

		public bool contains_teacher(Teacher t) {
			return this.teachers.ContainsKey(t);
		}

		// Tries to add a course
		// returns false if the course is already present
		public bool add_course(Course c) {
			if (this.courses.ContainsKey(c.Code)) {
				return false;
			}

			this.courses.Add(c.Code, c);
			return true;
		}

		public bool remove_course(string code) {
			return this.courses.Remove(code);
		}

		public bool get_course(string code, out Course course) {
			return this.courses.TryGetValue(code, out course);
		}


		// Copies the students to an array and returns the array
		public Student[] get_list_of_students() {
			return this.students.Select(kv => kv.Value).ToArray<Student>();
		}

		// Copies the students to an array and returns the array
		public Teacher[] get_list_of_teachers() {
			return this.teachers.Select(kv => kv.Value).ToArray<Teacher>();
		}

		// Copies the students to an array and returns the array
		public Course[] get_list_of_courses() {
			return this.courses.Select(kv => kv.Value).ToArray<Course>();
		}

		public bool contains_student(Student s) {
			return this.students.ContainsKey(s);
		}

		// Imports all the data from a file
		// This allows to import all the entries at once istead
		// of having to encode them one by one
		public static Establishment Import() {
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream("data.evaluator",
				                FileMode.Open,
				                FileAccess.Read,
				                FileShare.Read);
			
			Establishment Establishment = (Establishment)formatter.Deserialize(stream);
			stream.Close();
			return Establishment;
		}

		// Exports all the data to a file
		// This allows to make backups and use them later
		public bool export() {
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream("data.evaluator",
				                FileMode.Create,
				                FileAccess.Write, 
								FileShare.None);
			
			formatter.Serialize(stream, this);
			stream.Close();
			return false;
		}
	}
}
