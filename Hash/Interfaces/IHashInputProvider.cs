using Hash.Models;

namespace Hash.Interfaces {
    public interface IHashInputProvider {
        bool TryGetInput(out HashInput? input, out string? errorMessage);
    }
}
