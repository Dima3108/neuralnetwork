using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography;
using System.Security;
namespace ConsoleApp1
{
    internal class Program
    {
        static string get_file_name(string arg) { return $"fortrainsample{arg}.txt"; }
        static readonly string[] f = { "" };
        static MD5 md5 = MD5.Create();
        const string table = "1234567890qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        static string BtoT(byte[] c)
        {
            string s = "";
            foreach (var e in c)
                s +=  table[e % table.Length];
            return s;
        }
        static void CreateImage(string line)
        {
            var cesh_d = new double[15];
            char[] chars = line.ToCharArray();
            for (int i = 1; i < 16; i++)
            {
                //Console.WriteLine(chars[(2*i)]);
                // trainset[pos].Item1[i - 1] = Double.Parse(chars[2 * i].ToString());
                cesh_d[i - 1] = Double.Parse(chars[2 * i].ToString());
            }
            double o = Double.Parse(cesh_d[0].ToString());
            byte[] a = new byte[15];
            a[0] = (byte)o;
            string code = "";
            for (int i = 0; i < 15; i++)
            {
 a[i] = (byte)cesh_d[i];
                code += a[i].ToString();
            }
               
          string f_name = chars[0].ToString()+"_"+code+".bmp";
            Bitmap bitmap = new Bitmap(3,5,System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            bitmap.SetResolution(48, 48);
            Color color_1 = Color.White;
            Color color_0= Color.Black;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 5; j++)
                    bitmap.SetPixel(i, j, ((cesh_d[(3 * j) + i] == 1 ? color_1 : color_0)));
            bitmap.Save(f_name);
            // trainset[pos].Item2 = Convert.ToInt32(chars[0]);
            // pos++;
        }
        static void Main(string[] args)
        {
            string[]_f=new string[f.Length];    
            for(int i=0;i<_f.Length;i++)
                _f[i] = get_file_name(f[i]);
            List<string> cesh = new List<string>();
            foreach(string s in _f)
            {
                var elems=System.IO.File.ReadAllText(s).Split('\n');
                foreach(var e in elems)
                {
                    if (e != null && e.Length > 0)
                    {
                        bool Suc = true;
                        foreach(var t in cesh)
                            if (t == e)
                            {
                                Suc = false;
                                break;
                            }
                        if (Suc)
                            cesh.Add(e);
                    }
                }
            }
            /*  Task.Run(async delegate {
                  foreach (string s in cesh)
                     await Task.Run(()=> CreateImage(s));
              }).Wait();*/
            string c = "";
            foreach (var v in cesh)
                c += v + "\n";
            System.IO.File.WriteAllText("total.txt", c);
           foreach(var s in cesh)
                CreateImage(s); 
        }
    }
}
