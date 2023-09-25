using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace _37_2_Павлов_Нейросеть
{
    public partial class Form1 : Form
    {
        private const string trainFileNmae = "fortrainsample.txt";
        private readonly string pathMyApp = AppDomain.CurrentDomain.BaseDirectory+trainFileNmae;//файловый путь к приложению
        private int[] InputData = new int[15];
        private Button[] NumbersButtons;
        public Form1()
        {
            InitializeComponent();
            #region Инициализация_кнопок_ввода
            NumbersButtons = new Button[] {button1,button2,button3,button4,button5,button6,button7,
            button8,button9,button10,button11,button12,button13,button14,button15};
            InitInputButton();
            #endregion
        }
        private int GetInputBitToInt()
        {
            int i = 0;
            for (int l = 0; l < InputData.Length; l++)
                i += InputData[l] * (int)Math.Pow(2, l);
            return i;
        }
        private string GetInputToStringBit()
        {
            string s = "";
            for (int l = 0; l < InputData.Length; l++)
                s += (InputData[l] == 0) ? "0" : "1";
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
for(int i = 0; i < NumbersButtons.Length; i++)
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
#if DEBUG

                    label1.Text = GetInputBitToInt().ToString();

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
        //save train sample
        private void button19_Click(object sender, EventArgs e)
        {
            string tmp = numericUpDown1.Value.ToString();
            tmp += GetInputToStringBit()+"\n";
            File.AppendAllText(pathMyApp, tmp);
            
        }
    }
}
