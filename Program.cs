using System;
using System.Linq;
using  mnist_number_recognition.Model;

namespace mnist_number_recognition
{
    class Program
    {
        static void Main(string[] args)
        {
           var outputs = new double[,] { {0}, {0}, {1}, {0}, {0}, {0}, {1}, {0}, {1}, {1}, {1}, {1}, {1}, {0}, {1}, {1} };
           var inputs = new double[,]
            {
                // Результат - Пациент болен - 1
                //             Пациент Здоров - 0

                // Неправильная температура T
                // Хороший возраст A
                // Курит S
                // Правильно питается F
                //T  A  S  F
                { 0, 0, 0, 0 },
                { 0, 0, 0, 1 },
                { 0, 0, 1, 0 },
                { 0, 0, 1, 1 },
                { 0, 1, 0, 0 },
                { 0, 1, 0, 1 },
                { 0, 1, 1, 0 },
                { 0, 1, 1, 1 },
                { 1, 0, 0, 0 },
                { 1, 0, 0, 1 },
                { 1, 0, 1, 0 },
                { 1, 0, 1, 1 },
                { 1, 1, 0, 0 },
                { 1, 1, 0, 1 },
                { 1, 1, 1, 0 },
                { 1, 1, 1, 1 }
            };

            NeuralNetwork neuralNetwork = new NeuralNetwork();

            Layer inputLayer = new Layer(1, 4, NeuronType.Input);
            Layer hiddenLayer = new Layer(4, 2, NeuronType.Hidden);
            Layer outputLayer = new Layer(2, 1, NeuronType.Output);

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

            for(var i = 0; i < inputs.GetLength(0); i++)
            {
                Console.WriteLine($"Expected = {outputs[i,0]}");
                Console.WriteLine($"Actual = {neuralNetwork.Predict(neuralNetwork.GetRow(i,inputs))[0]}");
                Console.WriteLine(new String('-',20));
            }

            
        }
    }
}
