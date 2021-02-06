using System;
using System.Collections.Generic;
using System.Text;

namespace ICT
{
    class _2
    {
        public string DefangIPaddr(string IP)
        {

            string ans = "";
            for (int i = 0; i < IP.Length; i++)
            {
                if (IP[i] == '.')
                {
                    ans += "[.]";
                }
                else
                {
                    ans += IP[i];
                }
            }

            return ans;
        }
    }
}
