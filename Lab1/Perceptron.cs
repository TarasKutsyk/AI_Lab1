using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Perceptron
    {
        private const int InputsNumber = PerceptronConfig.NumberOfInputs;
        private const int NeuronsNumber = PerceptronConfig.NumberOfNeurons;
        
        private double[] biases;
        private double[][] weights;
        
        private Neuron[] neurons;
        
        public Perceptron(double[,] weights, double[] biases)
        {
            try
            {
                if (weights.GetLength(0) != NeuronsNumber)
                {
                    throw new Exception("Invalid number of weight sets (must be equal to the number of neurons)");
                }
                
                if (weights.GetLength(1) != InputsNumber)
                {
                    throw new Exception("Invalid number of weights in a weight set (must be equal to the number of inputs)");
                }
                
                if (biases.Length != NeuronsNumber)
                {
                    throw new Exception("Invalid number of biases (must be equal to the number of neurons)");
                }
                
                this.biases = biases;
                
                this.weights = new double[NeuronsNumber][];
                for (int i = 0; i < NeuronsNumber; i++)
                {
                    this.weights[i] = new double[InputsNumber];
                    for (int j = 0; j < InputsNumber; j++)
                    {
                        this.weights[i][j] = weights[i, j];
                    }
                }
                
                InitializeNeurons();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Perceptron was not initialized properly: ${e.Message}");
                throw;
            }
        }

        private void InitializeNeurons()
        {
            this.neurons = new Neuron[NeuronsNumber];
            
            for (int i = 0; i < NeuronsNumber; i++)
            {
                this.neurons[i] = new Neuron(weights[i], biases[i]);
            }
        }

        public void CalculateActivations(double[] inputs)
        {
            for (int i = 0; i < NeuronsNumber; i++)
            {
                var activation = this.neurons[i].CalculateActivation(inputs);
                Console.WriteLine($"Neuron {i + 1}: {activation}");
            }
        }
    }
}
