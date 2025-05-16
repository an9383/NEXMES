#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DG0430
//   Form Name    : 작업장별 가동현황
//   Name Space   : WIZ.PP
//   Created Date : 2018-01-17
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      :
//   Description  : 작업장별 가동현황
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using WIZ.PopUp;
using WIZ.MAIN;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Net;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
#endregion

namespace WIZ.MT
{
    using Infragistics.UltraChart.Core.Primitives;
    using Infragistics.Win.UltraWinGrid;
    using System.IO;

    using WIZ.MAIN;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Net;
    using System.Runtime.Versioning;
    using System.Security.AccessControl;
    using System.Windows.Forms;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public partial class DG0430 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataSet rtnDsTemp = new DataSet();    //return DataSet 공통
        DataTable rtnDtTemp = new DataTable();  //return DataTable 공통
        DataTable _DtTemp = new DataTable();    //임시로 사용할 데이터테이블 생성

        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();
        private ClsSystem pcSys = new ClsSystem();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        readonly string _networkName;
        public string myNetworkPath = string.Empty;
        
        //public string networkPath = @"\\{192.168.20.202}\TEST";
        //NetworkCredential credentials = new NetworkCredential(@"{administrator}", "{wizcore!23}");

        // http://msdn.microsoft.com/en-us/library/windows/desktop/ms681382(v=vs.85).aspx
        const int ERROR_MORE_DATA = 0xEA;

