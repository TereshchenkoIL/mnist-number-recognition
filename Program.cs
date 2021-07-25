using System;
using System.Linq;
using  mnist_number_recognition.Model;
using  mnist_number_recognition.Data;

namespace mnist_number_recognition
{
    class Program
    {
        static void Main(string[] args)
        {
            NeuralNetwork neuralNetwork = new NeuralNetwork();
            var inputs = DataLoader.LoadTrainImages();
            var outputs = DataLoader.LoadTrainLabels();

            Layer inputLayer = new Layer(1, inputs.GetLength(1), NeuronType.Input);
            Layer hiddenLayer = new Layer(inputs.GetLength(1), 40, NeuronType.Hidden);
            Layer outputLayer = new Layer(40, 10, NeuronType.Output);

            neuralNetwork.Append(inputLayer);
            neuralNetwork.Append(hiddenLayer);
            neuralNetwork.Append(outputLayer);
            TrainingOptions options = new TrainingOptions(){
                Inputs = inputs,
                Alpha = 0.1,
                Results = outputs,
                Iterations = 100

            };

            neuralNetwork.Train(options);
            
        }
    }
}
