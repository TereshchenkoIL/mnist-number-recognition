using System.Collections.Generic;
using System;

namespace mnist_number_recognition.Model
{
    public class Layer
    {
        public List<Neuron> Neurons{get; set;}
        public LayerType LayerType{get; set;}

        public Layer(int inputsCount,int neuronsCount, LayerType type ){
            Neurons = new List<Neuron>();
            for(var i = 0; i < neuronsCount; i++){
                Neurons.Add(new Neuron(inputsCount));
            }
        }

        public Layer(List<double> inputs){
            LayerType = LayerType.Input;
            Neurons = new List<Neuron>();

            for(var i = 0; i < inputs.Count; i++){
                Neurons.Add(new Neuron(1){Output = inputs[i]});
            }
        }

        public IEnumerable<double> GetOutputs(){
            foreach(Neuron neuron in Neurons){
                yield return neuron.Output;
            }
        }
    }
}