namespace Alvis.Script.Core.Models;

public record Token(TokenType Type)
{
    public int Line { get; set; }
    public string? Value { get; set; }
}