using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Pyg {
    using System.Collections;
    using System.Collections.Generic;

    public static class Extensions {
        public static bool ContainsAny<T>(this IEnumerable<T> collection, params T[] items) {
            return collection.Any(items.Contains);
        }

        public static string Value(this IEnumerable<string> options, string optionName, string defaultValue) {
            var v = Value(options, optionName);
            if (string.IsNullOrEmpty(v)) {
                return defaultValue;
            }
            return v;
        }


        public static string Value(this IEnumerable<string> options, string optionName) {
            optionName = optionName + "=";
            return (options.LastOrDefault(each => each.StartsWith(optionName)) ?? optionName).Substring(optionName.Length);
        }

        public static string[] Values(this IEnumerable<string> options, string optionName) {
            optionName = optionName + "=";
            var p = optionName.Length;
            return (options.Where(each => each.StartsWith(optionName)).Select(each => each.Substring(p))).ToArray();
        }

        public static string[] Values(this IEnumerable<string> options, string optionName, string defaultValue) {
            var v = Values(options, optionName);
            if (v == null || !v.Any()) {
                return new[] {defaultValue};
            }
            return v;
        }
    }

    class Pygmentize {
        static void Help() {
            
        }

        static void Main(string[] args)
        {
            var opts = args.Where(each => each.StartsWith("--")).Select( each=> each.TrimStart('-').ToLower()).ToArray();
            var files = args.Where(each => !each.StartsWith("--")).ToArray();

            
            if (files.Length == 0 || opts.ContainsAny("help", "?", "h" )) {
                Help();
                return;
            }

            var language = opts.Value("language",null);
            var style = opts.Value("style","scite") ;
            var outputs = opts.Values("output", "html").Distinct().ToArray();

            var highlighter = new Pygments.Highlighter();
            

            foreach (var o in outputs) {
                switch (o) {
                    case "html":
                        try {
                            foreach (var f in files) {
                                Console.WriteLine("Highlighting : [{0}] to [{0}.html]" , f);

                                File.WriteAllText(f + ".html", highlighter.HighlightToHtml(File.ReadAllText(f), language, style, f, preStyles: "font-family: consolas, courier", generateInlineStyles: true));
                            }
                        }
                        catch (Exception e) {
                            Console.Error.WriteLine("{0},{1}/{2}", e.Message, e.GetType().Name, e.StackTrace);
                        }
                        break;
                    case "bbcode":
                        break;
                    case "rtf":
                        foreach (var f in files) {
                            Console.WriteLine("Highlighting : [{0}] to [{0}.rtf]", f);
                            File.WriteAllText(f + ".rtf",
                                highlighter.HighlightToRTF(File.ReadAllText(f), language, style, f, fontFace: "consolas"));
                        }
                        break;
                    case "latex":
                        break;
                    default:
                        Console.Error.WriteLine("Unknown output type '{0}' -- skipping", o);
                        break;
                }
            }
        }
    }
}
