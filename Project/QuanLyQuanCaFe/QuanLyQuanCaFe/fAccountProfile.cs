using QuanLyQuanCaFe.DAO;
using QuanLyQuanCaFe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaFe
{
    public partial class fAccountProfile : Form
    {

        private Account loginAccount;

        public Account LoginAccount
        {
            get
            {
                return loginAccount;
            }
            set
            {
                loginAccount = value;

            }
        }


        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            changeAccount(loginAccount);
        }

        void changeAccount(Account acc)
        {
            txbUserName.Text = acc.Username;
            txbDisplayName.Text = acc.DisplayName;
            
        }

        void UpdateAccount()
        {
            string username = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            string pass = txbPassWord.Text;
            string newpass = txbNewPass.Text;
            string repass = txbReEnterPass.Text;
            if (!newpass.Equals(repass))
            {
                MessageBox.Show("vui lòng nhập đúng mật khẩu mới!");

            }else
            {
                if(AccountDAO.Instance.UpdateAccount(username, displayName, pass, newpass))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if(updateEventAccount!= null)
                    {
                        updateEventAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUsername(username)));
                    }
                } else
                {
                    MessageBox.Show("vui lòng điền đúng mật khẩu");
                }
            }

        }

        private event EventHandler<AccountEvent> updateEventAccount;
        public  event EventHandler<AccountEvent> UpdateEventAccount
        {
            add { updateEventAccount += value; }
            remove { updateEventAccount -= value; }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class AccountEvent:EventArgs
    {
        private Account acc;

        public Account Acc { get => acc; set => acc = value; }
        public AccountEvent(Account acc)
        {
            this.acc = acc;
        }
    }
}
