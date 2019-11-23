using QuanLyQuanCaFe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaFe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance { 
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; } 
        }
        private AccountDAO() { }

        public bool Login(string username, string password)
        {
            string query = "USP_Login @username , @password";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password});
            return result.Rows.Count > 0 ;
        }

        public Account GetAccountByUsername(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from account where username = '" + userName+ "'");
            foreach(DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public bool UpdateAccount(string username, string displayName, string pass, string newpass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @username , @displayName , @passWord , @newPassWord ", new object[] { username, displayName, pass, newpass });

            return result > 0;
        }
    }
}
