﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzGenerator
{
	/// <summary>
	/// Generates rule sequences for use in the Fizz Buzz Generator.
	/// </summary>
	public class RuleGenerator
	{
		/// <summary>
		/// Generates a collection that contains n elements, where each element is empty string except the last, which is word.
		/// </summary>
		/// <example>GenerateRuleSequence(4, "zombo") -> ["", "", "", "zombo"]</example>
		/// <param name="multiples">The number of elements in the output collection.</param>
		/// <param name="word">The string to use for the last element of the collection.</param>
		public IEnumerable<string> GenerateRuleSequence(int n, string word)
		{
			//C# doesn't allow you to call Reset() on an IEnumerator generated by the compiler via a yield itertor.
			//So sadly we have to render this collection, so that its Iterator can be properly used by Cycle().
			//The alternative is implementing IEnumerator, which is more complex than necessary.
			return GenerateDeferredRuleSequence(n, word).ToArray();
		}

		private IEnumerable<string> GenerateDeferredRuleSequence(int multiples, string word)
		{
			for (int i = 0; i < multiples - 1; i++)
			{
				yield return "";
			}
			yield return word;
		}
	}
}
