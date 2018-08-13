using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Modul_Utilizator
{
    class Receiver
    {
        public byte[] bobPublicKey;
        private byte[] bobKey;
        ECDiffieHellmanCng bob = new ECDiffieHellmanCng();
        public byte[] ReceiverPublicKey()
        {

            bob.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
            bob.HashAlgorithm = CngAlgorithm.Sha256;
            bobPublicKey = bob.PublicKey.ToByteArray();
            //bobKey = bob.DeriveKeyMaterial(CngKey.Import(alicePublicKey, CngKeyBlobFormat.EccPublicBlob));
            return bobPublicKey;



        }
        private byte[] ReceiverPrivateKey(byte[] alicePublicKey)
        {
            bobKey = bob.DeriveKeyMaterial(CngKey.Import(alicePublicKey, CngKeyBlobFormat.EccPublicBlob));
            return bobKey;
        }

        public string Receive(byte[] encryptedMessage, byte[] iv, byte[] alicePublicKey)
        {
            bobKey = bob.DeriveKeyMaterial(CngKey.Import(alicePublicKey, CngKeyBlobFormat.EccPublicBlob));
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = bobKey;
                aes.IV = iv;
                // Decrypt the message
                using (MemoryStream plaintext = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(plaintext, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedMessage, 0, encryptedMessage.Length);
                        cs.Close();
                        string message = Encoding.UTF8.GetString(plaintext.ToArray());
                        return message;
                    }
                }
            }
        }
    }
}
