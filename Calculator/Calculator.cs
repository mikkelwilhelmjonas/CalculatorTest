using System;

namespace Calculator
{
    public class Calculator
    {
        //Accumulator property and clear method
        public double Accumulator { get; private set; }

        public void Clear()
        {
            Accumulator = 0;
        }

        //Arithmetic operations
        public double Add(double a, double b)
        {

            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Power(double a, double exp)
        {
            return Math.Pow(a, exp);
        }

        public double Divide(double divided, double divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }

            return divided / divisor;

        }

        //Overloaded arithmetic operations
        public double Add(double a)
        {
            Accumulator += a;
            return Accumulator;
        }

        public double Subtract(double a)
        {
            Accumulator -= a;
            return Accumulator;
        }

        public double Multiply(double a)
        {
            Accumulator *= a;
            return Accumulator;
        }

        public double Power(double exp)
        {
            Accumulator = Math.Pow(Accumulator, exp);
            return Accumulator;
        }

        public double Divide(double divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }
            Accumulator /= divisor;
            return Accumulator;
        }

        ~Calculator()
        {

        }

    }
}