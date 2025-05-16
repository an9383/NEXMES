#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                  
//   Form ID      : BM6800                                                                                                                                                                   
//   Form Name    : 근무형태코드관리                                                                                                                                                                      
//   Name Space   : WIZ.BM                                                                                                                                                                   
//   Created Date :                                                                                                                                                                     
//   Made By      : WIZCORE                                                                                                                                              
//   Description  : 근무형태코드 등록 관리                                                                                                                                                                
// *---------------------------------------------------------------------------------------------*                                                                                                  
#endregion

using System;
using System.Data;
using System.Windows.Forms;

using WIZ.PopUp;



namespace WIZ.BM
{
    public partial class BM6800 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        // 변수나 Form에서 사용될 Class를 정의
        DataSet rtnDsTemp = new DataSet(); // return DataSet 공통
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        DataTable DtChange = new DataTable();
        #endregion

        #region < CONSTRUCTOR >
        public BM6800()
        {
            InitializeComponent();

            //this.KeyPreview = true;
            //this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Event);
        }
        #endregion

        #region < FORM LOAD >
        private void BM6800_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "WRKTYPECODE", "근무형태코드", true, GridColDataType_emu.VarChar, 130, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "WRKSTIME", "시작시간", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "WrkETime", "종료시간", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "WrkHours", "작업시간", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop1STime", "계획정지 시작 #1", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop1ETime", "계획정지 종료 #1", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop1Hours", "계획정지 시간 #1", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop2STime", "계획정지 시작 #2", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop2ETime", "계획정지 종료 #2", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop2Hours", "계획정지 시간 #2", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop3STime", "계획정지 시작 #3", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop3ETime", "계획정지 종료 #3", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop3Hours", "계획정지 시간 #3", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop4STime", "계획정지 시작 #4", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop4ETime", "계획정지 종료 #4", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop4Hours", "계획정지 시간 #4", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop5STime", "계획정지 시작 #5", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop5ETime", "계획정지 종료 #5", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop5Hours", "계획정지 시간 #5", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop6STime", "계획정지 시작 #6", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop6ETime", "계획정지 종료 #6", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop6Hours", "계획정지 시간 #6", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop7STime", "계획정지 시작 #7", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop7ETime", "계획정지 종료 #7", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop7Hours", "계획정지 시간 #7", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop8STime", "계획정지 시작 #8", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop8ETime", "계획정지 종료 #8", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop8Hours", "계획정지 시간 #8", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop9STime", "계획정지 시작 #9", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop9ETime", "계획정지 종료 #9", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Stop9Hours", "계획정지 시간 #9", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "OtSTime", "잔업 시작 시간", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "OtETime", "잔업 종료 시간", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "OtHours", "잔업 시간", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "비고", true, GridColDataType_emu.VarChar, 200, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "생성일시", true, GridColDataType_emu.DateTime24, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "생성자", true, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일시", true, GridColDataType_emu.DateTime24, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TotalSTime", "전체작업\r\n시작시간", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TotalETime", "전체작업\r\n종료시간", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TotalHours", "전체\r\n작업시간", true, GridColDataType_emu.Integer, 80, true, true);

            _GridUtil.SetInitUltraGridBind(grid1);


