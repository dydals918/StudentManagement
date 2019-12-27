using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProjcet
{
    class DBManager
    {
        private static DBManager instance = new DBManager();
        private static OracleConnection connection;
        private static bool connect = false;

        public static DBManager GetInstance()
        {

            return instance;
        }

        private DBManager()
        {
            // .. Some initialization for this singleton object
        }

        public object DBSaclar(string query)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connection;
            cmd.CommandText = query;
            object result= cmd.ExecuteScalar();
            return result;
        }

        public void DBConnection(OracleConnection con)
        {
            if (!connect)
            {
                connection = con;
                connection.ConnectionString = "USER ID=WOOKHYUN;PASSWORD=qkrtpwls;" + "DATA SOURCE = dbforproject.cwunyvqxb9zk.us-east-2.rds.amazonaws.com:1521/ORCL;";
                connection.Open();
                //MessageBox.Show("DB connection success"); //메세지 박스로 확인
                connect = true;
            }

        }
        public OracleDataReader ExecuteReader(string query) //executeReader 사용시 ex) select 구문
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connection;
            cmd.CommandText = query;

            OracleDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        public int ExecuteNon(string query)//executenonquery 사용시 ex)count 구문
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connection;
            cmd.CommandText = query;
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        //각 executeReader, nonquery 는 수업 피피티에 있습니다.
        // using Oracle.ManagedDataAccess.Client 추가 해야합니다.
        // namespaece 안 클래스 전문 입니다.
    }
}
