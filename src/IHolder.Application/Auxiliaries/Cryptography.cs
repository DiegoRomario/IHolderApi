using System.Security.Cryptography;
using System.Text;

namespace IHolder.Application.Auxiliaries
{
    public class Cryptography : ICryptography
    {
        private HashAlgorithm _algorithm;

        public Cryptography()
        {
            _algorithm = SHA512.Create();
        }

        public string PasswordEncrypt(string senha)
        {
            var encodedValue = Encoding.UTF8.GetBytes(senha);
            var encryptedPassword = _algorithm.ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }
            string passwordEncrypt = sb.ToString();
            return passwordEncrypt;
        }
    }
}
