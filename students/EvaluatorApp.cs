using System;

namespace Evaluator
{
	[Serializable]
	public class EvaluatorApp
	{
		static private Establishment establishment;
		static private bool run = true;

		public static void Run () {
			EvaluatorApp.InitMenu ();
			while (EvaluatorApp.run) {
				EvaluatorApp.MainMenu ();
			}
		}
			
		private static void InitMenu () {

			Console.WriteLine ("Welcome, would you like to create a new establishment or import an existing one (from file)\n");

			Menu init_menu = new Menu ();

			init_menu
				.add_option ("Create new", EvaluatorApp.NewEstablishment)
				.add_option ("Import", EvaluatorApp.ImportEstablishment);

			init_menu.Run ();
		}

		private static void MainMenu () {
			Console.WriteLine ("What would you like to do?\n");

			Menu main_menu = new Menu ();
			Menu student_menu = new Menu ();
			Menu teacher_menu = new Menu ();
			Menu course_menu = new Menu ();

			student_menu
				.add_option ("List students", EvaluatorApp.Dummy)
				.add_option ("Grades of student", EvaluatorApp.Dummy)
				.add_option ("Add student", EvaluatorApp.Dummy)
				.add_option ("Remove student", EvaluatorApp.Dummy);

			teacher_menu
				.add_option ("List teachers", EvaluatorApp.Dummy)
				.add_option ("Add teacher", EvaluatorApp.Dummy)
				.add_option ("Remove teacher", EvaluatorApp.Dummy);

			course_menu
				.add_option ("List courses", EvaluatorApp.Dummy)
				.add_option ("Add course", EvaluatorApp.Dummy)
				.add_option ("Remove course", EvaluatorApp.Dummy)
				.add_option ("Students signed up for a course", EvaluatorApp.Dummy)
				.add_option ("Statistics for a course", EvaluatorApp.Dummy);
			
			main_menu
				.add_option ("Manage students", student_menu.Run)
				.add_option ("Manage teachers", teacher_menu.Run)
				.add_option ("Manage courses", course_menu.Run)
				.add_option ("Exit", EvaluatorApp.Exit);

			main_menu.Run ();
		}

		private static bool NewEstablishment () {
			Console.WriteLine ("What is the establishments name?");
			string name = Console.ReadLine ();
			EvaluatorApp.establishment = new Establishment (name);
			return true;
		}

		private static bool ImportEstablishment () {
			try {
				EvaluatorApp.establishment = Establishment.import ();
			} catch {

				Console.WriteLine ("An error has occured, please contact the creator of this app.");
			}
			return true;
		}

		private static bool Exit() {
			EvaluatorApp.run = false;
			return true;
		}

		private static bool Dummy () {
			return true;
		}
	}
}

