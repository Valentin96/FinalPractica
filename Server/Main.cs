using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace Server
{
    public partial class FormServer : Form
    {
        Receiver r = new Receiver();
        Sender s = new Sender();
        private readonly Listener listener;
        private readonly Listener privateListener;
        IPEndPoint end;
        Socket sock;
        public static string path;
        public static string MesajCurrent = "Stopped";
        //public List<Socket> clients = new List<Socket>(); // store all the clients into a list
        public Dictionary<Socket, string> clientsWithDetails = new Dictionary<Socket, string>();
        public List<Socket> clienti = new List<Socket>();
        //public List<Socket> privateClients = new List<Socket>();


        public void BroadcastData(string data) // send to all clients
        {
            //foreach (var socket in clientsWithDetails)
            foreach (var socket in clientsWithDetails)
            {
                
                try { socket.Key.Send(Encoding.ASCII.GetBytes(data)); }
                catch (Exception e) { throw e; }
            }
        }
        public void BroadcastData(string data,int nr) // send to all clients
        {
            //foreach (var socket in clientsWithDetails)
            foreach (var socket in clientsWithDetails)
            {

                try { socket.Key.Send(Encoding.ASCII.GetBytes(data)); }
                catch (Exception e) { throw e; }
            }
        }

        public void BroadcastData(string data, string argClientName) // send to all clients
        {
            foreach (var socket in clientsWithDetails)
            //foreach (var socket in clientsWithDetails)
            {
                try { socket.Key.Send(Encoding.ASCII.GetBytes(data)); }
                catch (Exception e) { throw e; }
            }
            foreach (var socket in clienti)
            {
                try
                {
                    socket.Send(Encoding.ASCII.GetBytes(data));
                }
                catch (Exception e) { throw e; }
            }
        }

        //public void BroadcastPrivateData(string data) // send to private clients
        //{
        //    foreach (var socket in privateClients)
        //    {
        //        try { socket.Send(Encoding.ASCII.GetBytes(data)); }
        //        catch (Exception) { }
        //    }
        //}

        public FormServer()
        {

            InitializeComponent();
            listener = new Listener(3000);
            listener.SocketAccepted += listener_SocketAccepted;
            privateListener = new Listener(3000);
            privateListener.SocketAccepted += listenerForPrivate_SocketAccepted;
            end = new IPEndPoint(IPAddress.Any, 3001);
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            sock.Bind(end);
        }

        private void listenerForPrivate_SocketAccepted(Socket e)
        {
            var client = new Client(e);
            client.Received += client_Received;
            client.Disconnected += client_Disconnected;
            this.Invoke(() =>
            {
                
                clienti.Add(e);
                //clientsWithDetails.Add(new ChatClient(e, ))
            });
        }
        private void listener_SocketAccepted(Socket e)
        {
            var client = new Client(e);
            client.Received += client_Received;

            client.Disconnected += client_Disconnected;
            this.Invoke(() =>
            {
                string ip = client.Ip.ToString();//.Split(':')[0];
                var item = new ListViewItem(ip); // ip
                item.SubItems.Add(" "); // nickname
                item.SubItems.Add(" "); // status
                item.Tag = client;
                clientListView.Items.Add(item);
                clientsWithDetails.Add(e, e.RemoteEndPoint.ToString());
                //clientsWithDetails.Add(new ChatClient(e, ))
            });
        }

        public void client_Disconnected(Client sender, byte[] data)
        {
            this.Invoke(() =>
            {
                for (int i = 0; i < clientListView.Items.Count; i++)
                {
                    var client = clientListView.Items[i].Tag as Client;
                    if (client.Ip == sender.Ip)
                    {
                        txtReceive.Text += "<< " + clientListView.Items[i].SubItems[1].Text + " has left the room >>\r\n";

                        clientListView.Items.RemoveAt(i);
                        BroadcastData("RefreshChat|" + txtReceive.Text);
                        users = string.Empty;
                        for (int j = 0; j < clientListView.Items.Count; j++)
                        {
                            users += clientListView.Items[j].SubItems[1].Text + "|";
                        }
                        BroadcastData(".|" + users.TrimEnd('|'));

                    }
                }
            });
        }
        private string mesajDeTrimis = String.Empty;
        #region Timer UnusedCode
        //private Timer timer1;
        //public void InitTimer()
        //{
        //    timer1 = new Timer();
        //    timer1.Tick += new EventHandler(timer1_Tick);
        //    timer1.Interval = 500; // in miliseconds
        //    timer1.Start();
        //}

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    ListaUser.Items.Clear();
        //    Lista(ListaUser);

        //}
        #endregion
        byte[] cheiePrivata;
       static  RSAParameters cheie;
        byte[] receiverPublicKey;
        static RSAParameters ttttt;
        public static RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        public static UnicodeEncoding ByteConverter = new UnicodeEncoding();
        #region Refresh list unused code
        //ListBox ListaUser;

        //private ListBox Lista(ListBox listuta)
        //{
        //    listuta.Items.Clear();
        //    foreach (var item in clients)
        //    {
        //        listuta.Items.Add(item);
        //    }
        //    return listuta;
        //}      

        //public ListBox getListaClienti()
        //{
        //    // string t = clientList.ToString();
        //    return ListaUser;
        //}
        #endregion
        int q = 0;
        String users;
        BusinessLayer business = new BusinessLayer();
        private string nrChat;
       static Receptor receptor = new Receptor();
        List<string> listaPrivati;
        private void client_Received(Client sender, byte[] data)
        {
            this.Invoke(() =>
            {
                
                //clientsWithDetails[sender._socket] = command[1];


                for (int i = 0; i < clientListView.Items.Count; i++)
                {
                    var command = Encoding.ASCII.GetString(data).Split('|');
                    var client = clientListView.Items[i].Tag as Client;
                    if (client == null || client.Ip != sender.Ip) continue;
                    switch (command[0])
                    {
                        case "Hello":
                            receptor.RSAEncrypt(RSA.ExportParameters(false), false);
                            receptor.getCheie();
                            //   MessageBox.Show("treceDeEncript");
                            byte[] exponent = receptor.Exponent;
                            //    MessageBox.Show("treceDeExponent");
                            //    MessageBox.Show(HttpServerUtility.UrlTokenEncode(exponent));
                            byte[] modul = receptor.Modulus;
                            //MessageBox.Show("ExponentInServer::::::::::" + HttpServerUtility.UrlTokenEncode(exponent));
                            //MessageBox.Show("ModulInServer::::::::::" + HttpServerUtility.UrlTokenEncode(modul));
                            BroadcastData("CheieRSA|" + HttpServerUtility.UrlTokenEncode(exponent).Trim() + "|" + HttpServerUtility.UrlTokenEncode(modul).Trim()+ "|" + command[1].Trim());


                            break;
                        case "ParolaCriptataRSA":
                            
                            byte[] parolaCriptata = HttpServerUtility.UrlTokenDecode(command[1].Trim());
                            //byte[] newArray = new byte[parolaCriptata.Length - 44];
                            //Buffer.BlockCopy(parolaCriptata, 44, newArray, 0, newArray.Length);

                         //   MessageBox.Show("parola la server" + command[1]);
                         //   MessageBox.Show("parolaLaServerFrom byteArray:::::::::" + HttpServerUtility.UrlTokenEncode(parolaCriptata));
                            string criptat = command[1];

                            byte[] decryptedData = receptor.RSADecrypt(parolaCriptata, RSA.ExportParameters(true), false);
                        //    MessageBox.Show("parolaDEcriptataLaServer:::::::::" + HttpServerUtility.UrlTokenEncode(parolaCriptata));
                            bool ok = business.login(command[2], Encoding.UTF8.GetString(decryptedData));
                        //    MessageBox.Show(Encoding.UTF8.GetString(decryptedData));
                            if (ok)
                            {
                                BroadcastData("LogInSuccessful|" + command[2]);
                                //txtReceive.Text += "<< " + command[1] + " joined the room >>\r\n";
                                //clientListView.Items[i].SubItems[1].Text = command[1]; // nickname
                                //clientListView.Items[i].SubItems[2].Text = command[2]; // status
                                //users = string.Empty;
                                //for (int j = 0; j < clientListView.Items.Count; j++)
                                //{
                                //    users += clientListView.Items[j].SubItems[1].Text + "|";
                                //}
                                //BroadcastData("Users|" + users.TrimEnd('|'));
                                //BroadcastData("RefreshChat|" + txtReceive.Text);
                                //System.Threading.Thread.Sleep(500);
                                //users = string.Empty;
                                //for (int j = 0; j < clientListView.Items.Count; j++)
                                //{
                                //    users += clientListView.Items[j].SubItems[1].Text + "|";
                                //}
                                //BroadcastData(".|" + users.TrimEnd('|'));
                            }
                            else
                            {

                                BroadcastData("LogInFailed|" + command[2]);
                            }
                            break;

                        //case "administrator":
                        //    txtReceive.Text += "<< " + command[1] + " joined the room >>\r\n";
                        //    clientListView.Items[i].SubItems[1].Text = command[1]; // nickname
                        //    clientListView.Items[i].SubItems[2].Text = command[2]; // status
                        //    users = string.Empty;
                        //    for (int j = 0; j < clientListView.Items.Count; j++)
                        //    {
                        //        users += clientListView.Items[j].SubItems[1].Text + "|";
                        //    }
                        //    BroadcastData("Users|" + users.TrimEnd('|'));
                        //    BroadcastData("RefreshChat|" + txtReceive.Text);
                        //    System.Threading.Thread.Sleep(500);
                        //    BroadcastData("admin|" + command[1]);
                        //    users = string.Empty;
                        //    for (int j = 0; j < clientListView.Items.Count; j++)
                        //    {
                        //        users += clientListView.Items[j].SubItems[1].Text + "|";
                        //    }
                        //    BroadcastData(".|" + users.TrimEnd('|'));
                        //    break;

                        case "Connect":
                            txtReceive.Text += "<< " + command[1] + " joined the room >>\r\n";
                            mListBoxUsersList.Items.Add(command[1]);
                            clientListView.Items[i].SubItems[1].Text = command[1]; // nickname
                            clientListView.Items[i].SubItems[2].Text = command[2]; // status
                            users = string.Empty;
                            for (int j = 0; j < clientListView.Items.Count; j++)
                            {
                                users += clientListView.Items[j].SubItems[1].Text + "|";
                            }
                            BroadcastData("Users|" + users.TrimEnd('|'));
                            BroadcastData("RefreshChat|" + txtReceive.Text);
                            System.Threading.Thread.Sleep(500);
                            users = string.Empty;
                            for (int j = 0; j < clientListView.Items.Count; j++)
                            {
                                users += clientListView.Items[j].SubItems[1].Text + "|";
                            }
                            BroadcastData(".|" + users.TrimEnd('|'));
                            break;
                        case "Message":
                            users = string.Empty;
                            for (int j = 0; j < clientListView.Items.Count; j++)
                            {
                                users += clientListView.Items[j].SubItems[1].Text + "|";
                            }
                            BroadcastData("Users|" + users.TrimEnd('|'));
                            txtReceive.Text += command[1] + " says: " + command[2] + "\r\n";
                            BroadcastData("RefreshChat|" + txtReceive.Text);
                            break;
                        case "pChat":

                           // listaPrivati.Add(command[1] +"+"+ command[2] + "+"); //adauga cel cu care vrei sa vorbesti ++ tu
                            BroadcastData("privateChat|" + command[1]+"|" + command[2] + "|"+q.ToString().Trim());// userforPchat si thisuser
                            q++;
                            // BroadcastPrivateData()
                        

                            break;

                        case "pMessage":

                            string privateSender = string.Empty;
                            string privateReceiver = string.Empty;
                            privateSender = command[1];
                            privateReceiver = command[2];
                            String prop = command[4];
                            //String mesaj = command[3];
                            //txtReceive.Text += command[1] + " says to: " + command[2] + "\r\n";
                            BroadcastData("pMessage|" + command[3] + "|"+ privateReceiver+"|" + privateSender +"|" + prop.Trim());
                            

                            break;
                        case "cheie":
                            
                            receiverPublicKey = r.ReceiverPublicKey();
                            string someString = HttpServerUtility.UrlTokenEncode(receiverPublicKey);
                         //   MessageBox.Show(someString);
                          //  string result = Encoding.ASCII.GetString(receiverPublicKey);
                            BroadcastData("cheieServerReceiver|" + someString + "|" + command[3].Trim() + "|" + command[1].Trim() + "|" + command[2].Trim());// trimit cheie, codChat si utilizator care a cerut cheie + plus cel pe care il cauta utilizatorul
                           // MessageBox.Show("server a trimis cheia");

                            break;

                        case "mesajCriptat":
                          //  MessageBox.Show("in server"  + command[6]);
                            byte[] mesaj = HttpServerUtility.UrlTokenDecode(command[4]);
                            byte[] chestie = HttpServerUtility.UrlTokenDecode(command[5]);
                            byte[] cheiePublica = HttpServerUtility.UrlTokenDecode(command[6]);
                            string mesajDecriptat = r.Receive(mesaj, chestie, cheiePublica);
                            string s4 = HttpServerUtility.UrlTokenEncode(mesaj);
                            mesajDeTrimis = String.Empty;
                            nrChat = String.Empty;
                            nrChat = command[2].Trim();
                            //   MessageBox.Show("Mesajul criptat de la client spre server:      " + s4);
                            //   MessageBox.Show("server trimite mesaj decriptat");
                            mesajDeTrimis = mesajDecriptat; 
                           // BroadcastData("mesajDecriptat|" + mesajDecriptat + "|" + command[2] + "|" + command[1] + "|" + command[3]);
                            break;


                        case "CheieReceiver":
                            string qwe = command[3];
                            byte[] cheiePublicaDeLaReceiver = HttpServerUtility.UrlTokenDecode(qwe);


                            
                            s.Mesaj(cheiePublicaDeLaReceiver);
                           
                            byte[] mesajCriptat = s.sendToReceiver(cheiePublicaDeLaReceiver, mesajDeTrimis);
                            byte[] chestiaAia = s.sendChestiaAia();
                            byte[] senderPublicKey = s.getSenderPublicKey();
                            string mesajulCriptatPtClient = HttpServerUtility.UrlTokenEncode(mesajCriptat);
                            string IV = HttpServerUtility.UrlTokenEncode(chestiaAia);
                            string cheiaMea = HttpServerUtility.UrlTokenEncode(senderPublicKey);
                         //   MessageBox.Show("ServerSpreClient:::" + mesajulCriptatPtClient);
                            BroadcastData("DeLaServerPtAlaCautat|" + mesajulCriptatPtClient + "|" + IV + "|" + cheiaMea + "|" + command[1] + "|" + nrChat); // +++ pe cine caut + nrChat

                            break;

                        case "RefreshList":
                            users = string.Empty;
                            for (int j = 0; j < clientListView.Items.Count; j++)
                            {
                                users += clientListView.Items[j].SubItems[1].Text + "|";
                            }
                           // BroadcastData(".|" + users.TrimEnd('|'));


                            break;

                        case "Ban":
                            BroadcastData("AifostBanat|" + command[2]);

                            break;

                    }
                }

                //StringBuilder sb = new StringBuilder();
                //foreach (var item in clientsWithDetails)
                //{
                //    sb.AppendLine(string.Format("IpPort: {0} | Nick: {1}", item.Key.RemoteEndPoint, item.Value));
                //}
                //MessageBox.Show(sb.ToString());
            });
        }

        private void Main_Load(object sender, EventArgs e)
        {
            listener.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            listener.Stop();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != string.Empty)
            {
                BroadcastData("Message|" + txtInput.Text);
                txtReceive.Text += txtInput.Text + "\r\n";
                txtInput.Text = "Admin says: ";
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

       
        //private void chatWithClientToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    foreach (var client in from ListViewItem item in clientList.SelectedItems select (Client) item.Tag)
        //    {
        //        client.Send("Chat|");
        //        pChat = new PrivateChat(this);
        //        pChat.Show();
        //    }
        //}

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
            }
        }

        private void txtReceive_TextChanged(object sender, EventArgs e)
        {
            txtReceive.SelectionStart = txtReceive.TextLength;
        }
        public void StartServer()
        {
            try
            {
                MesajCurrent = "Starting...";
                sock.Listen(100);
                MesajCurrent = "Functioneaza si asteapta pt fisiere";
                Socket clientSock = sock.Accept();
                byte[] clientData = new byte[1024 * 5000];
                int receivedByteLen = clientSock.Receive(clientData);
                MesajCurrent = "Se primeste fisier...";
                int fNameLen = BitConverter.ToInt32(clientData, 0);
                string fName = Encoding.ASCII.GetString(clientData, 4, fNameLen);
                BinaryWriter write = new BinaryWriter(File.Open(path + "/" + fName, FileMode.Append));
                write.Write(clientData, 4 + fNameLen, receivedByteLen - 4 - fNameLen);
                MesajCurrent = "Saving file....";
                write.Close();
                clientSock.Close();
                MesajCurrent = "Fisierul a fost primit";
            }
            catch
            {
                MesajCurrent = "Eroare, fisierul nu a fost primit";
            }
        }

      

        private void chatWithClientToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void banClientToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (mListBoxUsersList.SelectedItem != null)
            //{
            //    nume = mListBoxUsersList.SelectedItem.ToString();
            //}
        }
        string nume;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public string getForBan()
        {

            return nume;

        }





        private void privateChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getForBan() != null)
            {



                //formLogin.Client.Send("Message|" + formLogin.getUser() + "|" + mTextBoxInput.Text);
                BroadcastData("Disconnect|" + getForBan().Trim());
                
                for (int i = 0; i < clientListView.Items.Count; i++)
                {
                   if( clientListView.Items[i].SubItems[1].Text == getForBan()) {
                       // clientListView.Items.RemoveAt(i);
                        //  MessageBox.Show("A");
                        //  var client2 = mListBoxUsersList.Items[i] as Client;
                        // var client = clientListView.Items[i].Tag as Client;


                        txtReceive.Text += "<< " + getForBan() + " has left the room >>\r\n";
                     
                            clientListView.Items.RemoveAt(i);
                        mListBoxUsersList.Items.RemoveAt(i);
                         //   mListBoxUsersList.Items.RemoveAt(i);
                            BroadcastData("RefreshChat|" + txtReceive.Text);
                            users = string.Empty;
                       
                        for (int j = 0; j < clientListView.Items.Count; j++)
                            {
                                users += clientListView.Items[j].SubItems[1].Text + "|";
                            }
                            BroadcastData(".|" + users.TrimEnd('|'));
                        
                    }

                }
            }
        }

        string connectionString = @"Data Source=.;Initial Catalog=Chat;Integrated Security=True";

        internal void insertLog(int a)
        {
            a = 1;
            using (SqlConnection sqlConActivity = new SqlConnection(connectionString))
            {
                sqlConActivity.Open();
                SqlCommand sqlCmd = new SqlCommand("Ban", sqlConActivity);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@administrator", a);
                
                sqlCmd.ExecuteNonQuery();

                //  throw new NotImplementedException();
            }
        }
        private void banClientToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // mesaje.Clear();
                conn.Open();
             //   string command = "SELECT * FROM Chat";
                PullDataForUser(dataTable);
                SqlCommand cmd2 = new SqlCommand(@"UPDATE USERS set administrator='" + 0 + "' where name= '" + getForBan() + "'", conn);
                cmd2.ExecuteNonQuery();
            }
            BroadcastData("Ban|" + getForBan().Trim());

            for (int i = 0; i < clientListView.Items.Count; i++)
            {
                if (clientListView.Items[i].SubItems[1].Text == getForBan())
                {
                    // clientListView.Items.RemoveAt(i);
                    //  MessageBox.Show("A");
                    //  var client2 = mListBoxUsersList.Items[i] as Client;
                    // var client = clientListView.Items[i].Tag as Client;


                    txtReceive.Text += "<< " + getForBan() + " a fost banat >>\r\n";

                    clientListView.Items.RemoveAt(i);
                    mListBoxUsersList.Items.RemoveAt(i);
                    //   mListBoxUsersList.Items.RemoveAt(i);
                    BroadcastData("RefreshChat|" + txtReceive.Text);
                    users = string.Empty;

                    for (int j = 0; j < clientListView.Items.Count; j++)
                    {
                        users += clientListView.Items[j].SubItems[1].Text + "|";
                    }
                    BroadcastData(".|" + users.TrimEnd('|'));

                }

            }

        }

        private void mListBoxUsersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mListBoxUsersList.SelectedItem != null)
            {
                nume = mListBoxUsersList.SelectedItem.ToString();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private DataTable dataTable = new DataTable();
        private void button1_Click(object sender, EventArgs e)
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

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string username = row["username"].ToString().Trim();
                        string actiune = row["action"].ToString().Trim();
                        string time = row["timestamp"].ToString().Trim();
                            richTextBox1.Text += username +" : " + actiune + "  " + time + "\r\n";
                      

                    }
                }
            }


        }
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

        public void PullData(DataTable dataTable)
        {
            string connectionString = @"Data Source=.;Initial Catalog=Chat;Integrated Security=True";
            string query = "select * from Activity";
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
    }
}