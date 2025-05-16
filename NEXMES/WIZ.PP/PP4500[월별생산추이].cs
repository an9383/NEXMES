#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP4500
//   Form Name    : 품목별 월 생산 추이 정보 조회
//   Name Space   : WIZ.PP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{

    public partial class PP4500 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        public PP4500()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            // 1 : 품목, 2 : 품목명, param[0] : PlantCode, param[1] : ItemType
            btbManager.PopUpAdd(txtItemCode1, txtItemName1, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode2, txtItemName2, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode3, txtItemName3, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode4, txtItemName4, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode5, txtItemName5, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode6, txtItemName6, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode7, txtItemName7, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode8, txtItemName8, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode9, txtItemName9, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode10, txtItemName10, "TBM0100", new object[] { cboPlantCode_H, "" });

            // TBM0400 :공정 
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });

        }
        #endregion

        #region PP4500_Load
        private void PP4500_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1);//90 95 160 120 200 76 69 75 50 58 59 100 100 100 100 100 100 100                                                    
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DeptCode", "팀구분", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "공정", false, GridColDataType_emu.VarChar, 95, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "공정명", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TotQty", "합 계", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M01", "1 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M02", "2 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M03", "3 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M04", "4 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M05", "5 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M06", "6 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M07", "7 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M08", "8 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M09", "9 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M10", "10 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M11", "11 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M12", "12 월", false, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DeptCode");  //팀구분
            WIZ.Common.FillComboboxMaster(this.cboDeptCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DeptCode", rtnDtTemp, "CODE_ID", "CODE_NAME");


            #endregion

            this.ultraChart1.EmptyChartText = string.Empty;
        }
        #endregion PP4500_Load

        #region 조회
        public override void DoInquire()
        {

            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);                                      // 사업장(공장)
                string sYyyy = Convert.ToDateTime(this.cboYear_H.Value).ToString("yyyy");                             // 년도
                string sOPCode = this.txtOPCode.Text.Trim();                                                          // 공정 코드
                string sItemCode1 = this.txtItemCode1.Text.Trim();                                                    // 품목
                string sItemCode2 = this.txtItemCode2.Text.Trim();                                                    // 품목
                string sItemCode3 = this.txtItemCode3.Text.Trim();                                                    // 품목
                string sItemCode4 = this.txtItemCode4.Text.Trim();                                                    // 품목
                string sItemCode5 = this.txtItemCode5.Text.Trim();                                                    // 품목
                string sItemCode6 = this.txtItemCode6.Text.Trim();                                                    // 품목
                string sItemCode7 = this.txtItemCode7.Text.Trim();                                                    // 품목
                string sItemCode8 = this.txtItemCode8.Text.Trim();                                                    // 품목
                string sItemCode9 = this.txtItemCode9.Text.Trim();                                                    // 품목
                string sItemCode10 = this.txtItemCode10.Text.Trim();                                                  // 품목
                //string sDeptCode = DBHelper.nvlString(cboDeptCode.Value, "");     //팀구분
                string sDeptCode = DBHelper.nvlString(this.cboDeptCode.Value, "");     //팀구분

                rtnDtTemp = helper.FillTable("USP_PP4500_S3N", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("Yyyy", sYyyy, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ItemCode1", sItemCode1, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ItemCode2", sItemCode2, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ItemCode3", sItemCode3, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ItemCode4", sItemCode4, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ItemCode5", sItemCode5, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ItemCode6", sItemCode6, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ItemCode7", sItemCode7, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ItemCode8", sItemCode8, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ItemCode9", sItemCode9, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ItemCode10", sItemCode10, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("DeptCode", sDeptCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("Param2", DBNull.Value, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("Param3", DBNull.Value, DbType.String, ParameterDirection.Input));
                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    ultraChart1.Series.Clear();
                    //----------------------------
                    DataTable dt = new DataTable();

                    dt.Columns.Add("ItemCode", typeof(System.String));
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
                            rtnDtTemp.Rows[i]["ItemCode"].ToString(),
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
                throw ex;
            }
            finally
            {
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
