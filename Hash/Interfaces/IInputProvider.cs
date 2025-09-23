namespace Hash.Interfaces;

public interface IInputProvider
{
    bool TryGetInput(out string? input);
}
