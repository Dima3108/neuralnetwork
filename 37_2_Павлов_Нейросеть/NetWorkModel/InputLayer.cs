using System;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class InputLayer
    {
        private Random random = new Random();//для случайности обуч примеров в новой эпохе
        //поля
        private (double[], int)[] trainset = new (double[], int)[100];
        public (double[], int)[] Trainset { get => trainset; }
#if DEBUG
        public InputLayer(NetworkMode networkMode) 
        {
            switch (networkMode)
            {
                case NetworkMode.Train:
                    //Считывание примеров из  файла 
                    using(System.IO.StreamReader reader=new System.IO.StreamReader("fortrainsample.txt"))
                    {
                        string line = "";
                        while((line = reader.ReadLine()) != null)
                        {

                        }
                    }
                    for(int n = trainset.Length - 1; n >= 1; n--)
                    {
                        int j = random.Next(n + 1);
                        var temp = trainset[n];
                        trainset[n]=trainset[j];
                        trainset[j]=temp;
                    }
                    //перемешать обучающий пример
                    break;
                case NetworkMode.Test:
                    break;
                case NetworkMode.Demo:
                    break;
                default:
                    break;
            }
        }
        public  double[] BackWardPass(double[] stuff)
        {
            throw new NotImplementedException();

        }
        public  void Recognaize(Network net, Layer _next)
        {
            throw new NotImplementedException();
        }
#else
        public InputLayer(Layer layer):base(layer)
        {
            neurons = new Neuron[15];
        }
#endif
    }
}
