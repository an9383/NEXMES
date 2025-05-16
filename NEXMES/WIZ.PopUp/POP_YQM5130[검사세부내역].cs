using System;
using System.Data;
using System.Text;

namespace WIZ.PopUp
{
    public partial class POP_YQM5130 : WIZ.Forms.BasePopupForm
    {
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        string[] tParm = new string[7];// 검사공정(0),공정코드(1),일자(2),검사자(3),품목(4),검사차수(5),PLANTCODE(6)
        public POP_YQM5130(string[] param)
        {
            InitializeComponent();
            tParm = param;
            txtProductCD.Text = tParm[4];
            txtProcess.Text = tParm[0];
        }

        private void POP_YQM5130_Load(object sender, EventArgs e)
        {
            Fill_grid1();
        }
        private void Fill_grid1()
        {
            DBHelper helper = new DBHelper(false);
            string[] tTmp = tParm[4].ToString().Split(':');
            StringBuilder Sql = new StringBuilder();
            //'각 법인별 근무시간이 다름(이루틴 FrmNewLot에도 있음)
            string tStartTime = string.Empty;
            string tEndTime = string.Empty;
            tStartTime = Work_StartTime();
            tEndTime = Work_EndTime();

            Sql.AppendLine(" select IITEMNAME, ISPECMEMO, IVALUE,");
            Sql.AppendLine("       'X' || IGUB || ':' || decode(IRESULT,'O','OK',IRESULT) IRESULT, ICHECKER, ILOTNO, PROCESSDATE");
            Sql.AppendLine("  from YQM1100 a, YQM0200 b, YQM0300 c");
            Sql.AppendLine(" where a.IITEMNO = b.IITEMNO and a.IOPCODE = b.IOPCODE");
            Sql.AppendLine("   and a.IITEMNO = c.IITEMNO and a.IOPCODE = c.IOPCODE and a.ITEMCODE = c.ITEMCODE");
            Sql.AppendLine("    and RPQ_BLIND(a.IOPCODE, a.IITEMNO) = 'N'");// '항목 숨김 2012.9.15
            Sql.AppendLine("    and ICHECKER is not null");
            Sql.AppendLine("   and a.ILOTNO like '" + tParm[2].ToString().Trim() + "%'");
            Sql.AppendLine("   and a.IOPCODE = '" + tParm[1].ToString().Trim() + "'");
            Sql.AppendLine("   and a.ITEMCODE = '" + tTmp[0].Trim() + "'");
            if (tParm[3].ToString().Trim() != "")
                Sql.AppendLine(" and a.ICHECKER = '" + tParm[3].ToString().Trim() + "'");
            if (tParm[5].ToString().Trim() != "" && chkALL.Checked == false)
                Sql.AppendLine(" and a.IGUB = '" + tParm[5].ToString().Trim().Substring(1, 1) + "'");
            Sql.AppendLine(" order by ICHECKER, PROCESSDATE, a.IITEMNO, IGUB");
            rtnDtTemp = helper.FillTable(Sql.ToString(), CommandType.Text);
            this.grid1.DataSource = rtnDtTemp;
        }
        private string Work_StartTime()
        {
            string tStartTime = string.Empty;
            switch (tParm[6].ToString()) //PLANTCODE
            {
                case "Z":
                    tStartTime = "080000";
                    break;
                case "U":
                    switch (tParm[6].ToString()) //PLANTCODE
                    {
                        case "2231":
                        case "6101":
                        case "6103":
                        case "6203":
                            tStartTime = "060000";// 'DWA는 코일성형공정은 시작시간이 다름
                            break;
                        case "2341":
                            tStartTime = "090000"; //'DWA는 코일도장공정은 시작시간이 다름
                            break;
                        default:
                            tStartTime = "070000";
                            break;
                    }
                    break;

                case "I": tStartTime = "083000"; break;
                case "P": tStartTime = "060000"; break;
                default: tStartTime = "083000"; break;
            }

            return tStartTime;
        }
        private string Work_EndTime()
        {
            string tEndTime = string.Empty;
            switch (tParm[6].ToString()) //PLANTCODE
            {
                case "Z": tEndTime = "075959"; break;
                case "U":
                    tEndTime = "065959"; break;
                    switch (tParm[6].ToString()) //PLANTCODE
                    {
                        case "2231":
                        case "6101":
                        case "6103":
                        case "6203": tEndTime = "055959"; break;// 'DWA는 코일성형공정은 시작시간이 다름
                        case "2341": tEndTime = "085959"; break;  //'DWA는 코일도장공정은 시작시간이 다름
                        default: tEndTime = "065959";
                    }

                case "I": tEndTime = "082959"; break;
                case "P": tEndTime = "055959"; break;
                default: tEndTime = "082959"; break;
            }
            return tEndTime;
        }

        private void chkALL_CheckedChanged(object sender, EventArgs e)
        {
            Fill_grid1();
        }
    }
}
