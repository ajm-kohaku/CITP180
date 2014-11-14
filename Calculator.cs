/*
 *       Author: Amber Murphy
 *   	 Author: Teresa Potts
 * Assignment #: 11
 * Date Written: 11/13/2014
 *  Course Code: CITP 180
 *     Abstract: Form performs basic mathematic calculations Add, Subtract, Divide, Multiply, Square Root, and Reciprocal .*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MurphyAA11
{
    public class Calculator
    {
        //initialize calculator variables
        private decimal currentValue;
        private decimal operand1;
        private decimal operand2;

        private Operator op;
        enum Operator { Add, Subtract, Multiply, Divide, SquareRoot, Reciprocal, None };

        //class constructor sets default values
        public Calculator()
        {
            defaultValues();
        }

        //method to get the currentValue
        public decimal CurrentValue
        {
            get { return this.currentValue; }
        }

        //method that determines the number of spaces in the remainder of a decimal
        private int roundValue(decimal round)
        {
            int roundIndex = Convert.ToString(round).IndexOf(".");
            if (roundIndex >= 0 && roundIndex <= 28)
                return Convert.ToString(round).Length - roundIndex;
            else if (roundIndex > 28)
                return 28;
            else
                return 0;
        }
        //method that defines default values for constructor and Clear method
        private void defaultValues()
        {
            this.currentValue = 0m;
            this.operand1 = 0m;
            this.operand2 = 0m;
            this.op = Operator.None;
        }

        //calls defaultValues
        public void Clear()
        {
            defaultValues();
        }

        //method that sets the operand
        private void setOperand(decimal displayValue)
        {
            this.operand1 = displayValue;
            this.currentValue = displayValue;
        }

        //determine Add operations
        public void Add(decimal displayValue)
        {
            setOperand(displayValue);
            op = Operator.Add;
        }

        //determine Subtract operations
        public void Subtract(decimal displayValue)
        {
            setOperand(displayValue);
            op = Operator.Subtract;
        }

        //determine Multiply operations
        public void Multiply(decimal displayValue)
        {
            setOperand(displayValue);
            op = Operator.Multiply;
        }

        //determine Divide operations
        public void Divide(decimal displayValue)
        {
            setOperand(displayValue);
            op = Operator.Divide;
        }

        //determine SquareRoot operations
        public void SquareRoot(decimal displayValue)
        {
            setOperand(displayValue);
            op = Operator.SquareRoot;
        }

        //determine Reciprocal operations
        public void Reciprocal(decimal displayValue)
        {
            setOperand(displayValue);
            op = Operator.Reciprocal;
        }

        //method that does all the math
        private void Calculate(decimal displayValue)
        {
            operand2 = displayValue;
            switch (op)
            {
                case Operator.Add:
                    //adds the 2 operands and rounds: no more decimal places than in the original numbers
                    currentValue = Math.Round((operand1 + operand2),Math.Max(roundValue(operand1),roundValue(operand2)));
                    break;
                case Operator.Subtract:
                    //subtracts the 2 operands and rounds: no more decimal places than in the original numbers
                    currentValue = Math.Round((operand1 - operand2),Math.Max(roundValue(operand1),roundValue(operand2)));
                    break;
                case Operator.Multiply:
                    //multiplies the 2 operands and rounds: no more decimal places than the number of decimal places in the first number + 
                    //the number of decimal places in the second number
                    currentValue = Math.Round((operand1 * operand2),(roundValue(operand1)+roundValue(operand2)));
                    break;
                case Operator.Divide:
                    //divides the 2 operands and rounds: to 8 decimal places
                    currentValue = Math.Round((operand1 / operand2),8);
                    break;
                case Operator.SquareRoot:
                    //takes square root of the display and rounds: to 8 decimal places
                    currentValue = (decimal)Math.Round(Math.Sqrt(Convert.ToDouble(displayValue)),8);
                    break;
                case Operator.Reciprocal:
                    //takes reciprocal of the display and rounds: to 8 decimal places
                    currentValue = Math.Round((1 / displayValue),8);
                    break;
                default:
                    //display error message
                    break;
            }
            operand1 = currentValue;
        }

        //method that calls the calculation 
        public void Equals(decimal displayValue)
        {
            Calculate(displayValue);
        }

        //Do Math based on operator
        public void Equals()
        {
            decimal displayValue = operand2;
            Calculate(displayValue);
        }
    }

}