#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0010_POP
//   Form Name    : 식별표 재발행 사유 입력 POP-UP
//   Name Space   : WIZ.POPUP
//   Created Date : 2018-04-24
//   Made By      : 
//   Edited Date  : 
//   Edit By      :
//   Description  : 식별표 재발행 사유 입력 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Windows.Forms;
#endregion


namespace WIZ.PopUp
{
    public partial class MM0010_POP : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >

        Common _Common = new Common();
        public string _sRemark = string.Empty;

        #endregion

        #region < CONSTRUCTOR >

        public MM0010_POP()
        {
            InitializeComponent();
        }
        #endregion

        #region < METHOD AREA >

        #endregion

        #region < EVENT AREA >
        private void btn_SAVE_H_Click(object sender, EventArgs e)
        {
            if (txt_REMARK_H.Text.Trim() == string.Empty)
            {
                MessageBox.Show("재발행 사유를 입력하세요.");
                return;
            }

            _sRemark = txt_REMARK_H.Text.Trim();
            this.Close();
        }

        private void btn_CLOSE_H_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


    }
}
