namespace ExpressionEvaluatorApp;

public interface ITokenizer
{
    IEnumerable<Token> Tokenize(string expression);
}