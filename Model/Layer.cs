using System.Collections.Generic;

namespace mnist_number_recognition.Model
{
    public class Layer
    {
        public List<Neuron> Neurons{get; set;}
        public NeuronType NeuronsType{get; set;}

        public Layer(int inputsCount,int neuronsCount, NeuronType type ){
            Neurons = new List<Neuron>();
            NeuronsType = type;
            for(var i = 0; i < neuronsCount; i++){
                Neurons.Add(new Neuron(inputsCount, type));
            }
        }


        public void Forward(double[] inputs){

            if(NeuronsType == NeuronType.Input){
                for(int i = 0; i < Neurons.Count; i++){
                    Neurons[i].Process(new double[]{inputs[i]});
                }
                return;
            }
            foreach(Neuron neuron in Neurons){
                neuron.Process(inputs);
            }
            
        }
        public IEnumerable<double> GetOutputs(){
            foreach(Neuron neuron in Neurons){
                yield return neuron.Output;
            }
        }
    }
}