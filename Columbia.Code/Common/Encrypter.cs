﻿using System.Security.Cryptography;
using System.Text;

namespace $safesolutionname$.Common
{
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
    public static class Encrypter
    {
        public static string Encrypt(this string text, string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key must have valid value.", nameof(key));
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("The text must have valid value.", nameof(text));

            var buffer = Encoding.UTF8.GetBytes(text);
            var aesKey = new byte[24];

            Buffer.BlockCopy(SHA512.HashData(Encoding.UTF8.GetBytes(key)), 0, aesKey, 0, 24);

            using var aes = Aes.Create();

            if (aes == null)
                throw new ArgumentException("Parameter must not be null.", nameof(aes));

            aes.Key = aesKey;

            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var resultStream = new MemoryStream();
            using (var aesStream = new CryptoStream(resultStream, encryptor, CryptoStreamMode.Write))
            using (var plainStream = new MemoryStream(buffer))
            {
                plainStream.CopyTo(aesStream);
            }

            var result = resultStream.ToArray();
            var combined = new byte[aes.IV.Length + result.Length];
            Array.ConstrainedCopy(aes.IV, 0, combined, 0, aes.IV.Length);
            Array.ConstrainedCopy(result, 0, combined, aes.IV.Length, result.Length);

            return Convert.ToBase64String(combined);
        }

        public static string Decrypt(this string encryptedText, string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key must have valid value.", nameof(key));
            if (string.IsNullOrEmpty(encryptedText))
                throw new ArgumentException("The encrypted text must have valid value.", nameof(encryptedText));

            var combined = Convert.FromBase64String(encryptedText);
            var buffer = new byte[combined.Length];
            var aesKey = new byte[24];

            Buffer.BlockCopy(SHA512.HashData(Encoding.UTF8.GetBytes(key)), 0, aesKey, 0, 24);

            using var aes = Aes.Create();

            if (aes == null)
                throw new ArgumentException("Parameter must not be null.", nameof(aes));

            aes.Key = aesKey;

            var iv = new byte[aes.IV.Length];
            var ciphertext = new byte[buffer.Length - iv.Length];

            Array.ConstrainedCopy(combined, 0, iv, 0, iv.Length);
            Array.ConstrainedCopy(combined, iv.Length, ciphertext, 0, ciphertext.Length);

            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var resultStream = new MemoryStream();
            using (var aesStream = new CryptoStream(resultStream, decryptor, CryptoStreamMode.Write))
            using (var plainStream = new MemoryStream(ciphertext))
            {
                plainStream.CopyTo(aesStream);
            }

            return Encoding.UTF8.GetString(resultStream.ToArray());
        }
    }
}
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
