using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Server
{
    class Sender
    {
        public static byte[] alicePublicKey;
        // private static string mesaj;
        private static byte[] alicePrivateKey;
        private static byte[] mesajCriptat;
        private static byte[] chestiaAia;
        public void Mesaj(byte[] bobPublicKey)

        {
            using (ECDiffieHellmanCng alice = new ECDiffieHellmanCng())
            {

                alice.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                alice.HashAlgorithm = CngAlgorithm.Sha256;
                alicePublicKey = alice.PublicKey.ToByteArray();
                alicePrivateKey = alice.DeriveKeyMaterial(CngKey.Import(bobPublicKey, CngKeyBlobFormat.EccPublicBlob));
                //  Bob bob = new Bob();
                //CngKey k = CngKey.Import(bobPublicKey, CngKeyBlobFormat.EccPublicBlob);
                //byte[] aliceKey = alice.DeriveKeyMaterial(CngKey.Import(bobPublicKey, CngKeyBlobFormat.EccPublicBlob));
                //byte[] encryptedMessage = null;
                //byte[] iv = null;
                //Send(aliceKey, mesaj, out encryptedMessage, out iv);
                //bob.Receive(encryptedMessage, iv);
            }

        }
        public byte[] getSenderPublicKey()
        {
            return alicePublicKey;
        }
        public byte[] sendToReceiver(byte[] bobPublicKey, string mesaj)
        {
            CngKey k = CngKey.Import(bobPublicKey, CngKeyBlobFormat.EccPublicBlob);

            byte[] encryptedMessage = null;
            byte[] iv = null;
            Send(alicePrivateKey, mesaj, out encryptedMessage, out iv);
            mesajCriptat = encryptedMessage;
            chestiaAia = iv;
            return mesajCriptat;
            // bob.Receive(encryptedMessage, iv);
        }
        public byte[] sendChestiaAia()
        {
            return chestiaAia;
        }

        private static void Send(byte[] key, string secretMessage, out byte[] encryptedMessage, out byte[] iv)
        {
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = key;
                iv = aes.IV;

                // Encrypt the message
                using (MemoryStream ciphertext = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ciphertext, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] plaintextMessage = Encoding.UTF8.GetBytes(secretMessage);
                    cs.Write(plaintextMessage, 0, plaintextMessage.Length);
                    cs.Close();
                    encryptedMessage = ciphertext.ToArray();
                }
            }
        }
    }
}
