using System;

namespace Evaluator
{
	public class EvaluatorApp
	{
		static private Establishment establishment;

		public static void Run() {
			EvaluatorApp.InitMenu();
		}

		private static void InitMenu()
		{

			Console.WriteLine ("Welcome, would you like to create a new establishment or import an existing one (from file)\n");

			bool initialised = false;

			while (!initialised) {
				Console.WriteLine ("\t1) Create new");
				Console.WriteLine ("\t2) Import");
				Console.WriteLine ("");

				int choice;

				try {
					choice = Int32.Parse(Console.ReadLine());

					switch (choice) {
						case 1:
							EvaluatorApp.NewEstablishment();
							initialised = true;
							break;
						case 2:
							if (EvaluatorApp.ImportEstablishment()) {
								initialised = true;	
							}
							break;
						default:
							Console.WriteLine ("Invalid choice\n");
							continue;
					}
				} catch (FormatException) {
					Console.WriteLine ("Invalid choice\n");
					continue;
				}
			}
		}

		private static void NewEstablishment()
		{
		}

		private static bool ImportEstablishment()
		{
			return true;
		}
	}
}

