using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Utils
{
    public static class CpfValidator
    {
        public static bool IsACpfValid(string cpfNumber)
        {

            if (string.IsNullOrWhiteSpace(cpfNumber))
                return false;

            cpfNumber = FormatCpf(cpfNumber);

            if (!(cpfNumber.All(c => c >= '0' && c <= '9') && cpfNumber.Length == 11))
                return false;

            for (int i = 0; i < 10; i++)
            {
                string fakeCpf = i.ToString().PadLeft(11, char.Parse(i.ToString()));

                if (fakeCpf == cpfNumber)
                    return false;
            }

            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string cpfTobeValidated = cpfNumber[..9];
            int sum = 0;
            string digits = "";
            int remainder = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(cpfTobeValidated[i].ToString()) * multiplier1[i];


            remainder = sum % 11;

            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;


            digits = remainder.ToString();
            cpfTobeValidated += digits;


            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(cpfTobeValidated[i].ToString()) * multiplier2[i];


            remainder = sum % 11;

            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            digits += remainder.ToString();

            return cpfNumber.EndsWith(digits);
        }

        public static string FormatCpf(string cpf)
        {
            return cpf.Trim().Replace(".", "").Replace("-", "");
        }
    }

}