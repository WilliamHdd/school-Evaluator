using System;

namespace Evaluator
{
	[Serializable]
	public class EvaluatorApp
	{
		static private Establishment establishment;

		public static void Run () {
			EvaluatorApp.InitMenu ();
			EvaluatorApp.MainMenu ();
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

			main_menu
				.add_option ("Manage students", EvaluatorApp.Dummy)
				.add_option ("Manage teachers", EvaluatorApp.Dummy)
				.add_option ("Manage courses", EvaluatorApp.Dummy);

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

		private static bool Dummy () {
			return true;
		}
	}
}

