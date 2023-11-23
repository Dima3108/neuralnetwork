namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class Network
    {
        private Layer _inputLayer = null,
                            _outputLayer = new OutputLayer(10, 32, TypeNeuron.OutputNeuron, nameof(_outputLayer));
        private HiddenLayer _hiddenLayer2 = new HiddenLayer(32, 73, TypeNeuron.HiddenNeuron, nameof(_hiddenLayer2));
        private HiddenLayer _hiddenLayer1 = new HiddenLayer(73, 15, TypeNeuron.HiddenNeuron, nameof(_hiddenLayer1));
        public double[] fact = new double[10];
        public Network(NetworkMode networkMode)
        {
            _inputLayer=new InputLayer(networkMode);


            /// _hiddenLayer1
            //   _hiddenLayer2 
            // _outputLayer 

        }
        public void ForwardPass(Network net, double[] netInput)
        {
            net._hiddenLayer1.Data = netInput;
            net._hiddenLayer1.Recognaize(null, net._hiddenLayer2);
            net._hiddenLayer2.Recognaize(null, net._outputLayer);
            net._outputLayer.Recognaize(net, null);
        }
        //Обучение
        public void Train(Network net)
        {
            int epoches = 70;//кол-во эпох обучения
            net._inputLayer = new InputLayer(NetworkMode.Train);
            double tmpSumError;//временная переменная суммы ошибок
            double[] errors;
            double[] tmp_gsums1,tmp_gsums2;//массивы локальныхградиентов 1 nad 2 hidden Lauyer

        }
    }
}
