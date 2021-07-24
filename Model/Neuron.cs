using System.Collections.Generic;
using System;

namespace mnist_number_recognition.Model
{
    public class Neuron
    {
        public List<double> Weights {get; set;}

        public double Output {get; set;}
        public NeuronType NeuronType {get; set;}
        public Neuron(int wieghtNumber, NeuronType type = NeuronType.Hidden ){
            Weights = new List<double>();

            Random rand = new Random();

            for(int i = 0; i < wieghtNumber; i++){
                Weights.Add(rand.NextDouble());
            }
            NeuronType = type;

        }

    
        public double Process(List<double> inputs){
            double sum = 0;
            for(var i = 0; i < inputs.Count; i++){
                sum += Weights[i] * inputs[i];
            }
            Output = Sigmoid(sum);
            return Output;
        }
         private double Sigmoid(double x){
            return 1.0 / (1.0 + Math.Pow(Math.E, -x));
        }

        public void Adjustment(List<double> delta, double alpha){
            for(var i = 0; i < delta.Count; i++){
                Weights[i] += alpha * Output * delta[i];
            }
        }
    }
    
}