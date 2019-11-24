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
        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("select Username, DisplayName, type from Account");
        }
        public bool InsertAccount(string username, string displayname, int type)
        {
            string query = string.Format("insert dbo.Account(username, displayname, type, passWord) values (N'{0}', N'{1}' , {2}, 0  )", username, displayname, type);
            int res = DataProvider.Instance.ExecuteNonQuery(query);
            return res > 0;
        }

        public bool UpdateAccount(string name, string displayname, int type)
        {
            string query = string.Format("update Account set  displayName = N'{1}' , type = {2} where username = N'{0}' ", name, displayname, type );
            int res = DataProvider.Instance.ExecuteNonQuery(query);
            return res > 0;
        }
        public bool DeleteAccount(string username)
        {
           // BillInfoDAO.Instance.DeleteBillInfoByFoodID(idfood);
            string query = string.Format("Delete Account where username = N'{0}' ", username);
            int res = DataProvider.Instance.ExecuteNonQuery(query);
            return res > 0;
        }

        public bool ResetPass(string username)
        {
            // BillInfoDAO.Instance.DeleteBillInfoByFoodID(idfood);
            string query = string.Format("update Account set passWord = 0 where username = N'{0}' ", username);
            int res = DataProvider.Instance.ExecuteNonQuery(query);
            return res > 0;
        }
    }
}
