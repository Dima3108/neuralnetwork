using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _37_2_Павлов_Нейросеть
{
    static class Program
    {
        private static Form1 form;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            Console.WriteLine("###");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          form = new Form1();
            Application.Run(form);
        }
    }
}
