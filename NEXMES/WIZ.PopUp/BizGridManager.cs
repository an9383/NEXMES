namespace WIZ.PopUp
{
    public class BizGridManager : WIZ.PopManager.BizGridManagerBase
    {
        static WIZ.PopUp.PopUp_Biz _biz = new PopUp_Biz();

        public delegate void delePopUpClosed(WIZ.Control.Grid grid, string sCode, string sName, bool bFindOK);
        public event delePopUpClosed PopUpClosed;

        public BizGridManager(WIZ.Control.Grid grid0)
        {
            base.init(grid0);
        }

        public override void getPopupGrid(string sFunctionName, string sCode, string sName, string sValueCode, string sValueName, string[] aParam1, string[] sParam2)
        {
            _biz.bFindOK = false;

            _biz.BIZ_POP(sFunctionName, sValueCode, sValueName, aParam1, sParam2, sCode, sName, grid);

            //switch (sFunctionName)
            //{
            //    case "BM0010": //품목 POP-UP ( PLANTCODE, ITEMTYPE, USEFLAG )
            //        _biz.BM0010_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], aParam1[2], grid, sCode, sName);
            //        break;
            //    case "BM0020": //작업자 POP-UP ( PLANTCODE, DEPTCODE, USEFLAG )
            //        _biz.BM0020_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], aParam1[2], grid, sCode, sName);
            //        break;
            //    case "BM0030": //거래처 POP-UP ( PLANTCODE, CUSTTYPE, USEFLAG )
            //        _biz.BM0030_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], aParam1[2], grid, sCode, sName);
            //        break;
            //    case "BM0040": //공정 POP-UP ( PLANTCODE, OPTYPE, USEFLAG )
            //        _biz.BM0040_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], aParam1[2], grid, sCode, sName);
            //        break;
            //    case "BM0050": //라인 POP-UP ( PLANTCODE, OPCODE, USEFLAG )
            //        _biz.BM0050_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], aParam1[2], grid, sCode, sName);
            //        break;
            //    case "BM0060": //작업장 POP-UP ( PLANTCODE, OPCODE, LINECODE, USEFLAG )
            //        _biz.BM0060_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], aParam1[2], aParam1[3], grid, sCode, sName);
            //        break;
            //    case "BM0070": //설비 POP-UP ( PLANTCODE, MACHTYPE, USEFLAG )
            //        _biz.BM0070_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], aParam1[2], grid, sCode, sName);
            //        break;
            //    case "BM0080": //창고 POP-UP ( PLANTCODE, WHTYPE, USEFLAG )
            //        _biz.BM0080_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], aParam1[2], grid, sCode, sName);
            //        break;
            //    case "BM0090": //저장위치 POP-UP ( PLANTCODE, STORAGELOCTYPE, OPCODE, USEFLAG )
            //        _biz.BM0090_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], aParam1[2], aParam1[3], grid, sCode, sName);
            //        break;
            //    case "BM0100": //불량항목 POP-UP ( PLANTCODE, ERRORTYPE, USEFLAG )
            //        _biz.BM0100_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], aParam1[2], grid, sCode, sName);
            //        break;
            //    case "BM0110": //비가동항목 POP-UP ( PLANTCODE, ERRORTYPE, USEFLAG )
            //        _biz.BM0110_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], aParam1[2], grid, sCode, sName);
            //        break;
            //    case "BM0130": //단위코드 POP-UP ( USEFLAG )
            //        _biz.BM0130_POP_GRID(sValueCode, sValueName, aParam1[0], grid, sCode, sName);
            //        break;
            //    case "BM0150": //검사항목 POP-UP ( PLANTCODE, USEFLAG )
            //        _biz.BM0150_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], grid, sCode, sName);
            //        break;
            //    case "BM0160": //수입검사항목 POP-UP ( PLANTCODE, USEFLAG )
            //        _biz.BM0160_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], grid, sCode, sName);
            //        break;
            //    case "BM0170": //공정검사항목 POP-UP ( PLANTCODE, USEFLAG )
            //        _biz.BM0170_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], grid, sCode, sName);
            //        break;
            //    case "BM0180": //자주검사항목 POP-UP ( PLANTCODE, USEFLAG )
            //        _biz.BM0180_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], grid, sCode, sName);
            //        break;
            //    case "BM0190": //제품검사항목 POP-UP ( PLANTCODE, USEFLAG )
            //        _biz.BM0190_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], grid, sCode, sName);
            //        break;
            //    case "BM0370": //설비고장항목 POP-UP ( PLANTCODE, FAILURETYPE, USEFLAG )
            //        _biz.BM0370_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], aParam1[2], grid, sCode, sName);
            //        break;
            //    case "BM0500": //운행차량 POP-UP ( PLANTCODE, CARGUBUN, USEFLAG )
            //        _biz.BM0500_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], aParam1[2], grid, sCode, sName);
            //        break;
            //    case "BM0530": //각종사유 POP-UP ( RESTYPE, USEFLAG )
            //        _biz.BM0530_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], grid, sCode, sName);
            //        break;
            //    case "BM0680": //금형마스터 POP-UP ( PLANTCODE, USEFLAG )
            //        _biz.BM0680_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], grid, sCode, sName);
            //        break;
            //    case "BM5100": //알람마스터 POP-UP ( PLANTCODE, USEFLAG )
            //        _biz.BM5100_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], grid, sCode, sName);
            //        break;
            //    case "TSY0030": //시스템사용자 POP-UP ( PLANTCODE, USEFLAG )
            //        _biz.TSY0030_POP_GRID(sValueCode, sValueName, aParam1[0], aParam1[1], grid, sCode, sName);
            //        break;
            //    default:
            //        WIZ.Forms.DialogForm dialogform = new WIZ.Forms.DialogForm("C:S00014");

            //        dialogform.ShowDialog();

            //        break;
            //}

            if (this.PopUpClosed != null)
            {
                PopUpClosed(grid, DBHelper.nvlString(grid.ActiveRow.Cells[sCode].Value), DBHelper.nvlString(grid.ActiveRow.Cells[sName].Value), _biz.bFindOK);
            }
        }
    }
}
