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
using System.Timers;
using System.Web;
using System.Windows.Forms;
using WindowsFormsApp3;

namespace Modul_Utilizator
{
    public partial class PrivateChat : Form
    {
        public ClientSettings Client { get; set; }
        public static Utilizator pChat;
        public LoginForm formLogin = new LoginForm();
       public IstoricConversatie istorie = new IstoricConversatie(pChat);
        string numeleMeu;
        string prop;
        string ala;
        //Client.Received += _client_Received;
        //Client.Disconnected += Client_Disconnected;
        public string MyProperty { get; set; }
        string privateKey;
        protected override void OnLoad(EventArgs e)
        {
            //    //if (formLogin.getCkeck() == true)
            //    //{
          
           base.OnLoad(e);
            
            prop = this.MyProperty;
             ala = this.Text;
            bool check = pChat.ReturinVerificare();
            Ticker();
           //  MessageBox.Show(prop);
            //    // Client.Connected += Client_Connected;
            //    //Client.Connect(ip, 2014);
            //    //Client.Send("Connect|" + userName + "|connected");
            //    //Client.Received += _client_Received;
            //    //Client.Disconnected += Client_Disconnected;
            if (check == true)
            {
                mesajPtServer = String.Empty;
                mesajPtServer = mTextSendTextBox.Text;
                pChat.getMesajDeCriptat(mesajPtServer, prop.Trim(), pChat.getPersoana().Trim());
                pChat.formLogin.Client.Send("cheie|" + pChat.getThisUser().Trim() + "|" + pChat.getPersoana().Trim() + "|" + prop.Trim());
             

               // mTextBoxMessageReceived.Text += "eu" + ": " + mesajPtServer + "\r\n";
                mTextSendTextBox.Text = string.Empty;
            
                //tu ai fost contactat
            }
            else
            {
                mesajPtServer = String.Empty;
                mesajPtServer = mTextSendTextBox.Text;
                pChat.getMesajDeCriptat(mesajPtServer, prop.Trim(), pChat.getUserForPChat().Trim());
                pChat.formLogin.Client.Send("cheie|" + pChat.getThisUser().Trim() + "|" + pChat.getUserForPChat().Trim() + "|" + prop.Trim());
              

              //  mTextBoxMessageReceived.Text += "eu" + ": " + mesajPtServer + "\r\n";
                mTextSendTextBox.Text = string.Empty;
              
                //tu ai deschis comunicatia
            }
            
           // Ticker2();
          //  Ticker3();
            formLogin.Client.Received += _client_Received;
            formLogin.Client.Disconnected += Client_Disconnected;
           // pChat.formLogin.Client.Send("publicKey|" + pChat.getThisUser().Trim() + "|" + pChat.getPersoana().Trim() + "|" + privateKey.Trim() + "|" + prop.Trim());
            // Text = "TCP Chat ";
            //  formLogin.ShowDialog();

            //    //loginForm.ShowDialog();
            //    //  }
            //    // else Application.Exit();

        }
        public void _client_Received(WindowsFormsApp3.ClientSettings cs, string received)
        {
            //var cmd = received.Split('|');
            //switch (cmd[0])
            //{
            //    case "pMessage":
            //        this.Invoke(() =>
            //        {
            //            mTextBoxMessageReceived.Text += cmd[3];
            //            mTextBoxMessageReceived.Text += cmd[1];


            //        });

            //        break;
            //}
            //if(cmd[0] == "pMessage")
            //{
            //    mTextBoxMessageReceived.Text += cmd[3];
            //}
        }
       // List<string> listaVorbitori;
        private System.Timers.Timer aTimer;
        Sender s = new Sender();
        Receiver r = new Receiver();
        private String cheiePrimita;
       
        public void Ticker()
        {
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 100;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

       
      
        public string mesajPtServer;
       
        string x = string.Empty;
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            string t =  pChat.getPrivatMessage().Trim();
            if (x == t)
            {

            }
            else
            {
                if (pChat.getNrPrimit().Trim() == prop.Trim())
                {
                    this.Invoke(() =>
                    {
                        x = t;
                   //     MessageBox.Show("Mesaj ajuns in privateChat::::   " +t);
                        mTextBoxMessageReceived.Text += t + "\r\n"; ;
                    });
                }
                else
                {
                    this.Invoke(() =>
                    {

                        mTextBoxMessageReceived.Text += "";
                    });
                }
            }
        }
        
