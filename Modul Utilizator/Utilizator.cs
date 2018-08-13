using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Windows.Forms;
using WindowsFormsApp3;

namespace Modul_Utilizator
{
    public partial class Utilizator : Form
    {
         public ClientSettings Client { get; set; }
        public LoginForm formLogin = new LoginForm();
        LoginForm ff = new LoginForm();
        // Client = new ClientSettings();
        private readonly PrivateChat pChat;
        String ip = "127.0.0.1";
        //String userName = "aa";
        private string ServerCheie;


        
        private System.Timers.Timer aTimer;
        public void Ticker()
        {
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 100;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(() =>
            {
                formLogin.Client.Send("RefreshList"); ;
               // MessageBox.Show("salut");
            });
        }
       
        string t;

        
        public Utilizator()
        {

            pChat = new PrivateChat(this);
            InitializeComponent();



                // FormServer qq = new FormServer();
                Client = new ClientSettings();
           
          //  this.Text = "TCP Chat - " + ip + " - (Connected as: " + formLogin.getUser() + ")";
        }
        //private Timer timer1;
        //public void InitTimer()
        //{
        //    timer1 = new Timer();
        //    timer1.Tick += new EventHandler(timer1_Tick);
        //    timer1.Interval = 500; // in miliseconds
        //    timer1.Start();
        //}

       // private static Timer aTimer;