        // http://www.pinvoke.net/default.aspx/mpr.WNetGetConnection
        [DllImport("mpr.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int WNetGetConnection(
            [MarshalAs(UnmanagedType.LPTStr)] string localName,
            [MarshalAs(UnmanagedType.LPTStr)] StringBuilder remoteName,
            ref int length);

        //http://www.pinvoke.net/default.aspx/mpr.VVNetAddConnection2
        [DllImport("mpr.dll")]
        public static extern int WNetAddConnection2(NETRESOURCE netResource,  string password, string username, uint flags);

        [StructLayout(LayoutKind.Sequential)]
        public class NETRESOURCE
        {
            public ResourceScope Scope;
            public ResourceType ResourceType;
            public ResourceDisplaytype DisplayType;
            public int Usage;
            public string LocalName;
            public string RemoteName;
            public string Comment;
            public string Provider;
        }

        public enum ResourceScope : int
        {
            Connected = 1,
            GlobalNetwork,
            Remembered,
            Recent,
            Context
        }

        public enum ResourceType : int
        {
            Any = 0,
            Disk = 1,
            Print = 2,
            Reserved = 8,
        }

        public enum ResourceDisplaytype : int
        {
            Generic = 0x0,
            Domain = 0x01,
            Server = 0x02,
            Share = 0x03,
            File = 0x04,
            Group = 0x05,
            Network = 0x06,
            Root = 0x07,
            Shareadmin = 0x08,
            Directory = 0x09,
            Tree = 0x0a,
            Ndscontainer = 0x0b
        }

        #endregion

        #region < CONSTRUCTOR >
        public DG0430()
        {
            InitializeComponent();
        }

        #endregion

        #region < FORM LOAD >
        private void DG0430_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EQPID", "설비코드", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "JOBID", "LOTNO", false, GridColDataType_emu.Float, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "RCPNAME", "레시피명 ", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REVERSE", "반전상태", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "NUMCELLX", "X 셀 개수", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "NUMCELLY", "Y 셀 개수", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "TOTALDEF", "검출된 총디펙개수", false, GridColDataType_emu.Double, 130, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PATH", "경로", false, GridColDataType_emu.VarChar, 450, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "BUTTON", "경로열기", true, GridColDataType_emu.Button, 80, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "DATETIME", "발생시각", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.SetInitUltraGridBind(grid1);

                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                //rtnDtTemp = _Common.GET_BM0000_CODE("YESNO");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "NOWLS", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("HIMSEQUIP"); //설비코드
                WIZ.Common.FillComboboxMaster(this.cbo_HIMSEQUIP_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

                cbo_STARTDATE_H.Value = DateTime.Now.AddHours(-6);
                cbo_ENDDATE_H.Value = DateTime.Now.AddDays(1);
                #endregion

                #region POPUP SETTING
                //작업장
                btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" });

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
        /// /// ToolBar의 조회 버튼 클릭
        /// /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);                            //공장
                string sEquipCode = DBHelper.nvlString(cbo_HIMSEQUIP_H.Value);                            //설비
                string sStartDate = DBHelper.nvlDateTime(cbo_STARTDATE_H.Value).ToString("yyyy-MM-dd");   //시작일자
                string sEndDate = DBHelper.nvlDateTime(cbo_ENDDATE_H.Value).ToString("yyyy-MM-dd");     //완료일자

                //if (Common.DateCheck.CheckDate(sStartDate, sEndDate) == false)
                //{
                //    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); 
                //    return;
                //}
                rtnDtTemp = helper.FillTable("USP_DG0430_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_EQUIPCODE", sEquipCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
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
        #endregion 

        #region < EVENT AREA >
        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //CustomMergedCellEvalutor CM1 = new CustomMergedCellEvalutor("WORKCENTERCODE", "WORKCENTERNAME");
            //e.Layout.Bands[0].Columns["PLANTCODE"].MergedCellEvaluator = CM1;
            //e.Layout.Bands[0].Columns["RECDATE"].MergedCellEvaluator = CM1;
            //e.Layout.Bands[0].Columns["DAYNIGHT"].MergedCellEvaluator = CM1;
        }

        private void grid1_ClickCellButton(object sender, CellEventArgs e)
        {
            string sFinishFlag = string.Empty;
            string sShipNo = string.Empty;
            string sItemCode = string.Empty;
            string path = e.Cell.Row.Cells["PATH"].Value.ToString();

            try
            {

                if (e.Cell.Column.ToString() == "BUTTON")
                {
                    //Process process = new Process();

                    //process.StartInfo.FileName = "net.exe";
                    //process.StartInfo.Arguments = "use \\\\192.168.20.202\\TEST wizcore!23 /user:administrator";

                    //process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    //process.StartInfo.UseShellExecute = false;
                    //process.Start();

                    ////사용자가 열고자 하는 폴더 경로 지정
                    //string localFolderPath = @"\\192.168.20.202\TEST" + path;

                    ////D드라이브 폴더 실행
                    //System.Diagnostics.Process.Start(localFolderPath);
                    //process.WaitForExit();

                    ////code to access file. Here is where the error occurs
                    //process.Dispose();

                    NetworkCredential credentials = new NetworkCredential(@"{administrator}", "{wizcore!23}");

                    var mapResult = WNetAddConnection2(
                        new NETRESOURCE
                        {
                            Scope = ResourceScope.Connected,
                            ResourceType = ResourceType.Disk,
                            DisplayType = ResourceDisplaytype.Generic,
                            Usage = 0,
                            LocalName = @"H:",
                            RemoteName = @"\\192.168.20.202\TEST",
                            Comment = "FROM MES",
                            Provider = null
                        }
                        , null
                        , null
                        , 0);

                    //if (mapResult != 0)
                    //{
                    //    throw new Exception("AddConnection failed");
                    //    // http://msdn.microsoft.com/en-us/library/windows/desktop/ms681383(v=vs.85).aspx
                    //}

                    // get the remote connection path
                    int remoteBufLen = 0;
                    StringBuilder remotePath = null;
                    var connRes = ERROR_MORE_DATA;
                    // call twice if the buffer is too small
                    for (int t = 0; t < 2 && connRes == ERROR_MORE_DATA; t++)
                    {
                        remotePath = new StringBuilder(remoteBufLen);
                        // and error is returned 
                        // and remoteBufLen holds the required size
                        connRes = WNetGetConnection(@"H:", remotePath, ref remoteBufLen);
                    }
                    if (connRes != 0)
                    {
                        throw new Exception("getconnetion failed");
                    }

                    string localFolderPath = @"\\192.168.20.202\TEST" + path;
                    System.Diagnostics.Process.Start(localFolderPath);

                }


            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
            }
        }

        #endregion

    }
}
