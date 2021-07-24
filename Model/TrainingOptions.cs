using System.Collections.Generic;

namespace mnist_number_recognition.Model
{
    public class TrainingOptions
    {
        public List<double>[] Inputs{get; set;}
        public List<double> Results {get; private set;}
        public int BatchSize{get; set;}
        public int Iterations {get; set;}
    }
}