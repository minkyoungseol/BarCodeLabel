using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Module
{
    public class CM_DBLIB
    {
        private static CM_DBLIB _default;
        public static CM_DBLIB Default
        {
            get
            {
                if (_default == null)
                    _default = new CM_DBLIB();
                return _default;
            }
        }

        //clsINI INI = new clsINI();
        //clsLog Log = new clsLog();

        public string ErMsg = "";
        public string Server = "";
        public string Port = "";
        public string User = "";
        public string Password = "";
        public string DataBase = "";
        public string TimeOut = "15";

        public SqlConnection initDB()
        {
            Server = "121.140.146.176";
            Port = "2476";
            User = "sa";
            Password = "aodlfwjdqh2476!";
            DataBase = "MIT_TEST";
            TimeOut = "0";

            //Server = Server.Replace("\0", "121.140.146.176");
            //Port = Port.Replace("\0", "2476");
            //User = User.Replace("\0", "sa");
            //Password = Password.Replace("\0", "aodlfwjdqh2476!");
            //DataBase = DataBase.Replace("\0", "MIT_TEST");
            //TimeOut = TimeOut.Replace("\0", "0");


            //SqlConnection sqlConnection = new SqlConnection("Server=" + Server + ";uid=" + User + ";pwd=" + Password 
            //    + ";database=" + DataBase + ";Timeout=" + TimeOut);

            SqlConnection sqlConnection = new SqlConnection("Server=" + Server + "," + Port + ";uid=" + User + ";pwd=" + Password
                + ";database=" + DataBase);

            return sqlConnection;
        }

        public SqlConnection initDBBR()
        {
            //Server = INI.INIDecryptRead("DB", "Server");
            //Port = INI.INIDecryptRead("DB", "Port");
            //User = INI.INIDecryptRead("DB", "User");
            //Password = INI.INIDecryptRead("DB", "Password");
            //DataBase = INI.INIRead("PATH", "RestoreDB");
            //TimeOut = INI.INIDecryptRead("DB", "TimeOut");

            Server = Server.Replace("\0", "");
            Port = Port.Replace("\0", "");
            User = User.Replace("\0", "");
            Password = Password.Replace("\0", "");
            DataBase = DataBase.Replace("\0", "");
            TimeOut = TimeOut.Replace("\0", "");


            //SqlConnection sqlConnection = new SqlConnection("Server=" + Server + ";uid=" + User + ";pwd=" + Password 
            //    + ";database=" + DataBase + ";Timeout=" + TimeOut);

            SqlConnection sqlConnection = new SqlConnection("Server=" + Server + "," + Port + ";uid=" + User + ";pwd=" + Password
                + ";database=" + DataBase);

            return sqlConnection;
        }

        #region 파라미터 사용 쿼리

        /// <summary>
        /// 저장 삭제 업데이트 쿼리 실행
        /// </summary>
        /// <param name="query"></param>
        /// <param name="sParams"></param>
        /// <returns></returns>
        public int NonQueryParams(String query, SqlParameter[] sParams)
        {
            int resultCode;

            SqlConnection sqlConnection = initDB();
            sqlConnection.Open();

            // SqlTransaction tran = sqlConnection.BeginTransaction();
            try
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                // sqlCommand.Transaction = tran;
                //파라 미터 배열을 받아서 파라 미터 처리 하는 로직 
                if (sParams != null)
                {
                    foreach (SqlParameter sParam in sParams)
                    {
                        sqlCommand.Parameters.Add(sParam);
                    }
                }

                resultCode = sqlCommand.ExecuteNonQuery();

                // tran.Commit();

                sqlConnection.Close();
                resultCode = 0;
                return resultCode;
            }
            catch (Exception ex)
            {
                // Log.ErrorLogFile("에러  : " + ex.ToString());
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message == "네트워크 경로를 찾지 못했습니다")
                    {
                        ErMsg = "데이터베이스 연결을 할수 없습니다.";
                        //MessageBox.Show("데이터베이스 연결을 할수 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ErMsg = "에러 : " + ex.Message;
                    }

                }
                else
                {
                    ErMsg = "에러 : " + ex.Message;
                }
                //  tran.Rollback();

                resultCode = -1;
                return resultCode;
            }

        }
        /// <summary>
        /// 데이터 셋 반환
        /// </summary>
        /// <param name="sQuery"></param>
        /// <param name="sParams"></param>
        /// <returns></returns>
        public DataSet SelectQueryDataset(string sQuery, SqlParameter[] sParams)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection sqlConnection = initDB();

                sqlConnection.Open();

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = new SqlCommand(sQuery, sqlConnection);

                if (sParams != null)
                {
                    foreach (SqlParameter sParam in sParams)
                    {
                        sda.SelectCommand.Parameters.Add(sParam);
                    }
                }

                sda.Fill(ds, "DATA");
                sqlConnection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                //Log.ErrorLogFile("에러  : " + ex.ToString());
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message == "네트워크 경로를 찾지 못했습니다")
                    {
                        ErMsg = "데이터베이스 연결을 할수 없습니다.";
                    }
                    else
                    {
                        ErMsg = "에러 : " + ex.Message;
                    }

                }
                else
                {
                    ErMsg = "에러 : " + ex.Message;
                }

                ds.Tables.Add("");
                return ds;
            }
        }
        /// <summary>
        /// 단입 값을 String 로 반환
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public string selectParmQuery(string sQuery, SqlParameter[] sParams)
        {
            object rStr = string.Empty;

            try
            {
                SqlConnection sqlConnection = initDB();

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(sQuery, sqlConnection);

                //파라 미터 배열을 받아서 파라 미터 처리 하는 로직 
                if (sParams != null)
                {
                    foreach (SqlParameter sParam in sParams)
                    {
                        sqlCommand.Parameters.Add(sParam);
                    }
                }

                rStr = sqlCommand.ExecuteScalar();

                sqlConnection.Close();
                return rStr.ToString();
            }
            catch (Exception ex)
            {
                //Log.ErrorLogFile("에러  : " + ex.ToString());
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message == "네트워크 경로를 찾지 못했습니다")
                    {
                        ErMsg = "데이터베이스 연결을 할수 없습니다.";
                    }
                    else
                    {
                        ErMsg = "에러 : " + ex.Message;
                    }
                }
                else
                {
                    ErMsg = "에러 : " + ex.Message;
                }

                return ErMsg;
            }
        }
        #endregion

        #region 파라미터 없는 쿼리
        /// <summary>
        /// 단입 값을 String 로 반환
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public string selectQuery(string sQuery)
        {
            object rStr = string.Empty;

            try
            {
                SqlConnection sqlConnection = initDB();

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(sQuery, sqlConnection);

                rStr = sqlCommand.ExecuteScalar();

                sqlConnection.Close();
                return rStr.ToString();
            }
            catch (Exception ex)
            {
                //Log.ErrorLogFile("에러  : " + ex.ToString());
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message == "네트워크 경로를 찾지 못했습니다")
                    {
                        ErMsg = "데이터베이스 연결을 할수 없습니다.";
                    }
                    else
                    {
                        ErMsg = "에러 : " + ex.Message;
                    }

                }
                else
                {
                    ErMsg = "에러 : " + ex.Message;
                }

                return ErMsg;
            }
        }

        public int NonQuery(String query)
        {
            int resultCode;

            SqlConnection sqlConnection = initDB();
            sqlConnection.Open();
            SqlTransaction tran = sqlConnection.BeginTransaction();

            try
            {

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Transaction = tran;

                resultCode = sqlCommand.ExecuteNonQuery();

                tran.Commit();
                sqlConnection.Close();

                return resultCode;
            }
            catch (Exception ex)
            {
                //Log.ErrorLogFile("에러  : " + ex.ToString());
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message == "네트워크 경로를 찾지 못했습니다")
                    {
                        ErMsg = "데이터베이스 연결을 할수 없습니다.";
                    }
                    else
                    {
                        ErMsg = "에러 : " + ex.Message;
                    }

                }
                else
                {
                    ErMsg = "에러 : " + ex.Message;
                }
                tran.Rollback();

                resultCode = -1;
                return resultCode;
            }
        }

        public DataSet SelectQueryDataset(string sQuery)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection sqlConnection = initDB();

                sqlConnection.Open();

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = new SqlCommand(sQuery, sqlConnection);

                sda.Fill(ds, "DATA");
                sqlConnection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                //Log.ErrorLogFile("에러  : " + ex.ToString());
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message == "네트워크 경로를 찾지 못했습니다")
                    {
                        ErMsg = "데이터베이스 연결을 할수 없습니다.";
                    }
                    else
                    {
                        ErMsg = "에러 : " + ex.Message;
                    }

                }
                else
                {
                    ErMsg = "에러 : " + ex.Message;
                }

                ds.Tables.Add("");
                return ds;
            }
        }

        #endregion

        #region 백업 복원 
        public int backupNonQuery(String query)
        {
            int resultCode;

            SqlConnection sqlConnection = initDB();
            sqlConnection.Open();
            try
            {

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                resultCode = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
                resultCode = 0;

                return resultCode;
            }
            catch (Exception ex)
            {
                //Log.ErrorLogFile("에러  : " + ex.ToString());
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message == "네트워크 경로를 찾지 못했습니다")
                    {
                        ErMsg = "데이터베이스 연결을 할수 없습니다.";
                    }
                    else
                    {
                        ErMsg = "에러 : " + ex.Message;
                    }

                }
                else
                {
                    ErMsg = "에러 : " + ex.Message;
                }

                resultCode = -1;
                return resultCode;
            }
        }

        public int RestoreNonQuery(String query)
        {
            int resultCode;

            SqlConnection sqlConnection = initDBBR();
            sqlConnection.Open();
            try
            {

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                resultCode = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
                resultCode = 0;

                return resultCode;
            }
            catch (Exception ex)
            {
                //Log.ErrorLogFile("에러  : " + ex.ToString());
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message == "네트워크 경로를 찾지 못했습니다")
                    {
                        ErMsg = "데이터베이스 연결을 할수 없습니다.";
                    }
                    else
                    {
                        ErMsg = "에러 : " + ex.Message;
                    }

                }
                else
                {
                    ErMsg = "에러 : " + ex.Message;
                }

                resultCode = -1;
                return resultCode;
            }
        }
        #endregion
    }
}
