using System.Security.Cryptography;
using System.Text;

namespace SuperHero.Services
{
    public static class SecurityService
    {        
        public static string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Converte a string de entrada em uma matriz de bytes e calcula o hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Criando uma nova stringBuilder para pegar os bytes               
                StringBuilder sBuilder = new StringBuilder();

                // Passa por cada byte dos dados em hash
                // e formata cada um como uma sequência hexadecimal.
                for (int i = 0; i < data.Length; i++)
                    sBuilder.Append(data[i].ToString("x2"));

                // Retorno a string hexadecimal.
                return sBuilder.ToString();
                // Convert the input string to a byte array and compute the hash.

            }
        }
    }
}
