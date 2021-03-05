using System;

namespace Lab1
{
    public class Neuron
    {
        private double[] weights;
        private double bias;
        private const int numberOfWeights = PerceptronConfig.NumberOfInputs;

        public Neuron(double[] weights, double bias)
        {
            try
            {
                if (weights.Length != numberOfWeights)
                {
                    throw new Exception("The number of weights passed to a neuron does not equal to the number of inputs");
                }
                
                this.weights = weights;
                this.bias = bias;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public double CalculateActivation(double[] inputs)
        {
            try
            {
                if (inputs.Length != numberOfWeights)
                {
                    throw new Exception("The number of inputs must be equal to the number of weights");
                }

                double weightedSum = bias;
                for (int i = 0; i < numberOfWeights; i++)
                {
                    weightedSum += inputs[i] * weights[i];
                }

                return activationFunction(weightedSum);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static int activationFunction(double x)
        {
            return (x > 0) ? 1 : 0;
        }
    }
}