using System;
using System.Collections.Generic;
using System.Text;

namespace ICT
{
    class _4
    {
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {

            string concat1 = string.Join("", word1);
            string concat2 = string.Join("", word2);

            bool flag = false;

            if (concat1.Length == concat2.Length)
            {
                for (int i = 0; i < concat1.Length; i++)
                {
                    if (concat1[i] == concat2[i])
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }

                    if (!flag)
                    {
                        break;
                    }
                }
            }

            return flag;
        }
    }
}
