using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Text;

class kanji
{
    static void Main()
    {
        int intValue = 12345;
        float floatValue = 1234.56f;

        Console.WriteLine($"整数: {intValue} → {ToKanjiNumber(intValue)}");
        Console.WriteLine($"浮動小数点数: {floatValue} → {ToKanjiNumber(floatValue)}");
    }

    static string ToKanjiNumber(int number)
    {
        string[] kanjiDigits = { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
        string[] kanjiUnits = { "", "十", "百", "千" };

        StringBuilder result = new StringBuilder();
        char[] digits = number.ToString().ToCharArray();

        for (int i = 0; i < digits.Length; i++)
        {
            int digit = int.Parse(digits[i].ToString());
            if (digit != 0)
            {
                result.Append(kanjiDigits[digit]);
                result.Append(kanjiUnits[digits.Length - i - 1]);
            }
            else
            {
                // 連続する0を無視
                if (i == digits.Length - 1 || digits[i + 1] != '0')
                    result.Append(kanjiDigits[digit]);
            }
        }

        return result.ToString();
    }

    static string ToKanjiNumber(float number)
    {
        // 小数点以下の桁数を指定
        int decimalPlaces = 2;

        int intValue = (int)number;
        float decimalValue = number - intValue;

        string integerPart = ToKanjiNumber(intValue);

        StringBuilder result = new StringBuilder(integerPart);

        if (decimalValue > 0)
        {
            result.Append("点");

            string decimalPart = decimalValue.ToString("F" + decimalPlaces).Substring(2);
            foreach (char digit in decimalPart)
            {
                result.Append(ToKanjiNumber(int.Parse(digit.ToString())));
            }
        }

        return result.ToString();
    }
}
