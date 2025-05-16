#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0580
//   Form Name    : 공지사항입력
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-17
//   Made By      : WIZCORE 남부사무소 사원 정길상
//   Edited Date  : 
//   Edit By      :
//   Description  : 공지사항 문구 입력
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.BM
{
    public partial class BM0580 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자

        FontDialog _font = new FontDialog();
        ColorDialog _color = new ColorDialog();

        #endregion

        #region < CONSTRUCTOR >
        public BM0580()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0010_Load(object sender, EventArgs e)
        {
            try
            {
                #region COMBOBOX SETTING
                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                Common.FillComboboxMaster(cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;
                #endregion
            }
            catch (Exception ex)
            {
                //Common.getLangText(해당 텍스트, 팝업창일 경우 "MSG", 나머지는 "TEXT") -> 다국어를 위한 기능이므로 필히 활용바람
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            //_GridUtil.Grid_Clear(grid1); // 조회 전 그리드 초기화

            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);

                if (ultraTabControl1.SelectedTab.Index == 0)
                {
                    rtnDtTemp = helper.FillTable("USP_BM0580_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        rtx_NOTICE_B.Text = Convert.ToString(rtnDtTemp.Rows[0]["MTTEXT"]);
                        rtx_NOTICE_B.Rtf = Convert.ToString(rtnDtTemp.Rows[0]["MTRTF"]);
                    }
                    else
                    {
                        rtx_NOTICE_B.Text = string.Empty;
                        rtx_NOTICE_B.Rtf = string.Empty;
                    }

                }
                else
                {
                    rtnDtTemp = helper.FillTable("USP_BM0581_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        rtx_Vision_B.Text = Convert.ToString(rtnDtTemp.Rows[0]["MTTEXT"]);
                        rtx_Vision_B.Rtf = Convert.ToString(rtnDtTemp.Rows[0]["MTRTF"]);
                    }
                    else
                    {
                        rtx_Vision_B.Text = string.Empty;
                        rtx_Vision_B.Rtf = string.Empty;
                    }
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

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {


            DateTime dtNow = DateTime.Now;
            string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
            string sText = string.Empty;
            string sRtf = string.Empty;

            if (ultraTabControl1.SelectedTab.Index == 0)
            {
                sText = rtx_NOTICE_B.Text;
                sRtf = rtx_NOTICE_B.Rtf;
            }
            else
            {
                sText = rtx_Vision_B.Text;
                sRtf = rtx_Vision_B.Rtf;
            }


            if (sText == "") return;

            DBHelper helper = new DBHelper("", true);

            try
            {

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                if (ultraTabControl1.SelectedTab.Index == 0)
                {
                    helper.ExecuteNoneQuery("USP_BM0580_I1", CommandType.StoredProcedure
                                                     , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_TEXT", sText, DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_RTF", sRtf, DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.String, ParameterDirection.Input));

                }
                else
                {
                    helper.ExecuteNoneQuery("USP_BM0581_I1", CommandType.StoredProcedure
                                                     , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_TEXT", sText, DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_RTF", sRtf, DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.String, ParameterDirection.Input));
                }


                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    helper.Commit();
                    DoInquire(); //성공적으로 수행되었을 경우에만 조회
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region < EVENT AREA >
        private void btn_FONT_H_Click(object sender, EventArgs e)
        {
            string sSelText = string.Empty;

            if (ultraTabControl1.SelectedTab.Index == 0)
            {
                sSelText = rtx_NOTICE_B.SelectedText;

                if (sSelText == "")
                {
                    this.ShowDialog(Common.getLangText("선택 된 텍스트가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                DialogResult drFont = _font.ShowDialog();

                if (drFont == DialogResult.OK)
                {
                    rtx_NOTICE_B.SelectionFont = _font.Font;
                }
            }
            else
            {
                sSelText = rtx_Vision_B.SelectedText;

                if (sSelText == "")
                {
                    this.ShowDialog(Common.getLangText("선택 된 텍스트가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                DialogResult drFont = _font.ShowDialog();

                if (drFont == DialogResult.OK)
                {
                    rtx_Vision_B.SelectionFont = _font.Font;
                }
            }


        }

        private void btn_COLOR_H_Click(object sender, EventArgs e)
        {
            string sSelText = string.Empty;

            if (ultraTabControl1.SelectedTab.Index == 0)
            {
                sSelText = rtx_NOTICE_B.SelectedText;

                if (sSelText == "")
                {
                    this.ShowDialog(Common.getLangText("선택 된 텍스트가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                DialogResult drColor = _color.ShowDialog();

                if (drColor == DialogResult.OK)
                {
                    rtx_NOTICE_B.SelectionColor = _color.Color;
                }
            }
            else
            {
                sSelText = rtx_Vision_B.SelectedText;

                if (sSelText == "")
                {
                    this.ShowDialog(Common.getLangText("선택 된 텍스트가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                DialogResult drColor = _color.ShowDialog();

                if (drColor == DialogResult.OK)
                {
                    rtx_Vision_B.SelectionColor = _color.Color;
                }
            }


        }

        #endregion
    }
}