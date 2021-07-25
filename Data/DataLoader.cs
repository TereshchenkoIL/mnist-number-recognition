using System;
using System.IO;
namespace mnist_number_recognition.Data
{
    public class DataLoader
    {
        private static readonly string s_trainDataFile =  "./Data/train-images.idx3-ubyte";
        private static readonly string s_trainLabelFile =  "./Data/train-labels.idx1-ubyte";

        private static double[,] LoadImages(string path){

            FileStream ifsPixels = new FileStream(path, FileMode.Open);
            BinaryReader brImages = new BinaryReader(ifsPixels);

            int magic1 = brImages.ReadInt32(); // stored as big endian
            magic1 = ReverseBytes(magic1); // convert to Intel format
            int imageCount = brImages.ReadInt32();
            imageCount = ReverseBytes(imageCount);
            int numRows = brImages.ReadInt32();
            numRows = ReverseBytes(numRows);
            int numCols = brImages.ReadInt32();
            numCols = ReverseBytes(numCols);

            double[,] res = new double[1000, numRows * numCols];

            for(int i = 0; i < 1000; i++){
                for(int j = 0; j < numRows * numCols; j++){
                    byte b = brImages.ReadByte();
                    res[i,j] = b/255;
                }
            }

            return res;
        }

       private static double[,] LoadLabels(string path){
            FileStream ifsLabels = new FileStream(path, FileMode.Open);
            BinaryReader brLabels = new BinaryReader(ifsLabels);
            int magic2 = brLabels.ReadInt32();
            magic2 = ReverseBytes(magic2);
            int numLabels = brLabels.ReadInt32();
            numLabels = ReverseBytes(numLabels);
            double[,] res = new double[1000,10];

            for(int i = 0; i < 1000; i++){
                byte lbl = brLabels.ReadByte();
                res[i,lbl] = 1.0;
            }

            return res;
       }
        public static double[,] LoadTrainImages(){
            return LoadImages(s_trainDataFile);
        }
        public static double[,] LoadTrainLabels(){
            return LoadLabels(s_trainLabelFile);
        }
        public static int ReverseBytes(int v)
        {
            byte[] intAsBytes = BitConverter.GetBytes(v);
            Array.Reverse(intAsBytes);
            return BitConverter.ToInt32(intAsBytes, 0);
        }
    }
}