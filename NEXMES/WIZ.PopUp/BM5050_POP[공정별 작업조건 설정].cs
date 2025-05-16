#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0000_POP
//   Form Name    : 자재 가입고 처리
//   Name Space   : WIZ.POPUP
//   Created Date : 2018-03-21
//   Made By      : WIZCORE 남부사무소 사원 윤근욱
//   Description  : MM0000에서 가입고 버튼 Click시 POPUP 호출
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >

using System;
using System.Data;
using System.Windows.Forms;


#endregion

namespace WIZ.PopUp
{
    public partial class BM5050_POP : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >
        private string sPlantCode1 = string.Empty;                  //사업장1
        private string sItemCode1 = string.Empty;                   //품목1
        private string sItemName1 = string.Empty;                   //품명1
        private string sOpCode1 = string.Empty;                     //공정1
        private string sPlantCode2 = string.Empty;                  //사업장2
        private string sItemCode2 = string.Empty;                   //품목2
        private string sItemName2 = string.Empty;                   //품명2
        private string sOpCode2 = string.Empty;                     //공정2

        private string itemcode = string.Empty;                     //선택한 품목
        private string itemname = string.Empty;                     //선택한 품명
        private string opcode = string.Empty;                       //선택한 공정

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자

        Common _Common = new Common();
        DataTable rtnDtTemp = new DataTable();

        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();

        #endregion

        #region < CONSTRUCTOR >
        public BM5050_POP(string itemcode, string itemname, string opcode)
        {
            InitializeComponent();

            this.itemcode = itemcode;
            this.itemname = itemname;
            this.opcode = opcode;
        }

        #endregion

        #region < METHOD AREA >

        private string CallDB(string ptype)
        {
            try
            {
                sPlantCode1 = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                sItemCode1 = DBHelper.nvlString(txt_ITEMCODE_H.Value);
                sItemName1 = DBHelper.nvlString(txt_ITEMNAME_H.Value);
                sOpCode1 = DBHelper.nvlString(cbo_OPCODE_H.Value);

                sPlantCode2 = DBHelper.nvlString(cbo_PLANTCODE_D.Value);
                sItemCode2 = DBHelper.nvlString(txt_ITEMCODE_D.Value);
                sItemName2 = DBHelper.nvlString(txt_ITEMNAME_D.Value);
                sOpCode2 = DBHelper.nvlString(cbo_OPCODE_D.Value);

                if (ptype != "S2")
                {
                    if (sPlantCode1 == "")
                    {
                        return "플랜트를 선택해주세요.";
                    }
                    else if (sItemCode1 == "")
                    {
                        return "품목을 선택해주세요.";
                    }
                    else if (sOpCode1 == "")
                    {
                        return "공정을 선택해주세요.";
                    }
                }
                if (ptype != "S1")
                {
                    if (sPlantCode2 == "")
                    {
                        return "플랜트를 선택해주세요.";
                    }
                    else if (sItemCode2 == "")
                    {
                        return "품목을 선택해주세요.";
                    }
                    else if (sOpCode2 == "")
                    {
                        return "공정을 선택해주세요.";
                    }
                }

                DBHelper helper = new DBHelper(false);

                rtnDtTemp = helper.FillTable("USP_POP_BM5050_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PTYPE", ptype, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PLANTCODE1", sPlantCode1, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMCODE1", sItemCode1, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMNAME1", sItemName1, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPCODE1", sOpCode1, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PLANTCODE2", sPlantCode2, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMCODE2", sItemCode2, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMNAME2", sItemName2, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPCODE2", sOpCode2, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input));
                if (ptype == "S1" || ptype == "S2")
                {
                    string cnt = rtnDtTemp.Rows[0]["METHOD_CNT"].ToString();
                    return cnt;
                }
                else
                {
                    string msg = rtnDtTemp.Rows[0]["MSG"].ToString();
                    return msg;
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                return ex.Message;
            }
        }

        #endregion

        #region < EVENT AREA >

        private void BM5050_POP_Load(object sender, EventArgs e)
        {
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_D, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            cbo_PLANTCODE_D.Value = WIZ.LoginInfo.PlantCode;

            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });
            txt_ITEMCODE_H.Value = itemcode;
            txt_ITEMNAME_H.Value = itemname;

            btbManager.PopUpAdd(txt_ITEMCODE_D, txt_ITEMNAME_D, "BM0010", new object[] { cbo_PLANTCODE_D, "", "Y" });

            rtnDtTemp = _Common.GET_BM0040_CODE("");
            WIZ.Common.FillComboboxMaster(this.cbo_OPCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            cbo_OPCODE_H.Value = opcode;

            rtnDtTemp = _Common.GET_BM0040_CODE("");
            WIZ.Common.FillComboboxMaster(this.cbo_OPCODE_D, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);

            PopUp_Common.SetLink(this, this.cbo_OPCODE_H, new System.Windows.Forms.Control[] { this.cbo_PLANTCODE_H, this.txt_ITEMCODE_H }, "TEST03");
        }

        private void btn_SEARCH_H_Click(object sender, EventArgs e)
        {
            string result = CallDB("S1");
            int num;
            if (int.TryParse(result, out num))
            {
                string msg = num + "건 존재합니다.";
                lbl_MSG_H.Text = msg;
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btn_SEARCH_D_Click(object sender, EventArgs e)
        {
            string result = CallDB("S2");
            int num;
            if (int.TryParse(result, out num))
            {
                string msg = num + "건 존재합니다.";
                lbl_MSG_D.Text = msg;
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btn_COPY_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("복사하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string msg = CallDB("S3");
                MessageBox.Show(msg);
            }
        }

        private void btn_COVER_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("덮어쓰시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string msg = CallDB("S4");
                MessageBox.Show(msg);
            }
        }

        #endregion
    }
}
