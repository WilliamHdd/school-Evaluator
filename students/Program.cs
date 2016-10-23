using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Activities;
using Entities;

namespace students
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Use the readX functions defined below to read the different csv files and construct lists
			List<Student> students = readStudents ("../../students.csv");
			List<Teacher> teachers = readTeachers ("../../teachers.csv");


			List<Activity> activities = readActivity ("../../activities.csv", teachers);

			readGrades ("../../grades.csv", students, activities);

			// Create a file for every student
			foreach (Student student in students) {
				File.WriteAllText("../../Bulletin-"+ student.LastName + "-" + student.FirstName +".txt", student.Bulletin());
			}

		}


		// Function that reads the file at the given path and constructs a list of Students
		public static List<Student> readStudents(string path) {

			// Read the file into an array of strings representing the lines
			string[] lines = System.IO.File.ReadAllLines(path);

			List<Student> students = new List<Student>();

			// For each line, split the line at commas and trim beginning and trailing whitespace from the elements.
			// The Select method works on enumerable objects: https://msdn.microsoft.com/en-us/library/bb548891(v=vs.110).aspx
			// and aplies a given function to every element. In this case the function is the lambda function `elem => elem.Trim()`
			foreach (string line in lines) {
				List<string> elems = line.Split(',').Select(elem => elem.Trim() ).ToList<string>();
				students.Add(new Student(elems[0], elems[1]));
			}

			return students;
		}


		// Function that reads the file at the given path and constructs a list of Teachers
		public static List<Teacher> readTeachers(string path) {
			string[] lines = System.IO.File.ReadAllLines(path);

			List<Teacher> teachers = new List<Teacher>();

			foreach (string line in lines) {
				List<string> elems = line.Split(',').Select(elem => elem.Trim()).ToList<string>();
				teachers.Add(new Teacher(elems[0], elems[1], Int32.Parse(elems[2])));				// Int32.Parse parses a string to an int
			}

			return teachers;
		}


		// Function that reads the file at the given path and constructs a list of Activities
		public static List<Activity> readActivity(string path, List<Teacher> teachers) {
			string[] lines = System.IO.File.ReadAllLines(path);

			List<Activity> activities = new List<Activity>();

			foreach (string line in lines) {
				List<string> elems = line.Split(',').Select(elem => elem.Trim() ).ToList<string>();

				// Find is a method on Lists that return an element that matches a given predicate. 
				// A predicate is a function given to Find that returns a boolean (true or false)
				// In this case the predicate is `t => t.LastName == elems[2]` and returns true when
				// the LastName property of the element t of type Teacher is equal to the third element of the line
				activities.Add(new Activity(elems[0], elems[1], teachers.Find(t => t.LastName == elems[2]), Int32.Parse(elems[3])));
			}

			return activities;
		}


		// Function that reads the file at the given path and adds grades to the students
		public static void readGrades(string path, List<Student> students, List<Activity> activities) {
			string[] lines = System.IO.File.ReadAllLines(path);

			foreach (string line in lines) {
				List<string> elems = line.Split(',').Select(elem => elem.Trim() ).ToList<string>();

				Evaluation grade;

				// Grades can be either given as an int or a string (N, C, B, ...)
				// We first try to parse the grade from the file as a number, if that fails (raises an exception)
				// we assume the grade is in the string fromat
				try {
					grade = new Grade(activities.Find(a => a.Code == elems[1]), Int32.Parse(elems[2]));
				} catch (FormatException) {
					grade = new Appreciation (activities.Find (a => a.Code == elems [1]), elems [2]);
				}

				// Find the corresponding student and add the grade
				students.Find(s => s.LastName == elems[0])
						.Add(grade);
			}
		}
	}


}
