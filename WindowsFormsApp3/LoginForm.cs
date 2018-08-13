using Chat;
using Modul_Utilizator;
using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailSendForReset;
using System.Security.Cryptography;
using System.Web;

namespace WindowsFormsApp3
{


    public partial class LoginForm : Form
    {
        private bool checkLogIn = false;
        string connectionString = @"Data Source=.;Initial Catalog=Test;Integrated Security=True";
        BusinessLayer business = new BusinessLayer();
        public ClientSettings Client { get; set; }
        public LoginForm()
        {
            InitializeComponent();
            Client = new ClientSettings();
        }
        // public readonly LoginForm formLogin = new LoginForm();

        public void Form1_Load(object sender, EventArgs e)
        {

#if DEBUG

            mUserNameTextBox.Text = "vali";
            mPasswordTextBox.Text = "987";
#endif
        }

        private void Client_Connected(object sender, EventArgs e)
        {
           this.Invoke(Close);
        }

        public void LoginForm_Load(object sender, EventArgs e)
        {

        }
        public void label1_Click(object sender, EventArgs e)
        {

        }
        public void Arat()
        {
            this.Show();
        }



        Emitator e = new Emitator();
        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //}
        public UnicodeEncoding ByteConverter = new UnicodeEncoding();
        Database db = new SqlDatabase();
        Activity activ = new Activity();
        string ip = "127.0.0.1";
        public bool check = false;
        RSAParameters cheie;

        static string PrintByteArray(byte[] bytes)
        {
            var sb = new StringBuilder("byte[] = ");

            foreach (var b in bytes)
                sb.Append(b + ", ");
            return sb.ToString();
            
        }
        public void CloseForm()
        {
            this.Invoke(Close);
        }
        public void _client_Received(WindowsFormsApp3.ClientSettings cs, string received)
        {


            var cmd = received.Split('|');
            switch (cmd[0])
            {
                case "CheieRSA":
                    if (mUserNameTextBox.Text.Trim() == cmd[3].Trim())
                    {
                        cheie.Exponent = HttpServerUtility.UrlTokenDecode(cmd[1]);
                        cheie.Modulus = HttpServerUtility.UrlTokenDecode(cmd[2]);
                        byte[] DataToEncrypt = System.Text.Encoding.UTF8.GetBytes(mPasswordTextBox.Text);

                        byte[] parolaCriptata = e.RSAEncrypt(cheie, false, DataToEncrypt);
                        string qwe = HttpServerUtility.UrlTokenEncode(parolaCriptata);
                        //   MessageBox.Show("parola criptata de la client::::" + qwe);
                        //MessageBox.Show("Exponent:::::::::::" + HttpServerUtility.UrlTokenEncode(cheie.Exponent));
                        //MessageBox.Show("Modul:::::::::::" + HttpServerUtility.UrlTokenEncode(cheie.Modulus));

                        Client.Send("ParolaCriptataRSA|" + qwe.Trim() + "|" + cmd[3].Trim());
                    }

                    break;
                case "LogInSuccessful":
                    // MessageBox.Show("1");
                    if (mUserNameTextBox.Text.Trim() == cmd[1].Trim())
                    {


                        Client.Connected += Client_Connected;
                        Client.Connect(ip, 3000);
                        Client.Send("Connect|" + mUserNameTextBox.Text.Trim() + "|connected");
                    }
                  //  CloseForm();
                    //   MessageBox.Show("2");
                    break;
                    

            }
        }
        string asaCeva;
        //private void Client_Connected(object sender, EventArgs e)
        //{
        //    this.Invoke(Close);
        //}
        //Administrator admin = new Administrator();
        public void PullDataForUser(DataTable dataTable)
        {
            string connectionString = @"Data Source=.;Initial Catalog=Chat;Integrated Security=True";
            string query = "select * from Users";
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
        private DataTable dataTable = new DataTable();
        public async void mLoginButton_Click(object sender, EventArgs e)
        {
            asaCeva = String.Empty;
            bool verif = false;
            string connectionString = @"Data Source=.;Initial Catalog=Chat;Integrated Security=True";
            asaCeva = mUserNameTextBox.Text.Trim();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // mesaje.Clear();
                conn.Open();
                string command = "SELECT * FROM Chat";
                PullDataForUser(dataTable);
                using (SqlCommand cmdd = new SqlCommand(command, conn))
                {

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string name = row["name"].ToString().Trim();
                        if (name == mUserNameTextBox.Text.Trim())
                        {
                            string administrator = row["administrator"].ToString().Trim();

                            // string time = row["timestamp"].ToString().Trim();
                            if (administrator == "0")
                            {
                                verif = true;
                            }
                        }

                    }
                }
            }
            // string phoneNumber = null;
            // business.login(mUserNameTextBox.Text, mPasswordTextBox.Text);
            //if (mUserNameTextBox.Text.Trim() == "Administrator" && mPasswordTextBox.Text.Trim() == "parola")
            //{
            //    Client.Connected += Client_Connected;
            //    Client.Connect(ip, 3000);
            //    Client.Send("administrator|" + mUserNameTextBox.Text.Trim() + "|connected");
            //    //admin.Show();
            //}
            if (verif == false)
            {
                Client.Received += _client_Received;
                Client.Connected += Client_Connected;
                Client.Connect(ip, 3000);
                Client.Send("Hello|" + mUserNameTextBox.Text.Trim());
            }
            else MessageBox.Show("ai fost banat!");
           



        }

