using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace Pygments
{
    internal static class PyExtensions
    {
        internal static dynamic Import(this ScriptRuntime runtime, string moduleName)
        {
            return Python.ImportModule(Python.GetEngine(runtime), moduleName);
        }
    }
}