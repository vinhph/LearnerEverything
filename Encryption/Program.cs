using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string plainStr = "66271e81-60a0-493b-baaa-4a09c1ba2c65";
            Console.WriteLine("Original Text: {0}", plainStr);
            int keySize = 256;
            string completeEncodedKey = "d1U5SEFjYlV0Q3J5dUtHUVRKYlhrQT09LGoycExrQzhnR0U4V0V4VStnN25NbE82TWFuNlpEVVNsY1NuQ2JvN2F6WjQ9"; //AESEncryption.GenerateKey(keySize);
            Console.WriteLine("Using complete key '{0}'", completeEncodedKey);
            string encryptedText = AESEncryption.Encrypt(plainStr, completeEncodedKey, keySize);
            Console.WriteLine("Encrypted Text: {0}", encryptedText);
            encryptedText = Base64Encryption.Base64Encode(encryptedText);
            Console.WriteLine("Encode Base64 Text: {0}", encryptedText);
            string decrypted = Base64Encryption.Base64Decode(encryptedText);
            Console.WriteLine("Decode Base64 Text: {0}", decrypted);
            decrypted = AESEncryption.Decrypt(decrypted, completeEncodedKey, keySize);
            Console.WriteLine("Decrypted Text: {0}", decrypted);
            Console.Read();
        }
    }
}
