using _37_2_Павлов_Нейросеть.NetWorkModel;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using SharpGL;
namespace _37_2_Павлов_Нейросеть
{
    public partial class Form1 : Form
    {
        private const string trainFileNmae = "fortrainsample.txt";
        private readonly string pathMyApp = AppDomain.CurrentDomain.BaseDirectory + trainFileNmae;//файловый путь к приложению
        private double[] InputData = new double[15];
        private Button[] NumbersButtons;
        public double[] NetOutput
        {
            set
            {
                // List<double> ol = new List<double>();
                string vla = value.ToList().IndexOf(value.Max()).ToString();

                // MessageBox.Show(vla);
               // LabelOutput.Text = vla;
                LabelOutput.Text = vla;
                string s = "";
                foreach(var v in value){
                  s+=  v.ToString()+" ";
             }
#if true
                Console.WriteLine($"output log:{ s}");
  for(int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"value {i}:{value[i] * 100.0}%");
                }
#endif
              

            }
        }
        /// <summary>
        /// Защита от дублирования
        /// </summary>
        private SecurityRead secReader;
#if true
        Network _network;
#endif
        /// <summary>
        /// Для графика функций
        /// </summary>
        private float[] X, Y;
        private int point_pos;
        float X_MIN,Y_MIN,X_MAX,Y_MAX,INP_ONE_PROC_X,INP_ONE_PROC_Y,OUTPUT_ONE_PROC_X,OUTPUT_ONE_PROC_Y;
        #region OpenGL
       
