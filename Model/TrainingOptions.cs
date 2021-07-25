using System.Collections.Generic;

namespace mnist_number_recognition.Model
{
    public class TrainingOptions
    {
        public double[,] Inputs{get; set;}

        public double[,] Results {get; set;}
        public int BatchSize{get; set;}
        public int Iterations {get; set;}
        public double Alpha {get; set;}
    }
}