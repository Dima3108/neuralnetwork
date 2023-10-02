using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class HiddenLayer2:Layer
    {
        public HiddenLayer2(Layer layer) : base(layer)
        {
            neurons = new Neuron[32];
        }
    }
}
