using System;
using System.Collections.Generic;

namespace Program
{
	public class Comparer : IEqualityComparer<Student>
	{

		public bool Equals(Student x, Student y) {
			return StringComparer
				.InvariantCultureIgnoreCase.Equals($"{x.FirstName} {x.LastName} {x.Index}", $"{y.FirstName} {y.LastName} {y.Index}");
		}

		public int GetHashCode(Student obj) {
			return StringComparer
				.InvariantCultureIgnoreCase
				.GetHashCode($"{obj.FirstName} {obj.LastName} {obj.Index}");
		}
	}
}