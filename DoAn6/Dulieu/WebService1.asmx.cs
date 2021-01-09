using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data.Common;
namespace Dulieu
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-GKACKIO\\SQLEXPRESS;Initial Catalog=QuanLyNhanvien24;Integrated Security=True");
        [WebMethod]
        public int  HelloWorld()
        {
            return 7+8 ;
        }
        [WebMethod]
        public DataSet getdata()
        {
            conn.Open();
            string query= "select N.MANV,TENNV,GIOITINH,TRINHDO,NGAYSINH,HONNHAN,SOCMND,QUEQUAN,PHONE,EMAIL,C.TEN,P.TEN from NHANVIEN n JOIN PHONGBAN P ON N.PHONGBAN = P.MAPB JOIN CHUCVU C ON N.CHUCVU = C.MACV; ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            conn.Close();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        public DataSet getAccount()
        {
            conn.Open();
            string query = "select * from USERS ;";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            conn.Close();
            da.Fill(ds);
            return ds;
        }
       [WebMethod]
       public DataSet getInformationDepartment(string ten)
        {
            conn.Open();
            string query= "select B.TEN,DIACHI,CHITIEU,DIACHI,N.TENNV from PHONGBAN B JOIN NHANVIEN N ON N.PHONGBAN = B.MAPB WHERE B.TEN = N'"+ten+@"' AND N.CHUCVU = 'TP'; ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            conn.Close();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        public DataSet getInformationEmplayee(string ten)
        {
            conn.Open();
            string query = "select N.MANV, TENNV, GIOITINH, TRINHDO, NGAYSINH, HONNHAN, SOCMND, QUEQUAN, PHONE, EMAIL, B.TEN, C.TEN from PHONGBAN B JOIN NHANVIEN N ON N.PHONGBAN = B.MAPB JOIN CHUCVU C ON N.CHUCVU = C.MACV WHERE B.TEN = N'"+ten+@"' AND NOT N.CHUCVU = 'TP'; ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            conn.Close();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        public string getMaphongban(string tenPB)
        {
            string name = "";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            string query = "select MAPB  from PHONGBAN WHERE TEN=N'" + tenPB + @"';";
            cmd.Connection = conn;
            cmd.CommandText = query;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int index = reader.GetOrdinal("MAPB");
                        name = reader.GetString(index);
                    }
                }
            }

                return name ;
        }
        [WebMethod]
        public string getMaChucVu(string tenCV)
        {
            string name = "";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            string query = "select MACV  from CHUCVU WHERE TEN=N'" + tenCV + @"';";
            cmd.Connection = conn;
            cmd.CommandText = query;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int index = reader.GetOrdinal("MACV");
                        name = reader.GetString(index);
                    }
                }
            }

            return name;
        }
        // thêm nhân viên vào cơ sở dữ liệu
        [WebMethod]
        public bool insert(string manv,string tennv, string gioitinh,string trinhdo,DateTime ngaysinh,string honnhn,string socmnn,string que,string phone,string email,string phongban,string cv)
        {
            string mapb = getMaphongban(phongban);
            string macv = getMaChucVu(cv);
            try
            {
                conn.Open();
                string query = "insert into NHANVIEN VALUES (N'" + manv + @"', N'" + tennv + @"', N'" + gioitinh + @"', N'" + trinhdo + @"', N'" + ngaysinh + @"',N'" + honnhn + @"',N'" + socmnn + @"',N'" + que + @"',N'" + phone + @"',N'" + email + @"',N'" + mapb + @"',N'" + macv + @"');";
                SqlCommand com = new SqlCommand(query,conn);
                com.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // lay danh sach tinh trang 
        [WebMethod]
        public DataTable getTinhTrang()
        {
            conn.Open();
            string query = "select * from TINHTRANG;";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);

            return dtbl;
        }
    }

    }