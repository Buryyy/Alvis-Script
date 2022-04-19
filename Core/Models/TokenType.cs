using System;


namespace Alvis.Script.Core.Models
{
    public enum TokenType
    {
        Match,
        Comma, 
        StringValue,
        OpenBrace,
        CloseBrace,
        OpenBracket,
        CloseBracket,
        SequenceTerminator,
        SemiColon,
        Message,
        BlockComment
    }
}
