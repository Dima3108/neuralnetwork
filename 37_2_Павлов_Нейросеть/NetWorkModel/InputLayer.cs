using System;
using System.Collections.Generic;
using System.Linq;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public class InputLayer
    {
        private Random random = new Random();//для случайности обуч примеров в новой эпохе
        //поля
        private (double[], int)[] trainset = new (double[], int)[100];
        public (double[], int)[] Trainset { get => trainset; }
        private int pred_len = -1;
        private List<(double[], int)> cesh;
#if true
        public InputLayer(NetworkMode networkMode) 
        {
            switch (networkMode)
            {
                case NetworkMode.Train:
                    int c_len = 0;
                    string line = "";
                    using (System.IO.StreamReader reader = new System.IO.StreamReader("fortrainsample.txt"))
                    {
                        while (( reader.ReadLine()) != null)
                        {
                            c_len++;
                        }
                    }
                        if (cesh == null||pred_len!=c_len)
                    {
                        pred_len = c_len;
                        cesh = new System.Collections.Generic.List<(double[], int)>();
                        //Считывание примеров из  файла 
                        using (System.IO.StreamReader reader = new System.IO.StreamReader("fortrainsample.txt"))
                        {
                            
                            //int pos = 0;
                            while ((line = reader.ReadLine()) != null)
                            {
                                // trainset[pos].Item1 = new double[15];
                                var cesh_d = new double[15];
                                char[] chars = line.ToCharArray();
                                for (int i = 1; i < 16; i++)
                                {
                                    //Console.WriteLine(chars[(2*i)]);
                                    // trainset[pos].Item1[i - 1] = Double.Parse(chars[2 * i].ToString());
                                    cesh_d[i - 1] = Double.Parse(chars[2 * i].ToString());
                                }
                                // trainset[pos].Item2 = Convert.ToInt32(chars[0]);
                                // pos++;
                                cesh.Add((cesh_d, Convert.ToInt32(chars[0].ToString())));
                            }
                        }
                        const int mnogit = 1;
int[] count = new int[10];
                       
                        List<(double[], int)>[] groups = new List<(double[], int)>[10];
                        for(int j = 0; j < 10; j++)
                        {
                            groups[j] = new List<(double[], int)>();
                        }
                        for(int i=0;i<cesh.Count;i++)
                            groups[cesh[i].Item2].Add(cesh[i]); 
                        for (int i = 0; i < groups.Length; i++)
                            count[i] = groups[i].Count;
                        //уравниеваем примеры так чтобы они содержали одинаковое кол-во для каждой цифры
                        int max = count.Max();
                        for(int i = 0; i < 10; i++)
                        {
                            for(int j = 0; j < max - count[i];j++)
                            {
                                cesh.Add(groups[i][j % count[i]]);
                            }    
                        }
                        //перенос в основной массив
                        trainset = new (double[], int)[mnogit * cesh.Count];
                        // cesh.CopyTo(trainset);
                        for (int i = 0; i < mnogit; i++)
                            for (int j = 0; j < cesh.Count; j++)
                                trainset[(cesh.Count * i) + j] = cesh[j];
                        
                    }
                    for(int n = trainset.Length - 1; n >= 0; n--)
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
