  public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            this.AutoScroll = false;
        }


        HomePage _Home = new HomePage();
        ConfigsPage _ConfigsPage = new ConfigsPage();
        StatusPage _StatusPage = new StatusPage();

        private void Main_Load(object sender, EventArgs e)
        {
            _Home.Location = new Point(0, 0);
            _Home.MdiParent = this;
            _Home.Show();
        }


        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                BL.SSH_Call.Stop_Connection();
                BL.Registry_config.UnSet_Reg();
            }
            catch
            {

            }

            Environment.Exit(0);
        }

        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
    
            BtnClose.BackColor = Color.Orange;
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            BtnClose.BackColor = Color.FromArgb(32,32,32);
        }

        private void BtnMini_MouseEnter(object sender, EventArgs e)
        {
            BtnMini.BackColor = Color.Orange;
        }

        private void BtnMini_MouseLeave(object sender, EventArgs e)
        {
            BtnMini.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void BtnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            _Home.Location = new Point(0, 0);
            _StatusPage.Hide();
            _ConfigsPage.Hide();
            _Home.Show();
        }

        private void BtnHome_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Orange;
        }

        private void BtnHome_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.White;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void BtnConfigs_Click(object sender, EventArgs e)
        {

            _ConfigsPage.Location = new Point(0, 0);
            _ConfigsPage.MdiParent = this;
            _Home.Hide();
            _StatusPage.Hide();
            _ConfigsPage.Show();
        }

        private void BtnStatus_Click(object sender, EventArgs e)
        {

            _StatusPage.Location = new Point(0, 0);
            _StatusPage.MdiParent = this;
            _Home.Hide();
            _ConfigsPage.Hide();
            _StatusPage.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BL.SSH_Call.Stop_Connection();
                BL.Registry_config.UnSet_Reg();
            }
            catch
            {

            }
        }
