﻿using System;
using NUnit.Framework;
using SharpRomans.Tests.Spec.Roman_Figure.Support;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[TestFixture, Category("Spec"), Category("RomanFigure")]
	public class ConversionsTester
	{
		[Test]
		public void ConvertToBoolean()
		{
			new Story("convert to Boolean")
				.InOrderTo("convert a roman figure to boolean")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, false)

			.WithScenario("one")
				.Given(TheRomanFigure_, RomanFigure.I)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, true)

			.WithScenario("more than one")
				.Given(TheRomanFigure_, RomanFigure.D)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, true)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, true)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToChar()
		{
			new Story("convert to Char")
				.InOrderTo("convert a roman figure to a char")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToChar(f)))
				.Then(Is_, 'N')

			.WithScenario("more than one")
				.Given(TheRomanFigure_, RomanFigure.D)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToChar(f)))
				.Then(Is_, 'D')

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToChar(f)))
				.Then(Is_, 'M')

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToSByte()
		{
			new Story("convert to SByte")
				.InOrderTo("convert a roman figure to a signed byte")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSByte(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanFigure_, RomanFigure.C)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSByte(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSByte(f)))
				.Then(Overflows)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToByte()
		{
			new Story("convert to Byte")
				.InOrderTo("convert a roman figure to a byte whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToByte(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanFigure_, RomanFigure.C)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToByte(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToByte(f)))
				.Then(Overflows)

			.ExecuteWithReport();
		}

		RomanFigure _subject;
		private void TheRomanFigure_(RomanFigure subject)
		{
			_subject = subject;
		}

		Func<object> _conversion;
		private void ConvertedTo_(Conv exp)
		{
			_conversion = () => exp.Execute(_subject);
		}

		private void Is_<T>(T value) where T : struct
		{
			Assert.That(_conversion(), Is.EqualTo(value));
		}

		private void Overflows()
		{
			TestDelegate conversion = () => _conversion();
			Assert.That(conversion, Throws.InstanceOf<OverflowException>());
		}
	}
}
