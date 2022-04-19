using System.Runtime.CompilerServices;
using System.Text;
using Alvis.Script.Core.Models;

namespace Alvis.Script.Core
{
    internal class Lexer
    {
        private readonly TokenDefinitions _tokenDefinitions;

        public Lexer()
        {
            _tokenDefinitions = new TokenDefinitions();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining
                    | MethodImplOptions.AggressiveOptimization)]
        public IList<Token> GetTokens(in string scriptFilePath)
        {
            IList<Token> tokens = new List<Token>();

            using var streamReader = File.OpenText(scriptFilePath);

            int readerLine = 0;
            while (true)
            {
                if (streamReader.Peek() < 0) break;

                if (streamReader.Peek() == '#') //Code comment
                {
                    while (true)
                    {
                        if (streamReader.EndOfStream) break;
                        streamReader.Read(); //skipping...

                        if (streamReader.Peek() == '\n')
                        {
                            readerLine++;
                            streamReader.Read();
                            break; //End of line, exiting.
                        }
                    }
                }

                char c = (char)streamReader.Read();
                if (c == '\n') readerLine++;

                if (c == '"') //reading string then
                {
                    var stringContent = new StringBuilder();
                    while (!streamReader.EndOfStream)
                    {
                        char stringContentChar = (char)streamReader.Read();

                        if (stringContentChar == '"')
                        {
                            if (streamReader.Peek() == ')')
                            {
                                tokens.Add(new Token(TokenType.StringValue)
                                {
                                    Line = readerLine,
                                    Value = stringContent.ToString()
                                });

                                break; //Exit string content read
                            }
                        }
                        stringContent.Append(stringContentChar);
                    }
                }

                if (_tokenDefinitions.IsMatch(in c))
                {
                    var token = _tokenDefinitions.GetToken(c);
                    token.Line = readerLine;
                    tokens.Add(token);
                }
            }
            foreach (var token in tokens)
            {
                if (token.Value == null)
                    Console.WriteLine($"AlvisScript Token at {tokens.IndexOf(token)}: [Type={token.Type}, Line: {token.Line}]");
                else
                    Console.WriteLine($"AlvisScript Token at {tokens.IndexOf(token)}: [Type={token.Type}, Line: {token.Line}, Value = '{token.Value}']");
            }
            return tokens;
        }
    }
}
