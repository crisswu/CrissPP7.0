using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace Bowtech
{
    public class SQLite
    {
         //连接数据库
        public string DBPath= "";
        SQLiteConnection conn = new SQLiteConnection();
        SQLiteConnectionStringBuilder connstr = new SQLiteConnectionStringBuilder();

        public SQLite()
        {
            
        }
        //注意 该SQLite 是 SQLite3 版本   如果是 SQLite2 版本则报错用不了
        public void InitDB()
        {
            connstr.DataSource = DBPath;
            conn.ConnectionString = connstr.ToString();
        }
          
        //执行SQL
        public void ExecuteNonQuery(string Sql)
        {
            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = Sql;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ep)
            {
                string s = ep.Message;
            }
        }
        //执行SQL 并返回 结果
        public int ExecuteNonQueryReturn(string Sql)
        {
            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = Sql;
                cmd.Connection = conn;
                int ret = cmd.ExecuteNonQuery();
                conn.Close();
                return ret;
            }
            catch (Exception ep)
            {
                string s = ep.Message;
                return 0 ;
            }
        }

        //返回单一字符串
        public string ExecuteString(string Sql)
        {
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = Sql;
            cmd.Connection = conn;
            object obj =  cmd.ExecuteScalar();
            conn.Close();
            if (obj != null)
                return obj.ToString();
            else
                return "";
        }
        //返回单一整型
        public int ExecuteInt(string Sql)
        {
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = Sql;
            cmd.Connection = conn;
            object obj = cmd.ExecuteScalar();
            conn.Close();
            if (obj != null && obj!=DBNull.Value)
                return Convert.ToInt32(obj);
            else
                return 0;
        }
        //返回单一浮点型
        public double ExecuteDouble(string Sql)
        {
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = Sql;
            cmd.Connection = conn;
            object obj = cmd.ExecuteScalar();
            conn.Close();
            if (obj != null)
                return Convert.ToDouble(obj);
            else
                return 0;
        }
        //返回单一Object
        public object ExecuteScalar(string Sql)
        {
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = Sql;
            cmd.Connection = conn;
            object obj = cmd.ExecuteScalar();
            conn.Close();
            return obj;
        }
        
        //返回数据集
        public DataTable ExecuteDataTable(string Sql)
        {
            try
            {
                SQLiteDataAdapter dta = new SQLiteDataAdapter(Sql, conn);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(dta);
                dta.InsertCommand = scb.GetInsertCommand();
                DataSet DS = new DataSet();
                dta.FillSchema(DS, SchemaType.Source, "Notes");    //加载表架构 注意
                dta.Fill(DS, "Notes");    //加载表数据
                return DS.Tables[0];
            }
            catch (Exception ep)
            {
                string mes = ep.Message;
                return null;
            }
        }

    }
}
