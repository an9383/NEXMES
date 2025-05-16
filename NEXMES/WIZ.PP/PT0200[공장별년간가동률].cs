#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PT0200
//   Form Name    : 작업장별 월 생산 추이 정보 조회
//   Name Space   : WIZ.PP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : PP4500 품목별 월 생산 추이 정보 화면을 이용 작업장별로 조회하는 화면 추가
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PT0200 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        PopUp_Biz _biz = new PopUp_Biz();//비지니스 로직 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public PT0200()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PT0200_Load(object sender, EventArgs e)
        {
            #region [ Grid 세팅 ]
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P01", "가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M01", "비가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M01RATE", "가동률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P02", "가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M02", "비가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M02RATE", "가동률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P03", "가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M03", "비가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M03RATE", "가동률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P04", "가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M04", "비가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M04RATE", "가동률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P05", "가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M05", "비가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M05RATE", "가동률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P06", "가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M06", "비가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M06RATE", "가동률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P07", "가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M07", "비가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M07RATE", "가동률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P08", "가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M08", "비가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M08RATE", "가동률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P09", "가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M09", "비가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M09RATE", "가동률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P10", "가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M10", "비가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M10RATE", "가동률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P11", "가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M11", "비가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M11RATE", "가동률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P12", "가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M12", "비가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M12RATE", "가동률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);


            string[] sMergeColumn = { "PlantCode" };
            string[] sMergeColumn1 = { "P01", "M01", "M01RATE" };
            string[] sMergeColumn2 = { "P02", "M02", "M02RATE" };
            string[] sMergeColumn3 = { "P03", "M03", "M03RATE" };
            string[] sMergeColumn4 = { "P04", "M04", "M04RATE" };
            string[] sMergeColumn5 = { "P05", "M05", "M05RATE" };
            string[] sMergeColumn6 = { "P06", "M06", "M06RATE" };
            string[] sMergeColumn7 = { "P07", "M07", "M07RATE" };
            string[] sMergeColumn8 = { "P08", "M08", "M08RATE" };
            string[] sMergeColumn9 = { "P09", "M09", "M09RATE" };
            string[] sMergeColumn10 = { "P10", "M10", "M10RATE" };
            string[] sMergeColumn11 = { "P11", "M11", "M11RATE" };
            string[] sMergeColumn12 = { "P12", "M12", "M12RATE" };

            string[] sHeadColumn = {"PlantCode", "P01","M01","M01RATE", "P02", "M02", "M02RATE", "P03", "M03", "M03RATE",
            "P04","M04", "M04RATE", "P05", "M05", "M05RATE", "P06", "M06", "M06RATE", "P07", "M07", "M07RATE",
            "P08", "M08","M08RATE", "P09", "M09", "M09RATE", "P10", "M10", "M10RATE", "P11", "M11", "M11RATE",
            "P12", "M12","M12RATE"};

            // Grid Merge
            _GridUtil.GridHeaderMerge(grid1, "G1", "1월", sMergeColumn1, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G2", "2월", sMergeColumn2, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G3", "3월", sMergeColumn3, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G4", "4월", sMergeColumn4, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G5", "5월", sMergeColumn5, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G6", "6월", sMergeColumn6, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G7", "7월", sMergeColumn7, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G8", "8월", sMergeColumn8, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G9", "9월", sMergeColumn9, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G10", "10월", sMergeColumn10, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G11", "11월", sMergeColumn11, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G12", "12월", sMergeColumn12, sHeadColumn);

            _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 0, 0);
            #endregion

            #region [ 콤보박스 세팅 ]

            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DeptCode", @"RELCODE1 IS NOT NULL ");  //팀구분
            WIZ.Common.FillComboboxMaster(this.cboDeptCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DeptCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            this.ultraChart1.EmptyChartText = string.Empty;
        }
        #endregion

        #region < TOOL BAR AREA >

        public override void DoInquire()
        {

            DBHelper helper = new DBHelper(false);
            try
            {


                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);             // 사업장(공장)
                string SYyyy = Convert.ToDateTime(this.cboYear_H.Value).ToString("yyyy"); // 년도
                string sOPCode = this.txtOPCode.Text.Trim();                              // 공정 코드
                string sItemCode1 = this.txtItemCode1.Text.Trim();                        // 품목
                string sDeptCode = DBHelper.nvlString(cboDeptCode.Value, "");             //팀구분

                rtnDtTemp = helper.FillTable("USP_PT0200_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("Yyyy", SYyyy, DbType.String, ParameterDirection.Input));
                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();



                if (rtnDtTemp.Rows.Count > 0)
                {
                    ultraChart1.Series.Clear();
                    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    DataTable dt = new DataTable();

                    dt.Columns.Add("PlantCode", typeof(System.String));
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
                            ((DataTable)grid1.DataSource).Rows[i]["PLANTCODE"].ToString(),
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
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region < METHOD AREA >

        #region [ 화면에 보이지 않게 해놓은 이유, 사용하지 않다면 삭제 필요 ]

        // Form에서 사용할 함수나 메소드를 정의
        #region --- 텍스트 박스에서 팝업창에서 값 가져오기
        private void Search_Pop_Item(TextBox ItemCode, TextBox ItemName)
        {
            //임시로 사용할 데이터테이블 생성
            DataTable _DtTemp = new DataTable();
            string sitem_cd = ItemCode.Text.Trim();    // 품목
            string sitem_name = ItemName.Text.Trim();  // 품목명
            string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value.ToString());
            // string splantcd = "820";
            string sitemtype = "";


            try
            {

                //_DtTemp = _biz.SEL_BM0010(sPlantCode, sitem_cd, sitem_name, sitemtype,"");

                if (_DtTemp.Rows.Count > 1)
                {
                    // 품목 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    _DtTemp = pu.OpenPopUp("Item", new string[] { sPlantCode, sitemtype, sitem_cd, sitem_name }); // 품목 조회 POP-UP창 Parameter(비가동코드, 비가동명, 비가동그룹)

                    if (_DtTemp != null && _DtTemp.Rows.Count > 0)
                    {
                        ItemCode.Text = Convert.ToString(_DtTemp.Rows[0]["ItemCode"]);
                        ItemName.Text = Convert.ToString(_DtTemp.Rows[0]["Itemname"]);
                    }
                }
                else
                {
                    if (_DtTemp.Rows.Count == 1)
                    {
                        ItemCode.Text = Convert.ToString(_DtTemp.Rows[0]["ItemCode"]);
                        ItemName.Text = Convert.ToString(_DtTemp.Rows[0]["Itemname"]);
                    }
                    else
                    {
                        MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                        ItemCode.Text = string.Empty;
                        ItemName.Text = string.Empty;
                    }

                }
            }
            catch (Exception ex)
            {
                this.ShowDialog("ERROR" + ex.ToString());
            }

        }

        private void Search_Pop_TBM0400()
        {
            string sPlantCode = string.Empty;             //사업장코드
            string sOPCode = txtOPCode.Text.Trim();       //공정코드
            string sOPName = txtOPName.Text.Trim();       //공정명 
            string sUseFlag = string.Empty;               //사용여부         

            if (this.cboPlantCode_H.Value != null)
                sPlantCode = cboPlantCode_H.Value.ToString() == "ALL" ? "" : cboPlantCode_H.Value.ToString();         ///사업장코드 

            //            if (this.cboUseFlag_H.Value != null)
            //                sUseFlag = cboUseFlag_H.Value.ToString() == "ALL" ? "" : cboUseFlag_H.Value.ToString();                 // 사용여부

            sUseFlag = "";                 // 사용여부

            try
            {
                _biz.BM0040_POP(sPlantCode, sOPCode, sOPName, sUseFlag, "", txtOPName, "");

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }
        } //공정(작업장)
        #endregion
        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            string ControlIdx = ((TextBox)sender).Name.Substring(((TextBox)sender).Name.Length - 1, 1);
            gbxHeader.Controls["txtItemName" + ControlIdx].Text = string.Empty;
        }

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TextBox ItemCode = ((TextBox)sender);
                TextBox ItemName = (TextBox)gbxHeader.Controls["txtItemName" + ItemCode.Name.Substring(ItemCode.Name.Length - 1, 1)];
                Search_Pop_Item(ItemCode, ItemName);
            }
        }

        private void txtItemCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextBox ItemCode = ((TextBox)sender);
            TextBox ItemName = (TextBox)gbxHeader.Controls["txtItemName" + ItemCode.Name.Substring(ItemCode.Name.Length - 1, 1)];
            Search_Pop_Item(ItemCode, ItemName);
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            string ControlIdx = ((TextBox)sender).Name.Substring(((TextBox)sender).Name.Length - 1, 1);
            gbxHeader.Controls["txtItemCode" + ControlIdx].Text = string.Empty;
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TextBox ItemName = ((TextBox)sender);
                TextBox ItemCode = (TextBox)gbxHeader.Controls["txtItemCode" + ItemName.Name.Substring(ItemName.Name.Length - 1, 1)];
                Search_Pop_Item(ItemCode, ItemName);
            }
        }

        private void txtItemName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextBox ItemName = ((TextBox)sender);
            TextBox ItemCode = (TextBox)gbxHeader.Controls["txtItemCode" + ItemName.Name.Substring(ItemName.Name.Length - 1, 1)];
            Search_Pop_Item(ItemCode, ItemName);
        }

        private void txtOPCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtOPName.Text = string.Empty;
        }

        private void txtOPNAME_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtOPCode.Text = string.Empty;
        }

        private void txtOPCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0400();
            }
        }

        private void txtOPName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0400();
            }

        }

        private void txtOPCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0400();
        }

        private void txtOPName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0400();
        }
        #endregion

        #endregion
    }
}
