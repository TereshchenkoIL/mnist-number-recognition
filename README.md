# Handwritten Digit Recognition using Deep Learning



### MNIST dataset:

MNIST is a collection of handwritten digits from 0-9. Image of size 28 X 28

## Realization

A simple neural network implemented in c# using Stochastic Gradient Descent and Backpropogation. I use perceptron model to represent the network.

---

### Ads

Actually, it is Deep Learning framework and you can build your own architecture using different Layers

##### Example

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
                Alpha = 0.005,
                Results = outputs,
                Iterations = 100

            };

            neuralNetwork.Train(options);
