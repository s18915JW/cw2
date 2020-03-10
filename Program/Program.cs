using System;
using System.Collections.Generic;
using System.IO;

namespace Program
{
	class Program
	{
		static void Main(string[] args)
		{
			var logPath = @"C:\Users\s18915\Desktop\log.txt";
			var log = File.Create(logPath);

			string csvLoc, xmlLoc, format;

			if (args.Length != 3)
			{
				csvLoc = @"C:\Users\s18915\Desktop\dane.csv";	// data
				xmlLoc = @"C:\Users\s18915\Desktop\wynik.xml";
				format = "xml";
			}
			else
			{
				csvLoc = args[0];
				xmlLoc = args[1];
				format = args[2];
			}

			if (File.Exists(csvLoc)) {

				var students = File.ReadLines(csvLoc);

				var hash = new HashSet<Student>(new Comparer());

				foreach (var student in students)
				{
					// Console.WriteLine(student);

					var st = new Student
					{
						FirstName = "Jan",
						LastName = "Kowalski",
						Index = "kowalski@wp.pl"
					};
					hash.Add(st);
				}

				if (!hash.Add(newStud))
				{
					// errors
					// zapis
				}

				//var today = DateTime.Today;
				//Console.WriteLine(today.ToShortDateString());

				//} else if (!File.Exists(csvLoc)) {
				//	using (StreamWriter sw = File.CreateText(logPath)) {
				//		sw.WriteLine("Plik: " + csvLoc + " nie istnieje");
				//	}
				//} else if (!Directory.Exists(csvLoc)) {
				//	using (StreamWriter sw = File.CreateText(logPath)) {
				//		sw.WriteLine("Podana sciezka jest niepoprawna");
				//	}
				//}

			}
		}
	}
}