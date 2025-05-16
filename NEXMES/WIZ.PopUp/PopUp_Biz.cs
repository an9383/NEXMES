using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public class PopUp_Biz
    {
        DataSet rtnDsTemp = new DataSet();   // return DataSet 공통
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable DtTemp = new DataTable();

        public bool bFindOK = false;

        public static Dictionary<string, DicItem> dic = new Dictionary<string, DicItem>();
        public class DicItem
        {
            public string Code;
            public string Name;

            public DicItem(string sCode, string sName)
            {
                Code = sCode;
                Name = sName;
            }
        }
        private void AddItem(string sPopType, DicItem item)
        {
            if (!dic.ContainsKey(sPopType))
            {
                dic.Add(sPopType, item);
            }
        }

        public PopUp_Biz()
        {
            AddItem("BM0000", new DicItem("MAJORCODE", "CODENAME"));
            AddItem("MD0001", new DicItem("CORE", "CORENAME"));
            AddItem("BM0010", new DicItem("ITEMCODE", "ITEMNAME"));
            AddItem("BM0011", new DicItem("CURNM", "CURNAME"));
            AddItem("BM0020", new DicItem("WORKERID", "WORKERNAME"));
            AddItem("BM0030", new DicItem("CUSTCODE", "CUSTNAME"));
            AddItem("BM0040", new DicItem("OPCODE", "OPNAME"));
            AddItem("BM0050", new DicItem("LINECODE", "LINENAME"));
            AddItem("BM0060", new DicItem("WORKCENTERCODE", "WORKCENTERNAME"));
            AddItem("BM0070", new DicItem("MACHCODE", "MACHNAME"));
            AddItem("BM0080", new DicItem("WHCODE", "WHNAME"));
            AddItem("BM0090", new DicItem("STORAGELOCCODE", "STORAGELOCNAME"));
            AddItem("BM0100", new DicItem("ERRORCODE", "ERRORDESC"));
            AddItem("BM8000", new DicItem("ULLAGECODE", "ULLAGENAME"));
            AddItem("BM0110", new DicItem("STOPCODE", "STOPDESC"));
            AddItem("BM0130", new DicItem("UNITCODE", "UNITNAME"));
            AddItem("BM0150", new DicItem("INSPCODE", "INSPNAME"));
            AddItem("BM0160", new DicItem("INSPCODE", "INSPNAME"));
            AddItem("BM0170", new DicItem("INSPCODE", "INSPNAME"));
            AddItem("BM0180", new DicItem("INSPCODE", "INSPNAME"));
            AddItem("BM0190", new DicItem("INSPCODE", "INSPNAME"));
            AddItem("BM0370", new DicItem("FAILURECODE", "FAILURENAME"));
            AddItem("BM0500", new DicItem("CARNO", "CARDESC"));
            AddItem("BM0530", new DicItem("RESCODE", "RESNAME"));
            AddItem("BM0680", new DicItem("MOLDCODE", "MOLDNAME"));
            AddItem("BM5100", new DicItem("AlarmCode", "AlarmText"));
            AddItem("TSY0030", new DicItem("WORKERID", "WORKERNAME"));
            AddItem("BM0710", new DicItem("MACODE", "MANAME"));
            AddItem("BM0460", new DicItem("MACHKCODE", "MACHKNAME"));
            AddItem("TBM0000", new DicItem("CODE_ID", "CODE_NAME"));
            AddItem("PP3510", new DicItem("ITEMCODE", "ITEMNAME"));
            AddItem("TSY0030", new DicItem("WorkerID", "WorkerName"));
            AddItem("TSY1500", new DicItem("ProgramID", "UidName"));
            AddItem("AP0110", new DicItem("CONTRACTNO", "CONTRACTNO"));
            AddItem("MM0020", new DicItem("PONO", "PONO"));
        }


        public void BIZ_POP(string sPopType, string sSrcCode, string sSrcName, string[] aParam1, string[] aParam2, object CODE_ID, object CODE_NAME, UltraGrid grid = null)
        {
            try
            {
                switch (sPopType)
                {
                    #region 코드2+매개변수0
                    case "BM0000": //단위코드 POP-UP ( USEFLAG )
                        DtTemp = SEL_BM0000(sSrcCode, sSrcName);
                        break;
                    #endregion
                    #region 코드2+매개변수1
                    case "BM0130": //단위코드 POP-UP ( USEFLAG )
                        DtTemp = SEL_BM0130(sSrcCode, sSrcName, aParam1[0]);
                        break;
                    #endregion
                    #region 코드2+매개변수2
                    //case "BM0011": //환율 POP-UP ( PLANTCODE, ITEMTYPE, USEFLAG , ITEMCD)
                    //    DtTemp = SEL_BM0011(aParam1[0], sSrcCode, sSrcName, aParam1[1]);
                    //    break;
                    case "BM0150": //검사항목 POP-UP ( PLANTCODE, USEFLAG )
                        DtTemp = SEL_BM0150(aParam1[0], sSrcCode, sSrcName, aParam1[1]);
                        break;
                    case "BM0160": //수입검사항목 POP-UP ( PLANTCODE, USEFLAG )
                        DtTemp = SEL_BM0160(aParam1[0], sSrcCode, sSrcName, aParam1[1]);
                        break;
                    case "BM0170": //공정검사항목 POP-UP ( PLANTCODE, USEFLAG )
                        DtTemp = SEL_BM0170(aParam1[0], sSrcCode, sSrcName, aParam1[1]);
                        break;
                    case "BM0180": //자주검사항목 POP-UP ( PLANTCODE, USEFLAG )
                        DtTemp = SEL_BM0180(aParam1[0], sSrcCode, sSrcName, aParam1[1]);
                        break;
                    case "BM0190": //제품검사항목 POP-UP ( PLANTCODE, USEFLAG )
                        DtTemp = SEL_BM0190(aParam1[0], sSrcCode, sSrcName, aParam1[1]);
                        break;
                    case "BM0530": //각종사유 POP-UP ( RESTYPE, USEFLAG )
                        DtTemp = SEL_BM0530(aParam1[0], sSrcCode, sSrcName, aParam1[1]);
                        break;
                    case "BM0680": //금형마스터 POP-UP ( PLANTCODE, USEFLAG )
                        DtTemp = SEL_BM0680(aParam1[0], sSrcCode, sSrcName, aParam1[1]);
                        break;
                    case "BM5100": //알람마스터 POP-UP ( PLANTCODE, USEFLAG )
                        DtTemp = SEL_BM5100(aParam1[0], sSrcCode, sSrcName, aParam1[1]);
                        break;
                    case "TSY0030": //시스템사용자 POP-UP ( PLANTCODE, USEFLAG )
                        DtTemp = SEL_TSY0030_N(aParam1[0], sSrcCode, sSrcName, aParam1[1]);
                        break;
                    #endregion
                    #region 코드2+매개변수3
                    case "MD0001": //품목 POP-UP ( PLANTCODE, ITEMTYPE, USEFLAG )
                        DtTemp = SEL_MD0001(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2]);
                        break;
                    case "BM0010": //품목 POP-UP ( PLANTCODE, ITEMTYPE, USEFLAG , ITEMSPEC)
                        DtTemp = SEL_BM0010(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2]);
                        break;

                    case "BM0020": //작업자 POP-UP ( PLANTCODE, DEPTCODE, USEFLAG )
                        DtTemp = SEL_BM0020(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2]);
                        break;
                    case "BM0030": //거래처 POP-UP ( PLANTCODE, CUSTTYPE, USEFLAG )
                        DtTemp = SEL_BM0030(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2]);
                        break;
                    case "BM0040": //공정 POP-UP ( PLANTCODE, OPTYPE, USEFLAG )
                        DtTemp = SEL_BM0040(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2]);
                        break;
                    case "BM0050": //라인 POP-UP ( PLANTCODE, OPCODE, USEFLAG )
                        DtTemp = SEL_BM0050(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2]);
                        break;
                    case "BM0070": //설비 POP-UP ( PLANTCODE, MACHTYPE, USEFLAG )
                        DtTemp = SEL_BM0070(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2]);
                        break;
                    case "BM0080": //창고 POP-UP ( PLANTCODE, WHTYPE, USEFLAG )
                        DtTemp = SEL_BM0080(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2]);
                        break;
                    case "BM0100": //불량항목 POP-UP ( PLANTCODE, ERRORTYPE, USEFLAG )
                        DtTemp = SEL_BM0100(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2]);
                        break;
                    case "BM8000": //결감항목 POP-UP ( PLANTCODE, ULLAGETYPE, USEFLAG )
                        DtTemp = SEL_BM8000(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2]);
                        break;
                    case "BM0110": //비가동항목 POP-UP ( PLANTCODE, ERRORTYPE, USEFLAG )
                        DtTemp = SEL_BM0110(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2]);
                        break;
                    case "BM0370": //설비고장항목 POP-UP ( PLANTCODE, FAILURETYPE, USEFLAG )
                        DtTemp = SEL_BM0370(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2]);
                        break;
                    case "BM0500": //운행차량 POP-UP ( PLANTCODE, CARGUBUN, USEFLAG )
                        DtTemp = SEL_BM0500(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2]);
                        break;
                    case "AP0110": //수주현황 POP-UP ( PLANTCODE, SDATE, EDATE )
                        //DtTemp = SEL_AP0110(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2], aParam1[3]);
                        DtTemp = SEL_AP0110(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2]);
                        break;
                    case "MM0020": //발주현황 POP-UP ( PLANTCODE, SDATE, EDATE )
                        //DtTemp = SEL_AP0110(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2], aParam1[3]);
                        DtTemp = SEL_MM0020(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2]);
                        break;
                    #endregion
                    #region 코드2+매개변수4
                    case "BM0060":
                        DtTemp = SEL_BM0060(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2], aParam1[3]);
                        break;
                    case "BM0090":
                        DtTemp = SEL_BM0090(aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2], aParam1[3]);
                        break;

                    #endregion
                    default:
                        WIZ.Forms.DialogForm dialogform = new WIZ.Forms.DialogForm("C:S00014");

                        dialogform.ShowDialog();

                        break;
                }

                //2020-08-04 YSH
                //검색 키워드 있어도 팝업창 활성화로 수정

                //if (DtTemp.Rows.Count == 1)
                //{
                //    if (grid == null)
                //    {
                //        SetText(CODE_ID, Convert.ToString(DtTemp.Rows[0][dic[sPopType].Code]));
                //        SetText(CODE_NAME, Convert.ToString(DtTemp.Rows[0][dic[sPopType].Name]));
                //    }
                //    else
                //    {
                //        grid.ActiveRow.Cells[DBHelper.nvlString(CODE_ID)].Value = Convert.ToString(DtTemp.Rows[0][dic[sPopType].Code]);

                //        if (grid.DisplayLayout.Bands[0].Columns.Exists(DBHelper.nvlString(CODE_NAME)))
                //        {
                //            grid.ActiveRow.Cells[DBHelper.nvlString(CODE_NAME)].Value = Convert.ToString(DtTemp.Rows[0][dic[sPopType].Name]);
                //        }
                //    }

                //    this.bFindOK = true;
                //}
                //else
                //{
                if (DtTemp.Rows.Count == 0)
                {
                    if (sSrcCode.Trim() != "" || sSrcName != "")
                    {
                        if (grid == null)
                        {
                            SetText(CODE_ID, string.Empty);
                            SetText(CODE_NAME, string.Empty);
                        }
                    }
                }

                // 품목 POP-UP 창 처리
                PopUpManager pu = new PopUpManager();

                switch (sPopType)
                {
                    case "BM0000": //코드마스터 
                        DtTemp = pu.OpenPopUp(sPopType, new string[] { sSrcCode, sSrcName });
                        break;
                    case "BM0130": //단위코드 POP-UP ( USEFLAG )
                        DtTemp = pu.OpenPopUp(sPopType, new string[] { sSrcCode, sSrcName, aParam1[0] });
                        break;
                    case "BM0150": //검사항목 POP-UP ( PLANTCODE, USEFLAG )
                    case "BM0160": //수입검사항목 POP-UP ( PLANTCODE, USEFLAG )
                    case "BM0170": //공정검사항목 POP-UP ( PLANTCODE, USEFLAG )
                    case "BM0180": //자주검사항목 POP-UP ( PLANTCODE, USEFLAG )
                    case "BM0190": //제품검사항목 POP-UP ( PLANTCODE, USEFLAG )
                    case "BM0530": //각종사유 POP-UP ( RESTYPE, USEFLAG )
                    case "BM0680": //금형마스터 POP-UP ( PLANTCODE, USEFLAG )
                    case "BM5100": //알람마스터 POP-UP ( PLANTCODE, USEFLAG )
                    case "TSY0030": //시스템사용자 POP-UP ( PLANTCODE, USEFLAG )                  
                        DtTemp = pu.OpenPopUp(sPopType, new string[] { aParam1[0], sSrcCode, sSrcName, aParam1[1] });
                        break;
                    case "MD0001": //코어 POP-UP
                    case "BM0010": //품목 POP-UP ( PLANTCODE, ITEMTYPE, USEFLAG )
                    case "BM0011": //품목 POP-UP ( PLANTCODE, ITEMTYPE, USEFLAG )
                    case "BM0020": //작업자 POP-UP ( PLANTCODE, DEPTCODE, USEFLAG )
                    case "BM0030": //거래처 POP-UP ( PLANTCODE, CUSTTYPE, USEFLAG )
                    case "BM0040": //공정 POP-UP ( PLANTCODE, OPTYPE, USEFLAG )

                    case "BM0070": //설비 POP-UP ( PLANTCODE, MACHTYPE, USEFLAG )
                    case "BM0080": //창고 POP-UP ( PLANTCODE, WHTYPE, USEFLAG )
                    case "BM0100": //불량항목 POP-UP ( PLANTCODE, ERRORTYPE, USEFLAG )
                    case "BM8000": //결감항목 POP-UP ( PLANTCODE, ULLAGETYPE, USEFLAG )
                    case "BM0110": //비가동항목 POP-UP ( PLANTCODE, ERRORTYPE, USEFLAG )
                    case "BM0370": //설비고장항목 POP-UP ( PLANTCODE, FAILURETYPE, USEFLAG )
                    case "BM0500": //운행차량 POP-UP ( PLANTCODE, CARGUBUN, USEFLAG )                   
                        DtTemp = pu.OpenPopUp(sPopType, new string[] { aParam1[0], aParam1[1], sSrcCode, sSrcName, aParam1[2] });
                        break;
                    case "BM0050": //라인 POP-UP ( PLANTCODE, OPCODE, USEFLAG )
                        DtTemp = pu.OpenPopUp(sPopType, new string[] { aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2] });
                        break;
                    case "BM0060": //작업장 POP-UP ( PLANTCODE, OPCODE, LINECODE, USEFLAG )
                    case "BM0090": //저장위치 POP-UP ( PLANTCODE, STORAGELOCTYPE, OPCODE, USEFLAG )
                    case "AP0110": //수주현황 POP-UP ( PLANTCODE, SDATE, EDATE )
                        DtTemp = pu.OpenPopUp(sPopType, new string[] { aParam1[0], aParam1[1], aParam1[2] }); // 품목 조회 POP-UP창 Parameter
                        break;
                    case "MM0020": //발주주현황 POP-UP ( PLANTCODE, SDATE, EDATE )
                        DtTemp = pu.OpenPopUp(sPopType, new string[] { aParam1[0], sSrcCode, sSrcName, aParam1[1], aParam1[2] }); // 품목 조회 POP-UP창 Parameter
                        break;
                }

                if (DtTemp != null && DtTemp.Rows.Count > 0)
                {
                    if (grid == null)
                    {
                        if (dic[sPopType].Code != "")
                        {
                            SetText(CODE_ID, Convert.ToString(DtTemp.Rows[0][dic[sPopType].Code]));
                        }

                        if (dic[sPopType].Name != "")
                        {
                            SetText(CODE_NAME, Convert.ToString(DtTemp.Rows[0][dic[sPopType].Name]));
                        }
                    }
                    else
                    {
                        grid.ActiveRow.Cells[DBHelper.nvlString(CODE_ID)].Value = Convert.ToString(DtTemp.Rows[0][dic[sPopType].Code]);

                        if (grid.DisplayLayout.Bands[0].Columns.Exists(DBHelper.nvlString(CODE_NAME)))
                        {
                            grid.ActiveRow.Cells[DBHelper.nvlString(CODE_NAME)].Value = Convert.ToString(DtTemp.Rows[0][dic[sPopType].Name]);
                        }
                    }

                    this.bFindOK = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        #region 구버전 
        #region [ NEW 코드마스터 POP-UP ]
        public DataTable SEL_BM0000(string sMajorCode, string sCodeName)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0000_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_MAJORCODE", sMajorCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_CODENAME", sCodeName, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region [ NEW 유진 코어 POP-UP ]
        public DataTable SEL_MD0001(string sPlantCode, string sItemCode, string sItemName, string sItemType, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_MD0001_POP_S1", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }


        #endregion

        #region [ NEW 품목 POP-UP ]
        public DataTable SEL_BM0010(string sPlantCode, string sItemCode, string sItemName, string sItemType, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0010_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMSPEC", "", DbType.String, ParameterDirection.Input));
                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        public DataTable SEL_BM0010(string sPlantCode, string sItemCode, string sItemName, string sItemType, string sUseFlag, string sItemSpec)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0010_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMSPEC", sItemSpec, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        public DataTable SEL_BM0011(string sPlantCode, string sCurCode, string sCurName, string sItemCd)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0011_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMCODE", sCurCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMNAME", sCurName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMCD", sItemCd, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        public DataTable SEL_BM0011(string sPlantCode, string sItemCode, string sItemName, string sItemCd, string sUseFlag, string sItemSpec)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0011_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMCD", sItemCd, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        public DataTable SEL_BM0013(string sPlantCode, string sItemCode, string sItemName, string sItemType, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0013_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMSPEC", "", DbType.String, ParameterDirection.Input));
                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        public DataTable SEL_BM0013(string sPlantCode, string sItemCode, string sItemName, string sItemType, string sUseFlag, string sItemSpec)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0013_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMSPEC", sItemSpec, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        public DataTable SEL_PP3510(string sPlantCode, string sItemCode, string sItemName, string sItemType, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PP3510_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMSPEC", "", DbType.String, ParameterDirection.Input));
                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        public DataTable SEL_PP3510(string sPlantCode, string sItemCode, string sItemName, string sItemType, string sUseFlag, string sItemSpec)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PP3510_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMSPEC", sItemSpec, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }


        #endregion

        #region [ NEW 작업자 POP-UP ]
        public DataTable SEL_BM0020(string sPlantCode, string sWorkerID, string sWorkerName, string sDeptCode, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0020_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_WORKERID", sWorkerID, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_WORKERNAME", sWorkerName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_DEPTCODE", sDeptCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 거래처 POP-UP ]
        public DataTable SEL_BM0030(string sPlantCode, string sCustType, string sCustCode, string sCustName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0030_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_CUSTTYPE", sCustType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_CUSTNAME", sCustName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }


        #endregion

        #region [ NEW 공정 POP-UP ]
        public DataTable SEL_BM0040(string sPlantCode, string sOpType, string sOpCode, string sOpName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0040_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_OPTYPE", sOpType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_OPNAME", sOpName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }


        #endregion

        #region [ NEW 라인 POP-UP ]
        public DataTable SEL_BM0050(string sPlantCode, string sLineCode, string sLineName, string sOpCode, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0050_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_LINECODE", sLineCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_LINENAME", sLineName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                this.bFindOK = false;

                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region [ NEW 작업장 POP-UP ]
        public DataTable SEL_BM0060(string sPlantCode, string sWorkCenterCode, string sWorkCenterName, string sOpCode, string sLineCode, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0060_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_WORKCENTERNAME", sWorkCenterName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_LINECODE", sLineCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }


        #endregion

        #region [ NEW 설비 POP-UP ]
        public DataTable SEL_BM0070(string sPlantCode, string sMachType, string sMachCode, string sMachName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0070_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_MACHTYPE", sMachType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_MACHNAME", sMachName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;

                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 창고 POP-UP ]
        public DataTable SEL_BM0080(string sPlantCode, string sWhType, string sWhCode, string sWhName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0080_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_WHTYPE", sWhType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_WHNAME", sWhName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 저장위치 POP-UP ]
        public DataTable SEL_BM0090(string sPlantCode, string sLoc, string sLocName, string sPosition, string sWHName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0090_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_LOC", sLoc, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_LOCNAME", sLocName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_POSITION", sPosition, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_WHNAME", sWHName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 불량항목 POP-UP ]
        public DataTable SEL_BM0100(string sPlantCode, string sErrorType, string sErrorCode, string sErrorDesc, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0100_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ERRORTYPE", sErrorType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ERRORCODE", sErrorCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ERRORDESC", sErrorDesc, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ 결감항목 POP-UP ]
        public DataTable SEL_BM8000(string sPlantCode, string sUllageType, string sUllageCode, string sUllageName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM8000_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ULLAGETYPE", sUllageType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ULLAGECODE", sUllageCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ULLAGENAME", sUllageName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 비가동항목 POP-UP ]
        public DataTable SEL_BM0110(string sPlantCode, string sStopType, string sStopCode, string sStopDesc, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0110_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_STOPTYPE", sStopType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_STOPCODE", sStopCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_STOPDESC", sStopDesc, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;

                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 단위코드 POP-UP ]
        public DataTable SEL_BM0130(string sUnitCode, string sUnitName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0130_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_UNITCODE", sUnitCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_UNITNAME", sUnitName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;

                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 검사항목 POP-UP ]
        public DataTable SEL_BM0150(string sPlantCode, string sInspCode, string sInspName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0150_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_INSPNAME", sInspName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                this.bFindOK = false;

                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 수입검사항목 POP-UP ]
        public DataTable SEL_BM0160(string sPlantCode, string sInspCode, string sInspName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0160_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_INSPNAME", sInspName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }


        #endregion

        #region [ NEW 공정검사항목 POP-UP ]
        public DataTable SEL_BM0170(string sPlantCode, string sInspCode, string sInspName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0170_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_INSPNAME", sInspName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 자주검사항목 POP-UP ]
        public DataTable SEL_BM0180(string sPlantCode, string sInspCode, string sInspName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0180_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_INSPNAME", sInspName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;

                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 제품검사항목 POP-UP ]
        public DataTable SEL_BM0190(string sPlantCode, string sInspCode, string sInspName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0190_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_INSPNAME", sInspName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;

                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 설비고장항목 POP-UP ]
        public DataTable SEL_BM0370(string sPlantCode, string sFailureType, string sFailureCode, string sFailureName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0370_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_FAILURETYPE", sFailureType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_FAILURECODE", sFailureCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_FAILURENAME", sFailureName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 운행차량 POP-UP ]
        public DataTable SEL_BM0500(string sPlantCode, string sCarGubun, string sCarNo, string sCarDesc, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0500_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_CARGUBUN", sCarGubun, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_CARNO", sCarNo, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_CARDESC", sCarDesc, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;

                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 각종사유 POP-UP ]
        public DataTable SEL_BM0530(string sResType, string sResCode, string sResName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0530_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_RESTYPE", sResType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_RESCODE", sResCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_RESNAME", sResName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;

                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 금형마스터 POP-UP ]
        public DataTable SEL_BM0680(string sPlantCode, string sMoldCode, string sMoldName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0680_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_MOLDNAME", sMoldName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;

                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 설비보전마스터 POP-UP ]
        public DataTable SEL_BM0710(string sPlantCode, string sMaCode, string sMaName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0710_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_MACODE", sMaCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_MANAME", sMaName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;

                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 설비점검항목마스터 POP-UP ]
        public DataTable SEL_BM0460(string sPlantCode, string sMachkCode, string sMachkName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0460_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_MACHKCODE", sMachkCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_MACHKNAME", sMachkName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region 코드마스터
        public DataTable SEL_TBM0000(string sCode, string sName, string major)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                this.bFindOK = false;
                return helper.FillTable("USP_BM0000_POP", CommandType.StoredProcedure
                                                             , helper.CreateParameter("ITEMCODE", sCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("ITEMNAME", sName, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("MAJOR", major, DbType.String, ParameterDirection.Input));


            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region 사용자(TSY0200:WorkerID)
        /// <summary>
        /// 작업자 정보 팝업
        /// </summary>
        /// <param name="sPlantCode">공장(사업장)</param>
        /// <param name="sOPCode">공정코드</param>
        /// <param name="sLineCode">라인코드</param>
        /// <param name="sWorkCenterCode">작업장코드</param>
        /// <param name="sWorkerID">작업자 ID</param>
        /// <param name="sWorkerName">작업자명</param>
        /// <param name="sUseFlag">사용여부</param>
        /// <param name="RS_CODE">리턴 코드</param>
        /// <param name="RS_MSG">리턴 메시지</param>
        /// <returns></returns>
        /// 


        public DataTable SEL_TSY0030(string sPlantCode, string sOPCode, string sLineCode, string sWorkCenterCode, string sWorkerID, string sWorkerName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                this.bFindOK = false;
                return helper.FillTable("USP_SY0030_POP", CommandType.StoredProcedure
                                                             , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("LineCode", sLineCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("WorkerID", sWorkerID, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("WorkerName", sWorkerName, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));


            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region 사용자그룹(TSY0080:GRPID)
        /// <summary>
        /// 작업자 정보 팝업
        /// </summary>
        /// <param name="sPlantCode">공장(사업장)</param>
        /// <param name="sOPCode">공정코드</param>
        /// <param name="sLineCode">라인코드</param>
        /// <param name="sWorkCenterCode">작업장코드</param>
        /// <param name="sWorkerID">작업자 ID</param>
        /// <param name="sWorkerName">작업자명</param>
        /// <param name="sUseFlag">사용여부</param>
        /// <param name="RS_CODE">리턴 코드</param>
        /// <param name="RS_MSG">리턴 메시지</param>
        /// <returns></returns>
        public DataTable SEL_TSY0080(string sGRPID, string sGRPNAME)
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                this.bFindOK = false;
                return helper.FillTable("USP_SY0080_S1", CommandType.StoredProcedure
                                                       , helper.CreateParameter("GRPID", sGRPID, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("GRPName", sGRPNAME, DbType.String, ParameterDirection.Input));

            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region 프로그램(TSY1500:ProgramID)
        /// <summary>
        /// 프로그램 정보 팝업
        /// </summary>
        /// <param name="sProgramID">프로그램 ID</param>
        /// <param name="sLang">언어</param>
        /// <returns></returns>
        /// 


        public DataTable SEL_TSY1500(string sProgramID, string sLang)
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                rtnDtTemp = helper.FillTable("USP_SY1500_POP", CommandType.StoredProcedure
                                                             , helper.CreateParameter("ProgramID", sProgramID, DbType.String, ParameterDirection.Input));
                //, helper.CreateParameter("Lang", sLang, DbType.String, ParameterDirection.Input));


                this.bFindOK = false;

                return rtnDtTemp;
            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region [NEW 알람마스터 POP-UP]
        public DataTable SEL_BM5100(string sPlantCode, string sItemCode, string sItemName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM5100_POP_N", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ALARMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ALARMTEXT", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region [NEW 시스템마스터 POP-UP]
        public DataTable SEL_TSY0030_N(string sPlantCode, string sItemCode, string sItemName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_SY0030_POP_N", CommandType.StoredProcedure
                                             , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("WORKERID", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("WORKERNAME", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));
                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region [ NEW 수주정보 POP-UP ]
        public DataTable SEL_AP0110(string sPlantCode, string sContractno, string sContractName, string sItemCode, string sCustCode)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_AP0110_POP2", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_CONTRACTNO", sContractno, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_CONTRACTNAME", sContractName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input));
                //, helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ NEW 발주정보 POP-UP ]
        public DataTable SEL_MM0020(string sPlantCode, string sPono, string sPoName, string sItemCode, string sCustCode)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_MM0020_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_PONO", sPono, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_PONAME", sPoName, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input));
                //, helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                this.bFindOK = false;
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #endregion

        #region 개별 호출 - 원래 사용화면을 위해서 남겨둠

        public void BM0030_POP(string sCustCode, string sCustName, string sPlantCode, string sCustType, string sUseFlag, string sEnabled, object CODE_ID, object CODE_NAME)
        {
            try
            {
                DtTemp = SEL_BM0030(sPlantCode, sCustType, sCustCode, sCustName, sUseFlag);

                if (DtTemp.Rows.Count == 1)
                {
                    SetText(CODE_ID, Convert.ToString(DtTemp.Rows[0]["CUSTCODE"]));
                    SetText(CODE_NAME, Convert.ToString(DtTemp.Rows[0]["CUSTNAME"]));

                    this.bFindOK = true;
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        if (sCustCode.Trim() != "" || sCustName != "")
                        {
                            SetText(CODE_ID, string.Empty);
                            SetText(CODE_NAME, string.Empty);
                        }
                    }

                    // 거래처 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("BM0030", new string[] { sPlantCode, sCustType, sCustCode, sCustName, sUseFlag, sEnabled }); // 거래처 조회 POP-UP창 Parameter

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        SetText(CODE_ID, Convert.ToString(DtTemp.Rows[0]["CUSTCODE"]));
                        SetText(CODE_NAME, Convert.ToString(DtTemp.Rows[0]["CUSTNAME"]));

                        this.bFindOK = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BM0040_POP(string sOpCode, string sOpName, string sPlantCode, string sOpType, string sUseFlag, object CODE_ID, object CODE_NAME)
        {
            try
            {
                DtTemp = SEL_BM0040(sPlantCode, sOpType, sOpCode, sOpName, sUseFlag);

                if (DtTemp.Rows.Count == 1)
                {
                    SetText(CODE_ID, Convert.ToString(DtTemp.Rows[0]["OPCODE"]));
                    SetText(CODE_NAME, Convert.ToString(DtTemp.Rows[0]["OPNAME"]));

                    this.bFindOK = true;
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        if (sOpCode.Trim() != "" || sOpName != "")
                        {
                            SetText(CODE_ID, string.Empty);
                            SetText(CODE_NAME, string.Empty);
                        }
                    }

                    // 공정 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("BM0040", new string[] { sPlantCode, sOpType, sOpCode, sOpName, sUseFlag }); // 공정 조회 POP-UP창 Parameter

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        SetText(CODE_ID, Convert.ToString(DtTemp.Rows[0]["OPCODE"]));
                        SetText(CODE_NAME, Convert.ToString(DtTemp.Rows[0]["OPNAME"]));

                        this.bFindOK = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BM0050_POP(string sLineCode, string sLineName, string sPlantCode, string sOpCode, string sUseFlag, object CODE_ID, object CODE_NAME)
        {
            try
            {
                DtTemp = SEL_BM0050(sPlantCode, sLineCode, sLineName, sOpCode, sUseFlag);

                if (DtTemp.Rows.Count == 1)
                {
                    SetText(CODE_ID, Convert.ToString(DtTemp.Rows[0]["LINECODE"]));
                    SetText(CODE_NAME, Convert.ToString(DtTemp.Rows[0]["LINENAME"]));

                    this.bFindOK = true;
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        if (sLineCode.Trim() != "" || sLineName != "")
                        {
                            SetText(CODE_ID, string.Empty);
                            SetText(CODE_NAME, string.Empty);
                        }
                    }

                    // 라인 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("BM0050", new string[] { sPlantCode, sLineCode, sLineName, sOpCode, sUseFlag }); // 라인 조회 POP-UP창 Parameter

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        SetText(CODE_ID, Convert.ToString(DtTemp.Rows[0]["LINECODE"]));
                        SetText(CODE_NAME, Convert.ToString(DtTemp.Rows[0]["LINENAME"]));

                        this.bFindOK = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BM0060_POP(string sWorkCenterCode, string sWorkCenterName, string sPlantCode, string sOpCode, string sLineCode, string sUseFlag, object CODE_ID, object CODE_NAME)
        {
            try
            {
                DtTemp = SEL_BM0060(sPlantCode, sWorkCenterCode, sWorkCenterName, sLineCode, sOpCode, sUseFlag);

                if (DtTemp.Rows.Count == 1)
                {
                    SetText(CODE_ID, Convert.ToString(DtTemp.Rows[0]["WORKCENTERCODE"]));
                    SetText(CODE_NAME, Convert.ToString(DtTemp.Rows[0]["WORKCENTERNAME"]));

                    this.bFindOK = true;
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        if (sWorkCenterCode.Trim() != "" || sWorkCenterName != "")
                        {
                            SetText(CODE_ID, string.Empty);
                            SetText(CODE_NAME, string.Empty);
                        }
                    }

                    // 작업장 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("BM0060", new string[] { sPlantCode, sWorkCenterCode, sWorkCenterName, sUseFlag }); // 작업장 조회 POP-UP창 Parameter

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        SetText(CODE_ID, Convert.ToString(DtTemp.Rows[0]["WORKCENTERCODE"]));
                        SetText(CODE_NAME, Convert.ToString(DtTemp.Rows[0]["WORKCENTERNAME"]));

                        this.bFindOK = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BM0070_POP(string sMachCode, string sMachName, string sPlantCode, string sMachType, string sUseFlag, object CODE_ID, object CODE_NAME)
        {
            try
            {
                DtTemp = SEL_BM0070(sPlantCode, sMachType, sMachCode, sMachName, sUseFlag);

                if (DtTemp.Rows.Count == 1)
                {
                    SetText(CODE_ID, Convert.ToString(DtTemp.Rows[0]["MACHCODE"]));
                    SetText(CODE_NAME, Convert.ToString(DtTemp.Rows[0]["MACHNAME"]));

                    this.bFindOK = true;
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        if (sMachCode.Trim() != "" || sMachName != "")
                        {
                            SetText(CODE_ID, string.Empty);
                            SetText(CODE_NAME, string.Empty);
                        }
                    }

                    // 설비 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("BM0070", new string[] { sPlantCode, sMachType, sMachCode, sMachName, sUseFlag }); // 설비 조회 POP-UP창 Parameter

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        SetText(CODE_ID, Convert.ToString(DtTemp.Rows[0]["MACHCODE"]));
                        SetText(CODE_NAME, Convert.ToString(DtTemp.Rows[0]["MACHNAME"]));

                        this.bFindOK = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void SetText(object objControl, string sValue)
        {
            if (objControl != null)
            {
                if (objControl.GetType().Name.Equals("TextBox"))
                    ((TextBox)objControl).Text = sValue;
                else
                    ((UltraTextEditor)objControl).Text = sValue;
            }
        }
    }
}
