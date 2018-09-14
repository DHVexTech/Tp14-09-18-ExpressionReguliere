using System;
using System.Collections.Generic;
using System.Text;

namespace RegularExpression
{
    public class Cursor
    {
        readonly string _s;
        int _idx;

        public Cursor(string s)
        {
            _s = s ?? string.Empty;
        }

        public char Current
        {
            get { return Lookahead(0);   }
        }

        public void Next()
        {
            _idx++;
        }

        public char Lookahead(int n)
        {
            if (_idx + n >= _s.Length) return (char)0;
            return _s[_idx + n];
        }
    }
}
