using System;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class Network
    {
        private InputLayer _inputLayer = null;
             private OutputLayer               _outputLayer = new OutputLayer(10, 32, TypeNeuron.OutputNeuron, nameof(_outputLayer));
        private HiddenLayer _hiddenLayer2 = new HiddenLayer(32, 73, TypeNeuron.HiddenNeuron, nameof(_hiddenLayer2));
        private HiddenLayer _hiddenLayer1 = new HiddenLayer(73, 15, TypeNeuron.HiddenNeuron, nameof(_hiddenLayer1));
        public double[] fact = new double[10];
        //средне знач энергии ош эпохи
        private double e_error_avr;//(energy error average)
        public double E_ERROR_AVR { get=>e_error_avr; set=>e_error_avr = value; }
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
        //анонимные функции
        /// <summary>
        /// https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/lambda-expressions
        /// </summary>
        public Action<int, double> PrintXY { set; private get; }
        public Action Clear;
        //Обучение
        public void Train(Network net)
        {
            int epoches = 100;//кол-во эпох обучения(было 70)
            net._inputLayer = new InputLayer(NetworkMode.Train);//инициализация входного слоя для формирования обучающего множества
            double tmpSumError;//временная переменная суммы ошибок
            double[] errors;
            double[] tmp_gsums1,tmp_gsums2;//массивы локальныхградиентов 1 nad 2 hidden Lauyer
              Clear();
            for(int k=0; k<epoches; k++)
            {
                e_error_avr = 0;
              
                for(int i = 0; i < net._inputLayer.Trainset.Length; i++)
                {
                    //прямой проход
                    ForwardPass(net, net._inputLayer.Trainset[i].Item1);
                    //вычисление ошибок по итерациям
                    tmpSumError = 0;
                    errors = new double[net.fact.Length];//переопределение масива сигнала ошибки
                    for(int x = 0; x < errors.Length; x++)
                    {
                        //дельтапраило
                        if (x==net._inputLayer.Trainset[i].Item2)
                        {
                            errors[x] = -(net.fact[x] - 1.0);//нахождение ошибки

                        }
                        else
                        {
                            errors[x] = -net.fact[x];//желаймый 0
                        }
                        tmpSumError+=errors[x]*errors[x]/2.0; 
                    }
                    //ошибка по эпох
                    e_error_avr += tmpSumError / errors.Length;//суммарное значение энергии ошибки эпох
                    //обратный проход и коррекция весов
                    tmp_gsums2 = net._outputLayer.BackWardPass(errors);//обратный проход для выходного слоя
                    tmp_gsums1 = net._hiddenLayer2.BackWardPass(tmp_gsums2);//предача градиента 2 скрыт слою
                    net._hiddenLayer1.BackWardPass(tmp_gsums1);

                }
                e_error_avr /= net._inputLayer.Trainset.Length;//среднне значение энергии ошибки 1 эпохи
                //написать код прередачи энергии ошибки эпохи на график и обновить график
                this.PrintXY(k, e_error_avr);
            }
            net._inputLayer = null;//обнуление входного слоя
            //запись скорректированных весов в файл
            net._hiddenLayer1.WeightInitialize(MemoryMode.SET, net._hiddenLayer1.pathFileWeights);
            net._hiddenLayer2.WeightInitialize(MemoryMode.SET, net._hiddenLayer2.pathFileWeights);
            net._outputLayer.WeightInitialize(MemoryMode.SET, net._outputLayer.pathFileWeights);
        }
    }
}
