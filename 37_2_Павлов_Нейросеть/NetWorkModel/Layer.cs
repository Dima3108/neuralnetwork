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
        public Layer(Layer _n = null)
        {
            _nextLayer = _n;
        }
       private  protected Neuron[] neurons;
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
        protected int numofneurons { get => neurons.Length; }
        /// <summary>
        /// кол-во пред нейронов
        /// </summary>
        protected int numofprevneurons;
        /// <summary>
        /// массив весов предыдущих слоев
        /// </summary>
        protected double[,] lastdeltaweights;
        /// <summary>
        /// Скорость обучения
        /// </summary>
        protected const double learmingrate = 0.5;
    }
}
