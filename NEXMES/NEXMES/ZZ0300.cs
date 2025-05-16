#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID        : ZZ0300
//   Form Name      : CHANGE PASSWORD
//   Name Space     : NEXMES
//   Created Date   : 2012.11.30
//   Made By        : WIZ INFORMATION SYSTEM CO.,LTD
//   Description    : 비밀번호 변경
//   DB Table       : SY0300
//   StoreProcedure : USP_ZZ0300_I1
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WIZ;
#endregion

#region < NEXMES >
namespace NEXMES
{
    public partial class ZZ0300 : Form
    {
        #region < FIELD >
        private System.Drawing.Point temp;
        private bool ismove = false;
        #endregion

        #region < CONSTRUCTOR >
        public ZZ0300()
        {
            InitializeComponent();

            txtID.Text = "";
        }

        public ZZ0300(string sWorkerID)
        {
            InitializeComponent();

            sLabel2.Text = WIZ.Common.getLangText(sLabel2.Text);
            sLabel5.Text = WIZ.Common.getLangText(sLabel5.Text);
            sLabel4.Text = WIZ.Common.getLangText(sLabel4.Text);
            sLabel3.Text = WIZ.Common.getLangText(sLabel3.Text);
            btnSave.Text = WIZ.Common.getLangText(btnSave.Text);
            btnClose.Text = WIZ.Common.getLangText(btnClose.Text);

            this.Text = WIZ.Common.getLangText(this.Text);

            txtID.Text = sWorkerID.Trim();
        }


        #endregion

        #region < EVENT AREA >
        private void pnlSplash_MouseUp(object sender, MouseEventArgs e)
        {
            this.ismove = false;
        }

        private void pnlSplash_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.ismove)
            {
                System.Drawing.Point d = Control.MousePosition;
                d.X = d.X - temp.X;
                d.Y = d.Y - temp.Y;
                this.Location = d;
            }
        }

        private void pnlSplash_MouseDown(object sender, MouseEventArgs e)
        {
            this.ismove = true;

            temp.X = Control.MousePosition.X - this.Location.X;
            temp.Y = Control.MousePosition.Y - this.Location.Y;
        }
        //2020-06-25 수정 하기전
        //private void ShowDialog(string messageid, WIZ.Forms.DialogForm.DialogType sType = WIZ.Forms.DialogForm.DialogType.OK)
        //{
        //    WIZ.Forms.DialogForm dialogform = new WIZ.Forms.DialogForm(messageid, sType);

        //    dialogform.ShowDialog();
        //}

        //2020-06-25 신규 추가
        public DialogResult ShowDialog(string messageid, WIZ.Forms.DialogForm.DialogType sType = WIZ.Forms.DialogForm.DialogType.YESNO)
        {
            WIZ.Forms.DialogForm dialogForm = new WIZ.Forms.DialogForm(messageid, sType);
            DialogResult dialogResult;
            return dialogResult = dialogForm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            Regex rxPassword = new Regex(@"^(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", RegexOptions.IgnorePatternWhitespace);

            Regex reg = new Regex(@"[A-Z]");

            //2020-06-25 신규 추가
            //if (this.ShowDialog(Common.getLangText("소문자, 숫자, 특수문자 1개이상을 포함한 비밀번호 8자 이상 입력해주세요. " +
            //    Environment.NewLine + "변경사항을 저장하시겠습니까?", "MSG"), WIZ.Forms.DialogForm.DialogType.YESNO) == System.Windows.Forms.DialogResult.Cancel)
            //    return;

            try
            {
                if (!rxPassword.IsMatch(txtPwdChg.Text))
                {
                    ShowDialog(WIZ.Common.getLangText(sLabel4.Text + " 소문자, 숫자, 특수문자 1개이상을 포함한 비밀번호 8자 이상 입력해주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
                if (reg.IsMatch(txtPwdChg.Text))
                {
                    ShowDialog(WIZ.Common.getLangText(sLabel4.Text + " 대문자는 포함하시면 안됩니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
                if (!rxPassword.IsMatch(txtPWDChk.Text))
                {
                    ShowDialog(WIZ.Common.getLangText(sLabel3.Text + " 소문자, 숫자, 특수문자 1개이상을 포함한 비밀번호 8자 이상 입력해주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
                if (reg.IsMatch(txtPWDChk.Text))
                {
                    ShowDialog(WIZ.Common.getLangText(sLabel3.Text + " 대문자는 포함하시면 안됩니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }


                if (txtPWDChk.Text.Trim() != txtPwdChg.Text.Trim())
                {
                    ShowDialog(WIZ.Common.getLangText("변경 비밀번호와 비밀번호 확인이 다릅니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                if (txtPwdNow.Text.Trim() == txtPwdChg.Text.Trim())
                {
                    ShowDialog(WIZ.Common.getLangText("현재 비밀번호와 변경할 비밀번호가 같습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                string pwd = txtPwdNow.Text;
                string pwd1 = txtPwdChg.Text;

                pwd = WIZ.Common.MD5Hash(pwd);
                pwd1 = WIZ.Common.MD5Hash(pwd1);

                DataTable dt = helper.FillTable("USP_ZZ0300_U1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("pWorkerID", txtID.Text, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("pPWD", pwd, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("pChgPWD", pwd1, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.Close();
                }
                else
                {
                    ShowDialog(helper.RSMSG, WIZ.Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion



    }
}
#endregion