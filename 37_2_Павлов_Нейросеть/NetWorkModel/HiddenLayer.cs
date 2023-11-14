namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class HiddenLayer : Layer
    {
        public HiddenLayer(int non, int nopn, TypeNeuron tn, string name, Layer n = null) : base(non, nopn, tn, name) { }
        public override void Recognaize(Network net, Layer _next)
        {
            double[] hidden_out = new double[Neurons.Length];
            for (int i = 0; i < neurons.Length; i++)
                hidden_out[i] = Neurons[i].Output;
            _next.Data = hidden_out;
        }
        public override double[] BackWardPass(double[] stuff)
        {
            double[] gr_sum = new double[numofprevneurons];
            for(int j = 0; j < gr_sum.Length; j++)
            {
                double sum = 0;
                for(int k = 0; k < Neurons.Length; k++)
                {
                    sum += Neurons[k].weights[j] * Neurons[k].Derivative*stuff[k];
                }
                gr_sum[j] = sum;
            }
            //код
            return gr_sum;
        }
    }
}
