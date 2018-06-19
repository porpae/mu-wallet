using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace mu_wallet
{
    public class connectionDatabase
    {
        //20131112 somboon ติดต่อฐานข้อมูล
        /*--------------------SQL------------------------*/
        string strConnString = "Server=10.98.94.140;UID=; PASSWORD=1234;Database=RFID-DB;Max Pool Size=9000000;Connect Timeout=9000000;";

        /// <ConnectDB details>
        /// Method Name(ชื่อเมธอด) :ConnectDB
        /// Author(ผู้ทำ) : somboon siyanglakang
        /// Create date(วันที่ทำ) : 2013-11-12
        /// Description(ใช้ทำหน้าที่อะไร) : สร้าง Connect กับฐานข้อมูล
        /// Parameter(ค่าที่่ส่งเข้ามาในเมธอด) : คำสั่งSQL,ชื่อตารางในฐานข้อมูล
        /// </ConnectDB>
        public DataSet ConnectDB(string strSql, string strTable)
        {
            DataSet ds = new DataSet();

            SqlConnection objConn = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();

            objConn.ConnectionString = strConnString;

            try
            {
                objConn.Open();

                adapter.SelectCommand = new SqlCommand(strSql, objConn);
                adapter.Fill(ds, strTable);

                objConn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Can not open connection ! ");//20150416
            }

            return (ds);
        }

        public DataSet ConnectDB(string strSql)
        {
            DataSet ds = new DataSet();

            //สร้างออบเจ็กต์ SqlConnection เพื่อเชื่อมต่อฐานข้อมูล Sql Server 2008 
            //พร้อมกับกำหนด provider ส่วนของการเชื่อมต่อฐานข้อมูลให้กับ ออบเจ็กต์ SqlConnection
            SqlConnection conn = new SqlConnection(strConnString); ;

            try
            {
                conn.Open();//เปิดการเชื่อมต่อ
                string sql = strSql;//"SELECT * FROM tb_customer";
                //สร้างออบเจ็กต์ SqlCommand พร้อมกับเตรียมคำสั่งที่จะส่งไปฐานข้อมูล โดยมีพาราเมเตอร์คือ คำสั่ง sql,ตัวแปร Connection
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();//คิวรี่ข้อมูลให้กับ SqlDataReader ชื่อ dr

                if (dr.HasRows)//ถ้ามีรายการเร็คคอร์ดอยู่แล้ว
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    ds.Tables.Add(dt);
                    conn.Close();
                    //MessageBox.Show("55552--"+dt.Rows.Count.ToString());
                }
            }
            catch (Exception ex)
            {
                ercode = ex.ToString();
                erstatus = true;
            }
            return (ds);
        }//แบบเขียน SQL เองทั้งหมด

        // แจ้ง Error
        bool erstatus = false; // ไว้บอกสถานะการ error
        public bool erStatus
        {
            get { return erstatus; }
        }
        string strsql = ""; // ไว้ใช้ตรวจสอบ SQL
        public string strSql
        {
            get { return strsql; }
        }
        string ercode = ""; // ไว้บอกข้อความ error 
        public string erCode
        {
            get { return ercode; }
        }

        /// <Select details>
        /// Method Name(ชื่อเมธอด) : select
        /// Author(ผู้ทำ) : somboon siyanglakang
        /// Create date(วันที่ทำ) : 2014-11-12
        /// Description(ใช้ทำหน้าที่อะไร) : ดึงข้อมูลจากตารางที่ต้องการจากฐานข้อมูล
        /// Parameter(ค่าที่่ส่งเข้ามาในเมธอด) : ชื่อตาราง,เงื่อนไขในการดึง
        /// Call other Methods(เมธอดอื่นที่ถูกเรียกใช้งานมีอะไรบ้าง) : ConnectDB 
        /// </Select>
        public DataSet select(string strTable)
        {
            DataSet ds = new DataSet();

            string strSql = "SELECT * FROM " + strTable;

            ds = ConnectDB(strSql, strTable);

            return ds;
        }// select 1 TB
        public DataSet select(string strTable, string whereColumn)
        {
            DataSet ds = new DataSet();

            string strSql = "SELECT * FROM " + strTable + " WHERE " + whereColumn;

            ds = ConnectDB(strSql, strTable);

            return ds;
        }//select แบบเขียน WHERE เอง
        public DataSet select(string views, string strTable, string whereColumn)
        {
            DataSet ds = new DataSet();

            string strSql = "SELECT " + views + " FROM " + strTable + " WHERE " + whereColumn;

            ds = ConnectDB(strSql, strTable);

            return ds;
        }//select แบบเขียน WHERE เอง

        public void insertData(string tableName, string columnNames, string values)
        {
            DataSet ds = select(tableName);
            DataRow dr = ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1];

            int sId = Convert.ToInt16(dr[0].ToString()) + 1;

            string strSql = "INSERT INTO " + tableName + "(" + columnNames + ") VALUES(" + values + ")";

            ConnectDB(strSql);
        }
        public void updateData(string tableName, string txtSet, string txtWhere)
        {
            //DataSet ds = select("musisSite");
            string strSql = "UPDATE " + tableName + " SET " + txtSet + "  WHERE " + txtWhere;
            ConnectDB(strSql);
        }
        public void deleteData(string tableName, string txtWhere)
        {
            //DataSet ds = select("musisSite");
            string strSql = "DELETE FROM " + tableName + "  WHERE " + txtWhere;
            ConnectDB(strSql);
        }
    }
}