        private void Client_Disconnected(WindowsFormsApp3.ClientSettings cs)
        {

        }
        public PrivateChat(Utilizator pchat)
        {
            InitializeComponent();
            pChat = pchat;
        }
        private bool tt=false;
        internal void insertLog(string v1, string v2, string now)
        {
            using (SqlConnection sqlConActivity = new SqlConnection(connectionString))
            {
                sqlConActivity.Open();
                SqlCommand sqlCmd = new SqlCommand("UserAddPrivateMessage", sqlConActivity);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@nume1", v1.Trim());
                sqlCmd.Parameters.AddWithValue("@nume2", v2);
                sqlCmd.Parameters.AddWithValue("@mesaj", now);
                sqlCmd.ExecuteNonQuery();
                //  throw new NotImplementedException();
            }
        }

        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private const int Keysize = 256;

        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public static string Encrypt(string plainText, string passPhrase)
        {
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
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

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }






        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        string mesajHASH;
        string password = "987";
        private void mButtonSend_Click(object sender, EventArgs e)
        {
            
            bool check = pChat.ReturinVerificare();
            if (mTextSendTextBox.Text != string.Empty)
            {
                mesajHASH = string.Empty;
                if (check == true)
                {
                    mesajPtServer = String.Empty;
                    mesajPtServer = mTextSendTextBox.Text;
                    pChat.getMesajDeCriptat(mesajPtServer, prop.Trim(), pChat.getPersoana().Trim());
                    pChat.formLogin.Client.Send("cheie|" + pChat.getThisUser().Trim() + "|" + pChat.getPersoana().Trim() + "|"  + prop.Trim());
                    mesajHASH = Encrypt(mesajPtServer, password);
                    MessageBox.Show(mesajHASH);
                    MessageBox.Show(Decrypt(mesajHASH, password));
                    insertLog(pChat.getThisUser().Trim(), pChat.getPersoana().Trim(), mesajPtServer);
                    //  tt = true;
                    // MessageBox.Show("100000");

                    //mesajPtServer = mTextSendTextBox.Text;
                    //  MessageBox.Show("aiciMesaj        " + mesajPtServer);

                    mTextBoxMessageReceived.Text += "eu" + ": "+ mesajPtServer + "\r\n";
                    mTextSendTextBox.Text = string.Empty;
                    //  System.Threading.Thread.Sleep(500);
                    //  string t = cheiePrimita;
                    //  byte[] cheieServer = HttpServerUtility.UrlTokenDecode(t);
                    //  s.Mesaj(cheieServer);
                    //  byte[] mesajCriptat = s.sendToReceiver(cheieServer, mTextSendTextBox.Text);
                    //  byte[] chestiaAia = s.sendChestiaAia();
                    //  byte[] senderPublicKey = s.getSenderPublicKey();
                    //  string mesajul = Encoding.ASCII.GetString(mesajCriptat);
                    //  string chestie = Encoding.ASCII.GetString(chestiaAia);
                    //  string cheiePublica = Encoding.ASCII.GetString(senderPublicKey);
                    //  pChat.formLogin.Client.Send("mesajCriptat|" + pChat.getThisUser().Trim() + "|" + pChat.getPersoana().Trim() + "|"  + prop.Trim() + "|" + mesajul + "|" + chestie + "|" + cheiePublica );
                    ////  System.Threading.Thread.Sleep(100);
                    //  //pChat.mTextBoxInput.Text = mTextSendTextBox.Text;
                    // // pChat.formLogin.Client.Send("pMessage|" + pChat.getThisUser().Trim() + "|" + pChat.getPersoana().Trim() + "|" + mTextSendTextBox.Text.Trim() + "|"+ prop.Trim());
                    //  //sender + receiver
                    //  mTextBoxMessageReceived.Text += "eu" + ": ";
                    //  mTextSendTextBox.Text = string.Empty;
                    //tu ai fost contactat
                }
                else
                {
                    mesajPtServer = String.Empty;
                    mesajPtServer = mTextSendTextBox.Text;
                    pChat.getMesajDeCriptat(mesajPtServer, prop.Trim(), pChat.getUserForPChat().Trim());
                    pChat.formLogin.Client.Send("cheie|" + pChat.getThisUser().Trim() + "|" + pChat.getUserForPChat().Trim() + "|" + prop.Trim());
                    mesajHASH = Encrypt(mesajPtServer, password);
                    MessageBox.Show(mesajHASH);
                    MessageBox.Show(Decrypt(mesajHASH, password));
                    insertLog(pChat.getThisUser().Trim(), pChat.getUserForPChat().Trim(), mesajPtServer);
                    //   tt = true;


                    //    MessageBox.Show("aiciMesaj        " + mesajPtServer);

                    mTextBoxMessageReceived.Text += "eu" + ": "+ mesajPtServer + "\r\n";
                    mTextSendTextBox.Text = string.Empty;
                    ////  System.Threading.Thread.Sleep(100);
                    //  byte[] cheieServer = Encoding.ASCII.GetBytes(cheiePrimita);
                    //  s.Mesaj(cheieServer);
                    //  byte[] mesajCriptat = s.sendToReceiver(cheieServer, mTextSendTextBox.Text);
                    //  byte[] chestiaAia = s.sendChestiaAia();
                    //  byte[] senderPublicKey = s.getSenderPublicKey();
                    //  string mesajul = Encoding.ASCII.GetString(mesajCriptat);
                    //  string chestie = Encoding.ASCII.GetString(chestiaAia);
                    //  string cheiePublica = Encoding.ASCII.GetString(senderPublicKey);
                    //  pChat.formLogin.Client.Send("mesajCriptat|" + pChat.getThisUser().Trim() + "|" + pChat.getPersoana().Trim() + "|" + prop.Trim() + "|" + mesajul + "|" + chestie + "|" + cheiePublica);
                    ////  pChat.formLogin.Client.Send("pMessage|" + pChat.getThisUser().Trim() + "|" + pChat.getUserForPChat().Trim() + "|" + mTextSendTextBox.Text.Trim() + "|" + prop.Trim());
                    //  //sender + receiver
                    //  mTextBoxMessageReceived.Text += "eu" + ": ";
                    //  mTextSendTextBox.Text = string.Empty;
                    //tu ai deschis comunicatia
                }
            }
        }
        public string getMesajDeCriptat()
        {
            return mesajPtServer;
        }
        public void Ticker3()
        {
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 50;
            aTimer.Elapsed += OnTimedEvent3;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        string connectionString = @"Data Source=.;Initial Catalog=Chat;Integrated Security=True";
        string x3 = String.Empty;
        private void OnTimedEvent3(Object source, System.Timers.ElapsedEventArgs e)
        {
            string t = pChat.getServerCheie().Trim();
            if (tt == true)
            {
                bool check = pChat.ReturinVerificare();
                if (mTextSendTextBox.Text != string.Empty)
                {
                    if (check == true)
                    {
                        tt = false;
                        //  System.Threading.Thread.Sleep(500);
                        // t = cheiePrimita;
                        byte[] cheieServer = HttpServerUtility.UrlTokenDecode(t);
                        s.Mesaj(cheieServer);
                        byte[] mesajCriptat = s.sendToReceiver(cheieServer, mTextSendTextBox.Text);
                        byte[] chestiaAia = s.sendChestiaAia();
                        byte[] senderPublicKey = s.getSenderPublicKey();
                        string mesajul = HttpServerUtility.UrlTokenEncode(mesajCriptat);
                        string chestie = HttpServerUtility.UrlTokenEncode(chestiaAia);
                        string cheiePublica = HttpServerUtility.UrlTokenEncode(senderPublicKey);
                        MessageBox.Show("eroare aici");
                        
                        pChat.formLogin.Client.Send("mesajCriptat|" + pChat.getThisUser().Trim() + "|" + pChat.getPersoana().Trim() + "|" + prop.Trim() + "|" + mesajul + "|" + chestie + "|" + cheiePublica);
                        //  System.Threading.Thread.Sleep(100);
                        //pChat.mTextBoxInput.Text = mTextSendTextBox.Text;
                        // pChat.formLogin.Client.Send("pMessage|" + pChat.getThisUser().Trim() + "|" + pChat.getPersoana().Trim() + "|" + mTextSendTextBox.Text.Trim() + "|"+ prop.Trim());
                        //sender + receiver
                       

                        //tu ai fost contactat
                    }
                    else
                    {
                        tt = false;
                        //  System.Threading.Thread.Sleep(100);
                        byte[] cheieServer = HttpServerUtility.UrlTokenDecode(t);
                        s.Mesaj(cheieServer);
                        byte[] mesajCriptat = s.sendToReceiver(cheieServer, mTextSendTextBox.Text);
                        byte[] chestiaAia = s.sendChestiaAia();
                        byte[] senderPublicKey = s.getSenderPublicKey();
                        string mesajul = HttpServerUtility.UrlTokenEncode(mesajCriptat);
                        string chestie = HttpServerUtility.UrlTokenEncode(chestiaAia);
                        string cheiePublica = HttpServerUtility.UrlTokenEncode(senderPublicKey);
                        MessageBox.Show("eroare 2");
                        
                        
                        pChat.formLogin.Client.Send("mesajCriptat|" + pChat.getThisUser().Trim() + "|" + pChat.getUserForPChat().Trim() + "|" + prop.Trim() + "|" + mesajul + "|" + chestie + "|" + cheiePublica);
                        //  pChat.formLogin.Client.Send("pMessage|" + pChat.getThisUser().Trim() + "|" + pChat.getUserForPChat().Trim() + "|" + mTextSendTextBox.Text.Trim() + "|" + prop.Trim());
                        //sender + receiver
                       

                        //tu ai deschis comunicatia
                    }
                }

            }
        }

        private void mTextBoxMessageReceived_TextChanged(object sender, EventArgs e)
        {
            mTextBoxMessageReceived.SelectionStart = mTextBoxMessageReceived.TextLength;

        }

        private void mTextSendTextBox_TextChanged(object sender, EventArgs e)
        {

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
          
        List<string> mesaje = new List<string>();
        string user;
        private DataTable dataTable = new DataTable();
        private void mButtonIstoric_Click(object sender, EventArgs e)
        {
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    mesaje.Clear();
            //    conn.Open();
            //    string command = "SELECT * FROM Chat";
            //    PullData(dataTable);
                
            //    using (SqlCommand cmdd = new SqlCommand(command, conn))
            //    {
            //        bool check = pChat.ReturinVerificare();
            //        if (check == true)
            //        {
            //            foreach (DataRow row in dataTable.Rows)
            //            {
            //                string nume1 = row["nume1"].ToString().Trim();
            //                string nume2 = row["nume2"].ToString().Trim();
            //                if (nume1 == pChat.getThisUser().Trim() & nume2 == pChat.getPersoana().Trim())
            //                {
            //                    mesaje.Add(pChat.getThisUser().Trim() + ":" + row["mesaj"].ToString());
            //                }
            //                else if (nume2 == pChat.getThisUser().Trim() & nume1 == pChat.getPersoana().Trim())
            //                {
            //                    mesaje.Add(pChat.getPersoana().Trim() + ":" + row["mesaj"].ToString());
            //                }

            //            }
            //        }
            //        else if (check == false)
            //        {
            //            foreach (DataRow row in dataTable.Rows)
            //            {
            //                string nume1 = row["nume1"].ToString().Trim();
            //                string nume2 = row["nume2"].ToString().Trim();
            //                if (nume1 == pChat.getThisUser().Trim() & nume2 == pChat.getUserForPChat().Trim())
            //                {
            //                    mesaje.Add(pChat.getThisUser().Trim() + ":" + row["mesaj"].ToString());
            //                }
            //                else if (nume2 == pChat.getThisUser().Trim() & nume1 == pChat.getUserForPChat().Trim())
            //                {
            //                    mesaje.Add(pChat.getUserForPChat().Trim() + ":" + row["mesaj"].ToString());
            //                }

            //            }
            //        }
            //    }


                


            //}
            istorie.Show();
            //        user = pChat.getThisUser();
            //  //  istorie.ShowDialog();
            //    bool temp = false;
            //    SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Chat;Integrated Security=True");
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("select * from MesajePrivate where first='" + textBox1.Text.Trim() + "'", con);
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        textBox2.Text = dr.GetString(1);
            //        textBox3.Text = dr.GetString(2);
            //        temp = true;
            //    }
            //    if (temp == false)
            //        MessageBox.Show("not found");
            //    con.Close();
            //}
            //public string getUser()
            //{
            //    return user;
            //}
        }
        public List<string> getMesajePrivate()
        {
            return mesaje;
        }

        private void mTextSendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mButtonSend.PerformClick();
                mTextSendTextBox.Text = string.Empty;
            }


        }
    }
}
