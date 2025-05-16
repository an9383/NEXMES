#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : QM4000
//   Form Name    : 종합(자주,수입,출하,초중종)검사실적조회
//   Name Space   : WIZ.BM
//   Created Date : 2020-03-30
//   Made By      : YSH
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.QM
{
    public partial class QM4000 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common(); //콤보박스 객체 생성
        BizTextBoxManager btbManager = new BizTextBoxManager();
        DBHelper helper = new DBHelper(false);

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자

        string sPlantCode = "";
        string sStartDate = "";
        string sEndDate = "";
        string sItemCode = "";

        #endregion

        #region < CONSTRUCTOR >
        public QM4000()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void QM0030_Load(object sender, EventArgs e)
        {
            #region GRID
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 0, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장",       false, GridColDataType_emu.VarChar,   90, 100, Infragistics.Win.HAlign.Center, true,  false);
            //_GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명",     false, GridColDataType_emu.VarChar,  150, 100, Infragistics.Win.HAlign.Left,   true,  false);

            _GridUtil.InitColumnUltraGrid(grid1, "INSPDATE", "검사일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SEQNO", "차수", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE", "검사항목", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME", "검사항목명", false, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.InitColumnUltraGrid(grid1, "SPECLSL", "하한값", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECNOL", "기준값", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECUSL", "상한값", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);

            _GridUtil.InitColumnUltraGrid(grid1, "INSPVALUE", "검사값", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULT", "검사결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTINSPRESULT", "검사결과", false, GridColDataType_emu.VarChar, 0, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일자", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일자", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);
            grid1.Columns["SPECLSL"].Format = "#,##0.##"; // 하한
            grid1.Columns["SPECNOL"].Format = "#,##0.##"; // 기준
            grid1.Columns["SPECUSL"].Format = "#,##0.##"; // 상한
            grid1.Columns["INSPVALUE"].Format = "#,##0.##";// 측정치




            _GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 0, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            //_GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERCODE", "작업장",       false, GridColDataType_emu.VarChar,   90, 100, Infragistics.Win.HAlign.Center, true,  false);
            //_GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERNAME", "작업장명",     false, GridColDataType_emu.VarChar,  150, 100, Infragistics.Win.HAlign.Left,   true,  false);

            _GridUtil.InitColumnUltraGrid(grid2, "INSPDATE", "검사일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "SEQNO", "차수", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE", "검사항목", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPNAME", "검사항목명", false, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.InitColumnUltraGrid(grid2, "SPECLSL", "하한값", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "SPECNOL", "기준값", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "SPECUSL", "상한값", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);

            _GridUtil.InitColumnUltraGrid(grid2, "INSPVALUE", "검사값", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPRESULT", "검사결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "TOTINSPRESULT", "검사결과", false, GridColDataType_emu.VarChar, 0, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", false, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일자", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일자", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid2);

            grid2.Columns["SPECLSL"].Format = "#,##0.##"; // 하한
            grid2.Columns["SPECNOL"].Format = "#,##0.##"; // 기준
            grid2.Columns["SPECUSL"].Format = "#,##0.##"; // 상한
            grid2.Columns["INSPVALUE"].Format = "#,##0.##";// 측정치



            #endregion

            #region COMBOBOX SETTING
            //사업장
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            //검사종류 구분 (수입, 출하, 초중종 ...)
            rtnDtTemp = _Common.GET_BM0000_CODE("INSPECTION");
            WIZ.Common.FillComboboxMaster(this.cbo_INSPTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "INSPECTION", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

            #endregion

            #region POPUP SETTING
            //품목
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" }); ;
            #endregion

            setGridVisible();
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);

            base.DoInquire();

            try
            {
                sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());

                if (DateCheck.CheckDate(sStartDate, sEndDate) == false)
                {
                    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                setGridVisible();

                switch (cbo_INSPTYPE_H.Value)
                {
                    case "INSPEC01": //수입
                        GetINPSPEC01();
                        break;

                    case "INSPEC02": //출하
                        GetINPSPEC02();
                        break;

                    case "INSPEC03": //부적합
                        GetINPSPEC03();
                        break;

                    case "INSPEC04": //불량
                        GetINPSPEC04();
                        break;
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        private void GetINPSPEC01()
        {

            _GridUtil.SetInitUltraGridBind(grid1);

            rtnDtTemp = helper.FillTable("USP_MM0030_S1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LOTNO", "", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INSPRESULT", "", DbType.String, ParameterDirection.Input));

            if (helper.RSCODE == "S")
            {
                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBind();

                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        if (grid1.Rows[i].Cells["INSPRESULT"].Value.ToString() == "NG")
                        {
                            grid1.Rows[i].Cells["INSPRESULT"].Appearance.BackColor = Color.LightPink;
                        }
                        else
                        {
                            grid1.Rows[i].Cells["INSPRESULT"].Appearance.BackColor = Color.DarkCyan;
                            grid1.Rows[i].Cells["INSPRESULT"].Appearance.ForeColor = Color.White;
                        }
                    }

                    grid1.DisplayLayout.Bands[0].Columns["LOTNO"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["LOTNO"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    grid1.DisplayLayout.Bands[0].Columns["LOTNO"].MergedCellAppearance.BorderColor = Color.Black;

                    grid1.DisplayLayout.Bands[0].Columns["INSPDATE"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["INSPDATE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    grid1.DisplayLayout.Bands[0].Columns["INSPDATE"].MergedCellAppearance.BorderColor = Color.Black;

                    grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellAppearance.BorderColor = Color.Black;

                    grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellAppearance.BorderColor = Color.Black;

                    grid1.DisplayLayout.Bands[0].Columns["SEQNO"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["SEQNO"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    grid1.DisplayLayout.Bands[0].Columns["SEQNO"].MergedCellAppearance.BorderColor = Color.Black;

                    grid1.Dock = System.Windows.Forms.DockStyle.Fill;
                    grid1.Visible = true;

                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        grid1.DisplayLayout.Rows[i].Appearance.BorderColor = Color.Black;
                    }

                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    this.ClosePrgForm();
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); // 조회할 데이터가 없습니다.
                    return;
                }
            }

            //string[] arrMerCol1 = { "INSPCODE", "INSPNAME", "INSPRESULT" };
        }
        private void GetINPSPEC02()
        {
            rtnDtTemp = helper.FillTable("USP_WM0030_S1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LOTNO", "", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INSPRESULT", "", DbType.String, ParameterDirection.Input));

            if (rtnDtTemp.Rows.Count > 0)
            {
                grid2.DataSource = rtnDtTemp;
                grid2.DataBinds(rtnDtTemp);

                for (int i = 0; i < grid2.Rows.Count; i++)
                {
                    if (grid2.Rows[i].Cells["INSPRESULT"].Value.ToString() == "NG")
                    {
                        grid2.Rows[i].Cells["INSPRESULT"].Appearance.BackColor = Color.LightPink;
                    }
                    else
                    {
                        grid2.Rows[i].Cells["INSPRESULT"].Appearance.BackColor = Color.DarkCyan;
                        grid2.Rows[i].Cells["INSPRESULT"].Appearance.ForeColor = Color.White;
                    }
                }

                grid2.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                grid2.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                grid2.DisplayLayout.Bands[0].Columns["LOTNO"].MergedCellStyle = MergedCellStyle.Always;
                grid2.DisplayLayout.Bands[0].Columns["LOTNO"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                grid2.DisplayLayout.Bands[0].Columns["INSPDATE"].MergedCellStyle = MergedCellStyle.Always;
                grid2.DisplayLayout.Bands[0].Columns["INSPDATE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                grid2.DisplayLayout.Bands[0].Columns["TOTINSPRESULT"].MergedCellStyle = MergedCellStyle.Always;
                grid2.DisplayLayout.Bands[0].Columns["TOTINSPRESULT"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                grid2.Dock = System.Windows.Forms.DockStyle.Fill;
                grid2.Visible = true;
            }
            else
            {
                _GridUtil.Grid_Clear(grid2);
                ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }



        }
        private void GetINPSPEC03()
        {
        }
        private void GetINPSPEC04()
        {
        }
        private void setGridVisible()
        {
            grid1.Dock = System.Windows.Forms.DockStyle.None;
            grid2.Dock = System.Windows.Forms.DockStyle.None;
            grid3.Dock = System.Windows.Forms.DockStyle.None;
            grid4.Dock = System.Windows.Forms.DockStyle.None;
            grid5.Dock = System.Windows.Forms.DockStyle.None;
            grid6.Dock = System.Windows.Forms.DockStyle.None;

            grid1.Visible = false;
            grid2.Visible = false;
            grid3.Visible = false;
            grid4.Visible = false;
            grid5.Visible = false;
            grid6.Visible = false;
        }
        #endregion < TOOL BAR AREA >

    }
}
