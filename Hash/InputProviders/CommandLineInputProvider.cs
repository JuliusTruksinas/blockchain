using Hash.Constants;
using Hash.Enums;
using Hash.Interfaces;
using Hash.Models;

namespace Hash.InputProviders
{
    public class CommandLineInputProvider : IHashInputProvider
    {

        private readonly string[] _args;

        public CommandLineInputProvider(string[] args)
        {
            _args = args;
        }

        public bool TryGetInput(out HashInput? input, out string? errorMessage)
        {
            input = default;
            errorMessage = default;

            if (_args.Length != 2)
            {
                errorMessage = MessageConstants.Errors.GeneralCLIArgumentsError;
                return false;
            }

            string providedAlgorithm = _args[0];
            string providedFilePath = _args[1];

            bool isAlgorithmParseSuccess = Enum.TryParse(providedAlgorithm, ignoreCase: true, out HashAlgorithm algorithm);

            if (!isAlgorithmParseSuccess)
            {
                errorMessage = string.Format(MessageConstants.Errors.UnsupportedAlgorithm, string.Join(",", Enum.GetNames<HashAlgorithm>()));
                return false;
            }

            bool fileExists = File.Exists(providedFilePath);

            if (!fileExists)
            {
                errorMessage = string.Format(MessageConstants.Errors.FileDoesNotExist, providedFilePath);
                return false;
            }

            string ext = Path.GetExtension(providedFilePath);

            if (ext != ".txt")
            {
                errorMessage = MessageConstants.Errors.UnsupportedFileExtention;
                return false;
            }

            string content = File.ReadAllText(providedFilePath);

            input = new()
            {
                HashAlgorithm = algorithm,
                Content = content
            };

            return true;
        }
    }
}