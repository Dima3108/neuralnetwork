using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://ru.wikipedia.org/wiki/%D0%A4%D1%83%D0%BD%D0%BA%D1%86%D0%B8%D1%8F_%D0%B0%D0%BA%D1%82%D0%B8%D0%B2%D0%B0%D1%86%D0%B8%D0%B8

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class Neuron
    {
        public double Output { get; }
        public double Derivative { get; }
        public double[] Weights { get; set; }
        public double[] InputData
        {
            get; set;
        }
        private TypeNeuron _type;

        private double LogicFunc(double x) => 1 / (1 + Math.Pow(Math.E, -x));
        private double LogicFuncDerivative(double x)
        {
            double val = LogicFunc(x);
            return val * (1 - val);
        }
        public void Activator(double[] inpt, double[] wght)
        {
            switch (_type)
            {
                case TypeNeuron.HiddenNeuron:break;
                case TypeNeuron.OutputNeuron:break;
            }
        }
    }
}
