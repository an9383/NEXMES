using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WIZ
{
    #region Ini 파일 관리
    public class IniFileData
    {
        #region 멤버변수
        private List<IniValue> ListData;
        private List<KeyValuePair<string, string>> ListOrder;
        private List<string> ListGroup;

        #endregion

        #region 생성자
        public IniFileData()
        {
            ListData = new List<IniValue>();
            ListOrder = new List<KeyValuePair<string, string>>();
            ListGroup = new List<string>();
        }
        #endregion

        #region 리스트 삽입, 수정 삭제
        /// <summary>
        /// 데이터를 삽입하거나 수정한다. 해당 Group에서 Key 가 있으면 수정, 없으면 삽입한다.
        /// </summary>
        /// <param name="sGroup"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public string this[string sGroup, string sKey]
        {
            get
            {
                foreach (IniValue v in ListData)
                {
                    if (v.Group.ToUpper() == sGroup.ToUpper() && v.Key.ToUpper() == sKey.ToUpper())
                    {
                        return v.Value;
                    }
                }

                return null;
            }
            set
            {
                foreach (IniValue v in ListData)
                {
                    if (v.Group.ToUpper() == sGroup.ToUpper() && v.Key.ToUpper() == sKey.ToUpper())
                    {
                        v.Value = value;
                        return;
                    }
                }

                ListData.Add(new IniValue(sGroup, sKey, value));

                bool bFind = false;

                for (int i = 0; i < ListOrder.Count; i++)
                {
                    KeyValuePair<string, string> key = ListOrder[i];

                    if (key.Key == "GROUP" && key.Value.ToUpper() == sGroup.ToUpper())
                    {
                        bFind = true;
                    }

                    if (bFind)
                    {
                        // 사이에 들어가는 경우
                        if (key.Key.ToUpper() == "GROUP" && key.Value.ToUpper() != sGroup.ToUpper())
                        {
                            ListOrder.Insert(i, new KeyValuePair<string, string>(sKey, ""));
                            bFind = false;
                            return;
                        }
                    }
                }

                // 찾았는데 추가하지 못 한 경우
                if (bFind)
                {
                    // 제일 끝에 추가
                    ListOrder.Add(new KeyValuePair<string, string>(sKey, ""));
                }
                else
                {
                    // 신규 Group 인 경우
                    ListOrder.Add(new KeyValuePair<string, string>("GROUP", sGroup));
                    ListOrder.Add(new KeyValuePair<string, string>(sKey, ""));
                }
            }
        }

        /// <summary>
        /// 데이터 삭제
        /// </summary>
        /// <param name="sGroup"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public bool Remove(string sGroup, string sKey)
        {
            for (int i = 0; i < ListData.Count; i++)
            {
                IniValue v = (IniValue)ListData[i];

                if (v.Group.ToUpper() == sGroup.ToUpper() && v.Key.ToUpper() == sKey.ToUpper())
                {
                    ListData.Remove(v);

                    bool bFind = false;

                    for (int j = 0; j < ListOrder.Count; j++)
                    {
                        KeyValuePair<string, string> key = ListOrder[j];

                        if (key.Key == "GROUP" && key.Value.ToUpper() == sGroup.ToUpper())
                        {
                            bFind = true;
                        }

                        if (bFind)
                        {
                            // 사이에 들어가는 경우
                            if (key.Key.ToUpper() == sKey.ToUpper())
                            {
                                ListOrder.RemoveAt(j);
                                break;
                            }
                        }
                    }

                    return true;
                }
            }

            return false;
        }
        #endregion

        #region 파일 처리
        /// <summary>
        /// 해당 파일로 데이터를 읽는다. 모든 리스트가 초기화된다.
        /// </summary>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        public bool ReadFile(string sFileName)
        {

            if (File.Exists(sFileName))
            {
                try
                {
                    // 초기화
                    ListData = new List<IniValue>();
                    ListOrder = new List<KeyValuePair<string, string>>();
                    ListGroup = new List<string>();

                    string sGroup = "";
                    FileStream fs = new FileStream(sFileName, FileMode.Open);
                    StreamReader sr = new StreamReader(fs, Encoding.Default);

                    while (!sr.EndOfStream)
                    {
                        string sValue = sr.ReadLine().Trim();

                        int idxSemiColon = sValue.IndexOf(";");
                        if (idxSemiColon > 0)
                        {
                            ListOrder.Add(new KeyValuePair<string, string>("POST", sValue.Substring(idxSemiColon)));
                            sValue = sValue.Substring(0, idxSemiColon).Trim();
                        }
                        else if (idxSemiColon == 0)
                        {
                            ListOrder.Add(new KeyValuePair<string, string>("ALL", sValue));
                            sValue = "";
                        }

                        if (sValue.StartsWith("[") && sValue.EndsWith("]"))
                        {
                            // 그룹 설정
                            sValue = sValue.Replace("[", "");
                            sValue = sValue.Replace("]", "");

                            sGroup = sValue;

                            ListOrder.Add(new KeyValuePair<string, string>("GROUP", sValue));
                            ListGroup.Add(sGroup);
                        }
                        else
                        {
                            // 그룹이 없으면 무시함.
                            if (sGroup == "")
                            {
                                continue;
                            }

                            // = 없으면 처리하지 않음
                            if (sValue.IndexOf("=") >= 0)
                            {
                                string[] sSecond = sValue.Split('=');

                                if (sSecond.Length > 2)
                                {
                                    string sSum = "";
                                    for (int i = 1; i < sSecond.Length; i++)
                                    {
                                        if (i == 1)
                                        {
                                            sSum += sSecond[i];
                                        }
                                        else
                                        {
                                            sSum += "=" + sSecond[i];
                                        }
                                    }

                                    this[sGroup, sSecond[0].Trim()] = sSum.Trim();
                                }
                                else
                                {
                                    this[sGroup, sSecond[0].Trim()] = sSecond[1].Trim();
                                }
                            }
                        }
                    }

                    sr.Close();
                    fs.Close();
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 설정된 정보를 파일에 쓴다.
        /// </summary>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        public bool WriteFile(string sFileName)
        {
            try
            {
                FileStream fs = new FileStream(sFileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                string sGroup = "";
                string sPostString = "";

                foreach (KeyValuePair<string, string> k in ListOrder)
                {
                    IniValue iv = null;

                    switch (k.Key)
                    {
                        case "GROUP":
                            if (sGroup != "")
                                sw.WriteLine();

                            sGroup = k.Value;
                            sw.WriteLine("[" + k.Value + "]");
                            break;
                        case "POST":
                            sPostString = k.Value;
                            break;
                        case "ALL":
                            sw.WriteLine(k.Value);
                            sPostString = "";
                            break;
                        //case "BLANK":
                        //    sw.WriteLine();
                        //    break;
                        default:
                            if (sGroup != "")
                            {
                                iv = GetIniValue(sGroup, k.Key);
                            }
                            break;
                    }

                    if (iv != null)
                    {
                        if (sPostString == "")
                        {
                            sw.WriteLine(iv.Key + " = " + iv.Value);
                        }
                        else
                        {
                            sw.WriteLine(iv.Key + " = " + iv.Value + "\t" + sPostString);
                            sPostString = "";
                        }
                    }
                }

                sw.Close();
                fs.Close();

                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }
        #endregion

        #region 리스트 검색 및 반환
        /// <summary>
        /// 그룹에 해당하는 전체리스트를 반환한다. 
        /// 단, 여기서 반환하는 개별 IniValue 에 대해선 수정하면 적용되지만,
        /// 리스트를 변경하는 것은 적용되지 않는다. ( Add, Remove 등 적용 안 됨)
        /// </summary>
        /// <param name="sGroup">검색할 그룹, 공백이면 전체가 반환된다.</param>
        /// <returns>IniValue 리스트</returns>
        public List<IniValue> GetList(string sGroup = "")
        {
            if (sGroup != "")
            {
                // 그룹 조건 있으면, 해당 그룹인 친구들만 반환
                List<IniValue> l = ListData.FindAll
                    (
                       delegate (IniValue v)
                       {
                           return v.Group.ToUpper() == sGroup.ToUpper();
                       }
                    );

                return l;
            }
            else
            {
                // sGroup 이 공백이면, 전체 반환
                List<IniValue> l = new List<IniValue>();

                foreach (string s in ListGroup)
                {
                    l.AddRange
                        (
                            ListData.FindAll
                            (
                               delegate (IniValue v)
                               {
                                   return v.Group.ToUpper() == s.ToUpper();
                               }
                            )
                        );
                }

                return l;
            }
        }

        /// <summary>
        /// 설정된 그룹을 반환한다.
        /// </summary>
        /// <returns></returns>
        public string[] GetGroupList()
        {
            return ListGroup.ToArray();
        }

        public IniValue GetIniValue(string sGroup, string sKey)
        {
            foreach (IniValue iv in ListData)
            {
                if (iv.Group.ToUpper() == sGroup.ToUpper() && iv.Key.ToUpper() == sKey.ToUpper())
                {
                    return iv;
                }
            }

            return null;
        }

        public void Clear()
        {
            ListData.Clear();
            ListGroup.Clear();
            ListOrder.Clear();
        }
        #endregion
    }

    public class IniValue
    {
        public string Group;
        public string Key;
        public string Value;

        public IniValue(string group, string key, string value)
        {
            Group = group;
            Key = key;
            Value = value;
        }
    }
    #endregion

}
