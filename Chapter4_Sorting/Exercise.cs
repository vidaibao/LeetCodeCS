using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtil;

namespace Chapter4_Sorting
{
    internal class Exercise
    {
        public static void Exec01()
        {
            string txtFile = "tc001.txt";
            string s = TextFileUtils.ReadAllText(txtFile);
            string[] delimiters = [", ", ".", "!\n", " ", "!", "?"];
            var str = s.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            foreach (var ss in str)
            {
                Console.WriteLine(ss);
            }
        }
    }
}
