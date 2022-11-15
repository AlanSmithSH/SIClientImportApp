using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIClientImport
{
    public class Validate
    {
        public static bool checkInt(string value)
        {
            if(value.Length == 0 || (!int.TryParse(value, out int result)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool checkString(string value, int fieldsize)
        {
            if (value.Length > fieldsize || (value.GetType() != typeof (string)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool checkMoney (string value)
        {
            if (value.Length == 0 || (!Single.TryParse(value, out float result)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool checkBit (string value)
        {
            if (value.Length > 1 || (value != "0" && value != "1") )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool checkDate (string value)
        {
            if (value.Length == 0 || (!DateTime.TryParse(value, out _)))
            { 
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool checkTinyInt(string value)
        {
            if (value.Length == 0 || (!int.TryParse(value, out int result)) || int.Parse(value) < 0 || int.Parse(value)>255)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool checkChar(string value)
        {
            if (value.Length > 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool checkNumeric (string value)
        {
            return Single.TryParse(value, out _);
        }

        public static bool checkDecimal (string value)
        {
            return decimal.TryParse(value, out _);
        }
    }
}
