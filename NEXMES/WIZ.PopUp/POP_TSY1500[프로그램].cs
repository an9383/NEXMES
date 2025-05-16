using System;
using System.Data;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class POP_TSY1500 : WIZ.Forms.BasePopupForm
    {
        string[] argument;

        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();

        ////비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        #endregion

        public POP_TSY1500(string[] param)
        {
            InitializeComponent();

            argument = new string[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                argument[i] = param[i];

                #region [작업자 및 명 Parameter Show 7=0 프로그램id, 1, 언어]
                switch (i)
                {
                    case 0: //프로그램id
                        this.txtProgramID.Text = argument[0].ToUpper(); //programid
                        break;
                }
                #endregion
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            string RS_CODE = string.Empty, RS_MSG = string.Empty;
            string sProgramID = Convert.ToString(this.txtProgramID.Text.Trim());
            string sLang = WIZ.Common.Lang;

            _DtTemp = _biz.SEL_TSY1500(sProgramID, sLang);

            Grid1.DataSource = _DtTemp;
            Grid1.DataBind();
        }

        private void txtProgramID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                search();
            }
        }

        private void POP_TSY1500_프로그램__Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(this.Grid1);

            _GridUtil.InitColumnUltraGrid(Grid1, "ProgramID", "프로그램ID", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Grid1, "UidName", "프로그램명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(Grid1);

            search();
        }

        private void Grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            DataTable TmpDt = new DataTable();
            TmpDt.Columns.Add("ProgramID", typeof(string));
            TmpDt.Columns.Add("UidName", typeof(string));

            TmpDt.Rows.Add(new object[] { e.Row.Cells["ProgramID"].Value, e.Row.Cells["UidName"].Value });

            this.Tag = TmpDt;
            this.Close();
        }
    }
}
