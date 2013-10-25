# Pygments for .NET

No Runtime Dependencies required!


#### Building from the command line
If you're building this code, make sure you have NuGet 2.7 or later installed.

If you're building from the command line, you need to do a NuGet restore first:

```
	> nuget restore
	
	> msbuild Pygments.sln
   
```

The output will be found at:
> `$(SolutionDir)output\v40\AnyCPU\$(Configuration)\bin\ClrPlus.Pygments.dll`

#### Building from Visual Studio
If you're building this code, make sure you have NuGet 2.7 or later installed.

Just open the Pygments.sln and build!

The output will be found at:
> `$(SolutionDir)output\v40\AnyCPU\$(Configuration)\bin\ClrPlus.Pygments.dll`


## API

The Pygments for .NET library exposes two properties and four methods in the `Pygments.Highlighter` class

``` csharp

public static IEnumerable<Lexer> Lexers; //  all the language lexers available

public static IEnumerable<string> Styles; // all the Styles available 


public string HighlightToBBCode(
	string sourceCode, 
	string lexerName, 
	string styleName, 
	bool codeTag = false, 
	bool  monoFont = false );

public string HighlightToRTF(
	string sourceCode, 
	string lexerName, 
	string styleName, 
	string fontFace=null);

public string HighlightToHtml(
	string sourceCode, 
	string lexerName, 
	string styleName, 
	bool fragment = false, 
	string title = "", 
	bool generateInlineStyles = false, 
	string classPrefix = "", 
    string wrappingDivClass = "highlight", 
    string wrappingDivStyles = "", 
    string preStyles = "", 
    LineNumberStyle lineNumberStyle = LineNumberStyle.none, 
    int lineNumberStart = 1, 
    bool noBackground = false,  
    string lineBreaks="\n", 
    string lineAnchorPrefix = null, 
    string lineSpanPrefix = null, 
    bool anchorLineNumbers = false, 
    string highlightLines = "");

public string HighlightToLatex(
	string sourceCode, 
	string lexerName, 
	string styleName, 
	bool fragment = false, 
	string title = "", 
	string documentClass = "article", 
	bool lineNumbers = false, 
	int lineNumberStart = 1, 
	int lineStep = 1, 
	bool texComments = false, 
	bool mathEscape = false ) 

```


## Usage

Quick Sample:

``` csharp

using System.IO;

namespace test {
    class Program {
        static void Main(string[] args)
        {
            var highlighter = new Pygments.Highlighter();
            var src = File.ReadAllText(@"program.cs");
            File.WriteAllText("output.html", highlighter.HighlightToHtml(src, "c#", "vs", highlightLines: "7 8 9 10"));
        }
    }
}


```


### History

I leveraged the rather great work to make this all function from

https://github.com/cvrajeesh/pygments-net

and added the bits to make it frictionless for anyone to consume.
