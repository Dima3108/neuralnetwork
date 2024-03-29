﻿using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public abstract class Layer
    {
        protected Layer(int non, int nopn, TypeNeuron _type, string nameLayer, Layer _n = null)
        {
            _nextLayer = _n;
            neurons = new Neuron[non];
            numofprevneurons = nopn;
            fLauerName = nameLayer;
            pathDirWeights = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "memory");
            if (!Directory.Exists(pathDirWeights))
                Directory.CreateDirectory(pathDirWeights);
            // AppDomain.CurrentDomain.BaseDirectory;
            pathFileWeights = Path.Combine(pathDirWeights, nameLayer + ".csv");
#if false
            File.Create(pathFileWeights);
            Console.WriteLine(pathFileWeights);
#endif
            double[,] weights;//временный массив весов

            weights = null;
            /*#if DEBUG
                        weights = WeightInitialize(MemoryMode.INIT, pathFileWeights);
            #endif*/
            if (File.Exists(pathFileWeights))
                weights = WeightInitialize(MemoryMode.GET, pathFileWeights);
            else
            {
                weights = WeightInitialize(MemoryMode.INIT, pathFileWeights);

            }
            lastdeltaweights = new double[non, nopn + 1];
            for (int i = 0; i < non; ++i)
            {
                double[] tmp_weights = new double[nopn + 1];
                for (int j = 0; j < nopn + 1; ++j)
                {
                    tmp_weights[j] = weights[i, j];
                }
                neurons[i] = new Neuron(tmp_weights, _type);
            }


        }
        public double[,] WeightInitialize(MemoryMode mm, string path)
        {
            double[,] w = new double[numofneurons, numofprevneurons + 1];
            char[] delim = { ';', ' ' };
            string tmpStr = "";
            string[] tmpStrWeights;
            switch (mm)
            {
                case MemoryMode.INIT:
                    Random random = new Random();
                    double ts = 0;
                    for (int i = 0; i < numofneurons; i++)
                    {
                        for (int j = 0; j < numofprevneurons + 1; j++)
                        {
                            w[i, j] = 2 * random.NextDouble() - 1;
                            ts += w[i, j];
                        }
                    }
                    tmpStrWeights = new string[numofneurons];

                    ts /= (double)((numofprevneurons + 1) * numofneurons);
                    /*for (int i = 0; i < numofneurons; i++)
                        for (int j = 0; j < numofprevneurons + 1; j++)
                            w[i, j] -= ts;*/
                    for (int i = 0; i < numofneurons; i++)
                    {
                        tmpStr = w[i, 0].ToString();
                        for (int j = 1; j < numofprevneurons + 1; j++)
                        {
                            w[i, j] -= ts;
                            tmpStr += delim[0].ToString() + w[i, j].ToString();
                        }
                        tmpStrWeights[i] = tmpStr;
                    }
#if true
                    Console.WriteLine(tmpStrWeights[0]);
#endif
                    File.AppendAllLines(path, tmpStrWeights);


                    break;
                case MemoryMode.GET:
                   // w = WeightInitialize(MemoryMode.INIT, path);
                    string[] lines = File.ReadAllLines(path);
                    for (int i = 0; i < numofneurons; ++i)
                    {
                        string[] val = lines[i].Split(delim[0]);
                        for (int j = 0; j < numofprevneurons + 1;++j)
                            w[i, j] = double.Parse(val[j].Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                    }
                    break;
                case MemoryMode.SET:
                    //w = new double[numofneurons, numofneurons + 1];
                    for(int i = 0; i < numofneurons; i++)
                    {

                        for(int j = 0; j < numofprevneurons + 1; j++)
                        {
                            w[i,j]=Neurons[i].weights[j];

                        }
                    }
                       

                    File.Delete(path);
                    tmpStrWeights = new string[numofneurons];
                    for (int i = 0; i < numofneurons; i++)
                    {
                        tmpStr = w[i, 0].ToString();
                        for (int j = 1; j < numofprevneurons + 1; j++)
                        {
                           // w[i, j] -= ts;
                            tmpStr += delim[0].ToString() + w[i, j].ToString();
                        }
                        tmpStrWeights[i] = tmpStr;
                    }
                    File.AppendAllLines(path, tmpStrWeights);
                    //Здесь другая функция
                    break;
                    // return w;
                    /* case MemoryMode.GET:
                         return w;
                     default:return null;*/
            }
            return w;
        }
        abstract public void Recognaize(Network net, Layer _next);
        abstract public double[] BackWardPass(double[] stuff);
        private protected Neuron[] neurons;
        public Neuron[] Neurons
        {
            get => neurons;
            set => neurons = value;
        }
        private double[] data_cesh;
        private int _Length, _Offset;
        private  void Thread_Compute(object id)
        {
            int i=Convert.ToInt32(id);

           
               // unsafe
                {
                   // fixed(double* idat = data_cesh)
                    {
                          while (i < _Length)
                          {
                        //Neurons[i].InputData = data_cesh;
                        if (Neurons[i].InputData == null || Neurons[i].InputData.Length!=data_cesh.Length)
                            Neurons[i].InputData=new double[data_cesh.Length];
                        for (int t = 0; t < data_cesh.Length; t++)
                            Neurons[i].InputData[t] = data_cesh[t];
                        Neurons[i].Activator(Neurons[i].InputData, Neurons[i].weights); 
                                i += _Offset; 
                          }
                    }
                }
               
               
            
        }
        // private Thread thread_one=new Thread(new ThreadStart(Thread_Compute))
        private Thread[] threads;
        public double[] Data
        {
            set
            {
                data_cesh=new double[value.Length];
                value.CopyTo(data_cesh,0);
               // Thread[] threads = new Thread[4];

                _Offset = 16;
                _Length = Neurons.Length;
                Parallel.For(0, _Offset, idx =>
                {
                    int i = idx;
                    while(i< Neurons.Length)
                    {
                        //Neurons[i].InputData = value;
                        if (Neurons[i].InputData == null || Neurons[i].InputData.Length != value.Length)
                            Neurons[i].InputData = new double[value.Length];
                        value.CopyTo(Neurons[i].InputData, 0);
                        Neurons[i].Activator(value, Neurons[i].weights);
                        i += _Offset;
                    }
                });
                // for (int i = 0; i < Neurons.Length; i++)
                /*Parallel.For(0, Neurons.Length,(i)=>
                {
                    Neurons[i].InputData = value;
                    Neurons[i].Activator(Neurons[i].InputData, Neurons[i].weights);
                });*/



            }
        }
        /// <summary>
        /// Внутренний уровень
        /// </summary>
        private protected Layer _nextLayer;
        /// <summary>
        /// имя слоя
        /// </summary>
        protected string fLauerName { get; }
        /// <summary>
        /// путь к катологу
        /// </summary>
        string pathDirWeights;
        public string pathFileWeights { get; private set; }
        protected int numofneurons { get => neurons.Length; }
        /// <summary>
        /// кол-во пред нейронов
        /// </summary>
        protected int numofprevneurons { get; }
        /// <summary>
        /// массив весов предыдущих слоев
        /// </summary>
        protected double[,] lastdeltaweights;

        /// <summary>
        /// Скорость обучения
        /// </summary>
        protected const double learmingrate = 0.19;
        //0.17
        protected const double momentum = 0.5d;
    }
}
