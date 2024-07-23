namespace ExpressionEvaluatorApp;

public class ExpressionEvaluator : IExpressionEvaluator
{
    private readonly ITokenizer _tokenizer;
    private readonly IParser _parser;

    public ExpressionEvaluator(ITokenizer tokenizer, IParser parser)
    {
        _tokenizer = tokenizer;
        _parser = parser;
    }

    public double Evaluate(string expression)
    {
        var tokens = _tokenizer.Tokenize(expression);
        var syntaxTree = _parser.Parse(tokens);
        return syntaxTree.Evaluate();
    }
}