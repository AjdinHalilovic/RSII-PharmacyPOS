using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Pharmacy.Core.Helpers
{
    public static class Cryptography
    {
        #region Hash & Salt
        public static class Hash
        {
            public static string Create(string value, string salt)
            {
                var valueBytes = KeyDerivation.Pbkdf2(
                    password: value,
                    salt: Encoding.UTF8.GetBytes(salt),
                    prf: KeyDerivationPrf.HMACSHA512,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8);

                return Convert.ToBase64String(valueBytes);
            }

            public static bool Validate(string value, string salt, string hash) => Create(value, salt) == hash;
        }
        public static class Salt
        {
            public static string Create()
            {
                var randomBytes = new byte[128 / 8];
                using (var generator = RandomNumberGenerator.Create())
                {
                    generator.GetBytes(randomBytes);
                    return Convert.ToBase64String(randomBytes);
                }
            }
        }
        #endregion

        #region Encryption
        public static class Encryption
        {
            private static readonly char[] Padding = { '=' };
            public static string Encrypt(string clearText, string encryptionKey)
            {
                if (!clearText.IsSet() || !encryptionKey.IsSet())
                    return null;

                byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        clearText = Convert.ToBase64String(ms.ToArray()).TrimEnd(Padding).Replace('+', '-').Replace('/', '_');
                    }
                }
                return clearText;

            }
            public static string Decrypt(string cipherText, string encryptionKey)
            {
                if (!cipherText.IsSet() || !encryptionKey.IsSet())
                    return null;

                string incoming = cipherText.Replace('_', '/').Replace('-', '+');
                switch (cipherText.Length % 4)
                {
                    case 2: incoming += "=="; break;
                    case 3: incoming += "="; break;
                }
                byte[] cipherBytes = Convert.FromBase64String(incoming);

                //cipherText = cipherText.Replace("-", "/").Replace("_", "\\").Replace("!", "+");

                //byte[] cipherBytes = Convert.FromBase64String(cipherText);


                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();  //roknulo ovdje
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return cipherText;
            }
        }
        #endregion
    }
}
