using System.Security.Cryptography;
using System.Text;

namespace Without.Systems.OAuthTokenExchange.Util;

public static class KeyGenerator
{
    private static readonly char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

    public static string Random(int size)
    {
        byte[] data = new byte[4 * size];

        using (var crypto = RandomNumberGenerator.Create())
        {
            crypto.GetBytes(data);
        }

        var result = new StringBuilder(size);

        for (int i = 0; i < size; i++)
        {
            var random = BitConverter.ToUInt32(data, i * 4);
            var index = random % chars.Length;
            result.Append(chars[index]);
        }

        return result.ToString();
    }
}