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
		enum Operator {Add, Subtract, Multiply, Divide, SquareRoot, Reciprocal, None};
		
		//class constructor sets default values
		public Calculator() {
            defaultValues();
        }
		
		//method to get the currentValue
		public decimal CurrentValue
		{
            get { return Math.Round(this.currentValue,8); }
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
                    currentValue = operand1 + operand2;
                    break;
                case Operator.Subtract:
                    currentValue = operand1 - operand2;
                    break;
                case Operator.Multiply:
                    currentValue = operand1 * operand2;
                    break;
                case Operator.Divide:
                    currentValue = operand1 / operand2;
                    break;
                case Operator.SquareRoot:
                    currentValue = (decimal)Math.Sqrt(Convert.ToDouble(displayValue));
                    break;
                case Operator.Reciprocal:
                    currentValue = 1 / displayValue;
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