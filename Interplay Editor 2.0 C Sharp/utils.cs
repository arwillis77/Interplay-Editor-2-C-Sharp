using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interplay_Editor_2_C_Sharp
{
    class utils
    {
        /// <summary>
        /// ShortToHex - Converts Short 2-byte Integer to Hexadecimal
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        public static string ShortToHex(int w)
        {
            char[] b = {'0','1','2','3','4','5','6','7',                         /* Initialize Values for Hex */
                        '8','9','A','B','C','D','E','F'};                      
            char[] s = new char[4];                                             /* Initialize array with padding.  Set size as 4 (0-3)*/
          
            s[0] = b[(w >> 12) & 15];
            s[1] = b[(w >> 8) & 15];
            s[2] = b[(w >> 4) & 15];
            s[3] = b[w  & 15];

            string _MakeHex = new string(s, 0, s.Count());
            return _MakeHex;

        }

    }
}
