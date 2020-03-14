using System;
using System.Collections.Generic;

namespace Program
{
	public class Comparer : IEqualityComparer<Student>
	{

		public bool Equals(Student x, Student y) {
			return StringComparer
				.CurrentCultureIgnoreCase
				.Equals($"{x.fname}{x.lname}{x.indexNumber}", $"{y.fname}{y.lname}{y.indexNumber}");
		}

		public int GetHashCode(Student obj) {
			return StringComparer
				.CurrentCultureIgnoreCase
				.GetHashCode($"{obj.fname}{obj.lname}{obj.indexNumber}");
		}
	}
}