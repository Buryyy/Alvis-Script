using System.Runtime.CompilerServices;
using Alvis.Script.Core.Models;

namespace Alvis.Script.Core
{
    internal class TokenDefinitions
    {
        private readonly IDictionary<char, Token> _definitions;

        public TokenDefinitions()
        {
            _definitions = new Dictionary<char, Token>()
            {
                { '{', new Token(TokenType.OpenBracket) },
                { '}', new Token(TokenType.CloseBracket) },


                { '(', new Token(TokenType.OpenBrace) },
                { ';', new Token(TokenType.SemiColon ) },
                { ')', new Token(TokenType.CloseBrace ) },
            };
        }

        public Token GetToken(char tokenName) =>
            _definitions[tokenName] ?? throw new KeyNotFoundException("Couldn't parse token " + tokenName);

        [MethodImpl(MethodImplOptions.AggressiveInlining
                    | MethodImplOptions.AggressiveOptimization)]
        public bool IsMatch(in char character)
        {
            return _definitions.ContainsKey(character);
        }
    }
}
