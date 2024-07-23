using ExpressionEvaluatorApp;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<ITokenizer, Tokenizer>()
    .AddSingleton<IParser, Parser>()
    .AddSingleton<IExpressionEvaluator, ExpressionEvaluator>()
    .BuildServiceProvider();

var evaluator = serviceProvider.GetRequiredService<IExpressionEvaluator>();

while (true)
{
    Console.Write("Введите выражение: ");
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input)) break;

    try
    {
        var result = evaluator.Evaluate(input);
        Console.WriteLine($"Результат: {result}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
}