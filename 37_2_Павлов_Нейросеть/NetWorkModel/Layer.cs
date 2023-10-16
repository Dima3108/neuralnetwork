using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
   public abstract class Layer
    {
        protected Layer(int non,int nopn,TypeNeuron _type,string nameLayer,Layer _n = null)
        {
            _nextLayer = _n;
            neurons = new Neuron[non];
            numofprevneurons = nopn;
            fLauerName = nameLayer;
            pathDirWeights = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "memory");
            if(!Directory.Exists(pathDirWeights))
                Directory.CreateDirectory(pathDirWeights);
                // AppDomain.CurrentDomain.BaseDirectory;
            pathFileWeights =Path.Combine( pathDirWeights,nameLayer+".csv");
#if DEBUG
            File.Create(pathFileWeights);
            Console.WriteLine(pathFileWeights);
#endif
            double[,] weights;//временныймассив весов
            weights = null;
#if DEBUG
            weights = WeightInitialize(MemoryMode.INIT, pathFileWeights);
#endif
            lastdeltaweights = new double[non, nopn + 1];
            for(int i = 0; i < non; ++i)
            {
                double[] tmp_weights = new double[nopn + 1];
                for(int j = 0; j < nopn + 1; ++j)
                {
                    tmp_weights[j] = weights[i, j];
                }
                neurons[i] = new Neuron(tmp_weights, _type);
            }


        }
        public double[,]WeightInitialize(MemoryMode mm,string path)
        { double[,] w = new double[numofneurons, numofprevneurons+1];
            switch (mm)
            {
                case MemoryMode.INIT:
                   

                    return w;
                case MemoryMode.GET:
                    return w;
                default:return null;
            }
        }
       private  protected Neuron[] neurons;
        public Neuron[] Neurons
        {
            get => neurons;
            set=>neurons = value;
        }
        public double[] Data
        {
            set
            {
               for(int i = 0; i < Neurons.Length; i++)
                {
 Neurons[i].InputData=value;
 Neurons[i].Activator(Neurons[i].InputData,Neurons[i].weights);
                }
                 
                 
                 
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
        string pathFileWeights;
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
        protected const double learmingrate = 0.5;
        protected const double momentum=0.05d;
    }
}
