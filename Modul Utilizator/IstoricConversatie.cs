using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Modul_Utilizator
{
    public partial class IstoricConversatie : Form
    {

        string mesajHASH;
        string password = "987";
        public Utilizator u;
        string aoleu;
        private DataTable dataTable = new DataTable();
        List<string> msj;
        private void mButtonShowConversation_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.;Initial Catalog=Chat;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
               // mesaje.Clear();
                conn.Open();
                string command = "SELECT * FROM Chat";
                PullData(dataTable);

                using (SqlCommand cmdd = new SqlCommand(command, conn))
                {
                    bool check = u.ReturinVerificare();
                    if (check == true)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            string nume1 = row["nume1"].ToString().Trim();
                            string nume2 = row["nume2"].ToString().Trim();
                            if (nume1 == u.getThisUser().Trim() & nume2 == u.getPersoana().Trim())
                            {
                                mesajHASH = String.Empty;
                                aoleu = string.Empty;
                                aoleu = row["mesaj"].ToString().Trim();
                              //  mesajHASH = Decrypt(aoleu, password);
                                richTextBox1.Text += u.getThisUser().Trim() + ":" + aoleu + "\r\n";
                            }
                            else if (nume2 == u.getThisUser().Trim() & nume1 == u.getPersoana().Trim())
                            {
                                mesajHASH = String.Empty;
                                aoleu = string.Empty;
                            //    mesajHASH = Decrypt(row["mesaj"].ToString(), password);
                                aoleu = row["mesaj"].ToString().Trim();
                                richTextBox1.Text += u.getPersoana().Trim() + ":" + aoleu + "\r\n";
                               
                            }

                        }
                    }
                    else if (check == false)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            string nume1 = row["nume1"].ToString().Trim();
                            string nume2 = row["nume2"].ToString().Trim();
                            if (nume1 == u.getThisUser().Trim() & nume2 == u.getUserForPChat().Trim())
                            {
                                richTextBox1.Text += u.getThisUser().Trim() + ":" + row["mesaj"].ToString() + "\r\n";
                               // mesaje.Add(pChat.getThisUser().Trim() + ":" + row["mesaj"].ToString());
                            }
                            else if (nume2 == u.getThisUser().Trim() & nume1 == u.getUserForPChat().Trim())
                            {
                                richTextBox1.Text += u.getUserForPChat().Trim() + ":" + row["mesaj"].ToString() + "\r\n";
                             //   mesaje.Add(pChat.getUserForPChat().Trim() + ":" + row["mesaj"].ToString());
                            }

                        }
                    }
                }

            }
        }

        private const int Keysize = 256;
        private const int DerivationIterations = 1000;
        public static string Decrypt(string cipherText, string passPhrase)
        {
         //   string mesajul = HttpServerUtility.UrlTokenEncode(mesajCriptat);
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Encoding.UTF8.GetBytes(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }


      

        public IstoricConversatie(Utilizator pchat)
        {
            u = pchat;
            InitializeComponent();

            //   bool temp = false;
            //  SqlConnection con = new SqlConnection("server=arun\\SQLEXPRESS;database=pan;Trusted_Connection=True");
            //   con.Open();
            //  SqlCommand cmd = new SqlCommand("select * from Table2 where nume1='" + textBox1.Text.Trim() + "'", con);
            //  SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    textBox2.Text = dr.GetString(1);
            //    textBox3.Text = dr.GetString(2);
            //    temp = true;
            //}
            //  if (temp == false)
            //   MessageBox.Show("not found");
            //    con.Close();
        }

        public void PullData(DataTable dataTable)
        {
            string connectionString = @"Data Source=.;Initial Catalog=Chat;Integrated Security=True";
            string query = "select * from MesajePrivate";
            List<string> aa = new List<string>();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
