using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class HiddenLayer1:Layer
    {
#if DEBUG
        public HiddenLayer1(Layer _n = null) : base(73, 15, TypeNeuron.HiddenNeuron, nameof(HiddenLayer1), _n) { }
#else
        public HiddenLayer1(Layer layer):base(layer)
        {
            neurons = new Neuron[73];
        }
#endif
    }
}
