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
                double error = 0;
                int correct = 0;

                for(int j = 0; j < options.Inputs.Length; j++){
                    List<double> res = Predict(options.Inputs[j]);

                    List<double> layer_2_delta = options.Results.Select((x, i ) => x);
                }

            }

        }

        public List<double> Predict(List<double> inputs){
            Layer previous = Layers[0];
            previous.Forward(inputs);

            for(int i = 1; i < Layers.Count; i++){
                Layers[i].Forward(previous.GetOutputs().ToList());
                previous = Layers[i];
            }

            return Layers[-1].GetOutputs().ToList();

    
        }
        
    }
}