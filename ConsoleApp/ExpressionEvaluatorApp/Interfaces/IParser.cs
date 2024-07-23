namespace ExpressionEvaluatorApp;

public interface IParser
{
    SyntaxNode Parse(IEnumerable<Token> tokens);
}