using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class HiddenLayer2:Layer
    {
#if DEBUG
        public HiddenLayer2(Layer _n = null) : base(32, 73, TypeNeuron.HiddenNeuron, nameof(HiddenLayer2), _n) { }
#else
        public HiddenLayer2(Layer layer) : base(layer)
        {
            neurons = new Neuron[32];
        }
#endif
    }
}
