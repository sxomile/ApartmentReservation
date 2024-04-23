using Client.Forms;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    internal class LoginGuiController
    {
        private static LoginGuiController instance;
        public static LoginGuiController Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoginGuiController();

                return instance;
            }
        }
        private FrmLogin frmLogin;
        internal void ShowFrmLogin()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin = new FrmLogin();
            frmLogin.btnLogin.Click += Login;
            frmLogin.AutoSize = true;
            Application.Run(frmLogin);
        } 

        internal void Login(object sender, EventArgs e)
        {
            Communication.Instance.Connect();
            User korisnik = Communication.Instance.Login(frmLogin.txtUsername.Text, frmLogin.txtPassword.Text);
            if(korisnik != null)
            {
                frmLogin.Hide();
                MainCoordinator.Instance.ShowFrmMain(korisnik.Uloga);
                frmLogin.Close();
            }
            else
            {
                MessageBox.Show("Neuspesan login!");
            }
        }

    }
}
