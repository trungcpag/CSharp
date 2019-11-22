using QuanLyQuanCaFe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaFe.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return instance; }
            private set { instance = value; }
        }
        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.billInfo where idBill = " + id);
            Console.WriteLine("id  " + data.ToString());
            foreach(DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                Console.WriteLine("Table " + info.Count);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }
    }
}
