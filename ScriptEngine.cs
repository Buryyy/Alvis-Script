using Alvis.Script.Models;

namespace Alvis.Script
{
    public class ScriptEngine
    {
        private readonly ScriptParser _parser;

        public ScriptEngineOptions Options { get; }

        private bool _engineIsInitialized;

        public ScriptEngine(ScriptEngineOptionsBuilder options)
        {
            Options = options.Build();
            _parser = new ScriptParser(Options);
        }

        public void Init()
        {
            _engineIsInitialized = true;
        }

        public void Execute(string scriptName)
        {
            if (!_engineIsInitialized)
                throw new InvalidOperationException("Engine is not initialized. Make sure to call .Init() to start the engine first before running scripts.");
            _parser.Parse(scriptName);
        }
    }
}
