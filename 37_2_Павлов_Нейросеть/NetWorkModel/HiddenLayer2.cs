using System;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class HiddenLayer2 : Layer
    {
#if DEBUG
        public HiddenLayer2
            (int non, int nopn, TypeNeuron tn, string name, Layer n = null) : base(non, nopn, tn, name, n) { }
        //(Layer _n = null) : base(32, 73, TypeNeuron.HiddenNeuron, nameof(HiddenLayer2), _n) { }
#else
        public HiddenLayer2(Layer layer) : base(layer)
        {
            neurons = new Neuron[32];
        }
#endif
        public override void Recognaize(Network net, Layer _next)
        {
            throw new NotImplementedException();
        }
        public override double[] BackWardPass(double[] stuff)
        {
            throw new NotImplementedException();
        }
    }
}
