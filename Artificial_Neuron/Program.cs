using Artificial_Neuron;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //The initial values provided from the assignment table. 

        decimal[] inputs1 = { -0.3m, 0.6m };
        decimal[] inputs2 = { 0.3m, -0.6m };
        decimal[] inputs3 = { 1.2m, -1.2m };
        decimal[] inputs4 = { 1.2m, 1.2m };

        bool output1 = false;
        bool output2 = false;
        bool output3 = true;
        bool output4 = true;

        //Using the WeightFinder method, the weights that match the input and output of the provided data are found. 
        var results1 = WeightFinder(inputs1, output1, false);
        var results2 = WeightFinder(inputs2, output2, false);
        var results3 = WeightFinder(inputs3, output3, false);
        var results4 = WeightFinder(inputs4, output4, false);

        //Intersections are made to find the common weights for all provided input and output sets. 
        var intersect1 = results1.Select(i => i).Intersect(results2);
        var intersect2 = intersect1.Select(i => i).Intersect(results3);
        var intersect3 = intersect2.Select(i => i).Intersect(results4);

        Console.WriteLine("Weights with Threshold function: ");
        foreach((decimal, decimal, decimal) result in intersect3)
        {
            var neuron = new Neuron();
            //Console.WriteLine(neuron.FindOutput(inputs1, new decimal[] { result.Item2, result.Item3 }, result.Item1, false));
            //Console.WriteLine(neuron.FindOutput(inputs2, new decimal[] { result.Item2, result.Item3 }, result.Item1, false));
            //Console.WriteLine(neuron.FindOutput(inputs3, new decimal[] { result.Item2, result.Item3 }, result.Item1, false));
            //Console.WriteLine(neuron.FindOutput(inputs4, new decimal[] { result.Item2, result.Item3 }, result.Item1, false));
            Console.WriteLine(result);
        }


        //The process is repeated again, this time using Sigmoid function instead of a Threshold function. 

        var results10 = WeightFinder(inputs1, output1, true);
        var results20 = WeightFinder(inputs2, output2, true);
        var results30 = WeightFinder(inputs3, output3, true);
        var results40 = WeightFinder(inputs4, output4, true);

        var intersect10 = results1.Select(i => i).Intersect(results20);
        var intersect20 = intersect1.Select(i => i).Intersect(results30);
        var intersect30 = intersect2.Select(i => i).Intersect(results40);

        Console.WriteLine("\nWeights with Sigmoid function: ");
        foreach ((decimal, decimal, decimal) result in intersect30)
        {
            var neuron = new Neuron();
            //Console.WriteLine(neuron.FindOutput(inputs1, new decimal[] { result.Item2, result.Item3 }, result.Item1, true));
            //Console.WriteLine(neuron.FindOutput(inputs2, new decimal[] { result.Item2, result.Item3 }, result.Item1, true));
            //Console.WriteLine(neuron.FindOutput(inputs3, new decimal[] { result.Item2, result.Item3 }, result.Item1, true));
            //Console.WriteLine(neuron.FindOutput(inputs4, new decimal[] { result.Item2, result.Item3 }, result.Item1, true));
            Console.WriteLine(result);
        }
    }

    //Static method that is invoked to find all the possible weights when provided with the input and output values for the neuron
    //as well as with the type of function that will be used (false for threshold, true for sigmoid). 
    public static List<(decimal, decimal, decimal)> WeightFinder(decimal[] inputs, bool output, bool functionType)
    {
        //A list of decimal tuples is created to store the results, first value is the bias, second is weight1, third is weight2. 
        var results = new List<(decimal, decimal, decimal)>();
        Neuron neuron = new Neuron();
        //A brute force iteration goes through all the possible combinations of the weight values. 
        for (decimal bias = -1m; bias < 1; bias += 0.1m)
        {
            for (decimal weight1 = -1m; weight1 <= 1; weight1 += 0.1m)
            {
                for (decimal weight2 = -1m; weight2 <= 1; weight2 += 0.1m)
                {
                    //If the output using the iterated weights matches the output provided, the weights are saved to the result. 
                    decimal[] weights = { weight1, weight2 };
                    if (neuron.FindOutput(inputs, weights, bias, functionType) == output)
                    {
                        (decimal, decimal, decimal) result = (bias, weight1, weight2);
                        results.Add(result);
                        //Console.WriteLine("CORRECT PAIR FOUND: " + bias + " " + weight1 + " " + weight2);
                    }
                }
            }
        }
        return results;
    }
}