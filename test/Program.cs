using System.IO;

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
