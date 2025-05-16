#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  WM0300
//   Form Name    :  제품 재고조회
//   Name Space   :  WIZ.WM
//   Created Date :  
//   Made By      :  WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM0300 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp1 = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성

        #endregion

        #region < CONSTRUCTOR >
        public WM0300()
        {
            InitializeComponent();

        }
        #endregion

        #region < WM0300_Load >
        private void WM0300_Load(object sender, EventArgs e)
        {
            #region <Grid Setting>

            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE", "품목구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SUMQTY3", "포장수량", false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SUMQTY", "총 수량\r\n(ⓐ+ⓑ)", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SUMQTY1", "재고 수량\r\n(ⓐ)", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SUMQTY2", "출고 대기 수량\r\n(ⓑ)", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WHCODE", "창고", false, GridColDataType_emu.VarChar, 10, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WHNAME", "창고", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STORAGELOCCODE", "위치", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STORAGELOCNAME", "위치", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMTYPE", "품목구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CNTITEM", "포장수량", false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Right, false, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SUMQTY", "재고수량", false, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTSTATUS", "LOT상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);

            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "STOCKQTY", "수량", false, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "WHCODE", "창고코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "WHNAME", "창고", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "STORAGELOCCODE", "위치코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "STORAGELOCNAME", "위치", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTSTATUS", "LOT상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid3);

            _GridUtil.InitializeGrid(this.grid4, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid4, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "DATE", "입출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "TYPECODE", "입출고구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "TYPENAME", "입출고구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "QTY", "수량", false, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid4);

            #endregion

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, cboItemType_H });

            #region <ComboBox Setting>

            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboPlantCode_H.Value = "10";

            //rtnDtTemp = _Common.GET_TBM0000_CODE("WHCODE");  //창고
            //WIZ.Common.FillComboboxMaster(this.cboWhCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("ITEMTYPE");  // 제품구분
            WIZ.Common.FillComboboxMaster(this.cboItemType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("LOTSTATUS");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "LOTSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            this.plantCode = CModule.GetAppSetting("Site", "10");

            GetWHCODE();
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                //base.DoInquire();
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                // 공장코드
                string sWHCode = Convert.ToString(cboWhCode_H.Value);                   // 창고코드
                string sITEMTYPE = Convert.ToString(cboItemType_H.Value);                 // 품목구분
                string sItemCode = this.txtItemCode.Text;                                 // 품목
                string sLOTNO = this.txtLotNo_H.Text;
                string LS_TABIDX = string.Empty;

                if (tabControl1.SelectedTab.Index == 0) { LS_TABIDX = "TAB1"; } else { LS_TABIDX = "TAB2"; }

                //조회조건 LOT번호 체크시 LOT번호로만 조회
                if (LS_TABIDX == "TAB2" && rdoLotChk.Checked == true)
                {
                    sWHCode = "";
                    sITEMTYPE = "";
                    sItemCode = "";
                }
                //품목별, LOT별 조회
                rtnDtTemp = helper.FillTable("USP_WM0300_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WHCODE", sWHCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMTYPE", sITEMTYPE, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LOTNO", sLOTNO, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("TAB", LS_TABIDX, DbType.String, ParameterDirection.Input));

                //창고별 재고 조회
                if (LS_TABIDX == "TAB1")
                    rtnDtTemp1 = helper.FillTable("USP_WM0300_S2N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WHCODE", sWHCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMTYPE", sITEMTYPE, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LOTNO", sLOTNO, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("TAB", LS_TABIDX, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                if (LS_TABIDX == "TAB1")
                {
                    if (rtnDtTemp.Rows.Count == 0 || rtnDtTemp1.Rows.Count == 0)
                    {
                        if (rtnDtTemp.Rows.Count == 0 && rtnDtTemp1.Rows.Count == 0)
                        {
                            _GridUtil.Grid_Clear(grid1);
                            _GridUtil.Grid_Clear(grid2);

                            this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        }

                        else if (rtnDtTemp.Rows.Count == 0)
                        {
                            _GridUtil.Grid_Clear(grid1);

                            this.ShowDialog(Common.getLangText("품목별 재고 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        }

                        else if (rtnDtTemp1.Rows.Count == 0)
                        {
                            _GridUtil.Grid_Clear(grid2);
                            this.ShowDialog(Common.getLangText("창고별 재고 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        }

                        // 조회할 데이터가 없습니다.
                        return;
                    }
                    else
                    {
                        for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                        {
                            if (rtnDtTemp.Rows[i]["SUMQTY1"].ToString() == "")
                            {
                                rtnDtTemp.Rows[i].BeginEdit();
                                rtnDtTemp.Rows[i]["SUMQTY1"] = "0";
                                rtnDtTemp.Rows[i].EndEdit();
                            }
                            if (rtnDtTemp.Rows[i]["SUMQTY2"].ToString() == "")
                            {
                                rtnDtTemp.Rows[i].BeginEdit();
                                rtnDtTemp.Rows[i]["SUMQTY2"] = "0";
                                rtnDtTemp.Rows[i].EndEdit();
                            }
                        }
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds(rtnDtTemp);
                        grid2.DataSource = rtnDtTemp1;
                        grid2.DataBinds(rtnDtTemp1);
                    }

                }
                else
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid3.DataSource = rtnDtTemp;
                        grid3.DataBinds(rtnDtTemp);
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid3);
                        _GridUtil.Grid_Clear(grid4);

                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >
        #endregion

        #region < METHOD AREA >
        private void GetWHCODE()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT MINORCODE                             AS CODE_ID, ");
                command.AppendLine("       '[' + MINORCODE + ']' + CODENAME      AS CODE_NAME");
                command.AppendLine("  FROM TBM0000                                           ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                     ");
                command.AppendLine("   AND MAJORCODE = 'WHCODE'                              ");
                command.AppendLine("   AND RELCODE1 LIKE '%" + cboPlantCode_H.Value + "%'");
                command.AppendLine("   AND RELCODE2 = 'WM'");
                command.AppendLine(" ORDER BY MINORCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(this.cboWhCode_H, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        private void grid3_ClickCell(object sender, EventArgs e)
        {
            if (this.grid3.Rows.Count == 0) return;

            _GridUtil.Grid_Clear(grid4);

            //입출고 이력조회
            DBHelper helper = new DBHelper(false);

            try
            {
                string LOTNO = grid3.ActiveRow.Cells["LOTNO"].Value.ToString();
                string TYPE = "";
                string TYPE1 = "";
                string STARTDATE = "";
                string ENDDATE = "";
                string PROG = "WM0300";

                rtnDtTemp = helper.FillTable("USP_WM0300_S3N", CommandType.StoredProcedure
                                                            , helper.CreateParameter("LOTNO", LOTNO, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("TYPE", TYPE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("TYPE1", TYPE1, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("PROG", PROG, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("STARTDATE", STARTDATE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ENDDATE", ENDDATE, DbType.String, ParameterDirection.Input));
                this.ClosePrgFormNew();


                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid4.DataSource = rtnDtTemp;
                    grid4.DataBinds(rtnDtTemp);

                }
                else
                {
                    _GridUtil.Grid_Clear(grid4);
                    //this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); 
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {

            if (grid1.Rows.Count == 0) return;

            //탭이동
            this.ultraTabPageControl2.Tab.Active = true;
            this.ultraTabPageControl2.Tab.Selected = true;


            DBHelper helper = new DBHelper(false);
            try
            {
                string sPlantCode = grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();                // 공장코드
                string sWHCode = "";                                                                 // 창고코드
                string sITEMTYPE = grid1.ActiveRow.Cells["ITEMTYPE"].Value.ToString();                 // 품목구분
                string sItemCode = grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();                 // 품목
                string sLOTNO = "";

                string LS_TABIDX = string.Empty;
                LS_TABIDX = "TAB2";

                rtnDtTemp = helper.FillTable("USP_WM0300_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WHCODE", sWHCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMTYPE", sITEMTYPE, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LOTNO", sLOTNO, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("TAB", LS_TABIDX, DbType.String, ParameterDirection.Input));
                grid3.DataSource = rtnDtTemp;
                grid3.DataBinds(rtnDtTemp);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void grid2_DoubleClick(object sender, EventArgs e)
        {
            if (grid2.Rows.Count == 0) return;

            //탭 이동
            this.ultraTabPageControl2.Tab.Active = true;
            this.ultraTabPageControl2.Tab.Selected = true;


            DBHelper helper = new DBHelper(false);
            try
            {
                string sPlantCode = grid2.ActiveRow.Cells["PLANTCODE"].Value.ToString();               // 공장코드
                string sWHCode = "";                                                                   // 창고코드
                string sITEMTYPE = grid2.ActiveRow.Cells["ITEMTYPE"].Value.ToString();                 // 품목구분
                string sItemCode = grid2.ActiveRow.Cells["ITEMCODE"].Value.ToString();                 // 품목
                string sLOTNO = "";

                string LS_TABIDX = string.Empty;
                LS_TABIDX = "TAB2";

                rtnDtTemp = helper.FillTable("USP_WM0300_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WHCODE", sWHCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMTYPE", sITEMTYPE, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LOTNO", sLOTNO, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("TAB", LS_TABIDX, DbType.String, ParameterDirection.Input));
                grid3.DataSource = rtnDtTemp;
                grid3.DataBinds(rtnDtTemp);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
    }
}