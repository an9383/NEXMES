#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : IMAGEVIEW_POP
//   Form Name    : IMAGE VIEWER
//   Name Space   : WIZ.PopUp
//   Created Date : 2017-01-01
//   Made By      : WIZ
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System.Drawing;
using System.IO;
using System.Windows.Forms;
#endregion

namespace WIZ.PopUp
{
    public partial class IMAGEVIEW_POP : WIZ.Forms.BasePopupForm
    {
        Image img;

        public IMAGEVIEW_POP(byte[] bImage)
        {
            InitializeComponent();

            MemoryStream MS = new MemoryStream(bImage);

            img = new Bitmap(MS);

            picView.SizeMode = PictureBoxSizeMode.StretchImage;
            picView.Image = img;
            MS.Dispose();
        }

        private void POP_IMAGEVIEW_FormClosed(object sender, FormClosedEventArgs e)
        {
            img.Dispose();
        }
    }
}
