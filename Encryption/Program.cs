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
            string plainStr = "629340361";
            //
            //
            //
            //

            Console.WriteLine("Original Text: {0}", plainStr);
            int keySize = 256;
            string completeEncodedKey = "d1U5SEFjYlV0Q3J5dUtHUVRKYlhrQT09LGoycExrQzhnR0U4V0V4VStnN25NbE82TWFuNlpEVVNsY1NuQ2JvN2F6WjQ9"; //AESEncryption.GenerateKey(keySize);
            //Key 256(hex): "8f 6a 4b 90 2f 20 18 4f 16 13 15 3e 83 b9 cc 94 ee 8c 6a 7e 99 0d 44 a5 71 29 c2 6e 8e da cd 9e"
            //IV(hex): "c1 4f 47 01 c6 d4 b4 2a f2 b8 a1 90 4c 96 d7 90"
            Console.WriteLine("Using complete key '{0}'", completeEncodedKey);
            string encryptedText = AESEncryption.Encrypt(plainStr, completeEncodedKey, keySize);
            Console.WriteLine("Encrypted Text: {0}", encryptedText);
            //encryptedText = Base64Encryption.Base64Encode(encryptedText);
            //Console.WriteLine("Encode Base64 Text: {0}", encryptedText);
            //string decrypted = Base64Encryption.Base64Decode(encryptedText);
            //Console.WriteLine("Decode Base64 Text: {0}", decrypted);
            string decrypted = AESEncryption.Decrypt(encryptedText, completeEncodedKey, keySize);
            Console.WriteLine("Decrypted Text: {0}", decrypted);
            Console.Read();
        }
    }
}
