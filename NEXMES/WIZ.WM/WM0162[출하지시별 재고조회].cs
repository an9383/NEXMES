#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0162
//   Form Name    : 출하지시별 재고조회
//   Name Space   : WIZ.WM
//   Created Date : 2020-08-14
//   Made By      : PJM
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM0162 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        DataTable rtnDtTemp = new DataTable(); //return DataTable 공통
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); // 콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;

        private class ClassSum
        {
            public double Qty1;
            public double Qty2;

            public ClassSum(double qty1, double qty2)
            {
                Qty1 = qty1;
                Qty2 = qty2;
            }
        }

        Dictionary<string, ClassSum> listSum = null;
        #endregion


        #region < CONSTRUCTOR >
        public WM0162()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM LOAD >
        private void WM0162_Load(object sender, EventArgs e)
        {
            try
            {
                #region Grid Setting

                //grid1
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "CONTRACTDATE", "수주일자",     false, GridColDataType_emu.YearMonthDay, 100, 130, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "RECDATE",      "출하지시일자", false, GridColDataType_emu.YearMonthDay, 100, 130, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목코드", false, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTOMERCODE", "거래처코드", false, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",     "품목명",       false, GridColDataType_emu.VarChar,      130, 130, Infragistics.Win.HAlign.Left,   true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "CONTRACTQTY",  "수주수량",     false, GridColDataType_emu.Double,       80,  130, Infragistics.Win.HAlign.Right,  true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "PLANQTY",      "계획수량",     false, GridColDataType_emu.Double,       80,  130, Infragistics.Win.HAlign.Right,  true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "SHIPQTY",      "출하수량",     false, GridColDataType_emu.Double,       80,  130, Infragistics.Win.HAlign.Right,  true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",     "단위",         false, GridColDataType_emu.VarChar,      80,  130, Infragistics.Win.HAlign.Center,   true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "UNITWGT",      "단위중량",     false, GridColDataType_emu.VarChar,      80,  130, Infragistics.Win.HAlign.Right,  true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "UNITWGT_UNIT",  "단위중량단위", false, GridColDataType_emu.VarChar,      100, 130, Infragistics.Win.HAlign.Center,  true, false);
                _GridUtil.SetInitUltraGridBind(grid1);

                //grid1.DisplayLayout.Bands[0].Columns["RECDATE"].Header.Appearance.ForeColor = Color.SkyBlue;

                //grid2
                //_GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);
                //_GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목코드", false, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "NOWQTY", "재고량", false, GridColDataType_emu.Double, 130, 130, Infragistics.Win.HAlign.Right, true, false);

                //_GridUtil.SetInitUltraGridBind(grid2);

                //grid1.DisplayLayout.Bands[0].Columns["RECDATE"].Header.Appearance.ForeColor = Color.SkyBlue;



                #endregion


                #region ComboBox Setting

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;

                cbo_STARTDATE2_H.Value = DateTime.Now.AddDays(7);
                cbo_ENDDATE2_H.Value = DateTime.Now;

                #endregion


                #region PopUp Setting

                btbManager.PopUpAdd(txt_CUSTCODE_H, txt_CUSTNAME_H, "BM0030", new object[] { cbo_PLANTCODE_H, "", "", "Y", "", "" });
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "1", "" });

                #endregion

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }

        }

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            for (; 4 < grid1.Columns.Count;)
            {
                grid1.Columns.RemoveAt(grid1.Columns.Count - 1);
            }

            grid1.DisplayLayout.Bands[0].Groups.Clear();
            _GridUtil.Grid_Clear(grid1);

            listSum = new Dictionary<string, ClassSum>();

            base.DoInquire();

            string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
            string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
            string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
            string sSDate2 = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE2_H.Value);
            string sEDate2 = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE2_H.Value);
            string sCustCode = DBHelper.nvlString(txt_CUSTCODE_H.Text.Trim());
            string sCustName = DBHelper.nvlString(txt_CUSTNAME_H.Text.Trim());
            string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
            string sItemName = DBHelper.nvlString(txt_ITEMNAME_H.Text.Trim());

            DBHelper helper = new DBHelper(false);

            // grid1
            try
            {
                rtnDtTemp = helper.FillTable("USP_WM0162_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_SDATE2", sSDate2, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_EDATE2", sEDate2, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_CUSTNAME", sCustName, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                                            );

                DataTable dtS2 = helper.FillTable("USP_WM0162_S2", CommandType.StoredProcedure
                                                           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_SDATE2", sSDate2, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_EDATE2", sEDate2, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_CUSTNAME", sCustName, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                                           );

                grid1.SuspendLayout();

                string sPreRecDate = "";


                foreach (DataRow dr in rtnDtTemp.Rows)
                {
                    string sRecDate = CModule.ToString(dr["RECDATE"]);
                    sCustCode = CModule.ToString(dr["CUSTOMERCODE"]);
                    sItemCode = CModule.ToString(dr["ITEMCODE"]);

                    if (sPreRecDate != sRecDate)
                    {
                        if (sPreRecDate == "")
                        {
                            sPreRecDate = Convert.ToDateTime(sRecDate).AddDays(-1).ToString("yyyy-MM-dd");
                        }

                        while (true)
                        {
                            DateTime da = Convert.ToDateTime(sPreRecDate);
                            da = da.AddDays(1);

                            sPreRecDate = da.ToString("yyyy-MM-dd");

                            grid1.Columns.Add("PLAN_" + sPreRecDate, "수주수량");
                            grid1.Columns.Add("REM_" + sPreRecDate, "잔여");
                            grid1.Columns["PLAN_" + sPreRecDate].CellAppearance.TextHAlign = HAlign.Right;
                            grid1.Columns["REM_" + sPreRecDate].CellAppearance.TextHAlign = HAlign.Right;
                            grid1.Columns["PLAN_" + sPreRecDate].Header.Appearance.TextHAlign = HAlign.Center;
                            grid1.Columns["REM_" + sPreRecDate].Header.Appearance.TextHAlign = HAlign.Center;
                            grid1.Columns["PLAN_" + sPreRecDate].Width = 80;
                            grid1.Columns["REM_" + sPreRecDate].Width = 80;

                            string[] sArr = { "PLAN_" + sPreRecDate, "REM_" + sPreRecDate };

                            _GridUtil.GridHeaderMerge(grid1, "A" + sPreRecDate, sPreRecDate, sArr, null);

                            if (sPreRecDate == sRecDate) break;

                        }
                    }

                    double dPlan = CModule.ToDouble(dr["PLANQTY"]);
                    double dShip = CModule.ToDouble(dr["SHIPQTY"]);

                    double dRem = dPlan - dShip;

                    bool bFind = false;
                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        if (CModule.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value) == CModule.ToString(dr["PLANTCODE"])
                            && CModule.ToString(grid1.Rows[i].Cells["CUSTOMERCODE"].Value) == CModule.ToString(dr["CUSTOMERCODE"])
                            && CModule.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value) == CModule.ToString(dr["ITEMCODE"]))
                        {
                            grid1.ActiveRow = grid1.Rows[i];
                            bFind = true;
                        }
                    }

                    if (!bFind)
                    {
                        grid1.InsertRow();

                        grid1.ActiveRow.Cells["PLANTCODE"].Value = CModule.ToString(dr["PLANTCODE"]);
                        grid1.ActiveRow.Cells["CUSTOMERCODE"].Value = CModule.ToString(dr["CUSTOMERCODE"]);
                        grid1.ActiveRow.Cells["CUSTNAME"].Value = CModule.ToString(dr["CUSTNAME"]);
                        grid1.ActiveRow.Cells["ITEMCODE"].Value = CModule.ToString(dr["ITEMCODE"]);
                        grid1.ActiveRow.Activation = Activation.NoEdit;
                    }

                    grid1.ActiveRow.Cells["PLAN_" + sRecDate].Value = string.Format("{0:#,##0}", CModule.ToDouble(dPlan));

                    if (dRem <= 0)
                    {
                        dRem = 0;
                    }
                    else
                    {
                        DataRow[] tdr = dtS2.Select("ITEMCODE = '" + sItemCode + "' and NOWQTY > 0");

                        if (tdr.Length > 0)
                        {
                            double dValue = CModule.ToDouble(tdr[0]["NOWQTY"]);

                            if (dValue > dRem)
                            {
                                dValue -= dRem;
                                dRem = 0;
                            }
                            else
                            {
                                dRem = dValue;
                                dValue = 0;
                            }

                            tdr[0]["NOWQTY"] = dValue;
                        }
                    }

                    grid1.ActiveRow.Cells["REM_" + sRecDate].Value = string.Format("{0:#,##0}", dRem);
                    string sKey = CModule.ToString(dr["PLANTCODE"]) + "|" + sCustCode + "|" + sItemCode;

                    if (listSum.ContainsKey(sKey))
                    {
                        listSum[sKey].Qty1 += dPlan;
                        listSum[sKey].Qty2 += dRem;
                    }
                    else
                    {
                        listSum.Add(sKey, new ClassSum(dPlan, dRem));
                    }
                }

                grid1.Columns.Add("PLAN_SUM", "수주수량");
                grid1.Columns.Add("REM_SUM", "잔여");
                grid1.Columns["PLAN_SUM"].CellAppearance.TextHAlign = HAlign.Right;
                grid1.Columns["REM_SUM"].CellAppearance.TextHAlign = HAlign.Right;
                grid1.Columns["PLAN_SUM"].Header.Appearance.TextHAlign = HAlign.Center;
                grid1.Columns["REM_SUM"].Header.Appearance.TextHAlign = HAlign.Center;
                grid1.Columns["PLAN_SUM"].Width = 80;
                grid1.Columns["REM_SUM"].Width = 80;

                string[] sArrSum = { "PLAN_SUM", "REM_SUM" };

                _GridUtil.GridHeaderMerge(grid1, "ASUM", "합계", sArrSum, null);

                foreach (string sKey in listSum.Keys)
                {
                    string[] sArr2 = sKey.Split('|');

                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        if (CModule.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value) == sArr2[0]
                            && CModule.ToString(grid1.Rows[i].Cells["CUSTOMERCODE"].Value) == sArr2[1]
                            && CModule.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value) == sArr2[2])
                        {
                            grid1.Rows[i].Cells["PLAN_SUM"].Value = string.Format("{0:#,##0}", listSum[sKey].Qty1);
                            grid1.Rows[i].Cells["REM_SUM"].Value = string.Format("{0:#,##0}", listSum[sKey].Qty2);
                            break;
                        }
                    }
                }

                grid1.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion
    }
    #endregion
}