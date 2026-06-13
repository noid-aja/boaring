using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WinFormsApp1.Controllers
{
    static class Validator
    {
        public static bool ApakahKosong(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        public static bool ApakahAngka(string input)
        {
            return int.TryParse(input, out _);
        }

        public static bool ApakahPanjang(int min, string input, int? max = null)
        {
            int panjangInput = input.Length;
            if (max == null)
            {
                return panjangInput >= min;
            }
            else
            {
                return panjangInput >= min && panjangInput <= max;
            }
        }

        public static bool ApakahHurufdanAngka(string input)
        {
            return input.All(ch => char.IsLetterOrDigit(ch));
        }
    }
}
