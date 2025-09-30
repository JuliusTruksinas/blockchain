using Hash.Interfaces;
using Hash.Models;

namespace Hash.InputProviders
{
    public class ConsoleInputProvider : IHashInputProvider
    {
        public bool TryGetInput(out HashInput? input, out string? errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}
