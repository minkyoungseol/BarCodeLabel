// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;

// End of VB project level imports


namespace Module
{
    public class CM_ADO
    {
        //------------------------------------------------------------------------------------------------------------------------
        //ADO 관련 함수  (2006. 2. 15 by JM)
        //------------------------------------------------------------------------------------------------------------------------
        //Public Sub SetRS(rs, sql, RSType, adoArguementString)              '쿼리 실행후 결과값을 가져오는 함수
        //Public Sub ExecCN(sql As String, adoArguementString)               '쿼리만 실행하는 함수
        //Public Sub CloseAll(optional rs As ADODB.Recordset = nothing)      'ADO 연결과 레코드셋을 해제하는 함수
        //------------------------------------------------------------------------------------------------------------------------
        //Public Sub OpenCN(TransAction As Boolean) As Boolean               'ADO 연결을 설정하는 함수
        //Public Sub CloseCN(TransAction As Integer) As Boolean              'ADO 연결을 해제하는 함수
        //Public Sub CloseRS(RS As ADODB.Recordset) As Boolean               '레코드셋을 해제하는 함수
        //------------------------------------------------------------------------------------------------------------------------

        public static string CNString;

        public static string CNStringSP;

        public static ADODB.Connection CN;


        //-----------------------------------------------------------------------------------------------------------------------
        // 제목 : ADO 연결을 하는 함수
        //
        // 인자 : Transaction = False
        //
        // 설명 : Transation 이 True 인 경우 트랙잭션을 시작한다
        //-----------------------------------------------------------------------------------------------------------------------
        public static void OpenCN(bool rTransAction)
        {
            try
            {
                if (CN != null)
                {
                    if (CN.State == Convert.ToInt32(ADODB.ObjectStateEnum.adStateOpen))
                    {
                        return;
                    }
                    else
                    {
                        CN.Close();
                    }
                }

                CloseAll();

                //Connection 오브젝트의 생성
                CN = new ADODB.Connection();

                //Connect By Using Active Data Object
                CN.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
                //CN.CommandTimeout = Convert.ToInt32(CM_Main.QUERYTIME);
                CN.Open(CNString);

                if (rTransAction == true)
                {
                    CN.BeginTrans(); //트랜잭션
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(e.Message + "\n Data Base Error!", "확인");
                CN.Close();
            }
            finally
            {

            }
        }


        //-----------------------------------------------------------------------------------------------------------------------
        // 제목 : ADO_Connection
        //
        // 설명 : 쿼리 실행한 결과를 RS(ADODB.Recordset)에 세팅한다
        //
        // 인자 : RS - ADODB.Recordset, SQL - 쿼리, optioan Ctype, option Ltype
        //
        // 결과 : 쿼리 실행결과를 RS에 셋함
        //
        //
        //Cursor Type--------------------
        //    adOpenForwardOnly      0   앞으로 전용 커서, 단순하게 데이타를 찾을때 유용, Movefirst, MovePrevious 불가능
        //    adOpenKeyset           1   Static과 Dynamic의 중간
        //    adOpenDynamic          2   자신 혹은 다른 사용자(if committed)의 모든 작업을 볼 수 있음
        //    adOpenStatic           3   레코드 집합의 정적 사본: 앞뒤로 scrolling 가능하다 점 제외하면 ForwardOnly와 동일

        //Lock Type----------------------
        //    adLockReadOnly         1   (기본값) 읽기 전용
        //    adLockPessimistic      2   독점 잠금, 레코드별?모든 편집상황
        //    adLockOptimistic       3   공유 잠금, 레코드별?update
        //    adLockBatchOptimistic  4   공유 일괄 업데이트
        //-------------------------------
        //
        //-----------------------------------------------------------------------------------------------------------------------
        //public static void SetRS(ADODB.Recordset Rs, string sql, int RSType, ref bool TransAction , bool doOpenCN)
        public static void SetRS(ref ADODB.Recordset Rs, string sql, int RSType, bool TransAction, bool doOpenCN)

        {
            try
            {
                //ADO 연결
                if (doOpenCN)
                {
                    OpenCN(TransAction);
                }

                int Ctype_Renamed = default(int);
                int lType = default(int);

                switch (RSType)
                {
                    case 0: //READ
                        Ctype_Renamed = (int)ADODB.CursorTypeEnum.adOpenStatic;
                        lType = (int)ADODB.LockTypeEnum.adLockReadOnly;
                        break;

                    case 1: //SAVE/EDIT
                        Ctype_Renamed = (int)ADODB.CursorTypeEnum.adOpenKeyset;
                        lType = (int)ADODB.LockTypeEnum.adLockOptimistic;
                        break;
                }

                Rs.Open(sql, CN, (ADODB.CursorTypeEnum)Ctype_Renamed, (ADODB.LockTypeEnum)lType, -1);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(e.Message + "\n Data Base Error!", "확인");
                CloseAll(ref Rs, 0);

            }
            finally
            {

            }
        }

        public static void SetRS(ref ADODB.Recordset Rs, string sql, int RSType)
        {
            try
            {
                OpenCN(false);
                if (RSType == 0)
                {
                    Rs.Open(sql, CN, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly, 0);

                }
                else
                {
                    Rs.Open(sql, CN, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, 0);
                }

            }
            catch (Exception)
            {
                //MessageBox.Show(e.Message + "\n Data Base Error!", "확인");
                CloseAll(ref Rs, 0);

            }
            finally
            {

            }
        }
        //-----------------------------------------------------------------------------------------------------------------------
        // 설명 : 쿼리 실행 함수
        //
        // 결과 : 쿼리 실행
        //-----------------------------------------------------------------------------------------------------------------------
        public static void ExecCN(string sql, bool OpenCloseCN)
        {

            try
            {
                //ADO 연결
                if (OpenCloseCN)
                {
                    OpenCN(false);
                }

                ////쿼리 실행
                object null_object = null;

                //CN.Execute(sql, out null_object, -1);
                CN.Execute(sql, out null_object);

                //ADO 연결 해제
                if (OpenCloseCN)
                {
                    CloseAll();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.Message + "\n Data Base Error!", "확인");
                CloseCN(0);
            }
            finally
            {

            }
        }

        public static void CloseAll()
        {
            try
            {
                //ADO 연결 해제 (1= Commit, 2=Rollback)
                CloseCN(0);

            }
            catch (Exception)
            {
                // MessageBox.Show(e.Message + "\n Data Base Error!", "확인");
                CloseCN(0);
                //CN.Close();
            }
            finally
            { }
        }

        //-----------------------------------------------------------------------------------------------------------------------
        // 제목 : Connection 과 Recordset 을 닫는 함수
        //
        // 인자 : rs - Recordset
        //-----------------------------------------------------------------------------------------------------------------------
        public static void CloseAll(ref ADODB.Recordset Rs, short TransAction)
        {
            try
            {
                //RecordSet 해제
                if (CN.State != (int)ADODB.ObjectStateEnum.adStateClosed)
                {
                    switch (TransAction)
                    {
                        case 0:
                            CN.Close();
                            break;
                        case 1:
                            CN.CommitTrans(); //CommitTrans
                            break;
                        case 2:
                            CN.RollbackTrans(); //RollbackTrans
                            break;
                    }
                }

                CN = null;

                if (Rs != null)
                {
                    if (Rs.State != (int)ADODB.ObjectStateEnum.adStateClosed)
                    {
                        Rs.Close();
                    }
                }
                //ADO 연결 해제 (1= Commit, 2=Rollback)
                CloseCN(TransAction);
            }
            catch (Exception)
            {
                //MessageBox.Show(e.Message + "\n Data Base Error!", "확인");
                //CloseAll(ref Rs, 0);
                Rs.Close();
                CN.Close();
            }
            finally
            {

            }

        }

        //-----------------------------------------------------------------------------------------------------------------------
        // 설명 : ADO 연결을 해제하는 함수
        //
        // 인자 : Transaction = 0
        //
        // 결과 : 데이터베이스에 연결을 끊음 (1= Commit, 2=Rollback)
        //-----------------------------------------------------------------------------------------------------------------------
        public static void CloseCN(short TransAction)
        {

            try
            {
                if (CN != null)
                {

                    if (CN.State != (int)ADODB.ObjectStateEnum.adStateClosed)
                    {
                        switch (TransAction)
                        {
                            case 0:
                                CN.Close();
                                break;
                            case 1:
                                CN.CommitTrans(); //CommitTrans
                                break;
                            case 2:
                                CN.RollbackTrans(); //RollbackTrans
                                break;
                        }
                    }

                    CN = null;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.Message + "\n Data Base Error!", "확인");
                CN.Close();
            }
            finally
            {

            }
        }


        //-----------------------------------------------------------------------------------------------------------------------
        // 설명 : 레코드셋을 닫는 함수
        //
        // 인자 : rs - 레코드셋
        //
        // 결과 : 레코드셋을 닫음
        //-----------------------------------------------------------------------------------------------------------------------
        public static void CloseRS(ref ADODB.Recordset Rs)
        {
            try
            {
                if (Rs != null)
                {
                    if (Rs.State != (int)ADODB.ObjectStateEnum.adStateClosed)
                    {
                        Rs.Close();
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.Message + "\n Data Base Error!", "확인");
                CloseAll(ref Rs, 0);
            }
            finally
            {

            }

        }

        public static string GetSysDate(int Length)
        {
            try
            {
                string Sql = "";
                string strdate = "";
                ADODB.Recordset Rs_tmp = new ADODB.Recordset();
                Sql = Sql + " select substring(replace(replace(replace(convert(varchar(19),getdate(),20),'-',''),':',''),' ',''),1,14)  as sysdate1";
                SetRS(ref Rs_tmp, Sql, 0, false, true);
                if (Rs_tmp.EOF == false)
                {
                    strdate = Rs_tmp.Fields["sysdate1"].Value.ToString().Substring(0, Length);
                }
                return strdate;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return "";
            }
        }
    }
}
