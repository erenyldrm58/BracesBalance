using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracesBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            //int aCount = Convert.ToInt32(Console.ReadLine().Trim());

            //List<int> a = new List<int>();

            //for (int i = 0; i < aCount; i++)
            //{
            //    int aItem = Convert.ToInt32(Console.ReadLine().Trim());
            //    a.Add(aItem);
            //}

            //int res = MissingNumber(a);

            /*********************************************/

            string[] value = { "{[()]}", "{[(])}", "{{[[(())]]}}" };
            string[] res = BracesBlance(value);
        }

        private static int MissingNumber(List<int> a)
            {
                int flag = 1;

                a = a.OrderBy(x => x).ToList();

                for (int i = 0; i < a.Count; i++)
                {
                    if (a[i] <= 0)
                        continue;
                    else if (a[i] == flag)
                    {
                        flag++;
                    }

                }
                return flag;
            }

        private static string[] BracesBlance(string[] values)
        {
            Stack<char> nested = new Stack<char>();
            List<string> result = new List<string>();

            foreach (string value in values)
            {
                nested.Clear();

                for (int i = 0; i < value.Length; i++)
                {
                    if (nested.Count == 0)
                    {
                        nested.Push(value[i]);
                    }
                    else
                    {
                        if ((nested.Peek() == '(' && value[i] == ')') || (nested.Peek() == '{' && value[i] == '}') || (nested.Peek() == '[' && value[i] == ']'))
                        {
                            nested.Pop();
                        }
                        else
                        {
                            nested.Push(value[i]);
                        }
                    }
                }

                if (nested.Count > 0)
                    result.Add("NO");
                else
                    result.Add("YES");
            }

            return result.ToArray();
        }
    }
}
