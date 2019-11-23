using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaFe.DTO
{
    public class Account
    {
        public Account(string username, string displayName, int type, string passWord = null)
        {
            this.username = username;
            this.displayName = displayName;
            this.type = type;
            this.passWord = passWord;
        }

        public Account(DataRow row) {
            this.username = row["username"].ToString();
            this.displayName = row["displayName"].ToString();
            this.type = (int)row["type"];
            this.passWord = row["passWord"].ToString();
        }

        private string username;
        private string displayName;
        private string passWord;
        private int type;

        public string Username { get => username; set => username = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int Type { get => type; set => type = value; }
    }
}
