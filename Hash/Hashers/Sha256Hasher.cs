using System.Security.Cryptography;
using System.Text;
using Hash.Interfaces;

namespace Hash.Hashers
{
    public class Sha256Hasher : IHasher
    {
        public string Hash(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder(hashBytes.Length * 2);
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
