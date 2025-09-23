using System.Text;
using Hash.Interfaces;

namespace Hash.InputProviders;

public class FileInputProvider : IInputProvider
{
    private readonly string _path;
    private readonly HashSet<string> _validFileExtentions;

    public FileInputProvider(
        string path,
        HashSet<string> validFileExtentions)
    {
        _path = path;
        _validFileExtentions = validFileExtentions;
    }

    public bool TryGetInput(out string? input)
    {
        input = default;

        if (!File.Exists(_path))
            return false;

        if (_validFileExtentions.Contains(Path.GetExtension(_path).ToLower()))
            return false;

        try
        {
            input = File.ReadAllText(_path, Encoding.UTF8);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
