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
                    //Считывание примеров из  фала 
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
