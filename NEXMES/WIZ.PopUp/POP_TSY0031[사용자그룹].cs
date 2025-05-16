using System;
using System.Data;
using System.Windows.Forms;



namespace WIZ.PopUp
{
    public partial class POP_TSY0031 : WIZ.Forms.BasePopupForm
    {

        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        //Common 객체 생성
        Common _Common = new Common();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        #endregion


        public POP_TSY0031(string[] param)
        {
            InitializeComponent();

            this.txtGRPID.Text = param[4];
            this.txtGRPName.Text = param[5];
        }

        private void POP_TSY0031_Load(object sender, EventArgs e)
        {
            #region ▶ GRID
            _GridUtil.InitializeGrid(this.Grid1);

            _GridUtil.InitColumnUltraGrid(Grid1, "GRPID", "그룹ID", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Grid1, "GRPNAME", "그룹명", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(Grid1);
            #endregion

            search();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            search();
        }
        private void search()
        {
            string sGRPID = txtGRPID.Text.Trim();
            string sGRPName = txtGRPName.Text.Trim();

            DataTable _DtTemp = _biz.SEL_TSY0080(sGRPID, sGRPName);

            Grid1.DataSource = _DtTemp;
            Grid1.DataBind();
        }

        private void Grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            DataTable TmpDt = new DataTable();
            TmpDt.Columns.Add("GRPID", typeof(string));
            TmpDt.Columns.Add("GRPNAME", typeof(string));

            if (Grid1.Selected.Rows.Count == 0)
            {
                TmpDt.Rows.Add(new object[] { e.Row.Cells["GRPID"].Value, e.Row.Cells["GRPNAME"].Value });
            }
            else
            {

                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow dr in Grid1.Selected.Rows)
                    TmpDt.Rows.Add(new object[] { dr.Cells["GRPID"].Value, dr.Cells["GRPNAME"].Value });

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
