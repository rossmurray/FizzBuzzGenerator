using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzGenerator;
using NUnit.Framework;

namespace GeneratorTests
{
	[TestFixture]
    public class GeneratorTests
    {
		[Test]
		public void CanCreateGenerator()
		{
			var gen = new Generator();
			Assert.NotNull(gen);
		}

		[Test]
		public void GeneratorGeneratesFizzBuzz()
		{
			var answer = "1, 2, fizz, 4, buzz, fizz, 7, 8, fizz, buzz, 11, fizz, 13, 14, fizzbuzz, 16, 17, fizz, 19, buzz, fizz, 22, 23, fizz, buzz, 26, fizz, 28, 29, fizzbuzz, 31, 32, fizz, 34, buzz, fizz, 37, 38, fizz, buzz, 41, fizz, 43, 44, fizzbuzz, 46, 47, fizz, 49, buzz, fizz, 52, 53, fizz, buzz, 56, fizz, 58, 59, fizzbuzz, 61, 62, fizz, 64, buzz, fizz, 67, 68, fizz, buzz, 71, fizz, 73, 74, fizzbuzz, 76, 77, fizz, 79, buzz, fizz, 82, 83, fizz, buzz, 86, fizz, 88, 89, fizzbuzz, 91, 92, fizz, 94, buzz, fizz, 97, 98, fizz, buzz";
			var gen = new Generator();
			var sequence = gen.Generate(
				Tuple.Create(3, "fizz"),
				Tuple.Create(5, "buzz")
			).Take(100);
			var output = string.Join(", ", sequence);
			Assert.That(answer == output);
		}

		[Test]
		public void GeneratorDoesEvens()
		{
			var answer = "1,even,3,even,5,even,7,even,9,even";
			var gen = new Generator();
			var sequence = gen.Generate(
				Tuple.Create(2, "even")
			).Take(10);
			var output = string.Join(",", sequence);
			Assert.That(answer == output);
		}

		[Test]
		public void GeneratorReturnsNumbersWhenGivenNoRules()
		{
			var answer = Enumerable.Range(1, 10).Select(x => x.ToString());
			var gen = new Generator();
			var sequence = gen.Generate().Take(10);
			Assert.That(sequence.SequenceEqual(answer));
		}
    }
}
