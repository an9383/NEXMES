#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : 
//   Form Name    : 
//   Name Space   : 
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.CM
{
    public partial class TO0200 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >
        public TO0200()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
        }
        #endregion

        #region 폼 초기화

        private void TO0200_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, false, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            //사업장, 공정, 작업장, 설비코드, 상태, 시작시간, 종료시간, 시간, 작업자수, 생산수량, 수불일자
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "공정코드", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "공정명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장코드", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MachCode", "설비코드", false, GridColDataType_emu.VarChar, 183, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MachName", "설비명", false, GridColDataType_emu.VarChar, 183, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ToolCount", "Tool 장착수", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, false, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Seq", "순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ToolCode", "TOOL", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ToolName", "TOOL명", false, GridColDataType_emu.VarChar, 230, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ProdQty", "사용량", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ShelfLife", "수명", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UseRate", "Life 잔량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MakeDate", "등록일", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);


            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable();              // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("EQUIP");      //장착여부
            WIZ.Common.FillComboboxMaster(this.cboEquip, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            WIZ.UltraGridUtil.SetGridDataCopy(this.grid1);
            #endregion
        }

        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);  // 공장코드 
                string sOPCode = txtOPCode.Text.Trim();                           // 품목                                                          
                string sOPName = txtOPName.Text.Trim();                           // 검사항목                                                          
                string sWorkCenterCode = txtWorkCenterCode.Text;                  // 검사항목 
                string sWorkCenterName = txtWorkCenterName.Text;                  // 사용여부 
                string sMachCode = txtMachCode.Text;
                string sMachName = txtMachName.Text;
                string sToolCode = txtToolCode.Text;
                string sToolName = txtToolName.Text;
                string sEquip = Convert.ToString(this.cboEquip.SelectedText);

                grid1.DataSource = helper.FillTable("USP_TO0200_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("pPlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pOPCode", sOPCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pOPName", sOPName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pWorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pWorkCenterName", sWorkCenterName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pMachCode", sMachCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pMachName", sMachName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pToolCode", sToolCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pToolName", sToolName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pSeq1", sEquip, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pSeq2", "", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pSeq3", "", DbType.String, ParameterDirection.Input));
                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                throw ex;
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
                if (grid1.ActiveRow != null)
                {
                    base.DoNew();
                    int iRow = _GridUtil.AddRow(grid2, (DataTable)grid2.DataSource);

                    DataTable dt = (DataTable)grid2.DataSource;
                    dt.Rows[iRow]["PlantCode"] = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);

                    UltraGridUtil.ActivationAllowEdit(grid2, "ToolCode");
                    UltraGridUtil.ActivationAllowEdit(grid2, "ToolName");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            this.grid2.DeleteRow();

        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                this.grid1.UpdateData();


                foreach (DataRow drRow in ((DataTable)grid1.DataSource).GetChanges().Rows)  // .GetChanges().Rows = 변경된 Rows 만 작업
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Added:
                        case DataRowState.Modified:
                        case DataRowState.Deleted:
                            break;
                    }
                }

                helper.Commit();

            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                throw ex;
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region<grid1_ClickCell>
        private void grid1_ClickCell(object sender, EventArgs e)
        {

        }
        #endregion

        #region<DoInquire2>

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            if (grid1.ActiveRow != null)
            {
                DoInquire2();
            }
        }

        private void DoInquire2()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                if (grid1.ActiveRow == null)
                    return;

                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);  // 공장코드 
                string sOPCode = Convert.ToString(grid1.ActiveRow.Cells["OPCode"].Value);                           // 품목                                                                                                                     
                string sWorkCenterCode = Convert.ToString(grid1.ActiveRow.Cells["WorkCenterCode"].Value);                  // 검사항목                 
                string sMachCode = Convert.ToString(grid1.ActiveRow.Cells["MachCode"].Value);
                // string sToolCode =Convert.ToString(grid1.ActiveRow.Cells["ToolCode"].Value);


                grid2.DataSource = helper.FillTable("USP_TO0200_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("pPlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pOPCode", sOPCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pWorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pMachCode", sMachCode, DbType.String, ParameterDirection.Input));

                //   , helper.CreateParameter("pToolCode", sToolCode, DbType.String, ParameterDirection.Input)


                grid2.DataBinds();
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
    }
}
