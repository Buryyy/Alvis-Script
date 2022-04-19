namespace Alvis.Script.Models;

public class ScriptEngineOptionsBuilder
{
    private ScriptEngineOptions _options;

    public ScriptEngineOptionsBuilder Create()
    {
        _options = new ScriptEngineOptions();
        return this;
    }

    /// <summary>
    /// Assign's a working directory of where the scripts are stored.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public ScriptEngineOptionsBuilder WithWorkingDirectory(string path)
    {
        _options.WorkingDirectory = path;
        return this;
    }

    internal ScriptEngineOptions Build()
    {
        if (_options == null)
        {
            throw new InvalidOperationException("Options are NULL, make sure to call Create() first.");
        }
        
        if (!Directory.Exists(_options.WorkingDirectory))
        {
            throw new DirectoryNotFoundException($"Couldn't find {_options.WorkingDirectory}.");
        }
        return _options;
    }



}