            _GridUtil.SetColumnTextHAlign(grid1, "WRKTYPECODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "Remark", Infragistics.Win.HAlign.Left);

            _GridUtil.SetColumnTextHAlign(grid1, "WrkHours", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "Stop1Hours", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "Stop2Hours", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "Stop3Hours", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "Stop4Hours", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "Stop5Hours", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "Stop6Hours", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "Stop7Hours", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "Stop8Hours", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "Stop9Hours", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "OtHours", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "TotalHours", Infragistics.Win.HAlign.Right);

            #endregion

            #region < COMBOBOX SETTING >
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT");  //주야구분                                                                                                                              
            WIZ.Common.FillComboboxMaster(this.cboDayNight_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("WRKTYPECODE");        //근무형태코드                                                                                                                                                                                 
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WRKTYPECODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            DtChange = (DataTable)grid1.DataSource;
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            this.DataSelect();

        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {


                int iRow = grid1.InsertRow();
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WrkTypeCode", iRow);        //	근무형태코드
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WrkSTime", iRow);        //	작업시작시간
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WrkETime", iRow);        //	작업종료시간
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WrkHours", iRow);        //	작업시간
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop1STime", iRow);        //	계획정지 시작 #1
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop1ETime", iRow);        //	계획정지 종료 #1
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop1Hours", iRow);        //	계획정지 시간 #1
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop2STime", iRow);        //	계획정지 시작 #2
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop2ETime", iRow);        //	계획정지 종료 #2
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop2Hours", iRow);        //	계획정지 시간 #2
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop3STime", iRow);        //	계획정지 시작 #3
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop3ETime", iRow);        //	계획정지 종료 #3
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop3Hours", iRow);        //	계획정지 시간 #3
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop4STime", iRow);        //	계획정지 시작 #4
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop4ETime", iRow);        //	계획정지 종료 #4
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop4Hours", iRow);        //	계획정지 시간 #4
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop5STime", iRow);        //	계획정지 시작 #5
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop5ETime", iRow);        //	계획정지 종료 #5
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop5Hours", iRow);        //	계획정지 시간 #5
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop6STime", iRow);        //	계획정지 시작 #6
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop6ETime", iRow);        //	계획정지 종료 #6
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop6Hours", iRow);        //	계획정지 시간 #6
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop7STime", iRow);        //	계획정지 시작 #7
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop7ETime", iRow);        //	계획정지 종료 #7
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop7Hours", iRow);        //	계획정지 시간 #7
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop8STime", iRow);        //	계획정지 시작 #8
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop8ETime", iRow);        //	계획정지 종료 #8
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop8Hours", iRow);        //	계획정지 시간 #8
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop9STime", iRow);        //	계획정지 시작 #9
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop9ETime", iRow);        //	계획정지 종료 #9
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Stop9Hours", iRow);        //	계획정지 시간 #9
                UltraGridUtil.ActivationAllowEdit(this.grid1, "OtSTime", iRow);        //	        특근 시작 시간
                UltraGridUtil.ActivationAllowEdit(this.grid1, "OtETime", iRow);        //  	특근 종료 시간
                UltraGridUtil.ActivationAllowEdit(this.grid1, "OtHours", iRow);        //	        특근 시간
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Remark", iRow);        //	        비고
                UltraGridUtil.ActivationAllowEdit(this.grid1, "TotalSTime", iRow);        //	전체작업시작시간
                UltraGridUtil.ActivationAllowEdit(this.grid1, "TotalETime", iRow);        //	전체작업종료시간
                UltraGridUtil.ActivationAllowEdit(this.grid1, "TotalHours", iRow);        //	전체작업시간


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

            this.grid1.DeleteRow();
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
                    return;

                UltraGridUtil.DataRowDelete(this.grid1);
                this.grid1.UpdateData();
                // helper.Transaction  =  helper._sConn.BeginTransaction();
                foreach (DataRow drRow in ((DataTable)grid1.DataSource).GetChanges().Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("USP_BM6800_D1", CommandType.StoredProcedure
                            , helper.CreateParameter("PlantCode", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)         // 공장코드
                            , helper.CreateParameter("WRKTYPECODE", drRow["WRKTYPECODE"].ToString(), DbType.String, ParameterDirection.Input));           // 검사항목코드

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM6800_I1", CommandType.StoredProcedure
                            , helper.CreateParameter("PlantCode", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)         // 공장코드
                            , helper.CreateParameter("WrkTypeCode", drRow["WrkTypeCode"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("WrkSTime", drRow["WrkSTime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["WrkSTime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("WrkETime", drRow["WrkSTime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["WrkETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("WrkHours", drRow["WrkHours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop1STime", drRow["Stop1STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop1STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop1ETime", drRow["Stop1ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop1ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop1Hours", drRow["Stop1Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop2STime", drRow["Stop2STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop2STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop2ETime", drRow["Stop2ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop2ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop2Hours", drRow["Stop2Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop3STime", drRow["Stop3STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop3STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop3ETime", drRow["Stop3ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop3ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop3Hours", drRow["Stop3Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop4STime", drRow["Stop4STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop4STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop4ETime", drRow["Stop4ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop4ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop4Hours", drRow["Stop4Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop5STime", drRow["Stop5STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop5STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop5ETime", drRow["Stop5ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop5ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop5Hours", drRow["Stop5Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop6STime", drRow["Stop6STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop6STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop6ETime", drRow["Stop6ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop6ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop6Hours", drRow["Stop6Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop7STime", drRow["Stop7STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop7STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop7ETime", drRow["Stop7ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop7ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop7Hours", drRow["Stop7Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop8STime", drRow["Stop8STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop8STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop8ETime", drRow["Stop8ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop8ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop8Hours", drRow["Stop8Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop9STime", drRow["Stop9STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop9STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop9ETime", drRow["Stop9ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop9ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop9Hours", drRow["Stop9Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("OtSTime", drRow["OtSTime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["OtSTime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("OtETime", drRow["OtETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["OtETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("OtHours", drRow["OtHours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("TotalSTime", drRow["TotalSTime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["TotalSTime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("TotalETime", drRow["TotalETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["TotalETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("TotalHours", drRow["TotalHours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Remark", drRow["Remark"].ToString(), DbType.String, ParameterDirection.Input)

                            , helper.CreateParameter("Maker", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:

                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM6800_U1", CommandType.StoredProcedure
                            , helper.CreateParameter("PlantCode", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)         // 공장코드
                            , helper.CreateParameter("WrkTypeCode", drRow["WrkTypeCode"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("WrkSTime", drRow["WrkSTime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["WrkSTime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("WrkETime", drRow["WrkSTime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["WrkETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("WrkHours", drRow["WrkHours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop1STime", drRow["Stop1STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop1STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop1ETime", drRow["Stop1ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop1ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop1Hours", drRow["Stop1Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop2STime", drRow["Stop2STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop2STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop2ETime", drRow["Stop2ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop2ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop2Hours", drRow["Stop2Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop3STime", drRow["Stop3STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop3STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop3ETime", drRow["Stop3ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop3ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop3Hours", drRow["Stop3Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop4STime", drRow["Stop4STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop4STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop4ETime", drRow["Stop4ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop4ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop4Hours", drRow["Stop4Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop5STime", drRow["Stop5STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop5STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop5ETime", drRow["Stop5ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop5ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop5Hours", drRow["Stop5Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop6STime", drRow["Stop6STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop6STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop6ETime", drRow["Stop6ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop6ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop6Hours", drRow["Stop6Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop7STime", drRow["Stop7STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop7STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop7ETime", drRow["Stop7ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop7ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop7Hours", drRow["Stop7Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop8STime", drRow["Stop8STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop8STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop8ETime", drRow["Stop8ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop8ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop8Hours", drRow["Stop8Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop9STime", drRow["Stop9STime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop9STime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop9ETime", drRow["Stop9ETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["Stop9ETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Stop9Hours", drRow["Stop9Hours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("OtSTime", drRow["OtSTime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["OtSTime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("OtETime", drRow["OtETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["OtETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("OtHours", drRow["OtHours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("TotalSTime", drRow["TotalSTime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["TotalSTime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("TotalETime", drRow["TotalETime"].ToString() == "" ? "" : Convert.ToDateTime(drRow["TotalETime"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("TotalHours", drRow["TotalHours"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Remark", drRow["Remark"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Editor", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            #endregion

                            break;
                    }
                }

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
                this.ClosePrgFormNew();
                base.DoInquire();
            }
        }
        #endregion

        #region < 조회 기능 >

        //private void KeyPress_Event(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        this.DataSelect();
        //        e.Handled = true;
        //    }
        //}


        private void DataSelect()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DtChange.Clear();
                _GridUtil.Grid_Clear(grid1);



                this.ShowProgressForm("C00004");

                string sPlantCode = LoginInfo.PlantCode;
                string sDayNight = this.cboDayNight_H.Value.ToString();


                rtnDtTemp = helper.FillTable("USP_BM6800_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("DAYNIGHT", sDayNight, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        DtChange = rtnDtTemp;
                        grid1.DataSource = DtChange;
                        grid1.DataBinds();
                        //this.grid1.DisplayLayout.Bands[0].PerformAutoResizeColumns(true, PerformAutoSizeType.AllRowsInBand);
                    }
                    else
                    {
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                helper.Rollback();
            }
            finally
            {
                this.ClosePrgForm();
                base.DoInquire();
                helper.Close();
            }
        }

        #endregion
    }
}
