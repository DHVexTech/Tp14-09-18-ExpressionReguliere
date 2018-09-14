using System;
using System.Collections.Generic;
using System.Text;

namespace RegularExpression
{
    public class Parser
    {
        readonly Cursor _cursor;
        public Parser()
        {

        }

        public Node Parse()
        {
            Node exp = ParseRegex();
            if (exp == null) return null;

            if (_cursor.Current == 0) return exp;
            return null;
        }

        Node ParseRegex()
        {
            Node root = null;
            while (true)
            {
                Node node = ParseConcatExp();
                
                if (node == null) return node;
                if (root == null) root = node;
                else root = new Node('|', root, node);
                if (_cursor.Current == '|')
                {
                    _cursor.Next();
                    continue;
                }
                else
                {
                    return root;
                }
            }
        }

        Node ParseConcatExp()
        {
            Node root = null;
            do
            {
                Node exp = ParseStarizableExp();
                if (root == null) root = exp;
                else root = new Node('+', root, exp);
                if (exp == null) return null;
            } while (_cursor.Current == '(' || char.IsLetterOrDigit(_cursor.Current));

            return root;
        }

        Node ParseStarExp()
        {
            Node exp = ParseStarizableExp();
            if (exp == null) return null;

            if (_cursor.Current == '*')
            {
                exp = new Node('*', exp, null);
                _cursor.Next();
            }
            return exp;
        }

        Node ParseStarizableExp()
        {
            if (_cursor.Current == '(') return ParseRegex();
            if (char.IsLetterOrDigit(_cursor.Current)) return ParseCharExp();
            return null;
        }

        Node ParseParenthesisExp()
        {
            if (_cursor.Current != '(') return null;
            _cursor.Next();
            Node exp = ParseRegex();
            if (_cursor.Current != ')') return null;
            _cursor.Next();
            return exp;
        }

        Node ParseCharExp()
        {
            if (!char.IsLetterOrDigit(_cursor.Current)) return null;
            Node node = new Node(_cursor.Current);
            _cursor.Next();
            return node;
        }
    }
}
