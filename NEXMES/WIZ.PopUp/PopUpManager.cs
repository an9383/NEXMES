namespace WIZ.PopUp
{
    public class PopUpManager : WIZ.PopManager.PopManagerBase
    {
        public override System.Data.DataTable OpenPopUp(string strPopUpName, string[] param)
        {
            System.Data.DataTable rtnDtTemp = null;
            switch (strPopUpName.Trim().ToUpper())//100 100 100 200 100 100 200 100 100 165 100 200 200 160 200 
            {
                //코드마스터 POP-UP
                case "BM0000":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0000_POP", "코드마스터 검색", param);
                    break;
                //코어 POP-UP
                case "MD0001":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "MD0001_POP", "코어 검색", param);
                    break;
                //품목 POP-UP
                case "BM0010":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0010_POP", "품목 검색", param);
                    break;
                //품목 POP-UP
                case "BM0011":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0011_POP", "품목 검색", param);
                    break;
                //작업자 POP-UP
                case "BM0020":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0020_POP", "작업자 검색", param);
                    break;
                //거래처 POP-UP
                case "BM0030":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0030_POP", "거래처 검색", param);
                    break;
                //공정 POP-UP
                case "BM0040":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0040_POP", "공정 검색", param);
                    break;
                //거래처 POP-UP
                case "BM0050":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0050_POP", "라인 검색", param);
                    break;
                //작업장 POP-UP
                case "BM0060":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0060_POP", "작업장 검색", param);
                    break;
                //설비 POP-UP
                case "BM0070":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0070_POP", "설비 검색", param);
                    break;
                //창고 POP-UP
                case "BM0080":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0080_POP", "창고 검색", param);
                    break;
                //저장위치 POP-UP
                case "BM0090":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0090_POP", "저장위치 검색", param);
                    break;
                //불량항목 POP-UP
                case "BM0100":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0100_POP", "불량항목 검색", param);
                    break;
                //결감항목 POP-UP
                case "BM8000":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM8000_POP", "결감항목 검색", param);
                    break;
                //비가동항목 POP-UP
                case "BM0110":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0110_POP", "비가동항목 검색", param);
                    break;
                //단위코드 POP-UP
                case "BM0130":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0130_POP", "단위코드 검색", param);
                    break;
                //검사항목 POP-UP
                case "BM0150":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0150_POP", "검사항목 검색", param);
                    break;
                //수입검사항목 POP-UP
                case "BM0160":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0160_POP", "수입검사항목 검색", param);
                    break;
                //공정검사항목 POP-UP
                case "BM0170":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0170_POP", "공정검사항목 검색", param);
                    break;
                //자주검사항목 POP-UP
                case "BM0180":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0180_POP", "자주검사항목 검색", param);
                    break;
                //제품검사항목 POP-UP
                case "BM0190":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0190_POP", "제품검사항목 검색", param);
                    break;
                //설비고장항목 POP-UP
                case "BM0370":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0370_POP", "설비고장항목 검색", param);
                    break;
                //설비점검항목 POP-UP
                case "BM0460":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0460_POP", "설비점검항목 검색", param);
                    break;
                //운행차량 POP-UP
                case "BM0500":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0500_POP", "운행차량 검색", param);
                    break;
                //각종사유 POP-UP
                case "BM0530":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0530_POP", "각종사유 검색", param);
                    break;
                //금형마스터 POP-UP
                case "BM0680":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0680_POP", "금형마스터 검색", param);
                    break;
                //알람마스터 POP-UP
                case "BM5100":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM5100_POP", "알람마스터 검색", param);
                    break;
                //설비보전항목마스터 POP-UP
                case "BM0710":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "BM0710_POP", "설비보전항목마스터 검색", param);
                    break;
                case "PP3510":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "PP3510_POP", "품목 검색", param);
                    break;
                //사용자 검색
                case "TSY0200":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "POP_TSY0200", "사용자 검색", param);
                    break;
                //시스템사용자 검색
                case "TSY0030":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "TSY0030_POP", "사용자 검색", param);
                    break;
                //프로그램검색
                case "TSY1500":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "POP_TSY1500", "프로그램 검색", param);
                    break;
                //수주현황
                case "AP0110":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "AP0110_POP", "수주현황", param);
                    break;
                //발주현황
                case "MM0020":
                    rtnDtTemp = OpenPopupShow("WIZ.PopUp", "MM0020_POP", "발주현황", param);
                    break;
            }

            return rtnDtTemp;
        }
    }
}