        public bool getCkeck()
        {
            return check;
        }


        private void mExitButton_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }



        private void panelSignUp_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mPasswordLabel_Click(object sender, EventArgs e)
        {

        }

        private void mPasswordLabelLogin_Click_Click(object sender, EventArgs e)
        {

        }

        public void mUserNameLabel_Click_Click(object sender, EventArgs e)
        {

        }

        private void mSignUpLabel_Click(object sender, EventArgs e)
        {

        }

        private void mPasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void mUserNameTextBoxSignUp_TextChanged(object sender, EventArgs e)
        {

        }

        private void mPasswordTextBoxSignUp_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void mConfirmPasswordLabel_Click(object sender, EventArgs e)
        {

        }

        private void mConfirmPasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        //private bool UserExists(string username)
        //{
        //    using (SqlConnection sqlConActivity = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("CheckUserExists", sqlConActivity);

        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add(new SqlParameter("@name", username));

        //        SqlDataReader reader = cmd.ExecuteReader(); // execute the function


        //        // return the respreonse from the reader (1 if it is true, 0 for false)
        //    }
        //}

        private void mButtonSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConActivity = new SqlConnection(connectionString))
                {
                    sqlConActivity.Open();

                    //if (mUserNameTextBoxSignUp.Text == "" || mPasswordTextBoxSignUp.Text == "")
                    //{

                    //    DateTime localData = DateTime.Now;

                    //    SqlCommand sqlCmd = new SqlCommand("UserAddActivity", sqlConActivity);
                    //    sqlCmd.CommandType = CommandType.StoredProcedure;
                    //    sqlCmd.Parameters.AddWithValue("@username", mUserNameTextBoxSignUp.Text.Trim());
                    //    sqlCmd.Parameters.AddWithValue("@action", "nu s-au completata toate campurile la signup");
                    //    sqlCmd.Parameters.AddWithValue("@timestamp", localData);
                    //    sqlCmd.ExecuteNonQuery();
                    //    MessageBox.Show("completeaza campurile obligatorii");
                    //}
                    //else if (mPasswordTextBoxSignUp.Text != mConfirmPasswordTextBox.Text)
                    //{

                    //    DateTime localData = DateTime.Now;
                    //    MessageBox.Show("password do not match");
                    //    SqlCommand sqlCmd = new SqlCommand("UserAddActivity", sqlConActivity);
                    //    sqlCmd.CommandType = CommandType.StoredProcedure;
                    //    sqlCmd.Parameters.AddWithValue("@username", mUserNameTextBoxSignUp.Text.Trim());
                    //    sqlCmd.Parameters.AddWithValue("@action", "password do not match la signUp");
                    //    sqlCmd.Parameters.AddWithValue("@timestamp", localData);
                    //    sqlCmd.ExecuteNonQuery();
                    //}

                    //else
                    //{

                    //    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    //    {
                    //        DateTime localData = DateTime.Now;
                    //        sqlCon.Open();


                    //        SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
                    //        SqlCommand sqlCmd1 = new SqlCommand("UserAddActivity", sqlConActivity);
                    //        sqlCmd1.CommandType = CommandType.StoredProcedure;
                    //        sqlCmd1.Parameters.AddWithValue("@username", mUserNameTextBoxSignUp.Text.Trim());
                    //        sqlCmd1.Parameters.AddWithValue("@action", "new username signup");
                    //        sqlCmd1.Parameters.AddWithValue("@timestamp", localData);


                    //        sqlCmd.CommandType = CommandType.StoredProcedure;
                    //        sqlCmd.Parameters.AddWithValue("@name", mUserNameTextBoxSignUp.Text.Trim());
                    //        sqlCmd.Parameters.AddWithValue("@pass", mPasswordTextBoxSignUp.Text.Trim());
                    //        sqlCmd.ExecuteNonQuery();
                    //        sqlCmd1.ExecuteNonQuery();
                    //        MessageBox.Show("registration succesfull");
                    //        mConfirmPasswordTextBox.Clear();
                    //        Clear();
                    //    }
                    //}
                    int administrator = 1;
                    string cheie = "cheie";
                    business.signUP(mUserNameTextBoxSignUp.Text, mPasswordTextBoxSignUp.Text, mConfirmPasswordTextBox.Text, mTextBoxPhoneNumberSignUp.Text, cheie, administrator);


                    MessageBox.Show("Felicitari!");
                }
            }
            catch (Exception exceptie)
            {
                CodeException exc = exceptie as CodeException;
                MessageBox.Show(exc.mesaj.ToString());
            }

        }
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (string.Equals((sender as Button).Name, @"CloseButton"))
            //    Application.Exit();
            //else
            //{
            //    Application.Exit();
            //}
        
        }
        void Clear()
        {
            mUserNameTextBoxSignUp.Text = mPasswordTextBoxSignUp.Text = "";
        }

        private void mButtonResetPassword_Click(object sender, EventArgs e)
        {

            // this.Hide();
            MailForResetPass sr = new MailForResetPass();
            //ResetPassword ss = new ResetPassword();
            sr.ShowDialog();
        }

        private void mTextBoxPhoneNumberSignUp_TextChanged(object sender, EventArgs e)
        {

        }
        public String getUser()
        {
            return mUserNameTextBox.Text.Trim();
        }
        public void mUserNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }


    }
}

