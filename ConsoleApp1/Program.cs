using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			test_CrossJoin();
			Console.ReadLine();
		}

		private static void test_CrossJoin()
		{
			var target = 16;
			var l = new int[] { 1, 3, 5, 8, 12, 13, 22 };

			var z1 = l.SelectMany(list => l, (p1, p2) => new { p1, p2 })	// cross join
				.Where(x => x.p1 <= target && x.p2 <= target) // eliminate values out of range
				.Where(x => x.p1 < x.p2) // eliminate duplicates
				.Where(x => (x.p1 + x.p2) == target); // find target results

			// consolidated
			//var z2 = l.SelectMany(p => l, (p1, p2) => new {p1, p2})
			//	.Where(x => x.p1 <= target && x.p2 <= target && x.p1 < x.p2 && (x.p1 + x.p2) == target);
			
			z1.ToList().ForEach(x => { Console.WriteLine("p1: " + x.p1.ToString() + ",  p2: " + x.p2.ToString() + ": " + (x.p1 + x.p2).ToString()); });


		}
	}
}
