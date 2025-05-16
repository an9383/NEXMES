namespace WIZ.PopUp
{
    public class BizTextBoxManager : WIZ.PopManager.BizTextBoxManagerBase
    {
        static WIZ.PopUp.PopUp_Biz _biz = new PopUp_Biz();

        public delegate void deleTBoxPopUpClosed(object tCode, object tName, bool bFindOK);
        public event deleTBoxPopUpClosed PopUpClosed;

        public override void Bz_Pop(string sFunctionName, object tCodeBox, object tNameBox, string sValueCode, string sValueName, string[] aParam, string[] ColumnList, object[] ObjectList)
        {
            _biz.bFindOK = false;

            _biz.BIZ_POP(sFunctionName, sValueCode, sValueName, aParam, ColumnList, tCodeBox, tNameBox);

            //switch (sFunctionName)
            //{
            //    case "BM0000": //코드마스터 POP-UP
            //        _biz.BM0000_POP(sValueCode, sValueName, tCodeBox, tNameBox);
            //        break;
            //    case "BM0010": //품목 POP-UP ( PLANTCODE, ITEMTYPE, USEFLAG )
            //        _biz.BM0010_POP(sValueCode, sValueName, aParam[0], aParam[1], aParam[2], tCodeBox, tNameBox);
            //        break;
            //    case "BM0020": //작업자 POP-UP ( PLANTCODE, DEPTCODE, USEFLAG )
            //        _biz.BM0020_POP(sValueCode, sValueName, aParam[0], aParam[1], aParam[2], tCodeBox, tNameBox);
            //        break;
            //    case "BM0030": //거래처 POP-UP ( PLANTCODE, CUSTTYPE, CUSTTYPE.ENABLED, USEFLAG )
            //        _biz.BM0030_POP(sValueCode, sValueName, aParam[0], aParam[1], aParam[2], aParam[3], tCodeBox, tNameBox);
            //        break;
            //    case "BM0040": //공정 POP-UP ( PLANTCODE, OPTYPE, USEFLAG )
            //        _biz.BM0040_POP(sValueCode, sValueName, aParam[0], aParam[1], aParam[2], tCodeBox, tNameBox);
            //        break;
            //    case "BM0050": //라인 POP-UP ( PLANTCODE, OPCODE, USEFLAG )
            //        _biz.BM0050_POP(sValueCode, sValueName, aParam[0], aParam[1], aParam[2], tCodeBox, tNameBox);
            //        break;
            //    case "BM0060": //작업장 POP-UP ( PLANTCODE, OPCODE, LINECODE, USEFLAG )
            //        _biz.BM0060_POP(sValueCode, sValueName, aParam[0], aParam[1], aParam[2], aParam[3], tCodeBox, tNameBox);
            //        break;
            //    case "BM0070": //설비 POP-UP ( PLANTCODE, MACHTYPE, USEFLAG )
            //        _biz.BM0070_POP(sValueCode, sValueName, aParam[0], aParam[1], aParam[2], tCodeBox, tNameBox);
            //        break;
            //    case "BM0080": //창고 POP-UP ( PLANTCODE, WHTYPE, USEFLAG )
            //        _biz.BM0080_POP(sValueCode, sValueName, aParam[0], aParam[1], aParam[2], tCodeBox, tNameBox);
            //        break;
            //    case "BM0090": //저장위치 POP-UP ( PLANTCODE, STORAGELOCTYPE, OPCODE, USEFLAG )
            //        _biz.BM0090_POP(sValueCode, sValueName, aParam[0], aParam[1], aParam[2], aParam[3], tCodeBox, tNameBox);
            //        break;
            //    case "BM0100": //불량항목 POP-UP ( PLANTCODE, ERRORTYPE, USEFLAG )
            //        _biz.BM0100_POP(sValueCode, sValueName, aParam[0], aParam[1], aParam[2], tCodeBox, tNameBox);
            //        break;
            //    case "BM0110": //비가동항목 POP-UP ( PLANTCODE, STOPTYPE, USEFLAG )
            //        _biz.BM0110_POP(sValueCode, sValueName, aParam[0], aParam[1], aParam[2], tCodeBox, tNameBox);
            //        break;
            //    case "BM0130": //단위코드 POP-UP ( USEFLAG )
            //        _biz.BM0130_POP(sValueCode, sValueName, aParam[0], tCodeBox, tNameBox);
            //        break;
            //    case "BM0150": //검사항목 POP-UP ( PLANTCODE, USEFLAG )
            //        _biz.BM0150_POP(sValueCode, sValueName, aParam[0], aParam[1], tCodeBox, tNameBox);
            //        break;
            //    case "BM0160": //수입검사항목 POP-UP ( PLANTCODE, USEFLAG )
            //        _biz.BM0160_POP(sValueCode, sValueName, aParam[0], aParam[1], tCodeBox, tNameBox);
            //        break;
            //    case "BM0170": //공정검사항목 POP-UP ( PLANTCODE, USEFLAG )
            //        _biz.BM0170_POP(sValueCode, sValueName, aParam[0], aParam[1], tCodeBox, tNameBox);
            //        break;
            //    case "BM0180": //자주검사항목 POP-UP ( PLANTCODE, USEFLAG )
            //        _biz.BM0180_POP(sValueCode, sValueName, aParam[0], aParam[1], tCodeBox, tNameBox);
            //        break;
            //    case "BM0190": //제품검사항목 POP-UP ( PLANTCODE, USEFLAG )
            //        _biz.BM0190_POP(sValueCode, sValueName, aParam[0], aParam[1], tCodeBox, tNameBox);
            //        break;
            //    case "BM0370": //설비고장항목 POP-UP ( PLANTCODE, FAILURETYPE, USEFLAG )
            //        _biz.BM0370_POP(sValueCode, sValueName, aParam[0], aParam[1], aParam[2], tCodeBox, tNameBox);
            //        break;
            //    case "BM0460": //설비점검항목 POP-UP ( PLANTCODE, USEFLAG )
            //        _biz.BM0460_POP(sValueCode, sValueName, aParam[0], aParam[1], tCodeBox, tNameBox);
            //        break;
            //    case "BM0500": //운행차량 POP-UP ( PLANTCODE, CARGUBUN, USEFLAG )
            //        _biz.BM0500_POP(sValueCode, sValueName, aParam[0], aParam[1], aParam[2], tCodeBox, tNameBox);
            //        break;
            //    case "BM0530": //각종사유 POP-UP ( RESTYPE, USEFLAG )
            //        _biz.BM0530_POP(sValueCode, sValueName, aParam[0], aParam[1], tCodeBox, tNameBox);
            //        break;
            //    case "BM0680": //금형마스터 POP-UP ( PLANTCODE, USEFLAG )
            //        _biz.BM0680_POP(sValueCode, sValueName, aParam[0], aParam[1], tCodeBox, tNameBox);
            //        break;
            //    case "BM0710": //설비보전항목마스터 POP-UP ( PLANTCODE, USEFLAG )
            //        _biz.BM0710_POP(sValueCode, sValueName, aParam[0], aParam[1], tCodeBox, tNameBox);
            //        break;
            //    default:
            //        WIZ.Forms.DialogForm dialogform = new WIZ.Forms.DialogForm("C:S00014");
            //        dialogform.ShowDialog();
            //        break;
            //}
            if (this.PopUpClosed != null)
            {
                PopUpClosed(tCodeBox, tNameBox, _biz.bFindOK);
            }
        }
    }
}
