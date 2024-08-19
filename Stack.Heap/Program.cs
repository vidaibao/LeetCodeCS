

namespace Stack.Heap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ValidParentheses_20();
            //LongestValidParentheses_32();
            CheckIfWordIsValidAfterSubstitutions_1003();

        }

        private static void CheckIfWordIsValidAfterSubstitutions_1003()
        {
            string s = "aabcbc";
            Console.WriteLine(IsValid_1003a(s));
        }
        static bool IsValid_1003a(string s)
        {
            if (s.Length < 3) { return false; }

            while (s != "")
            {
                string temp = s.Replace("abc", "");

                if (temp == s) break; // s has no more "abc"

                s = temp;
            }

            return s == "";
        }
        static bool IsValid_1003b(string s)
        {
            if (s.Length <= 2)
            {
                return false;
            }
            Stack<char> st = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (st.Count >= 2 && s[i] == 'c')
                {
                    char second = st.Pop();
                    char first = st.Pop();
                    if (first == 'a' && second == 'b')
                    {
                    }
                    else
                    {
                        st.Push(first);
                        st.Push(second);
                        st.Push(s[i]);
                    }
                }
                else
                {
                    st.Push(s[i]);
                }
            }
            return st.Count == 0;
        }
        static bool IsValid_1003(string s)
        {
            if (s.Length < 3) { return false; }
            
            var stack = new Stack<char>();

            foreach (char c in s) 
            {
                stack.Push(c);
                if (stack.Count >= 3)
                {
                    char third = stack.Pop(); // c
                    char second = stack.Pop(); // b
                    char first = stack.Pop(); // a
                    if (!(first == 'a' && second == 'b' && third == 'c')) 
                    {
                        stack.Push(first); stack.Push(second); stack.Push(third);
                    }
                }
            }

            return stack.Count == 0;
        }






        private static void LongestValidParentheses_32()
        {
            //string s = "()(()";
            //string s = "((()";
            //string s = "(())";
            //string s = "(())))((()))";
            string s = "()())(";
            Console.WriteLine(LongestValidParentheses(s));
        }
        static int LongestValidParentheses(string s)
        {
            if (s.Length <= 1) return 0;

            int max = 0;
            var stack = new Stack<int>();
            stack.Push(-1); // valid from the start 0

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        max = Math.Max(max, i - stack.Peek());
                    }
                }
            }
            
            return max;
        }
        static int LongestValidParentheses00(string s) // 156/231 "()(()"
        {
            if (s.Length <= 1) return 0;

            int max = 0;
            int pairs = 0;
            var stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ')')
                {
                    if (stack.Count > 0 && stack.Peek() == '(') { stack.Pop(); pairs++; }
                    else
                    {
                        if (pairs > max) max = pairs;
                        pairs = 0;
                    }
                }
                else if (s[i] == '(')
                {
                    stack.Push(s[i]);
                }
            }
            if (pairs > max) max = pairs;

            return max * 2;
        }





        private static void ValidParentheses_20()
        {
            string s = "({[)";
            //string s = "({[)";
            //string s = "{[]}";
            //string s = "(){}}{";
            //string s = "()[]{}";
            Console.WriteLine(IsValid(s));
        }
        static bool IsValid(string s) // 55ms
        {
            if (s.Length == 1 || s.Length % 2 == 1) return false;

            string open = "([{", close = ")]}";
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (open.Contains(s[i]))
                {
                    stack.Push(s[i]);
                }
                else
                {
                    int idx = close.IndexOf(s[i]);
                    if (stack.Count > 0 && stack.Peek() == open[idx]) stack.Pop();
                    else return false;
                }
            }
            
            return stack.Count == 0;
        }
        static bool IsValid00(string s) // 95/98 }{
        {
            if (s.Length == 1 || s.Length % 2 == 1) return false;
            string a = "()[]{}";
            var dic = new Dictionary<char, char>();
            dic.Add(a[0], a[1]); //dic.Add(a[1], a[0]);
            dic.Add(a[2], a[3]); //dic.Add(a[3], a[2]);
            dic.Add(a[4], a[5]); //dic.Add(a[5], a[4]);

            var stack = new Stack<char>();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (stack.Count > 0 && dic.TryGetValue(s[i], out char val))
                {
                    if (val == stack.Peek()) // pair
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(s[i]);
                }
            }   

            return stack.Count == 0;
        }
    }
}
