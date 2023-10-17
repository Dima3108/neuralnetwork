using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class OutputLayer:Layer
    {
#if false
        public OutputLayer(Layer _n=null) : base(10, 32, TypeNeuron.OutputNeuron, nameof(OutputLayer), _n) { 

        }
#endif
        public OutputLayer(int non,int nopn,TypeNeuron tn,string name) : base(non, nopn, tn, name) { }
        public override void Recognaize(Network network,Layer layer)
        {

        }
        public override void BackWardPass(double[] stuff)
        {
            //throw new NotImplementedException();
        }
        // public OutputLayer( int nopn, TypeNeuron _type, string nameLayer, Layer _n = null):base(10,)
        /*  {
              neurons = new Neuron[10];
              base
          }*/
    }
}
