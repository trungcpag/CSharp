﻿using QuanLyQuanCaFe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaFe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set { instance = value; }
        }
        private BillDAO() { }

        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.bill where idTable = "+id+" and status = 0");
            
            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }

            return -1;
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable", new object[] { id });
            //return true;
        }
        public int GetMaxBill()
        {
            try {
                return (int)DataProvider.Instance.ExecuteScalar("select MAX(id) from bill");
            } catch {
                return 1;
            }
        }
        public void CheckOut(int id)
        {
            string query = "update bill set status = 1 where id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}