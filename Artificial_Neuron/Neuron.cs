using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artificial_Neuron
{
    internal class Neuron
    {
        //Private method Threshold is used to find the result of the threshold function. Boolean values are used instead of 0 and 1. 
        private bool Threshold(decimal a)
        {
            if(a >= 0)
            {
                //Console.WriteLine("Threshold value: " + a + ", ergo TRUE\n");
                return true;
            }
            //Console.WriteLine("Threshold value: " + a + ", ergo FALSE\n");
            return false;
        }

        //Private method Sigmoid calculates the real value of the sigmoid function. 
        private decimal Sigmoid(decimal a)
        {
            double result = (1 / (1 + Math.Pow(Math.E, (double)(a * (-1)))));
            return (decimal)result;
        }
        //Private method SigmoidBoolean converts the real value of the sigmoid function into a 0 or a 1, represented by a bool value. 
        private bool SigmoidBoolean(decimal a)
        {
            if(Sigmoid(a) > 0.5m)
            {
                //Console.WriteLine("Sigmoid function result: " + Sigmoid(a) + ", ergo TRUE\n");
                return true;
            }
            //Console.WriteLine("Sigmoid function result: " + Sigmoid(a) + ", ergo FALSE\n");
            return false;
        }
        //Private method FindSum calculates the sum of the weight and input multiplication, which will be used by the neuron function. 
        private decimal FindSum(decimal[] inputs, decimal[] weights, decimal bias)
        {
            if(inputs.Length != weights.Length) 
            {
                throw new ArgumentException("Error, different amounts of inputs and weights found");
            }
            //Console.Write("\nStarting values: ");
            for(int i = 0; i < inputs.Length; i++)
            {
                //Console.Write("x" + (i + 1) + ": " + inputs[i] + " ");
            }
            for (int i = 0; i < weights.Length; i++)
            {
                //Console.Write("w" + (i + 1) + ": " + weights[i] + " ");
            }
            //Console.Write("Bias: " + bias + "\n");
            decimal a = 0;
            for(int i = 0; i < inputs.Length; i++) 
            {
                //Console.WriteLine("Sum X and W: " + a + " + " + inputs[i] + " * " + weights[i] + " = " + (a + inputs[i] * weights[i]));
                a += inputs[i] * weights[i];
            }
            //Console.WriteLine("Sum Bias: " + a + " + " + bias + " = " + (a + bias));
            return a + bias;
        }
        //Public method FindOutput invokes the previous methods to find the output of the neuron based on the inputs and weights provided, 
        //along with a boolean value that determines which of the two (threshold or sigmoid) functions will be used. 
        public bool FindOutput(decimal[] inputs, decimal[] weights, decimal bias, bool functionType)
        {
            if(functionType)
            {
                return SigmoidBoolean(FindSum(inputs, weights, bias));
            }
            return Threshold(FindSum(inputs, weights, bias));
        }
    }
}
