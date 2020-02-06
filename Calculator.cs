using System;

namespace Calculator
{
    public class Calculator
    {
        private double firstNumber;
        private double secondNumber;
        private double result;
        private string lastOperation;
        private string currentOperation;

        public Calculator()
        {
            firstNumber = 0;
            secondNumber = 0;
            result = 0;
            lastOperation = "";
            currentOperation = "";
        }
        /*ללא שימוש
        public Calculator(double firstNumber, double secondNumber, double result, string lastOperation, string currentOperation)
        {
            this.firstNumber = firstNumber;
            this.secondNumber = secondNumber;
            this.result = result;
            this.lastOperation = lastOperation;
            this.currentOperation = currentOperation;
        }
        */

        public double FirstNumber { get => firstNumber; set => firstNumber = value; }
        public double SecondNumber { get => secondNumber; set => secondNumber = value; }
        public double Result { get => result; }
        public string LastOperation { get => lastOperation; set => lastOperation = value; }
        public string CurrentOperation { get => currentOperation; set => currentOperation = value; }

        public double Calculate()
        {
            if (lastOperation.Equals("%"))
            {
                if (currentOperation.Equals("+"))
                    result = firstNumber + (firstNumber * (secondNumber / 100));
                else if (currentOperation.Equals("-"))
                    result = firstNumber - (firstNumber * (secondNumber / 100));
                else if (currentOperation.Equals("X"))
                    result = firstNumber * (secondNumber / 100);
                else
                    result = firstNumber / (secondNumber / 100);
            }
            else if (currentOperation.Equals("%"))
            {
                if (lastOperation.Equals("+"))
                    result = secondNumber + (secondNumber * (firstNumber / 100));
                else if (lastOperation.Equals("-"))
                    result = secondNumber - (secondNumber * (firstNumber / 100));
                else if (lastOperation.Equals("X"))
                    result = secondNumber * (firstNumber / 100);
                else
                    result = secondNumber / (firstNumber / 100);
            }
            else
            {
                if (currentOperation.Equals("+"))
                    result = firstNumber + secondNumber;
                else if (currentOperation.Equals("-"))
                    result = firstNumber - secondNumber;
                else if (currentOperation.Equals("X"))
                    result = firstNumber * secondNumber;
                else
                    result = firstNumber / secondNumber;
            }

            return result;
        }

        public void ClearAll()
        {
            firstNumber = 0;
            secondNumber = 0;
            result = 0;
            currentOperation = "";
            lastOperation = "";
        }
    }
}
