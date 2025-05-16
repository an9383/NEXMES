using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.Forms;
using WIZ.PopUp;

namespace WIZ.BM
{
    public partial class BM3651 : WIZ.Forms.BaseForm
    {
        string[] argument;

        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        public BM3651(string PlantCode, string WorkCenterCode, string WorkCenterName, string ItemCode, string ItemName)
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            BizGridManager gridManager = new BizGridManager(grid2);

            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });

            gridManager.PopUpAdd("WorkCenterCode", "WorkCenterName", "TBM0600", new string[] { "PlantCode", "" });    //품목         
            gridManager.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });    //품목            

            cboPlantCode_H.Value = PlantCode;
            txtItemCode.Text = ItemCode;
            txtItemName.Text = ItemName;
            txtWorkCenterCode.Text = WorkCenterCode;
            txtWorkCenterName.Text = WorkCenterName;
        }

        private void BM3651_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(this.grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "OpSeq", "NO", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "관리항목", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "관리항목명", false, GridColDataType_emu.VarChar, 157, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCManaSpec", "관리규격", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCManaSpecNM", "규격명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCSpQuality", "특별특성", false, GridColDataType_emu.VarChar, 82, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCSpQualityNM", "특성명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspValType", "등록형태", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SpecLSL", "규격하한치", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SpecUSL", "규격상한치", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCStandard", "측정구", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCStandardNM", "측정구명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ManaLSL", "관리하한치", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ManaUSL", "관리상한치", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DisplayNo", "표시순서", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspRequired", "검사필수여부", false, GridColDataType_emu.VarChar, 115, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspPeriod", "검사주기(일/주/월)", false, GridColDataType_emu.VarChar, 135, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCycle", "검사주기(별)", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspMethod", "검사수집장비", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCount", "검사횟수", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2);

            _GridUtil.InitColumnUltraGrid(grid2, "WorkCenterCode", "작업장코드", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WorkCenterName", "작업장명", false, GridColDataType_emu.VarChar, 400, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 400, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);


            //////MERGE
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;


            _GridUtil.SetInitUltraGridBind(grid2);

            //1. 사업자와, 품목이 선택되어 있으면 grid1에 tbm3650의 정보를 보여줌
            search();

        }
        private void search()
        {
            string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
            string sItemCode = txtItemCode.Text.Trim();
            string sWorkCenterCode = txtWorkCenterCode.Text.Trim();

            DBHelper helper = new DBHelper(false);

            try
            {
                _DtTemp = helper.FillTable("USP_BM3651_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input));


                grid1.DataSource = _DtTemp;
                grid1.DataBinds();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                helper.Close();
            }


        }
        private void insert()
        {
            try
            {
                int sGrid1 = grid1.Rows.Count;
                int sGrid2 = grid2.Rows.Count;
                string sCODE = string.Empty;
                string sMSG = string.Empty;

                for (int i = 0; i < sGrid2; i++)
                {
                    string I_PlantCode = Convert.ToString(cboPlantCode_H.Value);
                    string I_ItemCode = txtItemCode.Text.Trim();
                    string I_ItemCode1 = this.grid2.Rows[i].Cells["ItemCode"].Value.ToString();
                    string I_Maker = WIZ.LoginInfo.UserID;

                    if (this.txtItemCode.Text != "")
                        I_ItemCode = txtItemCode.Text.ToString();

                    INS_TBM3651(I_PlantCode, I_ItemCode, I_ItemCode1, I_Maker, ref sCODE, ref sMSG);

                }

                if (sCODE == "S")
                {
                    DialogForm dialogform;

                    dialogform = new DialogForm("C:R00005", DialogForm.DialogType.OK);

                    dialogform.ShowDialog();

                }
            }
            catch
            {

            }
            finally
            {

            }
        }

        public void INS_TBM3651(string I_PlantCode, string I_ItemCode, string I_ItemCode1, string I_Maker, ref string code, ref string mesg)
        {

            DBHelper helper = new DBHelper("", true);
            string RS_CODE = string.Empty, RS_MSG = string.Empty;
            this.grid2.UpdateData();

            try
            {
                helper.ExecuteNoneQuery("USP_BM3651_I1", CommandType.StoredProcedure//, ref RS_CODE, ref RS_MSG
                                                       , helper.CreateParameter("PlantCode", I_PlantCode, DbType.String, ParameterDirection.Input)        // 공장코드
                                                       , helper.CreateParameter("ItemCode", I_ItemCode, DbType.String, ParameterDirection.Input)        // 항목이름
                                                       , helper.CreateParameter("ItemCode1", I_ItemCode1, DbType.String, ParameterDirection.Input)        // 항목이름
                                                       , helper.CreateParameter("Maker", I_Maker, DbType.String, ParameterDirection.Input));        // 등록자  
                if (helper.RSCODE == "S")
                {
                    //성공처리 여부 메세지 쇼
                    helper.Commit();
                    DialogForm dialogform;

                    dialogform = new DialogForm("C:R00005", DialogForm.DialogType.OK);

                    dialogform.ShowDialog();
                }
                else
                {
                    //실패처리 여부 메세지 쇼
                    //RS_MSG
                    DialogForm dialogform;

                    dialogform = new DialogForm(helper.RSMSG, DialogForm.DialogType.OK);
                    dialogform.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                helper.Rollback();

            }
            finally
            {
                helper.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntFind_Click(object sender, EventArgs e)
        {
            search();  //조회처리
        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            _DtTemp = (DataTable)grid2.DataSource;
            //추가
            int iRow = _GridUtil.AddRow(this.grid1, _DtTemp);
        }

        private void bntDel_Click(object sender, EventArgs e)
        {
            //삭제
            int idx = this.grid2.ActiveRow == null ? 0 : this.grid2.ActiveRow.Index;
            if (idx >= 0)
                UltraGridUtil.GridRowDelete(grid2, idx);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogForm dialogform;

            dialogform = new DialogForm("C:Q00009", DialogForm.DialogType.YESNO);

            dialogform.ShowDialog();

            if (dialogform.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                insert();
            }

        }
    }
}
