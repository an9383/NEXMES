using System;
using System.Data;

namespace WIZ.PopUp
{
    public partial class POP_AP0400 : WIZ.Forms.BaseMDIChildForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable rtnDtTemp = new DataTable();

        private string ls_orderno = string.Empty;
        #endregion

        public POP_AP0400(string AS_ORDERNO)
        {
            InitializeComponent();
            ls_orderno = AS_ORDERNO;
        }

        private void POP_AP0400_Load(object sender, EventArgs e)
        {
            GridInit();
            GetChangerOrderNo();
        }

        #region [ User Method Area ]
        private void GridInit()
        {
            try
            {
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 100, 80, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "지시번호", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "지시일자", false, GridColDataType_emu.VarChar, 100, 80, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "계획수량", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "EVENTDATE", "최종 적용일자", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

                _GridUtil.SetInitUltraGridBind(grid1);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 작업장별 생산게획 변경 현황
        /// </summary>
        private void GetChangerOrderNo()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_AP0400_S2", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_ORDERNO", ls_orderno, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                _GridUtil.Grid_Clear(grid1);
                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }
                else
                {
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ Event Area ]
        /// <summary>
        /// 닫기 버튼
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
