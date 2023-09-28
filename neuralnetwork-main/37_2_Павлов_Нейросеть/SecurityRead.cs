using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_2_Павлов_Нейросеть
{
    /// <summary>
    /// Защита ввода от дублирующих записей
    /// </summary>
    public class SecurityRead
    {
        /// <summary>
        /// файл данных
        /// </summary>
        public string file_name { get; private set; }
        string[] cache;
        public int cache_length { get; private set; }

        public SecurityRead(string file_name, uint chace_count = 15)
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
            cache[cache_length - 1] = word;
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
            if (!File.Exists(file_name))
                return false;
            using (Stream str = File.Open(file_name, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(str))
                {
                    bool nal = false;
                    Task.Run(async delegate
                    {
                        while(!reader.EndOfStream) 
                        {
                            if (await reader.ReadLineAsync() == value)
                                nal = true;
                        }
                    reader.Close();
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
    }
}
