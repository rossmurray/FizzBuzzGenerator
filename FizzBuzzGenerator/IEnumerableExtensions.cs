using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzGenerator
{
	public static class IEnumerableExtensions
	{
		/// <summary>
		/// Converts an IEnumerable from a finite sequence to an infinite sequence by starting at the beginning again after each enumeration.
		/// </summary>
		/// <remarks>This is the same idea as the cycle() function in other languages such as python.</remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="sequence"></param>
		/// <returns></returns>
		public static IEnumerable<T> Cycle<T>(this IEnumerable<T> sequence)
		{
			if (sequence == null) throw new ArgumentNullException("sequence");
			if (!sequence.Any()) yield break;
			var e = sequence.GetEnumerator();
			while (true)
			{
				if (e.MoveNext()) yield return e.Current;
				else e.Reset();
			}
		}

		/// <summary>
		/// Combines several collections using Zip and a combination function.
		/// </summary>
		/// <remarks>
		/// Like with Zip, the length of the collection produced by this function will be the length of the shortest sequence passed in.
		/// Merge is Fold (Aggregate) where the accumulation is Zip.
		/// </remarks>
		/// <param name="sequences">Some collections that will be merged together.</param>
		/// <param name="resultSelector">A function that takes two elements from the collections and produces a single result of the same type.</param>
		/// <returns>A single collection that is the result of zipping together each collection in the input.</returns>
		public static IEnumerable<T> Merge<T>(this IEnumerable<IEnumerable<T>> collections, Func<T, T, T> combinationFunction)
		{
			if (collections == null) throw new ArgumentNullException("collections");
			if (combinationFunction == null) throw new ArgumentNullException("combinationFunction");
			if (!collections.Any()) return Enumerable.Empty<T>();
			return collections.Aggregate((a, b) => a.Zip(b, combinationFunction));
		}
	}
}
