using Client.Forms;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.IO;
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
            try
            {
                Communication.Instance.Connect();
                User korisnik = Communication.Instance.Login(frmLogin.txtUsername.Text, frmLogin.txtPassword.Text);
                if (korisnik != null)
                {
                    frmLogin.Hide();
                    MainCoordinator.Instance.ShowFrmMain(korisnik);
                    frmLogin.Close();
                }
                else
                {
                    MessageBox.Show("Neuspesan login!");
                }
            } catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server je ugasen!");
            }
        }

    }
}
