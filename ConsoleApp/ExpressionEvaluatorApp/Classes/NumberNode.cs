namespace ExpressionEvaluatorApp;

public class NumberNode : SyntaxNode
{
    private readonly double _value;

    public NumberNode(double value)
    {
        _value = value;
    }

    public override double Evaluate() => _value;
}

public class BinaryOperationNode : SyntaxNode
{
    private readonly SyntaxNode _left;
    private readonly SyntaxNode _right;
    private readonly string _operation;

    public BinaryOperationNode(SyntaxNode left, SyntaxNode right, string operation)
    {
        _left = left;
        _right = right;
        _operation = operation;
    }

    public override double Evaluate()
    {
        var leftValue = _left.Evaluate();
        var rightValue = _right.Evaluate();

        return _operation switch
        {
            "+" => leftValue + rightValue,
            "-" => leftValue - rightValue,
            "*" => leftValue * rightValue,
            "/" => leftValue / rightValue,
            _ => throw new InvalidOperationException($"Unsupported operation: {_operation}")
        };
    }
}