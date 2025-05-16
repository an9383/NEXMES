#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : TT1030
//   Form Name    :  
//   Name Space   : WIZ.PP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  :  
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace WIZ.PP
{
    public partial class TT1030 : WIZ.Forms.BaseMDIChildForm
    {

        #region <MEMBER AREA>
        private SqlConnection conn;
        private SqlTransaction trans;
        #endregion

        #region < CONSTRUCTOR >
        public TT1030()
        {
            InitializeComponent();

            GridInit();
        }
        private void GridInit()
        {
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "InspDate", "측정일", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PartNo", "PartNo", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LotNo", "LotNo", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Engine", "Engine", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OK_NG", "전체판정", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "Data_1_1", "편차값1_1", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OK_1_1", "편차값1_1결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "Data_1_2", "편차값1_2", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OK_1_2", "편차값1_2결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "Data_2_1", "편차값2_1", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OK_2_1", "편차값2_1결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "Data_2_2", "편차값2_2", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OK_2_2", "편차값2_2결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "Data_3_1", "편차값3_1", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OK_3_1", "편차값3_1결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "Data_3_2", "편차값3_2", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OK_3_2", "편차값3_2결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "Data_4_1", "편차값4_1", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OK_4_1", "편차값4_1결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "Data_4_2", "편차값4_2", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OK_4_2", "편차값4_2결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "TData_1", "토크값1", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TOK_1", "토크1결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "TData_2", "토크값2", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TOK_2", "토크2결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "TData_3", "토크값3", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TOK_3", "토크3결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "TData_4", "토크값4", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TOK_4", "토크4결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "ProcFlag", "처리구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProcFlagNM", "처리여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자ID", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakerNM", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        /// 

        #region 이전 doinquire
        /* public override void DoInquire()
        {
            base.DoInquire();
            string sStartDate = string.Format("{0:yyyy-MM-dd}", cboStartDate_H.Value);
            string sEndDate   = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);
            string sItemCode  = txtItemCode_H.Text;
            string RS_CODE    = string.Empty, RS_MSG = string.Empty;
            _DtTemp           = _biz.USP_TT1030_S1(sStartDate, sEndDate, sItemCode, ref RS_CODE, ref RS_MSG);
            
            grid1.DataSource = _DtTemp;
            grid1.DataBinds();

            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                for (int j = 7; j < grid1.Columns.Count; j++)
                {
                    // 합격결과에 따라서 글자 색 변경
                    if (grid1.Rows[i].Cells[j].Column.Header.Caption.IndexOf("결과") > 0)
                    {
                        if (Convert.ToString(grid1.Rows[i].Cells[j].Value) == "NG") grid1.Rows[i].Cells[j - 1].Appearance.ForeColor = Color.Red;
                        else grid1.Rows[i].Cells[j - 1].Appearance.ForeColor = Color.Blue;
                    }
                }
            }
        }*/
        #endregion

        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cboStartDate_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);
                string sItemCode = txtItemCode_H.Text;

                grid1.DataSource = helper.FillTable("USP_TT1030_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input));



                grid1.DataBinds();

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    for (int j = 0; j < grid1.Columns.Count; j++)
                    {
                        // 합격결과에 따라서 글자 색 변경
                        if (grid1.Rows[i].Cells[j].Column.Header.Caption.IndexOf("판정") > 0)
                        {
                            if (Convert.ToString(grid1.Rows[i].Cells[j].Value) == "NG") grid1.Rows[i].Cells[j - 1].Appearance.ForeColor = Color.Red;
                            else grid1.Rows[i].Cells[j - 1].Appearance.ForeColor = Color.Blue;
                        }
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

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();

        }

        #endregion

        #region < EVENT AREA >
        /// <summary>
        /// Form이 Close 되기전에 발생
        /// e.Cancel을 true로 설정 하면, Form이 close되지 않음
        /// 수정 내역이 있는지를 확인 후 저장여부를 물어보고 저장, 저장하지 않기, 또는 화면 닫기를 Cancel 함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// DATABASE UPDATE전 VALIDATEION CHECK 및 값을 수정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Modified)
            {
                e.Command.Parameters["@Editor"].Value = this.WorkerID;
                return;
            }

            if (e.Row.RowState == DataRowState.Added)
            {
                e.Command.Parameters["@Maker"].Value = this.WorkerID;
                return;
            }
        }

        /// <summary>
        /// 저장처리시 오류가 발생한 경우 오류 메세지에 대한 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.Errors == null) return;

            switch (((SqlException)e.Errors).Number)
            {
                // 중복
                case 2627:
                    e.Row.RowError = "공정코드가 있습니다.";
                    throw (new SException("C:S00099", e.Errors));
                default:
                    break;
            }
        }
        #endregion

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의
        #endregion
    }
}
