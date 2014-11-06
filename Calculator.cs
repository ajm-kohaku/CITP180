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
		private bool isOperand1;
		private bool isOperand2;
		
		private Operator op;
		enum Operator {Add, Subtract, Multiply, Divide, SquareRoot, Reciprocal, None};
		
		//class constructor sets default values
		public Calculator()
		{	
			//TODO: not sure if this is the correct syntax
			this.defaultValues();
		}
		
		public void defaultValues()
		{
			this.currentValue = 0m;
			this.operand1 = 0m;
			this.operand2 = 0m;
			this.isOperand1 = false;
			this.isOperand2 = false;
			this.op = Operator.None;
		}
		
		//method to get the currentValue
		public decimal CurrentValue
		{
			get { return this.currentValue}
		}
		
		//calls defaultValues
		public void Clear()
		{
			this.defaultValues();
		}
		
		private void getOperand(decimal displayValue)
		{
            if(isOperand1) 
            {
				operand2 = displayValue;
				isOperand2 = true;
            }
            else 
			{
				operand1 = displayValue;
				isOperand1 = true;
				currentValue = operand1;
            }
		}
		
		//determine Add operations
		private void Add(decimal displayValue)
		{
			this.getOperand(displayValue);
			this.op = Operator.Add;
		}
		
		//determine Subtract operations
		private void Subtract(decimal displayValue)
		{
			this.getOperand(displayValue);
			this.op = Operator.Subtract;
		}
		
		//determine Multiply operations
		private void Multiply(decimal displayValue)
		{
			this.getOperand(displayValue);
			this.op = Operator.Multiply;
		}
		
		//determine Divide operations
		private void Divide(decimal displayValue)
		{
			this.getOperand(displayValue);
			this.op = Operator.Divide;
		}
		
		//Do Math based on operator
		public void Equals(decimal displayValue)
		{
			switch(this.op)
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
					currentValue = (decimal) Math.Sqrt(Convert.ToDouble(displayValue));
					break;
				case Operator.Reciprocal:
					currentValue = 1 / displayValue;
					break;
				default
					//display error message
					break;
			}
			operand1 = currentValue;
		}
	}

}