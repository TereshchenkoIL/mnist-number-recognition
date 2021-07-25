using System.Collections.Generic;
using System;

namespace mnist_number_recognition.Model
{
    public class Neuron
    {
        public List<double> Weights {get; set;}

        public double Output {get; private set;}
        public NeuronType NeuronType {get; set;}
        public double Delta {get; set;}

        public int WieghtNumber{get; private set;}
        public double[] Input {get; set;}
        public Neuron(int wieghtNumber, NeuronType type = NeuronType.Hidden ){
            Weights = new List<double>();
            WieghtNumber = wieghtNumber;
            NeuronType = type;
            Input = new double[wieghtNumber];

        }

        private void InitWeights(){
            Random rand = new Random();

            for(int i = 0; i < WieghtNumber; i++){
                if(NeuronType == NeuronType.Input){
                    Weights.Add(1);
                }else
                    Weights.Add(rand.NextDouble());
            }

        }

    
        public double Process(double[] inputs){
            if(Weights.Count != inputs.Length)
                throw new ArgumentException();
            
            SetInputs(inputs);

            double sum = 0;
            for(var i = 0; i < inputs.Length; i++){
                sum += Weights[i] * inputs[i];
            }

            if(NeuronType == NeuronType.Input)
                Output = sum;
            else
                Output = Sigmoid(sum);

            return Output;
        }
        private void SetInputs(double[] inputs){
            for(var i = 0; i < inputs.Length; i++){
                Input[i] = inputs[i];
            }
        }
        private double SigmoidDerived(double x){
            return Sigmoid(x) / (1 - Sigmoid(x));
        }
         private double Sigmoid(double x){
            return 1.0 / (1.0 + Math.Pow(Math.E, -x));
        }

        public void Adjustment(double error, double alpha){
            if(NeuronType == NeuronType.Input)
                return;

            Delta = error * SigmoidDerived(Output); 

            for(var i = 0; i < WieghtNumber;i++){
                Weights[i] += Input[i] * Delta * alpha;
            }
           
        }
    }
    
}