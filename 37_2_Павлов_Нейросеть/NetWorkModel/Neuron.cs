using System;
//https://ru.wikipedia.org/wiki/%D0%A4%D1%83%D0%BD%D0%BA%D1%86%D0%B8%D1%8F_%D0%B0%D0%BA%D1%82%D0%B8%D0%B2%D0%B0%D1%86%D0%B8%D0%B8

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class Neuron
    {
        public double Output { get => _output; }
        private double _output, _derivative;
        public double[] weights { get; set; }
        public double[] InputData { set; get; }

        public double Derivative { get => _derivative; }
        public TypeNeuron _type { get; }
        public Neuron(double[] _weights, TypeNeuron type)
        {
            _type = type;
            weights = _weights;
        }
        /*public unsafe void Activator(double *inpt,int iLength,double[] wght)
        {
            double sum = wght[0];
            for (int m = 0; m < iLength; ++m)
                sum += inpt[m] * wght[m + 1];
            switch (_type)
            {
                case TypeNeuron.HiddenNeuron:
                    _output = LogicFunc(sum);
                    _derivative = LogicFuncDerivative(sum);
                    break;
                case TypeNeuron.OutputNeuron:
                    _output = Math.Exp(sum);

                    break;
            }
        }*/
        public void Activator(double[] inpt, double[] wght)
        {
            double sum = wght[0];
            for (int m = 0; m < inpt.Length; ++m)
                sum += inpt[m] * wght[m + 1];
            switch (_type)
            {
                case TypeNeuron.HiddenNeuron:
                     _output = LogicFunc(sum);
                     _derivative = LogicFuncDerivative(sum);
                   
                    break;
                case TypeNeuron.OutputNeuron:
                    _output = Math.Exp(sum);

                    break;
            }
        }
        private double LogicFunc(double x) => 1.00000000 / (1.000000 + Math.Exp(-x));
        private double LogicFuncDerivative(double x)
        {
            double val = LogicFunc(x);
            return val * (1.000000000000 - val);
        }
       
    }
}
