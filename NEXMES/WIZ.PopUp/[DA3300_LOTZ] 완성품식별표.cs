using System.Drawing;

namespace WIZ.PopUp
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DA3300_LOTZ : Telerik.Reporting.Report
    {
        public DA3300_LOTZ()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public static Image GetBarcodeImage(string barcode)
        {
            DataMatrix.net.DmtxImageEncoder dx = new DataMatrix.net.DmtxImageEncoder();
            Image img = dx.EncodeImage(barcode);

            return img;
        }

        //public static Image GetChart1()
        //{
        //    return Common.Chart1;
        //}
    }
}
