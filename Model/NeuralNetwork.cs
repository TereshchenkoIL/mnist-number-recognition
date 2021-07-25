using System;
using System.Collections.Generic;
using System.Linq;

namespace mnist_number_recognition.Model
{
    public class NeuralNetwork
    {
        public List<Layer> Layers {get; set;} 

        public NeuralNetwork(){
            Layers = new List<Layer>();
        }
        public void Append(Layer layer){
            if(layer == null)
                throw new ArgumentException("Layer is null");

            Layers.Add(layer);
        }

        public void Train(TrainingOptions options){

            for(int i = 0; i < options.Iterations; i++){
                var error = AdjustWieghts(options);

                Console.WriteLine($"Iteration = {i} - stdError = {error}");
            }
            
        }

        private double AdjustWieghts(TrainingOptions options){
            double stdError = 0.0;

            for(int i = 0; i < options.Inputs.GetLength(0); i++){
                
                double[] row = GetRow(i, options.Inputs);
                var res = Predict(row);

                var error = GetRow(i,options.Results).Select((x, index) => x - res[index]).ToArray();
                stdError += error.Select( x => x*x).Sum();
                Layer prev = Layers.Last();

                for(int j = 0; j < prev.Neurons.Count; j++){
                    prev.Neurons[j].Adjustment(error[j], options.Alpha);
                }

                for(int j = Layers.Count - 2; j >= 0; j--){
                    prev = Layers[j+1];
                    Layer current = Layers[j];
                    for(int k = 0; k < current.Neurons.Count; k++){

                        Neuron neuron = current.Neurons[k];

                        for(int l = 0; l < prev.Neurons.Count; l++){

                            Neuron previousNeuron = prev.Neurons[l];
                            var errorForAdjustment = previousNeuron.Delta * previousNeuron.Weights[k];
                            neuron.Adjustment(errorForAdjustment, options.Alpha);
                        }
                    }

                }

            }

            return stdError;
        }

        public double[] GetRow(int row, double[,] inputs){
            int colNumber = inputs.GetLength(1);
            double[] res = new double[colNumber];

            for(var i = 0; i < colNumber; i++){
                res[i] = inputs[row,i];
            }
            return res;
        }

        public List<double> Predict(double[] inputs){
            Layer previous = Layers[0];
            previous.Forward(inputs);

            for(int i = 1; i < Layers.Count; i++){
                Layers[i].Forward(previous.GetOutputs().ToArray());
                previous = Layers[i];
            }

            return Layers.Last().GetOutputs().ToList();

    
        }
        
    }
}