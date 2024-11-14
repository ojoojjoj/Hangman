using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal interface IMenuVariant
    {
        public List<string> Options { get; }

        public int Choice { get; set; }

        void MenuChoice();

    }
}
