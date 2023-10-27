using System;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class InputLayer : Layer
    {
#if DEBUG
        public InputLayer(NetworkMode networkMode, Layer _n = null) : base(15, 1, TypeNeuron.InputNeuron, nameof(InputLayer), _n) { }
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
