using System;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class HiddenLayer1 : Layer
    {
#if true
        /// <summary>
        /// 
        /// </summary>
        /// <param name="non">колво текущих нейронов</param>
        /// <param name="nopn">колво нейронов пред слоя</param>
        /// <param name="tn">тип нейронов</param>
        /// <param name="name">имя слоя</param>
        /// <param name="n"></param>
        public HiddenLayer1(int non, int nopn, TypeNeuron tn, string name, Layer n = null) : base(non, nopn, tn, name) { }
        //(Layer _n = null) : base(73, 15, TypeNeuron.HiddenNeuron, nameof(HiddenLayer1), _n) { }

#else
        public HiddenLayer1(Layer layer):base(layer)
        {
            neurons = new Neuron[73];
        }
#endif
        public override double[] BackWardPass(double[] stuff)
        {
            throw new NotImplementedException();
        }
        public override void Recognaize(Network net, Layer _next)
        {
            throw new NotImplementedException();
        }
    }
}
