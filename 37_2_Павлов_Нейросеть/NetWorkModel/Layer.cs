using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
   public abstract class Layer
    {
        public Layer(Layer _n = null)
        {
            _nextLayer = _n;
        }
       private  protected Neuron[] neurons;
        /// <summary>
        /// Внутренний уровень
        /// </summary>
        private protected Layer _nextLayer;
    }
}
