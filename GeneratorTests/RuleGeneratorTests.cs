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
	public class RuleGeneratorTests
	{
		[Test]
		public void RuleGeneratorMakesFizz()
		{
			var gen = new RuleGenerator();
			var output = gen.GenerateRuleSequence(3, "fizz");
			var answer = new[]{"", "", "fizz"};
			Assert.That(answer.SequenceEqual(output));
		}

		[Test]
		public void RuleGeneratorMakesBuzz()
		{
			var gen = new RuleGenerator();
			var output = gen.GenerateRuleSequence(5, "buzz");
			var answer = new[] { "", "", "", "", "buzz" };
			Assert.That(answer.SequenceEqual(output));
		}
	}
}
