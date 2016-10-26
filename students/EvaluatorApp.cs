using System;

using Evaluator.Entities;
using Evaluator.Activities;


namespace Evaluator
{
	public class EvaluatorApp
	{
		static private Establishment establishment;
		static private bool run = true;

		public static void Run() {
			EvaluatorApp.InitMenu();
			while (EvaluatorApp.run) {
				EvaluatorApp.MainMenu();
			}
		}

		private static void InitMenu() {

			Console.WriteLine("Welcome, would you like to create a new establishment or import an existing one (from file)\n");

			Menu init_menu = new Menu();

			init_menu
				.add_option("Create new", EvaluatorApp.NewEstablishment)
				.add_option("Import", EvaluatorApp.ImportEstablishment);

			init_menu.Run();
		}

		private static void MainMenu() {
			Console.WriteLine("\nWhat would you like to do?\n");

			Menu main_menu = new Menu();
			Menu student_menu = new Menu();
			Menu teacher_menu = new Menu();
			Menu course_menu = new Menu();

			student_menu
				.add_option("List students", EvaluatorApp.ListStudents)
				.add_option("Grades of student", EvaluatorApp.Dummy)
				.add_option("Add student", EvaluatorApp.AddStudent)
				.add_option("Remove student", EvaluatorApp.RemoveStudent);

			teacher_menu
				.add_option("List teachers", EvaluatorApp.ListTeacher)
				.add_option("Add teacher", EvaluatorApp.AddTeacher)
				.add_option("Remove teacher", EvaluatorApp.RemoveTeacher);

			course_menu
				.add_option("List courses", EvaluatorApp.ListCourse)
				.add_option("Add course", EvaluatorApp.AddCourse)
				.add_option("Remove course", EvaluatorApp.RemoveCourse)
				.add_option("Students signed up for a course", EvaluatorApp.Dummy)
				.add_option("Statistics for a course", EvaluatorApp.Dummy);

			main_menu
				.add_option("Manage students", student_menu.Run)
				.add_option("Manage teachers", teacher_menu.Run)
				.add_option("Manage courses", course_menu.Run)
				.add_option("Export data", EvaluatorApp.ExportEstablishment)
				.add_option("Exit", EvaluatorApp.Exit);

			main_menu.Run();
		}

		private static bool NewEstablishment() {
			Console.WriteLine("What is the establishments name?");
			string name = Console.ReadLine();
			EvaluatorApp.establishment = new Establishment(name);
			return true;
		}

		private static bool ImportEstablishment() {
			try {
				EvaluatorApp.establishment = Establishment.Import();
			} catch {
				Console.WriteLine("An error has occured, how unfortunate.");
				return false;
			}
			return true;
		}

		private static bool ExportEstablishment() {
			try {
				EvaluatorApp.establishment.export();
			} catch {
				Console.WriteLine("An error has occured, how unfortunate.");
				return false;
			}
			return true;
		}

		private static bool ListStudents() {
			var students = EvaluatorApp.establishment.get_list_of_students();

			if (students.Length == 0) {
				Console.WriteLine("There are no students to list...");
				return true;
			}

			foreach (var student in students) {
				Console.WriteLine(student);
			}

			return true;
		}

		private static bool ListTeacher() {

			var teachers = EvaluatorApp.establishment.get_list_of_teachers();

			if (teachers.Length == 0) {
				Console.WriteLine("There are no teachers to list yet...");
				return true;
			}
			foreach (var teacher in teachers) {
				Console.WriteLine(teacher);

			}
			return true;
		}

		private static bool AddStudent() {
			Console.Write("Last name: ");
			var last_name = Console.ReadLine();
			Console.Write("First name: ");
			var first_name = Console.ReadLine();

			var student = new Student(last_name, first_name);

			if (!EvaluatorApp.establishment.add_student(student)) {
				Console.WriteLine("\nStudent \"" + student + "\" is already present...");
				return true;
			}

			Console.WriteLine("\nStudent \"" + student + "\" was added sucessfully");

			return true;
		}


