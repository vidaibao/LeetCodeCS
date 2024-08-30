using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil
{
    public class TextFileUtils
    {
        public static string ReadAllText(string fileName)
        {
            string content = string.Empty;
            try
			{
                string filePath = @".\" + fileName;
                content = File.ReadAllText(filePath);
            }
			catch (Exception ex)
			{
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return content;
        }

        public static string[] ReadAllLines(string fileName)
        {
            string[] lines = Array.Empty<string>(); // null;
            try
            {
                string filePath = @".\" + fileName;
                lines = File.ReadAllLines(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return lines;
        }


    }
}
