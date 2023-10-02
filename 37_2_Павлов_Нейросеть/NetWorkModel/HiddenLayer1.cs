using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class HiddenLayer1:Layer
    {
       public HiddenLayer1(Layer layer):base(layer)
        {
            neurons = new Neuron[73];
        }
    }
}
