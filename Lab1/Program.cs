using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Program
    {
        private const int NumberOfTests = 5;
        
        static void Main(string[] args)
        {
            double[,] weightsMatrix = new double[PerceptronConfig.NumberOfNeurons, PerceptronConfig.NumberOfInputs]
            {
                {0.5, 0.7},
                {0.8, 0.3},
            };
            double[] biases = {-0.1, 0.2};

            Perceptron perceptron = new Perceptron(weightsMatrix, biases);

            Random rnd = new Random();
            StringBuilder inputsAccumulator = new StringBuilder(5);
            
            double[][] inputsMatrix = new double[NumberOfTests][];
            for (int i = 0; i < NumberOfTests; i++)
            {
                inputsMatrix[i] = new double[PerceptronConfig.NumberOfInputs];
                
                for (int j = 0; j < PerceptronConfig.NumberOfInputs; j++)
                {
                    var randomNumberInRange =
                        rnd.NextDouble() * (PerceptronConfig.UpperInputValueBound -
                                            PerceptronConfig.LowerInputValueBound) + PerceptronConfig.LowerInputValueBound;
                    inputsMatrix[i][j] = randomNumberInRange;

                    inputsAccumulator.Append($"{randomNumberInRange} ");
                }
                
                Console.WriteLine($"\nInput set {i + 1}: {inputsAccumulator}");
                perceptron.CalculateActivations(inputsMatrix[i]);

                inputsAccumulator.Clear();
            }
        }
    }
}
