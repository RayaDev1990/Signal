  public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            this.AutoScroll = false;
        
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            Thread _th = new Thread(SetValues);
            _th.Start();
        }


        public void SetValues()
        {
            GetDefault();
            GetIP();
      
        }

        public void GetIP()
        {
            lblIP.Text = BL.IPAddress.GetExternalIpAddress();
        }

        public void GetDefault()
        {
            SSHConfig _SSHConfig = BL.usr.GetDefault();

            if (_SSHConfig != null)
            {
                lblProfile.Text = _SSHConfig.C_Name;

                lblProfile.ForeColor = Color.Orange;

            }

            else
            {
                lblProfile.Text = "Not Selected";
                lblProfile.ForeColor = Color.Red;
            }
        }

        private void HomePage_Activated(object sender, EventArgs e)
        {
            Thread _th = new Thread(SetValues);
            _th.Start();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            int _ret = 0;
            if (BtnConnect.Text == "Connect")
            {
          
                _ret = BL.SSH_Call.Start_Connection();

                if (_ret == 0)
                {
                    BtnConnect.Text = "Disconnect";

                    lblStatus.Text = "Connected";

                    lblStatus.ForeColor = Color.Orange;

                    BtnConnect.BackColor = Color.FromArgb(138, 154, 91);

                    Thread _th = new Thread(SetValues);
                    _th.Start();
                }
            }
            else
            {
                _ret = BL.SSH_Call.Stop_Connection();

                if (_ret == -1)
                {
                    BtnConnect.Text = "Connect";

                    lblStatus.Text = "Disconnect";
                    lblStatus.ForeColor = Color.Red;

                    BtnConnect.BackColor = Color.FromArgb(40, 40, 40);

                    Thread _th = new Thread(GetIP);
                    _th.Start();
                }


            }
        }
