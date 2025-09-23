using Hash.Interfaces;

namespace Hash.InputProviders;

public class ConsoleInputProvider : IInputProvider
{
    public bool TryGetInput(out string? input)
    {
        Console.WriteLine("Enter text: ");
        input = Console.ReadLine();

        return !string.IsNullOrWhiteSpace(input);
    }
}