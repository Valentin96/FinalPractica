using Chat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailSendForReset
{
    public partial class MailForResetPass : Form
    {
        string codReset;
        

        string connectionString = @"Data Source=.;Initial Catalog=Chat;Integrated Security=True";
        Activity activitate = new Activity();
        RandomGeneratorCod cod = new RandomGeneratorCod();
        public MailForResetPass()
        {
            InitializeComponent();
        }
        internal void insertLog(string v1, string v2)
        {
            using (SqlConnection sqlConActivity = new SqlConnection(connectionString))
            {
                sqlConActivity.Open();
                SqlCommand sqlCmd = new SqlCommand("ResetPasswordAddCod", sqlConActivity);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mail", v1.Trim());
                sqlCmd.Parameters.AddWithValue("@codReset", v2.Trim());
               
                sqlCmd.ExecuteNonQuery();
                //  throw new NotImplementedException();
            }
        }
        private DataTable dataTableResetPassword = new DataTable();
        public void PullDataFromResetTable(DataTable dataTableResetPassword)
        {
            string connectionString = @"Data Source=.;Initial Catalog=Chat;Integrated Security=True";
            string query = "select * from Reset";
            List<string> aa = new List<string>();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTableResetPassword);
            conn.Close();
            da.Dispose();
        }

        private DataTable dataTable = new DataTable();
        public void PullData(DataTable dataTable)
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

        string codDataBase;
        private void mTextBoxMailName_TextChanged(object sender, EventArgs e)
        {

        }
        internal void deleteFromTable(string v1)
        {
            using (SqlConnection sqlConActivity = new SqlConnection(connectionString))
            {
                sqlConActivity.Open();
                SqlCommand sqlCmd = new SqlCommand("DeleteFromReset", sqlConActivity);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mail", v1.Trim());
                

                sqlCmd.ExecuteNonQuery();
                //  throw new NotImplementedException();
            }
        }
        bool what;
        private void mButtonSend_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                bool ok = false;
                con.Open();
                string command = "SELECT * FROM Chat";
                PullData(dataTable);
                PullDataFromResetTable(dataTableResetPassword);
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    foreach (DataRow row in dataTableResetPassword.Rows)
                    {
                        string mail = row["mail"].ToString().Trim();
                        if (mail == mTextBoxMailName.Text.Trim())
                        {
                            deleteFromTable(mail);
                        }
                    }

                        foreach (DataRow row2 in dataTable.Rows)
                        {
                            string name = row2["name"].ToString();
                            // string pass = row["pass"].ToString();
                            string phoneNr = row2["phone"].ToString().Trim();
                            //  MessageBox.Show(phone);
                            //MessageBox.Show(mTextBoxPhoneNumber.Text);
                            if (mTextBoxMailName.Text.Trim() == phoneNr)
                            {
                                MailSender mailToSend = new MailSender();

                                codReset = cod.RandomString();

                                mailToSend.sendMailForPasswordChange(mTextBoxMailName.Text.Trim(), codReset);

                                codDataBase = codReset;
                                ok = true;
                                insertLog(mTextBoxMailName.Text.Trim(), codReset);

                            }



                        }
                        what = ok;
                        if (ok == true)
                        {
                            this.Close();
                            MessageBox.Show("Mail trimis cu succes");
                            ResetPassword resetPass = new ResetPassword();
                            resetPass.Show();



                        }
                        else
                        {
                            // insertLog("unknownName", "ResetPassword", DateTime.Now);
                            MessageBox.Show("Nu exista acesta adresa de mail in baza de date");
                        }
                    }

               
            }
        }
    }
    }


