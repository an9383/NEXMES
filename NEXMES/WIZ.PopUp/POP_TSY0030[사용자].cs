using System;
using System.Data;
using System.Windows.Forms;



namespace WIZ.PopUp
{
    public partial class POP_TSY0030 : WIZ.Forms.BasePopupForm
    {
        // string[] argument;

        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();

        ////비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        #endregion

        public POP_TSY0030(string[] param)
        {
            InitializeComponent();

            // argument = new string[param.Length];

            Common _Common = new Common();

            //DataTable rtnDtTemp = _Common.GET_TBM0000_CODE("PLANTCODE");  //사업장
            //WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, "CODE_ID", "CODE_NAME", "ALL", "", false, param.Length > 0 && param[0]!=""?param[0]:"" );
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.Grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.txtWorkerID.Text = param[4];
            this.txtWorkerName.Text = param[5];
            cboUseFlag_H.Text = param[6] == "" ? "ALL" : param[6];
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");     //사용여부
            //WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, "CODE_ID", "CODE_NAME", "ALL","" , false, param.Length >3 && param[3]!=""?param[3]:"");
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.Grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
        }

        private void POP_TSY0030_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(this.Grid1);

            //_GridUtil.InitColumnUltraGrid(Grid1, "PlantCode",     "공장코드", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(Grid1, "PlantCodeNm",   "공장명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(Grid1, "OPCode",        "공정코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(Grid1, "LineCode",      "라인", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(Grid1, "WorkCenterCode","작업장코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Grid1, "WorkerID", "사용자ID", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Grid1, "WorkerName", "사용자명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            try
            {
                _GridUtil.SetInitUltraGridBind(Grid1);
            }
            catch (Exception ex)
            {
            }
            search();

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            search();
        }
        private void search()
        {
            string RS_CODE = string.Empty, RS_MSG = string.Empty;
            string sOPCode = "";
            string sLineCode = "";
            string sWorkCenterCode = "";
            string sWorkerID = txtWorkerID.Text.Trim();                                                                  // 작업자 ID
            string sWorkerName = txtWorkerName.Text.Trim();                                                                // 작업자명
            string sUseFlag = Convert.ToString(this.cboUseFlag_H.Value);
            string sPlantCode = "";// Convert.ToString(this.cboPlantCode_H.SelectedValue);

            DataTable rtnDtTemp = new DataTable();
            //Common _Common = new Common();
            //rtnDtTemp = _Common.GET_TBM0000_CODE("PLANTCODE");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.Grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");


            _DtTemp = _biz.SEL_TSY0030(sPlantCode, sOPCode, sLineCode, sWorkCenterCode, sWorkerID, sWorkerName, sUseFlag);

            Grid1.DataSource = _DtTemp;
            Grid1.DataBind();
        }

        private void Grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            DataTable TmpDt = new DataTable();
            TmpDt.Columns.Add("WorkerID", typeof(string));
            TmpDt.Columns.Add("WorkerName", typeof(string));

            if (Grid1.Selected.Rows.Count == 0)
            {
                TmpDt.Rows.Add(new object[] { e.Row.Cells["WorkerID"].Value, e.Row.Cells["WorkerName"].Value });
            }
            else
            {

                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow dr in Grid1.Selected.Rows)
                    TmpDt.Rows.Add(new object[] { dr.Cells["WorkerID"].Value, dr.Cells["WorkerName"].Value });

            }
            this.Tag = TmpDt;
            this.Close();
        }

        private void txtWorkerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                search();
            }
        }

        private void txtWorkerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                search();
            }
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            DataTable TmpDt = new DataTable();
            TmpDt.Columns.Add("WorkerID", typeof(string));
            TmpDt.Columns.Add("WorkerName", typeof(string));
            if (Grid1.Selected.Rows.Count == 0)
            {
                TmpDt.Rows.Add(new object[] { Grid1.ActiveRow.Cells["WorkerID"].Value, Grid1.ActiveRow.Cells["WorkerName"].Value });
            }
            else
            {

                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow dr in Grid1.Selected.Rows)
                    TmpDt.Rows.Add(new object[] { dr.Cells["WorkerID"].Value, dr.Cells["WorkerName"].Value });

            }

            this.Tag = TmpDt;
            this.Close();
        }


    }
}
