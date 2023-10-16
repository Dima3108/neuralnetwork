using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class OutputLayer:Layer
    {
#if DEBUG
        public OutputLayer(Layer _n=null) : base(10, 32, TypeNeuron.OutputNeuron, nameof(OutputLayer), _n) { 

        }
#endif
        // public OutputLayer( int nopn, TypeNeuron _type, string nameLayer, Layer _n = null):base(10,)
        /*  {
              neurons = new Neuron[10];
              base
          }*/
    }
}
