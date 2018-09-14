using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegularExpression
{
    class RegularExpressionCode
    {
        private static int LetterCount { get; set; } = 0;

        /// n = lenght of the expression checked
        /// 
        public static bool ReCheck(string expression, string input)
        {
            int n;
            string[] expressions = expression.Split('|');
            foreach(string i in expressions)
            {
                n = 0;
                if (ValidExpr(expression, input, 0, out n) && n == i.Length)
                { return true; }
            }
            return false;
        }

        private static bool ValidExpr(string expression, string input, int start, out int n)
        {
            n = start;
            if (expression[0] == '*') return false;
            // change pointer
            while (n < expression.Length)
            {
                if (!ParsExpr()) return false;
            }
            return true;
        }

        private static bool ParsExpr()
        {
            throw new NotImplementedException();
        }

        private static bool CheckExpressionInInput(string input, bool multipleOrNone, char characterLoking)
        {
            bool alreadyFind = false;
            foreach(char i in input)
            {
                if (i == characterLoking && (!alreadyFind || multipleOrNone))
                {
                    LetterCount++;
                    alreadyFind = true;
                }
                else
                    return false;
            }
            return true;
        }

    }

    [TestFixture]
    class RegularExpressionCodeTest
    {
        [TestCase("ab*|c", "abb", true)]
        [TestCase("ab*|c", "abbc", false)]
        [TestCase("ab*|c", "c", true)]
        [TestCase("ab*|c", "cb", false)]
        public void TestRegularExpression(string expression, string input, bool expected)
        {
            Assert.That(RegularExpressionCode.ReCheck(expression, input), Is.EqualTo(expected));
        }
    }
}
