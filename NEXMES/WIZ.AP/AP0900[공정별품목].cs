#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  AP0900
//   Form Name    : 월별 품목별 공장별 작업지시 추이 정보 조회
//   Name Space   : WIZ.AP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.AP
{
    public partial class AP0900 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        #endregion

        #region<CONSTRUCTOR>
        public AP0900()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();

            string sUseFlag = string.Empty;
            string sLineCode = string.Empty;
            string sOPCode = string.Empty;

            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, sUseFlag });
        }
        #endregion

        #region AP0900_Load
        private void AP0900_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);//90 95 160 120 200 76 69 75 50 58 59 100 100 100 100 100 100 100                                                    
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
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


            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");  // 사용유무, , MES적용유무

            WIZ.Common.FillComboboxMaster(this.cboYesNo, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            #endregion

            this.ultraChart1.EmptyChartText = string.Empty;
        }
        #endregion AP0900_Load

        #region 조회
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = cboPlantCode_H.Value.ToString();             // 사업장(공장)
                string SYyyy = string.Format("{0:yyyy}", cboYear_H.Value);       // 년도
                string sOPCode = this.txtOPCode.Text.Trim();                     // 공정 코드
                string sItemCode = this.txtItemCode.Text.Trim();                 // 품목

                grid1.DataSource = helper.FillTable("USP_AP0900_S1N"
                                             , CommandType.StoredProcedure
                                             , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)             // 사업장(공장)    
                                             , helper.CreateParameter("Yyyy", SYyyy, DbType.String, ParameterDirection.Input)                       // 년도 
                                             , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)                   // 공정 코드       
                                             , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input));             // 품목   


                grid1.DataBinds();


                if (rtnDtTemp.Rows.Count > 0)
                {
                    ultraChart1.Series.Clear();
                    //----------------------------
                    DataTable dt = new DataTable();

                    dt.Columns.Add("ItemName", typeof(System.String));
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
                            rtnDtTemp.Rows[i]["ItemName"].ToString(),
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
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion 조회

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의
        #endregion
    }
}
