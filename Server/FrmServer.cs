using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        Server server;

        public FrmServer()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            server = new Server();
            server.Start();
            txtStatus.Text = "Server je pokrenut!";
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            server.Stop();
            txtStatus.Text = "Server je zaustavljen!";
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

    }
}
