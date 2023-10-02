using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class Network
    {
        private Layer _inputLayer, _outputLayer;
        private HiddenLayer1 _hiddenLayer1;
        private HiddenLayer2 _hiddenLayer2;
        public Network()
        { _outputLayer=new OutputLayer();
            _hiddenLayer2 = new HiddenLayer2(_outputLayer);
            _hiddenLayer1=new HiddenLayer1(_hiddenLayer2);

            _inputLayer = new InputLayer(_hiddenLayer1);
           
        }
    }
}
