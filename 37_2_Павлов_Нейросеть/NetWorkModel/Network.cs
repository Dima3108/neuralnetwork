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
        {
            _inputLayer = new InputLayer();
            _outputLayer=new OutputLayer();
        }
    }
}
