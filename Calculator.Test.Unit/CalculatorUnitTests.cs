using System;
using System.ComponentModel;
using NUnit.Framework;

namespace Calculator.Test.Unit
{
    [TestFixture]
    public class CalculatorTests
    {
        //Private 'Calculator' field
        private Calculator uut;

        [SetUp]
        public void Setup()
        {
            //New 'Calculator' object
            uut = new Calculator();
        }

        /***********Original methods with two parameters and expected results***********/
        [TestCase(2, 2, ExpectedResult = 4)]
        [TestCase(5, 5, ExpectedResult = 10)]
        [TestCase(10, 10, ExpectedResult = 20)]
        public double Add_AddTwoNumbers_ResultIsCorrect(int a, int b)
        {
            return uut.Add(a, b);
        }

        [TestCase(10, 1, ExpectedResult = 9)]
        [TestCase(10, 3, ExpectedResult = 7)]
        [TestCase(10, 5, ExpectedResult = 5)]
        public double Subtract_SubtractTwoNumbers_ResultIsCorrect(double a, double b)
        {
            return uut.Subtract(a, b);
        }

        [TestCase(10, 1, ExpectedResult = 10)]
        [TestCase(10, 3, ExpectedResult = 30)]
        [TestCase(10, 5, ExpectedResult = 50)]
        public double Multiply_MultiplyTwoNumbers_ResultIsCorrect(double a, double b)
        {
            return uut.Multiply(a, b);
        }

        [TestCase(2, 2, ExpectedResult = 4)]
        [TestCase(3, 2, ExpectedResult = 9)]
        [TestCase(4, 2, ExpectedResult = 16)]
        public double Power_RaiseNumbers_ResultIsCorrect(double a, double b)
        {
            return uut.Power(a, b);
        }

        [TestCase(2, 2, ExpectedResult = 1)]
        [TestCase(4, 2, ExpectedResult = 2)]
        [TestCase(2, 4, ExpectedResult = 0.5)]
        public double Divide_DivideTwoNumbers_ResultIsCorrect(double a, double b)
        {
            return uut.Divide(a, b);
        }

        [TestCase(1, 0)]
        public void Divided_DivideByZero_ExpectException(double divided, double divisor)
        {
            Assert.Throws<DivideByZeroException>(() => uut.Divide(divided, divisor));
        }

        /***********Tests with accumulator***********/
        [TestCase(2, 4, 6)]
        [TestCase(3, 6, 9)]
        [TestCase(4, 8, 12)]
        public void Add_AddToAccumulator_ResultIsCorrect(double firstAdd, double b, double result)
        {
            uut.Add(firstAdd);

            Assert.That(uut.Add(b).Equals(result));
        }

        [TestCase(4, -6, 2)]
        [TestCase(-4, 6, -2)]
        [TestCase(4, 4, -8)]
        public void Subtract_SubtractFromAccumulator_ResultIsCorrect(double firstSub, double b, double result)
        {
            uut.Subtract(firstSub);

            Assert.That(uut.Subtract(b).Equals(result));
        }

        [TestCase(2, 2, 4)]
        [TestCase(2, 6, 12)]
        [TestCase(3, 6, 18)]
        public void Multiply_MultiplyWithAccumulator_ResultIsCorrect(double firstMultiply, double b, double result)
        {
            //Makes multiplication possible (0 * x == 0)
            uut.Add(1);

            uut.Multiply(firstMultiply);
            Assert.That(uut.Multiply(b).Equals(result));
        }

        [TestCase(10, 0, 1)]
        [TestCase(2, 2, 4)]
        [TestCase(4, 2, 16)]
        public void Power_RaiseAccumulatorWithPower_ResultIsCorrect(double firstAdd, double exp, double result)
        {
            //Makes power possible (0 ^ x == 0)
            uut.Add(firstAdd);

            Assert.That(uut.Power(exp).Equals(result));
        }

        [TestCase(0)]
        public void DividedByZeroTest_OneParameter_ResultIsCorrect(double divisor)
        {
            Assert.Throws<DivideByZeroException>(() => uut.Divide(divisor));
        }

        [TestCase(69, 0)]
        [TestCase(4, 0)]
        [TestCase(8, 0)]
        public void ClearTest_ResultIsCorrect(double firstAdd, double result)
        {
            //First add to accumulator, then clear
            uut.Add(firstAdd);
            uut.Clear();

            Assert.That(uut.Accumulator.Equals(result));
        }
    }
}