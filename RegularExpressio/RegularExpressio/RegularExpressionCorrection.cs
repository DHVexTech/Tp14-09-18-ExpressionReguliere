using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegularExpression
{
    [TestFixture]
    class RegularExpressionCorrection
    {
        //[TestCase("ab|c", "(| (+ a b) c)")]
        //[TestCase("ab|c", "(| (+ a b) (* c))")]
        //[TestCase("a(b|c)", "(+ a (* (| b c)))")]
        //[TestCase("(ab|xc)", "(| (+ a b) c)")]
        public void truc(string regex, string expected)
        {
            Parser parser = new Parser(regex);
            Node ast = parser.Parse();
            Assert.That(ast.ToString(), Is.EqualTo(expected));
        }
    }
}
