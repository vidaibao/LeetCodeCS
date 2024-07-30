
namespace StringSolutions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LengthOfTheLastWord_58();

        }

        private static void LengthOfTheLastWord_58()
        {
            string s = "   fly me   to   the moon  ";
            Console.WriteLine(LengthOfLastWord(s));
        }
        static int LengthOfLastWord(string s)
        {
            //var w = s.Split(' ');
            //for (int i = w.Length - 1; i >= 0; i--)
            //{
            //    if (w[i] != "") return w[i].Length;
            //}
            //return 0;
            s = s.TrimEnd();
            int count = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] != ' ') count++;
                else break;
            }
            return count;
        }
    }
}
