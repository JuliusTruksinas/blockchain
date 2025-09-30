using Hash.Constants;
using Hash.Enums;
using Hash.Interfaces;
using Hash.Models;

namespace Hash.InputProviders
{
    public class ConsoleInputProvider : IHashInputProvider
    {
        public bool TryGetInput(out HashInput? input, out string? errorMessage)
        {
            input = default;
            errorMessage = default;
            string allowedAlgorithms = string.Join(", ", Enum.GetNames<HashAlgorithm>());

            Console.WriteLine(string.Format(MessageConstants.Prompts.Algorithm, allowedAlgorithms));
            string providedAlgorithm = Console.ReadLine() ?? string.Empty;

            bool isAlgorithmParseSuccess = Enum.TryParse(providedAlgorithm, ignoreCase: true, out HashAlgorithm algorithm);

            if (!isAlgorithmParseSuccess)
            {
                errorMessage = string.Format(MessageConstants.Errors.UnsupportedAlgorithm, allowedAlgorithms);
                return false;
            }

            Console.WriteLine(MessageConstants.Prompts.Content);
            string content = Console.ReadLine() ?? string.Empty;

            input = new()
            {
                HashAlgorithm = algorithm,
                Content = content
            };

            return true;
        }
    }
}
