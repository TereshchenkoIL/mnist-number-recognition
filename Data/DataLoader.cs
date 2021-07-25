using System;
using System.IO;
namespace mnist_number_recognition.Data
{
    public class DataLoader
    {
        private string trainDataFile =  "train-images.idx3-ubyte";
        private string trainLabelFile =  "train-labels.idx1-ubyte";

        public double[,] LoadTrainImages(){

            FileStream ifsPixels = new FileStream(trainDataFile, FileMode.Open);
            BinaryReader brImages = new BinaryReader(ifsPixels);

            int magic1 = brImages.ReadInt32(); // stored as big endian
            magic1 = ReverseBytes(magic1); // convert to Intel format
            int imageCount = brImages.ReadInt32();
            imageCount = ReverseBytes(imageCount);
            int numRows = brImages.ReadInt32();
            numRows = ReverseBytes(numRows);
            int numCols = brImages.ReadInt32();
            numCols = ReverseBytes(numCols);

            double[,] res = new double[imageCount, numRows * numCols];

            for(int i = 0; i < imageCount; i++){
                for(int j = 0; j < numRows * numCols; j++){
                    byte b = brImages.ReadByte();
                    res[i,j] = b;
                }
            }

            return res;
        }

        public static int ReverseBytes(int v)
        {
            byte[] intAsBytes = BitConverter.GetBytes(v);
            Array.Reverse(intAsBytes);
            return BitConverter.ToInt32(intAsBytes, 0);
        }
    }
}