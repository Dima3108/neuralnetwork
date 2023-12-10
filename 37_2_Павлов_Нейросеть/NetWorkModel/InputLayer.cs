using System;
using System.Collections.Generic;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class InputLayer
    {
        private Random random = new Random();//для случайности обуч примеров в новой эпохе
        //поля
        private (double[], int)[] trainset = new (double[], int)[100];
        public (double[], int)[] Trainset { get => trainset; }
#if true
        public InputLayer(NetworkMode networkMode) 
        {
            switch (networkMode)
            {
                case NetworkMode.Train:
                    List<(double[], int)> cesh = new System.Collections.Generic.List<(double[], int)>();
                    //Считывание примеров из  файла 
                    using(System.IO.StreamReader reader=new System.IO.StreamReader("fortrainsample.txt"))
                    {
                        string line = "";
                        int pos = 0;
                        while((line = reader.ReadLine()) != null)
                        {
                            // trainset[pos].Item1 = new double[15];
                            var cesh_d = new double[15];
                            char []chars= line.ToCharArray();
                            for(int i = 1; i < 16; i++)
                            {
//Console.WriteLine(chars[(2*i)]);
                                // trainset[pos].Item1[i - 1] = Double.Parse(chars[2 * i].ToString());
                                cesh_d[i - 1] = Double.Parse(chars[2 * i].ToString());
                            }
                            // trainset[pos].Item2 = Convert.ToInt32(chars[0]);
                            // pos++;
                            cesh.Add((cesh_d, Convert.ToInt32(chars[0])));
                        }
                    }
                    trainset = new (double[], int)[cesh.Count];
                    cesh.CopyTo(trainset);
                    for(int n = trainset.Length - 1; n >= 1; n--)
                    {
                        int j = random.Next(n + 1);
                        var temp = trainset[n];
                        trainset[n]=trainset[j];
                        trainset[j]=temp;
                    }
                    //перемешать обучающий пример
                    break;
                case NetworkMode.Test:
                    break;
                case NetworkMode.Demo:
                    break;
                default:
                    break;
            }
        }
        public  double[] BackWardPass(double[] stuff)
        {
            throw new NotImplementedException();

        }
        public  void Recognaize(Network net, Layer _next)
        {
            throw new NotImplementedException();
        }
#else
        public InputLayer(Layer layer):base(layer)
        {
            neurons = new Neuron[15];
        }
#endif
    }
}