        #endregion
        public Form1()
        {
            InitializeComponent();
            #region Инициализация_кнопок_ввода
            NumbersButtons = new Button[] {button1,button2,button3,button4,button5,button6,button7,
            button8,button9,button10,button11,button12,button13,button14,button15};
            InitInputButton();
            #endregion
            #region ЗащитаОтДублирования
            secReader = new SecurityRead(pathMyApp);
            #endregion
#if true
            _network = new Network(NetworkMode.Demo);
#endif
            #region ИнициализацияГрафикаНейросети
            //  TrainingSchedule.Series["Series1"].
            #region OpenGL_help

            _network.Init = (s,xmin,xmax,ymin,ymax) =>
            {
                X = new float[s];
                Y=new float[s];
                point_pos = 0;
                X_MAX = xmax;
                X_MIN = xmin;
                Y_MAX = ymax;
                Y_MIN = ymin;
                INP_ONE_PROC_X = (X_MAX - X_MIN) / 100;
                INP_ONE_PROC_Y = (Y_MAX - Y_MIN) / 100;
                OUTPUT_ONE_PROC_X = openGLControl1.Width / 100;
                OUTPUT_ONE_PROC_Y=openGLControl1.Height / 100;
            };
            _network.Print = () =>
            {

               
            };
            #endregion
            _network.PrintXY = (x, y) =>
            {
                ///https://itarticle.ru/graphics-csharp/
                ///https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.forms.datavisualization.charting.chart?view=netframework-4.8.1
                TrainingSchedule.Series["Series1"].Points.AddXY(x, y);
                float proc_x = (X_MAX-x) / INP_ONE_PROC_X;
                float proc_y = (Y_MAX - (float)y) / INP_ONE_PROC_Y;
                X[point_pos] = x; //OUTPUT_ONE_PROC_X*proc_x;
                Y[point_pos++] = (float)y;//OUTPUT_ONE_PROC_Y*proc_y;
#if false
                Console.WriteLine("display_seXY");
#endif
            };
            _network.Clear = () =>
            {
                ///https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.forms.datavisualization.charting.series?view=netframework-4.8.1
#if false
                Console.WriteLine("display_clear");
#endif
                TrainingSchedule.Series["Series1"].ResetIsValueShownAsLabel();
               // TrainingSchedule.Series["Series1"].
            };
            #endregion
        }
        private double GetInputBitToInt()
        {
            double i = 0;
            for (int l = 0; l < InputData.Length; l++)
                i += InputData[l] * (double)Math.Pow(2, l);
            return i;
        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {

        }

        private string GetInputToStringBit()
        {
            string s = "";
            for (int l = 0; l < InputData.Length; l++)
                s += (InputData[l] == 0) ? "0 " : "1 ";
            return s;
        }
        /// <summary>
        /// Подписка на события кнопок ввода
        /// </summary>
        private void InitInputButton()
        {
            /*Обнулить кнопки*/
            for (int i = 0; i < NumbersButtons.Length; i++)
                NumbersButtons[i].BackColor = Color.Black;
            for (int i = 0; i < NumbersButtons.Length; i++)
            {
                int a = i;
                NumbersButtons[i].Click += (s, e) =>
                {
                    if (NumbersButtons[a].BackColor == Color.Black)
                    {
                        NumbersButtons[a].BackColor = Color.White;
                        InputData[a] = 1;
                    }
                    else
                    {
                        NumbersButtons[a].BackColor = Color.Black;
                        InputData[a] = 0;
                    }
#if false

                    LabelOutput.Text = GetInputBitToInt().ToString();

#endif
                };
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Защита ввода от дублирующих записей
        /// </summary>
     /*   private class SecurityRead
        {
            /// <summary>
            /// файл данных
            /// </summary>
            public string file_name { get; private set; }
            string[] cache;
            public int cache_length { get; private set; }
            
            public SecurityRead(string file_name,uint chace_count = 15)
            {
                this.file_name = file_name;
                cache = new string[chace_count];
                cache_length = 0;
                for (int i = 0; i < cache.Length; i++)
                    cache[i] = "";
            }
            private void ShiftWORDS(string word)
            {
                for (int I = 0; I < cache_length - 1; I++)
                    cache[I] = cache[I + 1];
                cache[cache_length-1] = word;
            }
            private void AddWordInCache(string word)
            {
                if (cache_length != cache.Length)
                {
                    cache[cache_length++] = word;
                }
                else
                {
                    ShiftWORDS(word);
                }
            }
            public bool ScanValue(string value)
            {
                for (int i = 0; i < cache_length; i++)
                    if (cache[i] == value)
                        return true;
                using(Stream str = File.Open(file_name, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using(StreamReader reader=new StreamReader(str))
                    {
                        bool nal = false;
                        Task.Run(async delegate
                        {
                            for(int i = 0; i < cache_length; i++)
                            {
                                if (await reader.ReadLineAsync() == value)
                                    nal = true;
                            }
                        }).Wait();
                        if (nal)
                        {
                            AddWordInCache(value);
                            return true;
                        }
                       // return nal;
                    }
                }
                return false;
            }
        }*/
        //save train sample

        private void button19_Click(object sender, EventArgs e)
        {
            string tmp = numericUpDown1.Value.ToString();
            tmp += " " + GetInputToStringBit();
            if (secReader.ScanValue(tmp))
            {
                MessageBox.Show("Введенное значение уже сохранено", "предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                File.AppendAllText(pathMyApp, tmp + "\n");
            }


        }

        private void button18_Click(object sender, EventArgs e)
        {
            _network.ForwardPass(_network, InputData);
            NetOutput = _network.fact;
            //TrainingSchedule.Series.
        }

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            // _network.Print();
            if (X != null && Y != null)
            {
                OpenGL openGL = openGLControl1.OpenGL;

                openGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

                // Сбрасываем модельно-видовую матрицу
                openGL.LoadIdentity();
                // Двигаем перо вглубь экрана
                //openGL.Translate(1.0f, 1.0f, 0.0f);
                openGL.Begin(SharpGL.Enumerations.BeginMode.Points);
                openGL.PointSize(1f);
                openGL.Color(1f, 1f, 1f);
                for (int i = 0; i < X.Length; i++)
                    openGL.Vertex(X[i], Y[i], 0.0f);
                openGL.End();
                //openGL.Flush();
               // openGLControl1.Invalidate();
            }
        }

        //обучение
        private void button16_Click(object sender, EventArgs e)
        {
            _network.Train(_network);

        }
    }
}
