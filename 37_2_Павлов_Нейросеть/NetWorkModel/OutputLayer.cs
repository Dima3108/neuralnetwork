using System.Threading.Tasks;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class OutputLayer : Layer
    {
#if false
        public OutputLayer(Layer _n=null) : base(10, 32, TypeNeuron.OutputNeuron, nameof(OutputLayer), _n) { 

        }
#endif
        public OutputLayer(int non, int nopn, TypeNeuron tn, string name) : base(non, nopn, tn, name) { }
        public override void Recognaize(Network network, Layer layer)
        {
            double e_sum = 0;
            for (int i = 0; i < Neurons.Length; ++i)
                e_sum += Neurons[i].Output;
            for (int i = 0; i < Neurons.Length; ++i)
            {
                network.fact[i] = Neurons[i].Output / e_sum;
            }
        }
        public override double[] BackWardPass(double[] stuff)
        {
            double[] gr_sum = new double[numofprevneurons + 1];
            //Вычисление градиентных сумм выходного слоя
            // for(int j = 0;j<gr_sum.Length;j++)
            Parallel.For(0, gr_sum.Length, j =>
            {
                double sum = 0;
                for (int k = 0; k < Neurons.Length; k++)
                {
                    sum += Neurons[k].weights[j] * stuff[k];
                }
                gr_sum[j] = sum;
            });
            for (int i = 0; i < numofneurons; i++)
           // Parallel.For(0, numofneurons, i =>
            {
                for (int n = 0; n < numofprevneurons + 1; n++)
                {
                    double delta_w;
                    if (n == 0)
                    {
                        delta_w = momentum * lastdeltaweights[i, 0] + learmingrate * stuff[i];
                    }
                    else
                    {
                        delta_w = momentum * lastdeltaweights[i, n] + learmingrate * Neurons[i].InputData[n - 1] * stuff[i];
                    }
                    lastdeltaweights[i, n] = delta_w;
                    Neurons[i].weights[n] += delta_w;
                    //коррекция весов
                }
            }
            //);
            return gr_sum;
            //throw new NotImplementedException();
        }
        // public OutputLayer( int nopn, TypeNeuron _type, string nameLayer, Layer _n = null):base(10,)
        /*  {
              neurons = new Neuron[10];
              base
          }*/
    }
}
