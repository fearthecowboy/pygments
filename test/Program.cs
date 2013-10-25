using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace test {
    class Program {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Need Input files.");
            }
            var Settings = new XmlWriterSettings {
                Indent = true,
                IndentChars = " ",
                NewLineHandling = NewLineHandling.None,
                
                NewLineOnAttributes = true
            };
            
            foreach (var f in args)
            {
                try
                {
#if pretty_print

                    bool isXml = true;
                    string xmlFile = string.Empty;
                    try
                    {
                        var xdoc = XDocument.Load(f);
                        var writer = XmlWriter.Create(f + ".xmltmp", Settings);
                        xdoc.WriteTo(writer);
                        writer.Close();
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("{0},{1}/{2}", e.Message, e.GetType().Name, e.StackTrace);
                        isXml = false;
                    }
                    var src = File.ReadAllText( isXml ? f +".xmltmp":f);
#endif

                    var highlighter = new Pygments.Highlighter();
                    var src = File.ReadAllText( f);
                    File.WriteAllText(f + ".html",
                        highlighter.HighlightToHtml(src, "xml", "scite", preStyles: "font-family: consolas, courier",
                            generateInlineStyles: true));
                    File.WriteAllText(f + ".rtf",
                        highlighter.HighlightToRTF(src, "xml", "scitedark" , fontFace:"consolas"));

                    if (File.Exists(f + ".xmltmp")) {
                        // File.Delete(f + ".xmltmp");
                    }

                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("{0},{1}/{2}", e.Message, e.GetType().Name, e.StackTrace);
                }
            }
        }
    }
}
