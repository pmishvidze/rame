using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.NET.Utilities
{
    public static class NumberHandler
    {
        #region lists
        private static List<string> numbers0_9 = new List<string>()
        {
            "",
            "erti",
            "ori",
            "sami",
            "otxi",
            "xuti",
            "eqvsi",
            "shvidi",
            "rva",
            "cxra"
        };

        private static List<string> numbers0_9Prefixies = new List<string>()
        {
            "",
            "as",
            "or",
            "sam",
            "otx",
            "xut",
            "eqvs",
            "shvid",
            "rva",
            "cxra"
        };

        private static List<string> numbers10_19 = new List<string>()
        {
            "ati",
            "tertmeti",
            "tormeti",
            "cameti",
            "totxmeti",
            "txutmeti",
            "teqvsmeti",
            "chvidmeti",
            "trvrameti",
            "cxrameti"
        };

        private static List<string> numbers20_90_prefixes = new List<string>()
        {
            "",
            "ocda",
            "ormocda",
            "samocda",
            "otxmocda"
        };

        private static List<string> numbers20_is_jeradebi = new List<string>()
        {
            "",
            "oci",
            "ormoci",
            "samoci",
            "otxmoci"
        };
        #endregion

        #region helper Get Functions
        private static string GetErtnishna(int x)
        {

            //if (CountNishna(x) != 1)
            //{
            //    return "";
            //}
            return numbers0_9[x];
        }
        private static string GetOrnishna(int x)
        {
            if (CountNishna(x) < 2)
            {
                return GetErtnishna(x);
            }
            if (9 < x && x < 20)
            {
                return numbers10_19[x % 10];
            }

            int xMod20 = x % 20;

            if (xMod20 == 0)
            {
                return numbers20_is_jeradebi[x / 20];
            }

            string str = numbers20_90_prefixes[x / 20];

            if (xMod20 < 10 && xMod20 != 0)
            {
                str = str + GetErtnishna(xMod20);
            }
            else // 10 <= xMod20 <= 19
            {
                str = str + numbers10_19[xMod20 % 10];
            }

            return str;

        }
        private static string GetSamnishna(int x)
        {
            if (CountNishna(x) < 3)
            {
                return GetOrnishna(x);
            }

            string str = "";
            int xMod100 = x % 100;
            int xDiv100 = x / 100;
            if (xMod100 == 0)
            {
                if (xDiv100 == 1)
                    return "asi";
                str += numbers0_9Prefixies[xDiv100];
                str += "asi";
                return str;
            }
            str += numbers0_9Prefixies[xDiv100];
            if (xDiv100 > 1)
            {
                str += "as";
            }

            str += ' ';
            str += GetOrnishna(xMod100);
            return str;
        }
        private static string Get4_5_6_nishna(int x)
        {
            if (CountNishna(x) < 4)
            {
                return GetSamnishna(x);
            }

            string str = "";
            int xMod1000 = x % 1000;
            int xDiv1000 = x / 1000;
            if (xMod1000 == 0 && CountNishna(xDiv1000) == 1)
            {
                if (xDiv1000 == 1)
                    return "atasi";
                str += numbers0_9[xDiv1000];
                str += " atasi";
                return str;
            }
            int t = (x - xMod1000) / 1000;
            if (t == 1)
            {
                str += "atas";
            }
            else
            {
                str += GetSamnishna(t);

                if (xDiv1000 > 1)
                {
                    str += " atas";
                }
            }
            if (xMod1000 > 0)
            {
                str += ' ';
                str += GetSamnishna(xMod1000);
            }
            else
            {
                str += "i";
            }
            return str;
        }

        private static string Get7_8_9_nishna(int x)
        {
            if (CountNishna(x) < 7)
            {
                return Get4_5_6_nishna(x);
            }

            string str = "";
            int xMod1000000 = x % 1000000;
            int xDiv1000000 = x / 1000000;
            if (xMod1000000 == 0 && CountNishna(xDiv1000000) == 1)
            {
                if (xDiv1000000 == 1)
                    return "milioni";
                str += numbers0_9[xDiv1000000];
                str += " milioni";
                return str;
            }
            int t = (x - xMod1000000) / 1000000;
            if (t == 1)
            {
                str += "erti milion";
            }
            else
            {
                str += GetSamnishna(t);

                if (xDiv1000000 > 1)
                {
                    str += " milion";
                }
            }
            str += ' ';
            str += Get4_5_6_nishna(xMod1000000);
            return str;
        }

        private static string Get_10_nishna(int x)
        {
            if (CountNishna(x) < 10)
            {
                return Get7_8_9_nishna(x);
            }
            int xDiv1000000000 = x / 1000000000;
            int xMod1000000000 = x % 1000000000;
            string str = "";
            if (xDiv1000000000 == 2)
            {
                str += "ori ";
            }
            if (xMod1000000000 == 0)
            {
                str += "miliardi";
            }
            else
            {
                str += "miliard ";
            }
            return str + Get7_8_9_nishna(xMod1000000000);
        }
        #endregion
        private static int CountNishna(int x)
        {
            int c = 0;
            while (x != 0)
            {
                x /= 10;
                c++;
            }
            return c;
        }

        public static void NumberInWords(int x)
        {
            if (x < 0)
            {
                Console.Write("minus ");
                x = -x;
            }
            Console.WriteLine(NumberHandler.Get_10_nishna(x));
        }

    }
}
