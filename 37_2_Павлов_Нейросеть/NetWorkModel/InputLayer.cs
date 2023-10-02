using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class InputLayer:Layer
    {
        public InputLayer(Layer layer):base(layer)
        {
            neurons = new Neuron[15];
        }
    }
}
