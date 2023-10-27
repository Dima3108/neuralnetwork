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
