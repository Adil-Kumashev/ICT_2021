using System;
using System.Collections.Generic;
using System.Text;

namespace ICT
{
    class _3
    {
        public int NumberOfSteps(int num)
        {
            int cnt = 0;

            while (num != 0)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                }
                else
                {
                    num -= 1;
                }
                cnt++;
            }

            return cnt;
        }
    }
}