      //  private void timer1_Tick(object sender, EventArgs e)
      //
      //  PrivateChat pc = new PrivateChat();
        string nume;
        private void mListBoxUsersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mListBoxUsersList.SelectedItem != null)
            {
                nume = mListBoxUsersList.SelectedItem.ToString();
            }

        }
        public string getUserForPChat()
        {
           
                return nume;
            
        }
        private void Client_Disconnected(WindowsFormsApp3.ClientSettings cs)
        {
            //this.Invoke(() =>
            //{

            //   // mListBoxUsersList.Items.Remove(this);
            //    //for (int i = 0; i < mListBoxUsersList.Items.Count; i++)
            //    //{


            //    //    var client = mListBoxUsersList.Items[i].Tag as Client;
            //    //    if (client.Ip == sender.Ip)
            //    //    {
            //    //        txtReceive.Text += "<< " + clientList.Items[i].SubItems[1].Text + " has left the room >>\r\n";
            //    //        BroadcastData("RefreshChat|" + txtReceive.Text);
            //    //        clientList.Items.RemoveAt(i);

            //    //    }
            //    //}
            //});
        }
        public List<string> nrLegatura;
        Sender s = new Sender();
        Receiver r = new Receiver();
        protected override void OnLoad(EventArgs e)
        {
            //if (formLogin.getCkeck() == true)
            //{
            
                base.OnLoad(e);
           
            // Client.Connected += Client_Connected;
            //Client.Connect(ip, 2014);
            //Client.Send("Connect|" + userName + "|connected");
            //Client.Received += _client_Received;
            //Client.Disconnected += Client_Disconnected;
            //Ticker();
                formLogin.Client.Received += _client_Received;
                formLogin.Client.Disconnected += Client_Disconnected;
                 Text = "TCP Chat ";
          //  formLogin.Hide();
                formLogin.ShowDialog();
                //loginForm.ShowDialog();
          //  }
           // else Application.Exit();
          
        }
        public List<string> getIstorie()
        {
            return pChat.getMesajePrivate();
        }
        Administrator admin = new Administrator();
        List<string> qwe;
        string nrPrimit;
        bool verificare = false;
        string mesaj;
        string vorbitor;
        string ala;
        string persoana;
        private string mesajDeCriptat;
        public void _client_Received(WindowsFormsApp3.ClientSettings cs, string received)
        {
            var cmd = received.Split('|');
            switch (cmd[0])
            {
                case "admin":

                    this.Invoke(() =>
                    {

                        if (getThisUser().Trim() == cmd[1])
                        {
                            this.Hide();
                            admin.ShowDialog();
                        }

                    });
                    break;

                case "Users":
                    this.Invoke(() =>
                    {

                        mListBoxUsersList.Items.Clear();
                        for (int i = 1; i < cmd.Length; i++)
                        {
                            if (cmd[i] != "Connected" | cmd[i] != "RefreshChat" | cmd[i] != "Poftim") 
                            {
                                mListBoxUsersList.Items.Add(cmd[i]);
                            }
                        }
                    });
                    break;
                case "Message":
                    this.Invoke(() =>
                    {

                        mTextBoxReceiveMessages.Text += cmd[1] + "\r\n";

                        if (cmd[1] == "RefreshChat")
                        {
                            mListBoxUsersList.Items.Clear();
                            for (int i = 2; i < cmd.Length; i++)
                            {
                                if (cmd[i] != "Connected" | cmd[i] != "RefreshChat" | cmd[i] != "Message")
                                {
                                    mListBoxUsersList.Items.Add(cmd[i]);
                                }
                                // mTextBoxReceiveMessages.Text += cmd[1] + "\r\n";
                            }
                        }

                    });
                    break;
                case ".":
                    this.Invoke(() =>
                    {

                        mListBoxUsersList.Items.Clear();
                        for (int i = 1; i < cmd.Length; i++)
                        {
                            
                                mListBoxUsersList.Items.Add(cmd[i]);
                            
                        }
                    });
                    break;
                //case "pMessage":
                //    this.Invoke(() =>
                //    {
                //        pChat.Text = pChat.Text.Replace("user", formLogin.getUser());
                //        pChat.Show();
                //    });
                case "AifostBanat":

                    if(getThisUser().Trim() == cmd[1])
                    {
                        MessageBox.Show("Ai fost banat!E irevocabil, bafta!");
                        this.Hide();
                    }

                    break;
                case "RefreshChat":
                    this.Invoke(() =>
                    {

                        //  mListBoxUsersList.Items.Clear();
                        //mListBoxUsersList.Items.Clear();
                        mTextBoxReceiveMessages.Text = cmd[1];
                        
                        //for (int i = 2; i < cmd.Length; i++)
                        //{
                        //    if (cmd[i] != "Connected" | cmd[i] != "RefreshChat" | cmd[i] != "Message")
                        //    {
                        //        mListBoxUsersList.Items.Add(cmd[i]);
                        //    }
                        //    // mTextBoxReceiveMessages.Text += cmd[1] + "\r\n";
                        //}
                        //foreach (var item in cmd[2])
                        //{
                        //    mListBoxUsersList.Items.Add(cmd[2]);
                        //}

                    });
                    break;
                case "pMessage":
                    this.Invoke(() =>
                    {
                        //bool leg = false;
                        //foreach (var item in nrLegatura)
                        //{
                        //    if(item == cmd[4])
                        //    {
                        //        leg = true;
                        //    }
                        //}
                        
                        // mTextBoxReceiveMessages.Text += cmd[1] + "\r\n";
                        
                            //vorbitor = String.Empty;
                            //mesaj = String.Empty;
                            //// PrivateChat pc = new PrivateChat(this);
                            ////  MessageBox.Show("aoleu");
                            //mesaj = cmd[1].Trim();
                            //vorbitor = cmd[3].Trim();
                            //nrPrimit = String.Empty;

                            //nrPrimit = cmd[4].Trim();
                            //MessageBox.Show("a" + cmd[2].Trim());
                            //MessageBox.Show("a" +vorbitor);
                            //MessageBox.Show("a" +mesaj);
                            //MessageBox.Show("a" + nrPrimit);

                          //  mTextBoxReceiveMessages.Text = mesaj;

                        
                        

                        //MessageBox.Show("aoelu");
                        //pChat.Text = formLogin.getUser();
                        //pChat.Show();

                    });

                    
                    break;
                case "mesajDecriptat":
                    this.Invoke(() =>
                    {
                        //bool leg = false;
                        //foreach (var item in nrLegatura)
                        //{
                        //    if(item == cmd[4])
                        //    {
                        //        leg = true;
                        //    }
                        //}

                        // mTextBoxReceiveMessages.Text += cmd[1] + "\r\n";
                        if (getThisUser().Trim() == cmd[2].Trim())
                        {
                            vorbitor = String.Empty;
                            mesaj = String.Empty;
                            // PrivateChat pc = new PrivateChat(this);
                            //  MessageBox.Show("aoleu");
                            mesaj = cmd[1].Trim();
                            vorbitor = cmd[2].Trim();
                            nrPrimit = String.Empty;

                            nrPrimit = cmd[4].Trim();
                            //MessageBox.Show("a" + cmd[2].Trim());
                            //MessageBox.Show("a" +vorbitor);
                            //MessageBox.Show("a" +mesaj);
                            //MessageBox.Show("a" + nrPrimit);

                            //  mTextBoxReceiveMessages.Text = mesaj;
                        }



                        //MessageBox.Show("aoelu");
                        //pChat.Text = formLogin.getUser();
                        //pChat.Show();

                    });


                    break;

                case "DeLaServerPtAlaCautat":
                    this.Invoke(() =>
                    {
                     
                        if (getThisUser().Trim() == cmd[4].Trim())
                        {
                            byte[] mesaj1 = HttpServerUtility.UrlTokenDecode(cmd[1]);
                            byte[] chestie = HttpServerUtility.UrlTokenDecode(cmd[2]);
                            byte[] cheiePublica = HttpServerUtility.UrlTokenDecode(cmd[3]);
                            mesaj = String.Empty;
                            mesaj = r.Receive(mesaj1, chestie, cheiePublica);
                            nrPrimit = String.Empty;
                            vorbitor = String.Empty;
                            vorbitor = getThisUser();
                            nrPrimit = cmd[5].Trim();

                        }



                        

                    });


                    break;
                

                case "cheieServerReceiver":
                    this.Invoke(() =>
                    {
                       if(cmd[3].Trim()  == getThisUser())
                        { 

                            ServerCheie = String.Empty;
                            ServerCheie = cmd[1].Trim();
                            //nrPrimit = String.Empty;
                            //nrPrimit = cmd[2].Trim();
                            

                                byte[] cheieServer = HttpServerUtility.UrlTokenDecode(ServerCheie);
                                s.Mesaj(cheieServer);
                                
                                byte[] mesajCriptat = s.sendToReceiver(cheieServer, nou);
                                byte[] chestiaAia = s.sendChestiaAia();
                                byte[] senderPublicKey = s.getSenderPublicKey();
                                string mesajul = HttpServerUtility.UrlTokenEncode(mesajCriptat);
                                string chestie = HttpServerUtility.UrlTokenEncode(chestiaAia);
                                string cheiePublica = HttpServerUtility.UrlTokenEncode(senderPublicKey);
                             //   MessageBox.Show("in utilizator sender   ::: " + mesajul);
                                formLogin.Client.Send("mesajCriptat|" + getThisUser().Trim() + "|" + cmd[2].Trim() + "|" + nrCautat + "|" + mesajul + "|" + chestie + "|" + cheiePublica);

                            
                        }
                       else if(cmd[4].Trim() == getThisUser())
                        {
                            System.Threading.Thread.Sleep(100);
                            byte[] receiverPublicKey = r.ReceiverPublicKey();
                            string cheiePublicaReceiver = HttpServerUtility.UrlTokenEncode(receiverPublicKey);
                            //MessageBox.Show("in utilizator receiver cheie   ::: " + cheiePublicaReceiver);
                            formLogin.Client.Send("CheieReceiver|" + getThisUser().Trim() + "|" + cmd[2].Trim() + "|" + cheiePublicaReceiver); //acesta + nr + cheiaMea


                        }
                       // nrPrimit = String.Empty;
                       
                    });
                    break;
                case "privateChat":
                    this.Invoke(() =>
                    {
                        // mTextBoxReceiveMessages.Text += cmd[1] + "\r\n";
                        if (getThisUser().Trim() == cmd[1].Trim())
                        {


                            //string[] str = null;
                            //list.Trim();
                            //list.ToString();
                            //str = list.Split('+');
                            //  recipient = cmd[1].Trim();
                            string t = cmd[3].Trim();
                            persoana = cmd[2].Trim();
                            PrivateChat pc = new PrivateChat(this);
                            pc.MyProperty = t;
                            // recipient = getThisUser().Trim();
                            //   persoana = cmd[2].Trim();
                            verificare = true;
                            // ala = cmd[2].Trim();
                            //  qwe.Add(cmd[2].Trim());


                            //  MessageBox.Show("aoleu");
                            pc.Text = cmd[2].Trim();
                            pc.Show();
                          
                            
                            
                        }
                        if (getThisUser().Trim() == cmd[2].Trim())
                        {
                            
                            string t = cmd[3].Trim();
                            PrivateChat cc = new PrivateChat(this);
                            cc.MyProperty = t;
                            cc.Text = getUserForPChat();
                            cc.Show();
                            verificare = false;
                            //cc.Text = getUserForPChat();
                            //cc.Client = Client;
                            // qwe.Add(cmd[1].Trim());
                            

                        }

                        //MessageBox.Show("aoelu");
                        //pChat.Text = formLogin.getUser();
                        //pChat.Show();

                    });
            break;
                case "LogInFailed":
                    if (getThisUser().Trim() == cmd[1].Trim())
                    {
                        MessageBox.Show("UserName sau Password gresite");
                        Application.Restart();
                    }
                    break;
                case "Disconnect":
                    this.Invoke(() =>
                    {
                        if (getThisUser().Trim() == cmd[1].Trim())
                        {
                            // mListBoxUsersList.Items.Clear();
                            this.Hide();
                        }
                    });
                    break;
                case "Ban":
                    this.Invoke(() =>
                    {
                        if (getThisUser().Trim() == cmd[1].Trim())
                        {
                            // mListBoxUsersList.Items.Clear();
                            this.Hide();
                        }
                    });
                    break;
                    //     default:
                    //         this.Invoke(() =>
                    //{
                    //    mListBoxUsersList.Items.Clear();
                    //    for (int i = 1; i < cmd.Length; i++)
                    //    {
                    //        if (cmd[i] != "Users" | cmd[i] != "Connected" | cmd[i] != "RefreshChat" | cmd[i] != "Message")
                    //        {
                    //            mListBoxUsersList.Items.Add(cmd[i]);
                    //        }
                    //        mTextBoxReceiveMessages.Text += cmd[1] + "\r\n";
                    //    }
                    //});
                    //         break;
            }
        }
        private string nou;
        private  string nrCautat;
        private string cf;
        public void getMesajDeCriptat(string txt, string proprietate, string interlocutor)
        {
            nou = String.Empty;
            nrCautat = String.Empty;
            cf = String.Empty;
            nou = txt;
            nrCautat = proprietate;
            cf = interlocutor;
        }
        public string getServerCheie()
        {
            return ServerCheie;
        }
        public string getVorbitor()
        {
            return vorbitor;
        }
        public string getAla()
        {
            return ala;
        }
       public List<string> getListVorbitor()
        {
            return qwe;
        }
        public string getPersoana()
        {
            return persoana;
        }
        public string getNrPrimit()
        {
            return nrPrimit;
        }
        public bool ReturinVerificare()
        {
            return verificare;
        }
        public string getPrivatMessage()
        {
            return mesaj;
            
        }
        private void Client_Connected(object sender, EventArgs e)
        {
            this.Invoke(Close);
        }

        private void mTextBoxMessages_TextChanged(object sender, EventArgs e)
        {

        }

        private void mButtonSend_Click(object sender, EventArgs e)
        {
            if (mTextBoxInput.Text != string.Empty)
            {
                formLogin.Client.Send("Message|" + formLogin.getUser() + "|" + mTextBoxInput.Text);
                mTextBoxReceiveMessages.Text += formLogin.getUser() + " says: " + mTextBoxInput.Text + "\r\n";
                mTextBoxInput.Text = string.Empty;
            }
            mTextBoxInput.Text = string.Empty;
        }

        private void mTextBoxInput_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void mTextBoxReceiveMessages_TextChanged(object sender, EventArgs e)
        {
            mTextBoxReceiveMessages.SelectionStart = mTextBoxReceiveMessages.TextLength;
            
        }


        // OpenFileDialog dlg_open_file = new OpenFileDialog();
        private void mButtonSendAttachment_Click(object sender, EventArgs e)
        {





            Atasament at = new Atasament();
            ServerAtasament s = new ServerAtasament();
            s.Show();
            at.Show();






























            //if (dlg_open_file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    String selected_file = dlg_open_file.FileName;
            //    String file_name = Path.GetFileName(selected_file);
            //    FileStream fs = new FileStream(selected_file, FileMode.Open);
            //    TcpClient tc = new TcpClient("127.0.0.1", 2014);
            //    NetworkStream ns = tc.GetStream();
            //    byte[] data_tosend = CreateDataPacket(Encoding.UTF8.GetBytes("125"), Encoding.UTF8.GetBytes(file_name));
            //    ns.Write(data_tosend, 0, data_tosend.Length);
            //    ns.Flush();
            //    Boolean loop_break = false;
            //    while (true)
            //    {
            //        if (ns.ReadByte() == 2)
            //        {
            //            byte[] cmd_buff = new byte[3];
            //            ns.Read(cmd_buff, 0, cmd_buff.Length);
            //            byte[] recv_data = ReadStream(ns);
            //            switch (Convert.ToInt32(Encoding.UTF8.GetString(cmd_buff)))
            //            {
            //                case 126:
            //                    long recv_file_pointer = long.Parse(Encoding.UTF8.GetString(recv_data));
            //                    if (recv_file_pointer != fs.Length)
            //                    {
            //                        fs.Seek(recv_file_pointer, SeekOrigin.Begin);
            //                        int temp_buff_length = (int)(fs.Length - recv_file_pointer < 20000 ? fs.Length - recv_file_pointer : 20000);
            //                        byte[] temp_buff = new byte[temp_buff_length];
            //                        fs.Read(temp_buff, 0, temp_buff.Length);
            //                        byte[] data_to_send = CreateDataPacket(Encoding.UTF8.GetBytes("127"), temp_buff);
            //                        ns.Write(data_to_send, 0, data_to_send.Length);
            //                        ns.Flush();
            //                        pb_upload.Value = (int)Math.Ceiling((double)recv_file_pointer / (double)fs.Length * 100);
            //                    }
            //                    else 
            //                    {
            //                        byte[] data_to_send = CreateDataPacket(Encoding.UTF8.GetBytes("128"), Encoding.UTF8.GetBytes("Close"));
            //                        ns.Write(data_to_send, 0, data_to_send.Length);
            //                        ns.Flush();
            //                        fs.Close();
            //                        loop_break = true;
            //                    }
            //                    break;
            //                default:
            //                    break;
            //            }
            //        }
            //        if (loop_break == true)
            //        {
            //            ns.Close();
            //            break;
            //        }
            //    }
            //}
        }
        
        public string getThisUser()
        {
            return formLogin.getUser();
        }
        private void Utilizator_Load(object sender, EventArgs e)
        {

        }

        private void mContextMenuStripUserClick_Opening(object sender, CancelEventArgs e)
        {

           
        }

        private void privateChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getUserForPChat() != null)
            {
                
               

                //formLogin.Client.Send("Message|" + formLogin.getUser() + "|" + mTextBoxInput.Text);
                formLogin.Client.Send("pChat|" + getUserForPChat() + "|" + getThisUser());

                

            }
        }

        private void mTextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    mButtonSend.PerformClick();
            //    mTextBoxInput.Text = string.Empty;
            //}

        }




        //public byte[] ReadStream(NetworkStream ns)
        //{
        //    byte[] data_buff = null;

        //    int b = 0;
        //    String buff_length = "";
        //    while ((b = ns.ReadByte()) != 4)
        //    {
        //        buff_length += (char)b;
        //    }
        //    int data_length = Convert.ToInt32(buff_length);
        //    data_buff = new byte[data_length];
        //    int byte_read = 0;
        //    int byte_offset = 0;
        //    while (byte_offset < data_length)
        //    {
        //        byte_read = ns.Read(data_buff, byte_offset, data_length - byte_offset);
        //        byte_offset += byte_read;
        //    }

        //    return data_buff;
        //}
        //private byte[] CreateDataPacket(byte[] cmd, byte[] data)
        //{
        //    byte[] initialize = new byte[1];
        //    initialize[0] = 2;
        //    byte[] separator = new byte[1];
        //    separator[0] = 4;
        //    byte[] datalength = Encoding.UTF8.GetBytes(Convert.ToString(data.Length));
        //    MemoryStream ms = new MemoryStream();
        //    ms.Write(initialize, 0, initialize.Length);
        //    ms.Write(cmd, 0, cmd.Length);
        //    ms.Write(datalength, 0, datalength.Length);
        //    ms.Write(separator, 0, separator.Length);
        //    ms.Write(data, 0, data.Length);
        //    return ms.ToArray();
        //}
    }
}

