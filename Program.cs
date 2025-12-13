using NUnit.Framework;
using System;

namespace MyProject
{
    public class Program
    {
        // 1.1. Сортировка массива
        public static void SortArray(int[] arr)
        {
            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        // 1.2. Проверка палиндрома
        public static bool IsPalindrome(string str)
        {
            string cleanStr = "";
            foreach (char c in str.ToLower())
            {
                if (char.IsLetterOrDigit(c))
                    cleanStr += c;
            }
            
            for (int i = 0; i < cleanStr.Length / 2; i++)
            {
                if (cleanStr[i] != cleanStr[cleanStr.Length - 1 - i])
                    return false;
            }
            return true;
        }

        // 1.3. Факториал
        public static long Factorial(int n)
        {
            if (n < 0) return -1;
            long result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }

        // 1.4. Число Фибоначчи
        public static int Fibonacci(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;
            
            int a = 0, b = 1, result = 0;
            for (int i = 2; i <= n; i++)
            {
                result = a + b;
                a = b;
                b = result;
            }
            return result;
        }

        // 1.5. Поиск подстроки
        public static int FindSubstring(string text, string substring)
        {
            if (string.IsNullOrEmpty(substring)) return 0;
            
            for (int i = 0; i <= text.Length - substring.Length; i++)
            {
                bool found = true;
                for (int j = 0; j < substring.Length; j++)
                {
                    if (text[i + j] != substring[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found) return i;
            }
            return -1;
        }

        // 1.6. Проверка простого числа
        public static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        // 1.7. Обратное число
        public static int ReverseNumber(int x)
        {
            int sign = x < 0 ? -1 : 1;
            long num = Math.Abs((long)x);
            long reversed = 0;
            
            while (num > 0)
            {
                reversed = reversed * 10 + num % 10;
                num /= 10;
            }
            
            reversed *= sign;
            if (reversed < int.MinValue || reversed > int.MaxValue)
                return 0;
                
            return (int)reversed;
        }

        // 1.8. Римская система
        public static string ToRoman(int x)
        {
            if (x < 1 || x > 3999) return "Invalid number";
            
            string[] thousands = {"", "M", "MM", "MMM"};
            string[] hundreds = {"", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"};
            string[] tens = {"", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"};
            string[] ones = {"", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"};
            
            return thousands[x / 1000] + 
                   hundreds[(x % 1000) / 100] + 
                   tens[(x % 100) / 10] + 
                   ones[x % 10];
        }
    }
}

namespace MyProject.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        // 1.1. Сортировка
        [Test] 
        public void SortArray_Unsorted() 
        { 
            int[] arr = {5, 2, 8, 1, 9};
            Program.SortArray(arr);
            Assert.AreEqual(new int[] {1, 2, 5, 8, 9}, arr);
        }

        [Test] 
        public void SortArray_AlreadySorted() 
        { 
            int[] arr = {1, 2, 3, 4, 5};
            Program.SortArray(arr);
            Assert.AreEqual(new int[] {1, 2, 3, 4, 5}, arr);
        }

        [Test] 
        public void SortArray_ReverseOrder() 
        { 
            int[] arr = {5, 4, 3, 2, 1};
            Program.SortArray(arr);
            Assert.AreEqual(new int[] {1, 2, 3, 4, 5}, arr);
        }

        [Test] 
        public void SortArray_WithDuplicates() 
        { 
            int[] arr = {3, 1, 2, 1, 3};
            Program.SortArray(arr);
            Assert.AreEqual(new int[] {1, 1, 2, 3, 3}, arr);
        }

        [Test]
        public void SortArray_SingleElement()
        {
            int[] arr = {42};
            Program.SortArray(arr);
            Assert.AreEqual(new int[] {42}, arr);
        }

        [Test]
        public void SortArray_EmptyArray()
        {
            int[] arr = { };
            Program.SortArray(arr);
            Assert.AreEqual(new int[] { }, arr);
        }

        // 1.2. Палиндром
        [Test] 
        public void IsPalindrome_Valid() 
        { 
            Assert.IsTrue(Program.IsPalindrome("казак"));
        }

        [Test] 
        public void IsPalindrome_NotPalindrome() 
        { 
            Assert.IsFalse(Program.IsPalindrome("привет"));
        }

        [Test] 
        public void IsPalindrome_WithSpaces() 
        { 
            Assert.IsTrue(Program.IsPalindrome("а роза упала на лапу азора"));
        }

        [Test] 
        public void IsPalindrome_EmptyString() 
        { 
            Assert.IsTrue(Program.IsPalindrome(""));
        }

        // Факториал
        [Test] 
        public void Factorial_Positive() 
        { 
            Assert.AreEqual(120, Program.Factorial(5));
        }

        [Test] 
        public void Factorial_Zero() 
        { 
            Assert.AreEqual(1, Program.Factorial(0));
        }

        [Test] 
        public void Factorial_One() 
        { 
            Assert.AreEqual(1, Program.Factorial(1));
        }

        [Test] 
        public void Factorial_Negative() 
        { 
            Assert.AreEqual(-1, Program.Factorial(-5));
        }

        // Фибоначчи
        [Test] 
        public void Fibonacci_Positive() 
        { 
            Assert.AreEqual(5, Program.Fibonacci(5));
        }

        [Test] 
        public void Fibonacci_Zero() 
        { 
            Assert.AreEqual(0, Program.Fibonacci(0));
        }

        [Test] 
        public void Fibonacci_One() 
        { 
            Assert.AreEqual(1, Program.Fibonacci(1));
        }

        [Test] 
        public void Fibonacci_Large() 
        { 
            Assert.AreEqual(55, Program.Fibonacci(10));
        }

        // Подстрока
        [Test] 
        public void FindSubstring_Exists() 
        { 
            Assert.AreEqual(7, Program.FindSubstring("Привет мир", "мир"));
        }

        [Test] 
        public void FindSubstring_NotExists() 
        { 
            Assert.AreEqual(-1, Program.FindSubstring("Привет", "мир"));
        }

        [Test] 
        public void FindSubstring_AtStart() 
        { 
            Assert.AreEqual(0, Program.FindSubstring("Привет мир", "Привет"));
        }

        [Test] 
        public void FindSubstring_EmptySubstring() 
        { 
            Assert.AreEqual(0, Program.FindSubstring("Привет мир", ""));
        }

        // Простые числа
        [Test]
        public void IsPrime_PrimeNumber() 
        { 
            Assert.IsTrue(Program.IsPrime(17));
        }

        [Test]
        public void IsPrime_NotPrimeNumber() 
        { 
            Assert.IsFalse(Program.IsPrime(15));
        }

        [Test]
        public void IsPrime_One() 
        { 
            Assert.IsFalse(Program.IsPrime(1));
        }

        [Test]
        public void IsPrime_NegativeNumber() 
        { 
            Assert.IsFalse(Program.IsPrime(-5));
        }

        [Test]
        public void IsPrime_Zero() 
        { 
            Assert.IsFalse(Program.IsPrime(0));
        }

        // Обратное число
        [Test] 
        public void ReverseNumber_Positive() 
        { 
            Assert.AreEqual(321, Program.ReverseNumber(123));
        }

        [Test] 
        public void ReverseNumber_Negative() 
        { 
            Assert.AreEqual(-321, Program.ReverseNumber(-123));
        }

        [Test] 
        public void ReverseNumber_WithZero() 
        { 
            Assert.AreEqual(21, Program.ReverseNumber(120));
        }

        [Test] 
        public void ReverseNumber_Overflow() 
        { 
            Assert.AreEqual(0, Program.ReverseNumber(2147483647));
        }

        // Римские цифры
        [Test] 
        public void ToRoman_Simple() 
        { 
            Assert.AreEqual("XII", Program.ToRoman(12));
        }

        [Test] 
        public void ToRoman_WithFour() 
        { 
            Assert.AreEqual("XIV", Program.ToRoman(14));
        }

        [Test] 
        public void ToRoman_WithNine() 
        { 
            Assert.AreEqual("XIX", Program.ToRoman(19));
        }

        [Test] 
        public void ToRoman_Invalid() 
        { 
            Assert.AreEqual("Invalid number", Program.ToRoman(0));
        }
    }
}

