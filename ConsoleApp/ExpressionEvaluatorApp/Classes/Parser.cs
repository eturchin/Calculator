namespace ExpressionEvaluatorApp;

public class Parser : IParser
{
    public SyntaxNode Parse(IEnumerable<Token> tokens)
    {
        var enumerator = tokens.GetEnumerator();
        enumerator.MoveNext();
        return ParseExpression(enumerator);
    }

    private SyntaxNode ParseExpression(IEnumerator<Token> enumerator)
    {
        var left = ParseTerm(enumerator);

        while (enumerator.Current != null && (enumerator.Current.Value == "+" || enumerator.Current.Value == "-"))
        {
            var operation = enumerator.Current.Value;
            enumerator.MoveNext();
            var right = ParseTerm(enumerator);
            left = new BinaryOperationNode(left, right, operation);
        }

        return left;
    }

    private SyntaxNode ParseTerm(IEnumerator<Token> enumerator)
    {
        var left = ParseFactor(enumerator);

        while (enumerator.Current != null && (enumerator.Current.Value == "*" || enumerator.Current.Value == "/"))
        {
            var operation = enumerator.Current.Value;
            enumerator.MoveNext();
            var right = ParseFactor(enumerator);
            left = new BinaryOperationNode(left, right, operation);
        }

        return left;
    }

    private SyntaxNode ParseFactor(IEnumerator<Token> enumerator)
    {
        if (enumerator.Current.Type == TokenType.Number)
        {
            var number = double.Parse(enumerator.Current.Value);
            enumerator.MoveNext();
            return new NumberNode(number);
        }

        if (enumerator.Current.Value == "(")
        {
            enumerator.MoveNext();
            var expression = ParseExpression(enumerator);
            if (enumerator.Current.Value != ")")
            {
                throw new InvalidOperationException("Mismatched parentheses");
            }
            enumerator.MoveNext();
            return expression;
        }

        throw new InvalidOperationException($"Unexpected token: {enumerator.Current.Value}");
    }
}