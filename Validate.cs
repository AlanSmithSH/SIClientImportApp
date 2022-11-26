using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIClientImport
{
    public class Validate
    {
        public static bool checkInt(string value)
        {
            if(value.Length == 0 || (!int.TryParse(value, out int result)))
            {
                Form1.strErrorDetail = "Value could not be parsed into integer.";
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
                Form1.strErrorDetail = "Value exceeds size limit of field. Size limit is " + fieldsize.ToString() + " and string is " + value.Length.ToString();
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
                Form1.strErrorDetail="Value could not be parsed into single (for money entry).";
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
                Form1.strErrorDetail = "Value expected is 0 or 1 to convert to true/false or bit.";
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool checkDate (string value)
        {
            if (!string.IsNullOrEmpty(value)  && (!DateTime.TryParse(value, out _)))

            {
                Form1.strErrorDetail = "Value is expected to be in date format selected. Could not be parsed.";

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
                Form1.strErrorDetail = "Value is expected to be whole number from 0-255.";

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
                Form1.strErrorDetail = "Value is expected to be a single character.";

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

        public static int convertToInt32 (string oldValue)
        {
            int result = int.Parse(oldValue);
            return result;
        }

        public static bool convertToBool (string oldValue)
        {
            bool result;
            if (oldValue == "Y" || oldValue == "1" || oldValue == "T")
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public static DateTime? convertToDateTime (string oldValue)
        {
            if (oldValue.Length==0)
            {
                DateTime? result2 = null;
                return (DateTime?)result2;
            }
            DateTime? result;
            if (DateTime.TryParse(oldValue, out DateTime dTime))
            {
                result = dTime;
                return result;
            }
            else 
            {
                //result = DateTime.Parse("1/1/99");
                result = null;
                return result;
            }

            
        }

        public static Single convertToSingle (string oldValue)
        {
            Single result = Single.Parse(oldValue);
            return result;
        }

        public static Guid convertToGuid (string oldValue)
        {
            int temp = int.Parse(oldValue);
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(temp).CopyTo(bytes, 0);
            return new Guid(bytes);

        }

        public static decimal convertToDecimal(string oldValue)
        {
            decimal result = decimal.Parse(oldValue);
            return result;
        }

        public static char convertToChar(string oldValue)
        {
            char result = char.Parse(oldValue);
            return result;
        }

        public static string applyDateFormat (string value, string format)
        {
            string result;
            try
            {
                if (value.Length != format.Length) 
                {
                    result = "fail";
                }
                else if (value.Contains("/") && !format.Contains("/"))
                {
                    result = "fail";
                }
                else if (!value.Contains("/") && format.Contains("/"))
                {
                    result = "fail";
                }
                else if (value.Contains("-") && !format.Contains("-"))
                {
                    result = "fail";
                }
                else if (!value.Contains("-") && format.Contains("-"))
                {
                    result = "fail";
                }
                result = DateTime.ParseExact(value, format, CultureInfo.InvariantCulture).ToString();
                return result;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error converting " + value + " to date format :" + ex.Message);
                result = "fail";
            }
            return result;
        }

    }
}
