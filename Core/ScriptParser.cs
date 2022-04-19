using Alvis.Script.Core;
using Alvis.Script.Models;

namespace Alvis.Script
{
    internal class ScriptParser
    {
        private const string FileExtension = ".as";

        private readonly ScriptEngineOptions _options;
        private readonly Lexer _lexer;

        public ScriptParser(ScriptEngineOptions options)
        {
            _options = options;
            _lexer = new Lexer();
        }

        public void Parse(string scriptName)
        {
            string fileName = scriptName + FileExtension;
            string fullPath = Path.Combine(_options.WorkingDirectory, fileName);

            if (!File.Exists(fullPath))
            {
                System.Diagnostics.Debug.WriteLine($"Script {scriptName} failed to execute, it doesn't exist.");
                return;
            }
            System.Diagnostics.Debug.WriteLine("Attempting to execute script " + fullPath);
            var tokens = _lexer.GetTokens(in fullPath);
        }

    }
}
