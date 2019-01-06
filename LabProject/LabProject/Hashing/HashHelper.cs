using System.Security.Cryptography;
using System.Text;

namespace LabProject.Hashing
{
    public static class HashHelper
    {
        public static string ComputeHash(string input)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hashBytes = sha.ComputeHash(bytes);

                var sb = new StringBuilder();
                foreach (var hashByte in hashBytes)
                {
                    sb.Append(hashByte.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}