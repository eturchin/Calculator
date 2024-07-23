using System.Text.RegularExpressions;

namespace ExpressionEvaluatorApp;

public class Tokenizer : ITokenizer
{
    private static readonly Regex TokenRegex = new(@"\d+(\.\d+)?|[+\-*/()]");

    public IEnumerable<Token> Tokenize(string expression)
    {
        var matches = TokenRegex.Matches(expression);

        foreach (Match match in matches)
        {
            if (double.TryParse(match.Value, out _))
            {
                yield return new Token(TokenType.Number, match.Value);
            }
            else
            {
                yield return new Token(TokenType.Operator, match.Value);
            }
        }
    }
}