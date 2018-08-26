using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Encryption
    {
        private AesCryptoServiceProvider cryptoProvider;

        public Encryption()
        {
            cryptoProvider = new AesCryptoServiceProvider
            {
                KeySize = 256, // setting he 
                BlockSize = 128
            };

            cryptoProvider.GenerateIV(); // generate a random initialization vector to use 
            cryptoProvider.GenerateKey();// generate a random key to use 
            cryptoProvider.Mode = CipherMode.ECB; 
            cryptoProvider.Padding = PaddingMode.PKCS7;
        }

        public string Encrypt(string plainText)
        {
            ICryptoTransform transform = cryptoProvider.CreateEncryptor();// creates an AES encryptor object using the generated key and initialization vector
            byte[] encryptedBytes = transform.TransformFinalBlock(Encoding.ASCII.GetBytes(plainText), 0, plainText.Length);//enctrypt the text
            
            return Convert.ToBase64String(encryptedBytes);// return it
        }

        public string Decrypt(string cipherText)
        {
            ICryptoTransform transform = cryptoProvider.CreateDecryptor();// creates an AES Decryptor object using the generated key and initialization vector
            byte[] encryptedBytes = Convert.FromBase64String(cipherText);
            byte[] decryptedBytes = transform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);// converts encrypted text to plain text

            return Encoding.ASCII.GetString(decryptedBytes);
        }
    }
}
