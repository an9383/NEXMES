#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP4600
//   Form Name    : 작업장별 월 생산 추이 정보 조회
//   Name Space   : WIZ.PP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : PP4500 품목별 월 생산 추이 정보 화면을 이용 작업장별로 조회하는 화면 추가
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{

    public partial class PP4600 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER  AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        #endregion

        #region<CONSTRUCTOR>
        public PP4600()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            //    * TBM0100 : 품목
            //*          - 1 : 품목, 2 : 품목명, param[0] : PlantCode, param[1] : ItemType
            btbManager.PopUpAdd(txtItemCode1, txtItemName1, "TBM0100", new object[] { cboPlantCode_H, "" });

            //            * TBM0400 : 공정(작업장) 
            //*          - 1 : OPCode, 2 : OPName, param[0] : PlantCode, param[1] : UseFlag
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });

        }
        #endregion

        #region PP4600_Load
        private void PP4600_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.lblYear);//90 95 160 120 200 76 69 75 50 58 59 100 100 100 100 100 100 100                                                    
            _GridUtil.InitColumnUltraGrid(lblYear, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblYear, "OPCode", "공정", false, GridColDataType_emu.VarChar, 95, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblYear, "OPName", "공정명", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblYear, "TotQty", "합 계", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblYear, "M01", "1 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblYear, "M02", "2 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblYear, "M03", "3 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblYear, "M04", "4 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblYear, "M05", "5 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblYear, "M06", "6 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblYear, "M07", "7 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblYear, "M08", "8 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblYear, "M09", "9 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblYear, "M10", "10 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblYear, "M11", "11 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblYear, "M12", "12 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(lblYear);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.lblYear, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DeptCode");  //팀구분
            //rtnDtTemp = _Common.GET_TBM0000_CODE("DeptCode", @"ISNULL(RELCODE1, '') != '' ");  //팀구분
            WIZ.Common.FillComboboxMaster(this.cboDeptCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.lblYear, "DeptCode", rtnDtTemp, "CODE_ID", "CODE_NAME");


            #endregion

            this.ultraChart1.EmptyChartText = string.Empty;
        }
        #endregion PP4600_Load

        #region 조회
        public override void DoInquire()
        {
            //DBHelper helper = new DBHelper(false);
            //System.Data.Common.DbParameter[] param = new System.Data.Common.DbParameter[7];
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();
                //string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);                                       // 사업장(공장)
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);                                      // 사업장(공장)
                string SYyyy = Convert.ToDateTime(this.cboYear_H.Value).ToString("yyyy");                             // 년도
                string sOPCode = this.txtOPCode.Text.Trim();                                                          // 공정 코드
                string sItemCode1 = this.txtItemCode1.Text.Trim();                                                    // 품목
                //string sDeptCode = DBHelper.nvlString(cboDeptCode.Value, "");                                       //팀구분
                string sDeptCode = DBHelper.nvlString(cboDeptCode.Value, "");                                         //팀구분

                //param[0] = helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input);             // 사업장(공장)    
                //param[1] = helper.CreateParameter("Yyyy", SYyyy, DbType.String, ParameterDirection.Input);                       // 년도 
                //param[2] = helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input);                   // 공정 코드       
                //param[3] = helper.CreateParameter("ItemCode1", sItemCode1, DbType.String, ParameterDirection.Input);             // 품목   
                //param[4] = helper.CreateParameter("Param1", sDeptCode, DbType.String, ParameterDirection.Input);                 // 품목   
                //param[5] = helper.CreateParameter("Param2", DBNull.Value, DbType.String, ParameterDirection.Input);              // 품목   
                //param[6] = helper.CreateParameter("Param3", DBNull.Value, DbType.String, ParameterDirection.Input);              // 품목   


                //rtnDtTemp = helper.FillTable("USP_PP4600_S1N", CommandType.StoredProcedure, param);

                rtnDtTemp = helper.FillTable("USP_PP4600_S1N", CommandType.StoredProcedure
                                                             , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("Yyyy", SYyyy, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("ItemCode1", sItemCode1, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("Param1", sDeptCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("Param2", DBNull.Value, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("Param3", DBNull.Value, DbType.String, ParameterDirection.Input));

                lblYear.DataSource = rtnDtTemp;
                lblYear.DataBinds();
                //_Common.Grid_Column_Width(this.grid1); //grid 정리용   

                if (rtnDtTemp.Rows.Count > 0)
                {
                    ultraChart1.Series.Clear();
                    //----------------------------
                    DataTable dt = new DataTable();

                    dt.Columns.Add("OPCODE", typeof(System.String));
                    dt.Columns.Add("1월", typeof(System.Double));
                    dt.Columns.Add("2월", typeof(System.Double));
                    dt.Columns.Add("3월", typeof(System.Double));
                    dt.Columns.Add("4월", typeof(System.Double));
                    dt.Columns.Add("5월", typeof(System.Double));
                    dt.Columns.Add("6월", typeof(System.Double));
                    dt.Columns.Add("7월", typeof(System.Double));
                    dt.Columns.Add("8월", typeof(System.Double));
                    dt.Columns.Add("9월", typeof(System.Double));
                    dt.Columns.Add("10월", typeof(System.Double));
                    dt.Columns.Add("11월", typeof(System.Double));
                    dt.Columns.Add("12월", typeof(System.String));

                    for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    {
                        dt.Rows.Add(new object[] {
                            rtnDtTemp.Rows[i]["OPCODE"].ToString(),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M01"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M02"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M03"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M04"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M05"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M06"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M07"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M08"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M09"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M10"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M11"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M12"])
                        });
                    }

                    ultraChart1.DataSource = dt;

                    //   ultraChart1.DataSource = rtnDtTemp;
                    /*                  NumericSeries series = new NumericSeries();
                                      series.Data.DataSource = rtnDtTemp;
                                      series.Data.LabelColumn = "ErrorDesc";
                                      series.Data.ValueColumn = "ErrorQty";
                                      series.DataBind();

                                      ultraChart1.Series.Add(series);
                                      ultraChart1.Data.DataBind();
                  */

                }

            }
            catch (Exception ex)
            {
                //this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
                throw ex;
            }
            finally
            {
                //helper.Close();
                //if (param != null) { param = null; }
                helper.Close();
            }
        }
        #endregion 조회

        //#region <METHOD AREA>
        //// Form에서 사용할 함수나 메소드를 정의
        //#region 텍스트 박스에서 팝업창에서 값 가져오기

        //private void Search_Pop_Item(TextBox ItemCode, TextBox ItemName)
        //{
        //    string sitem_cd = ItemCode.Text.Trim();    // 품목
        //    string sitem_name = ItemName.Text.Trim();  // 품목명
        //    string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value.ToString());
        //    // string splantcd = "820";
        //    string sitemtype = "";


        //    try
        //    {

        //        _DtTemp = _biz.SEL_TBM0100(sPlantCode, sitem_cd, sitem_name, sitemtype);

        //        if (_DtTemp.Rows.Count > 1)
        //        {
        //            // 품목 POP-UP 창 처리
        //            PopUpManager pu = new PopUpManager();
        //            _DtTemp = pu.OpenPopUp("Item", new string[] { sPlantCode, sitemtype, sitem_cd, sitem_name }); // 품목 조회 POP-UP창 Parameter(비가동코드, 비가동명, 비가동그룹)

        //            if (_DtTemp != null && _DtTemp.Rows.Count > 0)
        //            {
        //                ItemCode.Text = Convert.ToString(_DtTemp.Rows[0]["ItemCode"]);
        //                ItemName.Text = Convert.ToString(_DtTemp.Rows[0]["Itemname"]);
        //            }
        //        }
        //        else
        //        {
        //            if (_DtTemp.Rows.Count == 1)
        //            {
        //                ItemCode.Text = Convert.ToString(_DtTemp.Rows[0]["ItemCode"]);
        //                ItemName.Text = Convert.ToString(_DtTemp.Rows[0]["Itemname"]);
        //            }
        //            else
        //            {
        //                MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
        //                ItemCode.Text = string.Empty;
        //                ItemName.Text = string.Empty;
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("ERROR", ex.Message);
        //    }

        //}
        //#endregion
        //private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        //{
        //    string ControlIdx = ((TextBox)sender).Name.Substring(((TextBox)sender).Name.Length - 1, 1);
        //    gbxHeader.Controls["txtItemName" + ControlIdx].Text = string.Empty;
        //}

        //private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        TextBox ItemCode = ((TextBox)sender);
        //        TextBox ItemName = (TextBox)gbxHeader.Controls["txtItemName" + ItemCode.Name.Substring(ItemCode.Name.Length - 1, 1)];
        //        Search_Pop_Item(ItemCode, ItemName);
        //    }
        //}

        //private void txtItemCode_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    TextBox ItemCode = ((TextBox)sender);
        //    TextBox ItemName = (TextBox)gbxHeader.Controls["txtItemName" + ItemCode.Name.Substring(ItemCode.Name.Length - 1, 1)];
        //    Search_Pop_Item(ItemCode, ItemName);
        //}

        //private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    string ControlIdx = ((TextBox)sender).Name.Substring(((TextBox)sender).Name.Length - 1, 1);
        //    gbxHeader.Controls["txtItemCode" + ControlIdx].Text = string.Empty;
        //}

        //private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        TextBox ItemName = ((TextBox)sender);
        //        TextBox ItemCode = (TextBox)gbxHeader.Controls["txtItemCode" + ItemName.Name.Substring(ItemName.Name.Length - 1, 1)];
        //        Search_Pop_Item(ItemCode, ItemName);
        //    }
        //}

        //private void txtItemName_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    TextBox ItemName = ((TextBox)sender);
        //    TextBox ItemCode = (TextBox)gbxHeader.Controls["txtItemCode" + ItemName.Name.Substring(ItemName.Name.Length - 1, 1)];
        //    Search_Pop_Item(ItemCode, ItemName);
        //}

        //#region 텍스트 박스에서 팝업창에서 값 가져오기
        ////////////////////     
        //private void Search_Pop_TBM0400()
        //{

        //    string sPlantCode = string.Empty;             //사업장코드
        //    string sOPCode = txtOPCode.Text.Trim();       //공정코드
        //    string sOPName = txtOPName.Text.Trim();       //공정명 
        //    string sUseFlag = string.Empty;               //사용여부         


        //    if (this.cboPlantCode_H.Value != null)
        //        sPlantCode = cboPlantCode_H.Value.ToString() == "ALL" ? "" : cboPlantCode_H.Value.ToString();         ///사업장코드 

        //    //            if (this.cboUseFlag_H.Value != null)
        //    //                sUseFlag = cboUseFlag_H.Value.ToString() == "ALL" ? "" : cboUseFlag_H.Value.ToString();                 // 사용여부

        //    sUseFlag = "";                 // 사용여부

        //    try
        //    {
        //        _biz.TBM0400_POP(sPlantCode, sOPCode, sOPName, sUseFlag, txtOPCode, txtOPName);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("ERROR", ex.Message);
        //    }

        //}
        //#endregion        //공정(작업장)
        //private void txtOPCode_KeyDown(object sender, KeyEventArgs e)
        //{
        //    this.txtOPName.Text = string.Empty;
        //}

        //private void txtOPNAME_KeyDown(object sender, KeyEventArgs e)
        //{
        //    this.txtOPCode.Text = string.Empty;
        //}

        //private void txtOPCode_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        Search_Pop_TBM0400();
        //    }
        //}



        //private void txtOPName_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        Search_Pop_TBM0400();
        //    }

        //}




        //#endregion

        //private void txtOPCode_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    Search_Pop_TBM0400();
        //}

        //private void txtOPName_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    Search_Pop_TBM0400();
        //}
    }
}
