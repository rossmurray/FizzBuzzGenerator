using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzGenerator
{
	/// <summary>
	/// Generates infinitely-long, deferred sequences of FizzBuzz solutions, based on supplied rules.
	/// </summary>
    public class Generator
    {
		private RuleGenerator ruleGen;

		public Generator()
		{
			this.ruleGen = new RuleGenerator();
		}

		/// <summary>
		/// Given some pairs of multiples and words, this generates a FizzBuzz-like solution of infinite length.
		/// </summary>
		/// <example>
		/// Generate(Tuple.Create(3, "fizz"), Tuple.Create(5, "buzz")).Take(100) -> [solution to traditional FizzBuzz]
		/// </example>
		/// <remarks>Does not use division or modulo, but does use string concatenation.</remarks>
		/// <param name="rules">Some number of pairs. Each pair contains a word to substitute, and the multiple that it should replace.</param>
		/// <returns>A FizzBuzz-like solution based on the supplied rules.</returns>
		public IEnumerable<string> Generate(params Tuple<int, string>[] rules)
		{
			var ruleSequences = rules.Select(x => this.ruleGen.GenerateRuleSequence(x.Item1, x.Item2).Cycle());
			//create one empty rule, in case the input provides no additional rules.
			ruleSequences = ruleSequences.Concat(new[] { new[] { "" }.Cycle() });
			var words = ruleSequences.Merge((a, b) => a + b);
			var naturals = AllPositiveIntegers().Select(x => x.ToString());
			var result = words.Zip(naturals, (word, number) => word == "" ? number : word);
			return result;
		}

		/// <summary>
		/// Returns a list of every positive integer.
		/// </summary>
		/// <returns></returns>
		private IEnumerable<BigInteger> AllPositiveIntegers()
		{
			var i = BigInteger.Zero;
			while (true)
			{
				i++;
				yield return i;
			}
		}
    }
}
