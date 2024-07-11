using System;
using System.Security.Cryptography;
using System.Text;

public static class PasswordHandler
{
    private const int SaltSize = 16;
    private const int KeySize = 32;
    private const int Iterations = 10000;

    // 哈希密码的方法
    public static string HashPassword(string password)
    {
        using (var algorithm = new Rfc2898DeriveBytes(password, SaltSize, Iterations, HashAlgorithmName.SHA256))
        {
            var salt = algorithm.Salt;
            var key = algorithm.GetBytes(KeySize);
            var hash = new byte[SaltSize + KeySize];
            Buffer.BlockCopy(salt, 0, hash, 0, SaltSize);
            Buffer.BlockCopy(key, 0, hash, SaltSize, KeySize);
            return Convert.ToBase64String(hash);
        }
    }

    // 验证密码的方法
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        var hashBytes = Convert.FromBase64String(hashedPassword);
        var salt = new byte[SaltSize];
        Buffer.BlockCopy(hashBytes, 0, salt, 0, SaltSize);

        using (var algorithm = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
        {
            var key = algorithm.GetBytes(KeySize);
            for (int i = 0; i < KeySize; i++)
            {
                if (hashBytes[i + SaltSize] != key[i])
                {
                    return false;
                }
            }
        }
        return true;
    }
}