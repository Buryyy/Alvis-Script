
# Alvis Script

Scripting language made for game server backend scripting such as chat dialogues. 

**Features**
- Lexer
- Tokenization
- Parser
- Fluent engine builder
- Run natively with C# 


## Status

Currently this language is **not** ready to use.


## Usage/Examples

```csharp

var options = new ScriptEngineOptionsBuilder()
.WithWorkingDirectory(Path.Combine(Environment.CurrentDirectory, "scripts"))//Executes scripts at "running directory/scripts".
.Build(); 
var engine = new ScriptEngine(options); //Include options with engine.

//Executing a script:
engine.Execute("my_script.as");

```



[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg)](https://opensource.org/licenses/)