		private static bool RemoveStudent() {
			Console.Write("Last name: ");
			var last_name = Console.ReadLine();
			Console.Write("First name: ");
			var first_name = Console.ReadLine();

			var student = new Student(last_name, first_name);

			if (!EvaluatorApp.establishment.remove_student(student)) {
				Console.WriteLine("\nStudent \"" + student + "\" could not be found...");
				return true;
			}

			Console.WriteLine("\nStudent \"" + student + "\" was removed sucessfully");

			return true;
		}


		private static bool AddTeacher() {
			Console.Write("Last name: ");
			var last_name = Console.ReadLine();
			Console.Write("First name: ");
			var first_name = Console.ReadLine();
			Console.Write("Salary: ");
			int salary;
			while (true) {
				int trySalary;

				try {
					trySalary = Int32.Parse(Console.ReadLine());
					if (trySalary > 0) {

						salary = trySalary;
						break;
					} else {
						Console.WriteLine("Please enter a possitif integer as salary.");
					}
				} catch {
					Console.WriteLine("Please enter an integer as salary.");
				}
			}
			var teacher = new Teacher(last_name, first_name, salary);

			EvaluatorApp.establishment.add_teacher(teacher);

			Console.WriteLine("\nTeacher \"" + teacher + "\" was added successfully");
			return true;
		}

		private static bool RemoveTeacher() {
			Console.Write("Last name: ");
			var last_name = Console.ReadLine();
			Console.Write("First name: ");
			var first_name = Console.ReadLine();

			var teacher = new Teacher(last_name, first_name, 0);

			if (!EvaluatorApp.establishment.get_teacher(teacher)) {
				Console.WriteLine("\nTeacher \"" + teacher + "\" could not be found...");
				return true;
			}

			if (teacher.Courses().Count > 0) {
				Console.WriteLine("This teacher gives some courses, they will be removed as well...");

				foreach (var course in teacher.Courses()) {
					EvaluatorApp.RemoveCourse();
				}
			}

			Console.WriteLine("Teacher \"" + teacher + "\" was removed sucessfully");

			return true;
		}


		private static bool AddCourse() {

			Console.Write("Name: ");
			var name = Console.ReadLine();
			Console.Write("Code: ");
			var code = Console.ReadLine();
			Console.Write("Teacher's last name: ");
			var teacherName = Console.ReadLine();
			Console.Write("Teacher's first name: ");
			var teacherFirstName = Console.ReadLine();

			var teacher = new Teacher(teacherName, teacherFirstName, 0);

			Console.Write("Number of ECTS: ");
			int ects_ok;
			while (true) {
				int ects;

				try {
					ects = Int32.Parse(Console.ReadLine());
					if (ects > 0) {

						ects_ok = ects;
						break;
					} else {
						Console.WriteLine("Please enter a possitif integer as ECTS.");
					}
				} catch {
					Console.WriteLine("Please enter an integer as ECTS.");
				}
			}

			if (EvaluatorApp.establishment.get_teacher(teacher)) {
				var course = new Course(name, code, teacher, ects_ok);
				EvaluatorApp.establishment.add_course(course);
				teacher.Add(course);

			} else {
				Console.WriteLine("The name you gave does not exist. Would you like to create a new teacher ? (y/n) ");
				string answer = Console.ReadLine();

				if (answer == "y") {
					EvaluatorApp.AddTeacher();
				} else if (answer == "n") {
					EvaluatorApp.Exit();
				} else {
					Console.WriteLine("Please choose between y or n ");
				}
			}


			return true;
		}
		private static bool RemoveCourse() {

			Console.WriteLine("Course's code: ");
			var code = Console.ReadLine();

			if (!EvaluatorApp.establishment.remove_course(code)) {
				Console.WriteLine("The course you want to erase could not be found...");
				return true;
			}

			Console.WriteLine("The course has been sucessfuly removed");

			return true;
		}
			


		private static bool ListCourse() {

			var courses = EvaluatorApp.establishment.get_list_of_courses();

			if (courses.Length == 0) {
				Console.WriteLine("There are no courses to list yet...");
				return true;
			}
			foreach (var course in courses) {
				Console.WriteLine(course);

			}
			return true;
		}
	

		private static bool Exit() {
			EvaluatorApp.run = false;
			return true;
		}

		private static bool Dummy() {
			return true;
		}
	}
}

