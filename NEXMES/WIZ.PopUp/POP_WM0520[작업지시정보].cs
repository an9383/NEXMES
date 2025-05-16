using System;
using System.Data;
using System.Windows.Forms;


namespace WIZ.PopUp
{
    public partial class POP_WM0520 : WIZ.Forms.BaseMDIChildForm
    {

        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();

        ////비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        private string plantCode = string.Empty; //plantcode default 설정

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        #endregion

        public POP_WM0520()
        {
            InitializeComponent();

            this.plantCode = CModule.GetAppSetting("Site", "10");

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600Y", new object[] { "", "Y", "" });

        }

        private void POP_WM0520_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(this.grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "지시번호", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "지시일자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "지시품목 ", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "지시품목명 ", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "지시량", true, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            //_GridUtil.InitColumnUltraGrid(grid1, "UNITCODE ", "단위", true, GridColDataType_emu.VarChar,  80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정(작업그룹)", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인(작업소그룹)", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            //_GridUtil.InitColumnUltraGrid(grid1, "ORDERSTATUS", "지시상태", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "ORDERTYPE", "지시유형", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "PLANNO", "생산계획번호 ", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "PRODQTY       ", "생산보고수량 ", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "SEQNO         ", "작업순서 ", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "DAYNIGHT      ", "주야구분", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "CAVITY        ", "동시생산갯수", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "ORDERFIX      ", "지시 확정여부", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "REMARK        ", "비고(특기사항)", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE      ", "등록일시", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "MAKER         ", "등록자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "EDITDATE      ", "수정일시", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "EDITOR        ", "수정자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "GROUPKEY      ", "L/R생산시 사용", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode"); //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");


            //공장 콤보박스 기본 value 설정
            cboPlantCode_H.Value = this.plantCode;

            //조회
            search();

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            search();
        }
        private void search()
        {
            if (!CheckData())
            {
                return;
            }

            DBHelper helper = new DBHelper(false);
            try
            {
                string PLANTCODE = Convert.ToString(cboPlantCode_H.Value);                  // 공장코드     
                string ORDERNO = txtOrderNo.Text.Trim();                                  // 지시번호  
                string STARTDATE = string.Format("{0:yyyy-MM-dd}", cboStartDate_H.Value);   // 지시일자 FROM
                string ENDDATE = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);     // 지시일자 TO   
                string ITEMCODE = this.txtItemCode.Text.Trim();                             // 품목코드  
                string ITEMNAME = this.txtItemName.Text.Trim();                             // 품목명
                string WORKCENTERCODE = this.txtWorkCenterCode.Text.Trim();                 // 작업장
                string WORKCENTERNAME = this.txtWorkCenterName.Text.Trim();                 // 작업장명  

                rtnDtTemp = helper.FillTable("USP_POP_WM0520_S1", CommandType.StoredProcedure
                                                                 , helper.CreateParameter("PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input) // 사업장 공장코드    
                                                                 , helper.CreateParameter("STARTDATE", STARTDATE, DbType.String, ParameterDirection.Input) // 일자 FROM          
                                                                 , helper.CreateParameter("ENDDATE", ENDDATE, DbType.String, ParameterDirection.Input)     // 일자 TO            
                                                                 , helper.CreateParameter("ORDERNO", ORDERNO, DbType.String, ParameterDirection.Input)   // 발주번호   
                                                                 , helper.CreateParameter("ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                                                                 , helper.CreateParameter("ITEMNAME", ITEMNAME, DbType.String, ParameterDirection.Input)
                                                                 , helper.CreateParameter("WORKCENTERCODE", WORKCENTERCODE, DbType.String, ParameterDirection.Input)
                                                                 , helper.CreateParameter("WORKCENTERNAME", WORKCENTERNAME, DbType.String, ParameterDirection.Input)
                                                                  );
                this.ClosePrgFormNew();
                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                }
            }
            catch (Exception ex)
            {
                //  this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cboStartDate_H.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cboEndDate_H.Value));
            if (sSrart > sEnd)
            {
                //this.ShowDialog("조회 시작일자가 종료일자보다 큽니다.", Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }

        private void grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            //DataTable TmpDt = new DataTable();
            //TmpDt.Columns.Add("WorkerID", typeof(string));
            //TmpDt.Columns.Add("WorkerName", typeof(string));
            //TmpDt.Columns.Add("OPCode", typeof(string));
            //TmpDt.Columns.Add("LineCode", typeof(string));
            //TmpDt.Columns.Add("WorkCenterCode", typeof(string));

            //TmpDt.Rows.Add(new object[] { e.Row.Cells["WorkerID"].Value, e.Row.Cells["WorkerName"].Value
            //    , e.Row.Cells["OPCode"].Value, e.Row.Cells["LineCode"].Value, e.Row.Cells["WorkCenterCode"].Value });

            //팝업의 공장, 작업지시, 품목, 작업장, 단위 정보를 가져오기
            string TmpDt = e.Row.Cells["PLANTCODE"].Value.ToString() + "," + e.Row.Cells["ORDERNO"].Value.ToString() + "," + e.Row.Cells["ITEMCODE"].Value.ToString() + "," + e.Row.Cells["WORKCENTERCODE"].Value.ToString() + "," + e.Row.Cells["UNITCODE"].Value.ToString();

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

    }
}
