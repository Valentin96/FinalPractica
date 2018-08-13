using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Server
{
    public class Receptor
    {
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSAParameters cheie;
        byte[] decryptedData;
        public byte[] D { get { return cheie.D; } set { cheie.D = value; } }
        public byte[] DP { get { return cheie.DP; } set { cheie.DP = value; } }

        public byte[] DQ { get { return cheie.DQ; } set { cheie.DQ = value; } }

        public byte[] Exponent { get { return cheie.Exponent; } set { cheie.Exponent = value; } }

        public byte[] InverseQ { get { return cheie.InverseQ; } set { cheie.InverseQ = value; } }

        public byte[] Modulus { get { return cheie.Modulus; } set { cheie.Modulus = value; } }

        public byte[] P { get { return cheie.P; } set { cheie.P = value; } }

        public byte[] Q { get { return cheie.Q; } set { cheie.Q = value; } }
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        public RSAParameters getCheie()
        {
            cheie = RSAEncrypt(RSA.ExportParameters(false), false);


            return cheie;
        }


        public string ReturnExponent()
        {
            string exponent = HttpServerUtility.UrlTokenEncode(cheie.Exponent);
            return exponent;
        }

        public string ReturnModulus()
        {
            string modul = HttpServerUtility.UrlTokenEncode(cheie.Modulus);
            return modul;
        }

        public RSAParameters RSAEncrypt(RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {


            RSA.ImportParameters(RSAKeyInfo);


            return RSAKeyInfo;

        }
        public byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {

            byte[] decryptedData;
            Encoding.UTF8.GetString(DataToDecrypt);
            //Create a new instance of RSACryptoServiceProvider.

            //Import the RSA Key information. This needs
            //to include the private key information.
            RSA.ImportParameters(RSAKeyInfo);

            //Decrypt the passed byte array and specify OAEP padding.  
            //OAEP padding is only available on Microsoft Windows XP or
            //later.  
            try
            {
                decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);

            }
            catch (Exception e)
            {

                throw e;
            }

            return decryptedData;
        }
        //Catch and display a CryptographicException  
        //to the console.


    }
}
