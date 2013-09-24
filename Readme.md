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

