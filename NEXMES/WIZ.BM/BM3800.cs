#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM3800
//   Form Name    : MES P/C 관리
//   Name Space   : 
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>

using Infragistics.Win.UltraWinGrid;


using System;
using System.Data;
using System.Windows.Forms;
using WIZ.Forms;

#endregion

namespace WIZ.BM
{
    public partial class BM3800 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); //return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM3800()
        {
            InitializeComponent();
        }
        #endregion

        #region BM3800_Load
        private void BM3800_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IPAddress", "IP주소", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PCDesc", "PC명", false, GridColDataType_emu.VarChar, 167, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PCType", "단말형태", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BarPrtUseFlag", "프린터\n사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BarPrtPortNo", "프린터\n포트", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BarPrtComSet", "프린터\n설정", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BarScanUseFlag", "스캐너\n사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BarScanPortNo", "스캐너\n포트", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BarScanComSet", "스캐너\n설정", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PrintType", "프린터종류", false, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "비고", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            ///////MERGE 
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 50;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;



            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "BarPrtUseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "BarScanUseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PCTYPE");     //PCTYPE
            WIZ.Common.FillComboboxMaster(this.cboPCType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PCType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PrintType");     //PCTYPE
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PrintType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion
        }
        #endregion BM3800_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            base.DoInquire();
            DBHelper helper = new DBHelper(false);

            try
            {

                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);
                string pctype = DBHelper.nvlString(this.cboPCType_H.Value);
                string ipaddress = Convert.ToString(this.txtIPAddress_H.Value);
                string useflag = DBHelper.nvlString(this.cboUseFlag_H.Value);

                grid1.DataSource = helper.FillTable("USP_BM3800_S1N", CommandType.StoredProcedure
                                                             , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("PCTYPE", pctype, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("IPAddress", ipaddress, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("UseFlag", useflag, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("Param1", DBNull.Value, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("Param2", DBNull.Value, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("Param3", DBNull.Value, DbType.String, ParameterDirection.Input));


                grid1.DataBinds();


            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                base.DoNew();
                _GridUtil.AddRow(this.grid1);
                //this.grid1.SetDefaultValue("PlantCode", "SY");

                UltraGridUtil.ActivationAllowEdit(this.grid1, "IPAddress");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            this.grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);

            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                base.DoSave();


                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlantCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "공장 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM3800_D1N", CommandType.StoredProcedure
                            , helper.CreateParameter("IPAddress", drRow["IPAddress"].ToString(), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM3800_I1N", CommandType.StoredProcedure
                            , helper.CreateParameter("PlantCode", drRow["PlantCode"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("IPAddress", drRow["IPAddress"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("PCDesc", drRow["PCDesc"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("PCType", drRow["PCType"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("BarPrtUseFlag", drRow["BarPrtUseFlag"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("BarPrtPortNo", drRow["BarPrtPortNo"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("BarPrtComSet", drRow["BarPrtComSet"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("BarScanUseFlag", drRow["BarScanUseFlag"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("BarScanPortNo", drRow["BarScanPortNo"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("BarScanComSet", drRow["BarScanComSet"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("PrintType", drRow["PrintType"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Remark", drRow["Remark"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("UseFlag", drRow["UseFlag"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM3800_U1N", CommandType.StoredProcedure
                            , helper.CreateParameter("PlantCode", drRow["PlantCode"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("IPAddress", drRow["IPAddress"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("PCDesc", drRow["PCDesc"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("PCType", drRow["PCType"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("BarPrtUseFlag", drRow["BarPrtUseFlag"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("BarPrtPortNo", drRow["BarPrtPortNo"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("BarPrtComSet", drRow["BarPrtComSet"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("BarScanUseFlag", drRow["BarScanUseFlag"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("BarScanPortNo", drRow["BarScanPortNo"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("BarScanComSet", drRow["BarScanComSet"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("PrintType", drRow["PrintType"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Remark", drRow["Remark"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("UseFlag", drRow["UseFlag"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("PlantCode");
                helper.Commit();

            }
            catch (Exception ex)
            {
                helper.Rollback();
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

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의
        #endregion
    }
}
