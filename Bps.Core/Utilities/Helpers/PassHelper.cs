using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bps.Core.Utilities.Helpers
{
    public static class PassHelper
    {
        public static string GeneratePassword(string yetki, int passLength = 6, string machineInfo = "", DateTime? date = null, bool numeric = true)
        {
            DateTime currentDate = date == null ? DateTime.Now.Date : date.Value.Date; //date parametresi verilmezse anlık tarihi alır
            string combinedString = $"{currentDate.ToString("ddMMyyyy")}_{yetki}_{machineInfo}"; //Makineye özel şifre oluşturulmak istenirse machineInfo parametresi olarak verilebilir
            string hashedString = HashString(combinedString).ToUpper();
            if (numeric) hashedString = GetNumericString(hashedString);

            return hashedString.Substring(0, Math.Min(passLength, hashedString.Length));
        }

        private static string HashString(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashedBytes).Replace("-", "");
            }
        }

        private static string GetNumericString(string input)
        {
            StringBuilder numericStringBuilder = new StringBuilder();
            foreach (char c in input)
            {
                numericStringBuilder.Append(((int)c).ToString());
            }
            return numericStringBuilder.ToString();
        }
    }
}
