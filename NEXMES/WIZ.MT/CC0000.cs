#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : 
//   Form Name    : 
//   Name Space   : 
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Windows.Forms;
#endregion

namespace WIZ.MT
{
    public partial class CC0000 : WIZ.Forms.BaseMDIChildForm
    {

        #region <MEMBER AREA>

        #endregion

        #region < CONSTRUCTOR >

        public CC0000()
        {
            InitializeComponent();

        }

        private void CC0000_Load(object sender, EventArgs e)
        {
            // axCeXview2DPro1.Open(@"../../Sample_A1.dwg");
        }


        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
        }
        #endregion

        #region<btn_Open_Click>
        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Title = "파일 열기";
            openFileDlg.DefaultExt = "*.*";
            openFileDlg.Filter = " All Files (*.*) | *.*";

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                string openFilePath = openFileDlg.FileName;
                //axCeXview2DPro1.Open(openFilePath);
                //Process.Start(openFilePath);   // Process.Start() 사용시 System.Diagnostics를 using 해주어야 한다.
            }

        }
        #endregion
    }
}


