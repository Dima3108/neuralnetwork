using System;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class InputLayer : Layer
    {
        private Random random = new Random();//для случайности обуч примеров в новой эпохе
        //поля
        private (double[], int)[] trainset = new (double[], int)[100];
        public (double[], int)[] Trainset { get => trainset; }
#if DEBUG
        public InputLayer(NetworkMode networkMode, Layer _n = null) : base(15, 1, TypeNeuron.InputNeuron, nameof(InputLayer), _n) {
            switch (networkMode)
            {
                case NetworkMode.Train:break;
                case NetworkMode.Test:break;
            }
        }
        public override double[] BackWardPass(double[] stuff)
        {
            throw new NotImplementedException();

        }
        public override void Recognaize(Network net, Layer _next)
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
