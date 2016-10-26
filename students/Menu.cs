using System;
using System.Collections.Generic;

namespace Evaluator
{
	public class Menu
	{
		private List<Tuple<string, Func<bool>>> options;

		public Menu() {
			this.options = new List<Tuple<string, Func<bool>>>();
		}

		public Menu add_option(string text, Func<bool> action) {
			this.options.Add(new Tuple<string, Func<bool>>(text, action));
			return this;
		}

		public bool Run() {
			while (true) {
				for (int i = 0; i < this.options.Count; i++) {
					Console.WriteLine("\t" + (i + 1) + ") " + options[i].Item1);
				}

				int choice;

				try {
					choice = Int32.Parse(Console.ReadLine()) - 1;
					if (choice >= 0 && choice < this.options.Count) {
						
						Console.WriteLine("");

						if (options[choice].Item2()) {
							break;
						} else {
							Console.WriteLine("Could not perform the operation... :'(\n");
						}
					} else {
						Console.WriteLine("Invalid choice...\n");
					}
				} catch (FormatException) {
					Console.WriteLine("Invalid choice...\n");
				}
			}
				
			return true;
		}
	}
}

