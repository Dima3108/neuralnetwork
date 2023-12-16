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
            //расчет локального градиента
            for(int j = 0; j < gr_sum.Length; j++)
            {
                double sum = 0;
                for(int k = 0; k < Neurons.Length; k++)
                {
                    sum += Neurons[k].weights[j] * Neurons[k].Derivative*stuff[k];
                }
                gr_sum[j] = sum;
            }

            //расчет измененияи коррекции весов
            for(int i = 0; i < numofneurons; i++)
            {
                for(int n = 0; n < numofprevneurons + 1; n++)
                {
                    double delta_w;
                    if(n==0)
                    {
                        delta_w = momentum * lastdeltaweights[i, 0] + learmingrate * Neurons[i].Derivative * stuff[i];

                    }
                    else
                    {
                        delta_w = momentum * lastdeltaweights[i, n] + learmingrate * Neurons[i].InputData[n - 1] * Neurons[i].Derivative * stuff[i];
                    }
                    lastdeltaweights[i, n] = delta_w;
                    Neurons[i].weights[n] += delta_w;
                    //Коррекция весов
                }
            }
            return gr_sum;
        }
    }
}
