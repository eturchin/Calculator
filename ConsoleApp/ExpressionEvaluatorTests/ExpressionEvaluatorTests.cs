using ExpressionEvaluatorApp;
using Microsoft.Extensions.DependencyInjection;

namespace ExpressionEvaluatorTests;

public class ExpressionEvaluatorTests
{
    private readonly IExpressionEvaluator _evaluator;

    public ExpressionEvaluatorTests()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ITokenizer, Tokenizer>()
            .AddSingleton<IParser, Parser>()
            .AddSingleton<IExpressionEvaluator, ExpressionEvaluator>()
            .BuildServiceProvider();

        _evaluator = serviceProvider.GetRequiredService<IExpressionEvaluator>();
    }

    [Theory]
    [InlineData("1+2", 3)]
    [InlineData("2-1", 1)]
    [InlineData("2*3", 6)]
    [InlineData("6/2", 3)]
    [InlineData("(1+2)*3", 9)]
    [InlineData("3*(1+2)", 9)]
    [InlineData("10/2-3", 2)]
    [InlineData("10/(2-1)", 10)]
    [InlineData("2+3*4", 14)]
    [InlineData("(2+3)*4", 20)]
    public void Evaluate_Expression_ReturnsExpectedResult(string expression, double expected)
    {
        var result = _evaluator.Evaluate(expression);
        Assert.Equal(expected, result, 2);
    }
}