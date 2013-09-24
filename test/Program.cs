using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace test {
    class Program {
        static void Main(string[] args)
        {
            var highlighter = new Pygments.Highlighter();
            var src = File.ReadAllText(@"..\..\..\..\..\test\program.cs");
            File.WriteAllText("output.html", highlighter.HighlightToHtml(src, "c#", "vs", highlightLines: "7 8 9 10"));
        }
    }
}
