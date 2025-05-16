using System;
using System.Data;
using System.Text;

namespace WIZ.PopUp
{
    public partial class POP_YQM5140 : WIZ.Forms.BaseMDIChildForm
    {
        private string[] temp;
        private string tLotNo = string.Empty;
        private string tProductCD = string.Empty;
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        public POP_YQM5140(string[] param)
        {
            InitializeComponent();
            temp = param;
        }

        private void POP_YQM5140_Load(object sender, EventArgs e)
        {
            if (temp.ToString().Length != 0)
            {
                string[] Tmp = temp.ToString().Split(':');
                if (Tmp[0].ToString().Length != 0 && Tmp[1].ToString().Length != 0)
                {
                    tLotNo = Tmp[1].Trim();
                    tProductCD = Tmp[0].Trim();
                }
                Tmp = temp.ToString().Split('|');
                if (Tmp[0].ToString().Length != 0 && Tmp[1].ToString().Length != 0)
                {
                    tLotNo = Tmp[0].Trim();
                    tProductCD = Tmp[1].Trim();
                }

            }
            lbLotNo.Text = tLotNo;
            lbProductNo.Text = tProductCD;
            lbSum.Text = "";
        }
        private void Fill_Grid1()
        {
            DBHelper helper = new DBHelper(false);
            StringBuilder Sql = new StringBuilder();
            Sql.AppendLine("select ORDER_NO, ORDER_DATE, FIX_QTY");
            Sql.AppendLine(" from W_ORDER ");
            Sql.AppendLine(" where ORDER_NO in");
            Sql.AppendLine("(select distinct w.ORDER_NO");
            Sql.AppendLine(" from INSP_LOT i, W_ORDER w");
            Sql.AppendLine(" where i.ORDER_NO = w.ORDER_NO");
            Sql.AppendLine("   and i.ILOT_NO like '" + tLotNo.Trim() + "%'");
            Sql.AppendLine("   and w.PRODUCT_CD = '" + tProductCD.Trim() + "')");
            rtnDtTemp = helper.FillTable(Sql.ToString(), CommandType.Text);
            this.grid1.DataSource = rtnDtTemp;

        }
    }
}
