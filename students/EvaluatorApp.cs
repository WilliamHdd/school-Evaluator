using System;

namespace Evaluator
{
	public class EvaluatorApp
	{
		static private Establishment establishment;

		public static void Run() {
			EvaluatorApp.InitMenu();
            EvaluatorApp.MainMenu();
		}

        private static void ConstructMenu(Tuple<string, Func<bool>>[] options)
        {
            while(true)
            {
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine("\t" + (i+1) + ") " + options[i].Item1);
                }

                int choice;

                try
                {
                    choice = Int32.Parse(Console.ReadLine()) - 1;
                    if (choice >= 0 || choice < options.Length)
                    {
                        if (options[choice].Item2()) {
                            break;
                        } else
                        {
                            Console.WriteLine("Could not perform the operation... :'(");
                        }
                    }
                }
                catch (FormatException)
                {
                    // Do nothing, the range and parse error is handled at the same time below
                }

                Console.WriteLine("Invalid choice...");
            }
        }

		private static void InitMenu()
		{

			Console.WriteLine ("Welcome, would you like to create a new establishment or import an existing one (from file)\n");

            Tuple<string, Func<bool>>[] options = {
                new Tuple<string, Func<bool>>("Create new", EvaluatorApp.NewEstablishment),
                new Tuple<string, Func<bool>>("Create new", EvaluatorApp.ImportEstablishment)
            };

            EvaluatorApp.ConstructMenu(options);
		}

        private static void MainMenu()
        {
            Console.WriteLine("What would you like to do?\n");

            Tuple<string, Func<bool>>[] options = {
                new Tuple<string, Func<bool>>("Manage students", EvaluatorApp.Dummy),
                new Tuple<string, Func<bool>>("Manage teachers", EvaluatorApp.Dummy),
                new Tuple<string, Func<bool>>("Manage courses", EvaluatorApp.Dummy)
            };

            EvaluatorApp.ConstructMenu(options);

        }

		private static bool NewEstablishment()
		{
            Console.WriteLine("What is the establishments name?");
            string name = Console.ReadLine();
            EvaluatorApp.establishment = new Establishment(name);
            return true;
		}

		private static bool ImportEstablishment()
		{
			return true;
		}

        private static int WaitForChoice(int min, int max)
        {
            while (true)
            {
                int choice;

                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                    if (choice > min || choice < max)
                    {
                        return choice;
                    }
                }
                catch (FormatException)
                {
                    // Do nothing, the range and parse error is handled at the same time below
                }

                Console.WriteLine("Invalid choice...");
            }
        }

        private static bool Dummy() {
            return true;
        }
	}
}

