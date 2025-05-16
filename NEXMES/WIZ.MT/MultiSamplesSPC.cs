using System;
using System.Collections.Generic;
using System.Linq;

namespace WIZ.MT
{
    public class MultiSamplesSPC : SPCBase
    {
        /// <summary>
        /// 실제값
        /// </summary>
        private List<List<double>> m_Actual = new List<List<double>>();
        /// <summary>
        /// 샘플 범위의 관리 상한
        /// </summary>
        private double m_UCLr = 0.0;
        /// <summary>
        /// X-Bar 관리 하한
        /// </summary>
        private double m_LCLx = 0.0;
        /// <summary>
        /// 샘플의 범위
        /// </summary>
        private List<double> m_R = new List<double>();
        /// <summary>
        /// 샘픔 범위의 평균
        /// </summary>
        private double m_RBar = 0.0;
        /// <summary>
        /// 샘플의 평균
        /// </summary>
        private List<double> m_X = new List<double>();
        /// <summary>
        /// 샘플 평균의 평균
        /// </summary>
        private double m_XBar = 0.0;
        /// <summary>
        /// X-Bar 관리 상한
        /// </summary>
        private double m_UCLx = 0.0;
        /// <summary>
        /// 샘플 범위의 관리 하한
        /// </summary>
        private double m_LCLr = 0.0;
        /// <summary>
        /// 실제값
        /// </summary>
        public List<List<double>> Actual
        {
            get
            {
                return m_Actual;
            }
            set
            {
                m_Deviation.Clear();
                m_R.Clear();
                m_X.Clear();
                m_Distribution.Clear();

                m_Actual = value;

                m_Z = 0.0;
                double tempZ = 0.0;
                int additionalWidthLeft = 0;
                int additionalWidthRight = 0;
                List<double> tempXList = new List<double>();
                int center = 0;

                //m_ActualSubGroupSize = m_Actual.Count;

                if (m_Actual.Count <= 1)
                {
                    m_Sigma = null;

                    m_Cp = null;
                    m_Cpk = null;
                    m_Pp = null;
                    m_Ppk = null;
                    m_Z = null;
                    return;
                }

                double tempDeviSum = 0.0;

                switch (base.PointMethod)
                {
                    case WIZ.MT.PointMethod.ROUNDED:
                        m_X.Clear();
                        m_R.Clear();

                        m_XBar = 0;
                        int cnt = 0;

                        for (int i = 0; i < m_Actual.Count; i++)
                        {
                            //! 샘플의 평균 계산
                            m_X.Add(Math.Round(m_Actual[i].Average(), base.Point));

                            //! 샘플의 범위 계산
                            m_R.Add(Math.Round(Math.Abs(m_Actual[i].Max() - m_Actual[i].Min()), base.Point));

                            m_XBar += m_Actual[i].Sum();
                            cnt += m_Actual[i].Count;
                        }

                        //! 샘플 평균의 평균 계산
                        m_XBar = m_XBar / cnt;

                        m_Deviation.Clear();

                        for (int i = 0; i < m_Actual.Count; i++)
                        {
                            for (int j = 0; j < m_Actual[i].Count; j++)
                                //! 샘플 평균의 편차 계산
                                m_Deviation.Add(Math.Round(Math.Abs(m_Actual[i][j] - m_XBar), base.Point));
                        }

                        //! 샘플 범위의 평균 계산
                        m_RBar = Math.Round(m_R.Average(), base.Point);

                        //! 중간값 계산
                        tempXList.AddRange(m_X);
                        tempXList.Sort();
                        center = tempXList.Count / 2;
                        if (tempXList.Count % 2 == 1)
                        {
                            m_Median = m_X[center];
                        }
                        else
                        {
                            m_Median = Math.Round((m_X[center - 1] + m_X[center]) / 2.0, base.Point);
                        }

                        //! UCLx 계산
                        m_UCLx = Math.Round(m_XBar + (A2() * m_RBar), base.Point);
                        //! LCLx 계산
                        m_LCLx = Math.Round(m_XBar - (A2() * m_RBar), base.Point);

                        //! UCLr 계산
                        m_UCLr = Math.Round(D4() * m_RBar, base.Point);
                        //! LCLr 계산
                        m_LCLr = Math.Round(D3() * m_RBar, base.Point);

                        if (m_Actual.Count > 0)
                        {
                            if (m_ActualSubGroupSize > 0)
                            {
                                //! 표준편차 계산
                                for (int i = 0; i < m_Deviation.Count; i++)
                                {
                                    tempDeviSum += Math.Round(Math.Pow(m_Deviation[i], 2), base.Point);
                                }

                                m_Sigma = Math.Round(Math.Sqrt((tempDeviSum / (m_Deviation.Count - 1))), base.Point);

                                double sum = 0;
                                int free = 0;

                                for (int i = 0; i < m_Actual.Count; i++)
                                {
                                    for (int j = 0; j < m_Actual[i].Count; j++)
                                    {
                                        sum += Math.Pow(m_Actual[i][j] - m_X[i], 2);
                                    }

                                    free += (m_Actual[i].Count - 1);
                                }

                                m_SigmaWithin = Math.Round(Math.Sqrt((sum / free)) / c4(free + 1), base.Point);

                                if (m_SigmaWithin == 0)
                                {
                                    m_Cp = null;
                                    m_Cpk = null;
                                }
                                else
                                {
                                    switch (base.LimitType)
                                    {
                                        case LimitType.Bilateral:
                                            //! Cp 계산
                                            m_Cp = Math.Round((base.UpperTol - base.LowerTol) / (6 * m_SigmaWithin), base.Point);
                                            //! Cpk 계산
                                            m_Cpk = Math.Round(Math.Min(((m_XBar - base.LowerTol) / (3 * m_SigmaWithin)), ((base.UpperTol - m_XBar) / (3 * m_SigmaWithin))), base.Point);
                                            break;
                                        case LimitType.UnilateralLower:
                                            //! Cp 계산
                                            m_Cp = null;
                                            //! Cpk 계산
                                            m_Cpk = Math.Round(((base.UpperTol - m_XBar) / (3 * m_SigmaWithin)), base.Point);
                                            break;
                                        case LimitType.UnilateralUpper:
                                            //! Cp 계산
                                            m_Cp = null;
                                            //! Cpk 계산
                                            m_Cpk = Math.Round(((m_XBar - base.LowerTol) / (3 * m_SigmaWithin)), base.Point);
                                            break;
                                    }
                                }

                                if (m_Sigma == null || m_Sigma == 0)
                                {
                                    m_Pp = null;
                                    m_Ppk = null;
                                    m_Z = null;
                                }
                                else
                                {
                                    m_Z = Math.Round((Nominal - m_XBar) / Sigma.Value, base.Point);

                                    switch (base.LimitType)
                                    {
                                        case LimitType.Bilateral:
                                            //! Pp 계산
                                            m_Pp = Math.Round((base.UpperTol - base.LowerTol) / (6 * m_Sigma.Value), base.Point);
                                            //! Ppk 계산
                                            m_Ppk = Math.Round(Math.Min(((m_XBar - base.LowerTol) / (3 * m_Sigma.Value)), ((base.UpperTol - m_XBar) / (3 * m_Sigma.Value))), base.Point);
                                            break;
                                        case LimitType.UnilateralLower:
                                            //! Pp 계산
                                            m_Pp = null;
                                            //! Ppk 계산
                                            m_Ppk = Math.Round(((base.UpperTol - m_XBar) / (3 * m_Sigma.Value)), base.Point);
                                            break;
                                        case LimitType.UnilateralUpper:
                                            //! Pp 계산
                                            m_Pp = null;
                                            //! Ppk 계산
                                            m_Ppk = Math.Round(((m_XBar - base.LowerTol) / (3 * m_Sigma.Value)), base.Point);
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                m_Sigma = null;

                                m_Cp = null;
                                m_Cpk = null;
                                m_Pp = null;
                                m_Ppk = null;
                                m_Z = null;
                            }
                        }
                        else
                        {
                            m_Sigma = null;

                            m_Cp = null;
                            m_Cpk = null;
                            m_Pp = null;
                            m_Ppk = null;
                            m_Z = null;
                        }

                        // 구간 설정
                        m_FrequencyCount = (int)(Math.Round(Math.Sqrt(m_Actual.Count), 0)) + 1;
                        // 구간 폭
                        m_FrequencyWidth = Math.Round(Math.Ceiling((m_RBar / m_FrequencyCount) * 1000.0) / 1000.0, base.Point);
                        // 아래 경계
                        m_LowerLimit = Math.Round(Math.Round((m_X.Min() - m_FrequencyWidth / 2.0), 3), base.Point);
                        // 첫 구간경계
                        m_FirstFrequency = Math.Round(m_LowerLimit - (m_FrequencyWidth * 2.0), base.Point);

                        // 추가 구간 계산
                        additionalWidthLeft = (int)Math.Ceiling(Math.Abs(Math.Min(LowerTol, (m_XBar - (3.0 * m_Sigma.Value))) - m_FirstFrequency) / m_FrequencyWidth);

                        // 분포 계산
                        for (int i = 0; i < m_FrequencyCount; i++)
                        {
                            if (i == 0)
                            {
                                m_Distribution.Add(m_FirstFrequency);
                            }
                            else
                            {
                                m_Distribution.Add(Math.Round(m_FirstFrequency + (m_FrequencyWidth * i), base.Point));
                            }
                        }

                        additionalWidthRight = (int)Math.Ceiling(Math.Abs(Math.Max(UpperTol, (m_XBar + (3.0 * m_Sigma.Value))) - m_Distribution[m_Distribution.Count - 1]) / m_FrequencyWidth);

                        // 추가구간 분포 계산
                        for (int i = 1; i <= additionalWidthLeft; i++)
                        {
                            m_Distribution.Insert(0, m_FirstFrequency - (m_FrequencyWidth * i));
                        }

                        for (int i = 1; i <= additionalWidthRight; i++)
                        {
                            m_Distribution.Add(m_Distribution[m_Distribution.Count - 1] + m_FrequencyWidth);
                        }

                        m_NormalDistribution.Clear();
                        for (int i = 0; i < m_Distribution.Count; i++)
                        {
                            if (!(m_Sigma == null || m_Sigma.Value == 0))
                            {
                                tempZ = Math.Round(((m_Distribution[i] - m_XBar) / m_Sigma.Value), base.Point);
                            }
                            else
                            {
                                tempZ = 0.0;
                            }

                            m_NormalDistribution.Add(new PointD(m_Distribution[i], Math.Round(((1 / (Math.Sqrt(2.0 * Math.PI))) * Math.Exp(-Math.Pow(tempZ, 2.0) / 2.0)), base.Point)));
                        }

                        for (int i = 0; i <= m_Distribution.Count - 1; i++)
                        {
                            int count = 0;
                            if (i == 0)
                            {
                                foreach (double v in m_X)
                                {
                                    if (v <= m_Distribution[i])
                                    {
                                        count += 1;
                                    }
                                }
                            }
                            else if (i == m_Distribution.Count - 1)
                            {
                                foreach (double v in m_X)
                                {
                                    if (v >= m_Distribution[i])
                                    {
                                        count += 1;
                                    }
                                }
                            }
                            else
                            {
                                foreach (double v in m_X)
                                {
                                    if (m_Distribution[i] <= v & v < m_Distribution[i + 1])
                                    {
                                        count += 1;
                                    }
                                }
                            }
                            m_Frequency.Add(count);

                            // Nominal, UTol, LTol 계산
                            if (i <= m_Distribution.Count - 2)
                            {
                                if (m_Distribution[i] <= Nominal & Nominal < m_Distribution[i + 1])
                                {

                                    m_NominalList.Add(true);
                                }
                                else
                                {
                                    m_NominalList.Add(false);
                                }

                                if (m_Distribution[i] <= UpperTol & UpperTol < m_Distribution[i + 1])
                                {
                                    m_UTolList.Add(true);
                                }
                                else
                                {
                                    m_UTolList.Add(false);
                                }

                                if (m_Distribution[i] <= LowerTol & LowerTol < m_Distribution[i + 1])
                                {
                                    m_LTolList.Add(true);
                                }
                                else
                                {
                                    m_LTolList.Add(false);
                                }
                            }
                        }
                        break;
                    case WIZ.MT.PointMethod.TRUNCATE:
                        break;
                    default:
                        m_X.Clear();
                        m_R.Clear();

                        //// 임시 자료 저장용 리스트 생성
                        //tempSub = null;
                        //tempList = new List<List<double>>(m_Actual[0].Count);

                        //for (int i = 0; i < m_Actual[0].Count; i++)
                        //{
                        //    tempSub = new List<double>();
                        //    for (int j = 0; j < m_Actual.Count; j++)
                        //    {
                        //        tempSub.Add(0.0);
                        //    }
                        //    tempList.Add(tempSub);
                        //}

                        //for (int i = 0; i < m_Actual.Count; i++)
                        //{
                        //    for (int j = 0; j < m_Actual[i].Count; j++)
                        //    {
                        //        tempList[j][i] = m_Actual[i][j];
                        //    }
                        //}

                        //for (int i = 0; i < tempList.Count; i++)
                        //{
                        //    //! 샘플의 평균 계산
                        //    m_X.Add(tempList[i].Average());

                        //    //! 샘플의 범위 계산
                        //    m_R.Add(Math.Abs(tempList[i].Max() - tempList[i].Min()));
                        //}

                        for (int i = 0; i < m_Actual.Count; i++)
                        {
                            //! 샘플의 평균 계산
                            m_X.Add(m_Actual[i].Average());

                            //! 샘플의 범위 계산
                            m_R.Add(Math.Abs(m_Actual[i].Max() - m_Actual[i].Min()));
                        }

                        //! 샘플 평균의 평균 계산
                        m_XBar = m_X.Average();

                        //! 샘플 범위의 평균 계산
                        m_RBar = m_R.Average();

                        //! 중간값 계산
                        tempXList.AddRange(m_X);
                        tempXList.Sort();
                        center = tempXList.Count / 2;
                        if (tempXList.Count % 2 == 1)
                        {
                            m_Median = m_X[center];
                        }
                        else
                        {
                            m_Median = (m_X[center - 1] + m_X[center]) / 2.0;
                        }

                        m_Deviation.Clear();
                        for (int i = 0; i < m_X.Count; i++)
                        {
                            //! 샘플 평균의 편차 계산
                            m_Deviation.Add(Math.Abs(m_X[i] - m_XBar));
                        }

                        //! UCLx 계산
                        m_UCLx = m_XBar + (A2() * m_RBar);
                        //! LCLx 계산
                        m_LCLx = m_XBar - (A2() * m_RBar);

                        //! UCLr 계산
                        m_UCLr = D4() * m_RBar;
                        //! LCLr 계산
                        m_LCLr = D3() * m_RBar;

                        if (m_Actual.Count > 0)
                        {
                            if (m_ActualSubGroupSize > 0)
                            {
                                //! 표준편차 계산
                                for (int i = 0; i < m_Deviation.Count; i++)
                                {
                                    tempDeviSum += Math.Pow(m_Deviation[i], 2);
                                }

                                m_Sigma = Math.Sqrt((tempDeviSum / m_Actual.Count));

                                //! 샘플 범위의 표준편차 계산
                                m_SigmaWithin = m_RBar / D2();

                                if (m_SigmaWithin == 0)
                                {
                                    m_Cp = null;
                                    m_Cpk = null;
                                }
                                else
                                {
                                    switch (base.LimitType)
                                    {
                                        case LimitType.Bilateral:
                                            //! Cp 계산
                                            m_Cp = (base.UpperTol - base.LowerTol) / (6 * m_SigmaWithin);
                                            //! Cpk 계산
                                            m_Cpk = Math.Min(((m_XBar - base.LowerTol) / (3 * m_SigmaWithin)), ((base.UpperTol - m_XBar) / (3 * m_SigmaWithin)));
                                            break;
                                        case LimitType.UnilateralLower:
                                            //! Cp 계산
                                            m_Cp = null;
                                            //! Cpk 계산
                                            m_Cpk = (base.UpperTol - m_XBar) / (3 * m_SigmaWithin);
                                            break;
                                        case LimitType.UnilateralUpper:
                                            //! Cp 계산
                                            m_Cp = null;
                                            //! Cpk 계산
                                            m_Cpk = (m_XBar - base.LowerTol) / (3 * m_SigmaWithin);
                                            break;
                                    }
                                }

                                if (m_Sigma == null || m_Sigma == 0)
                                {
                                    m_Pp = null;
                                    m_Ppk = null;
                                    m_Z = null;
                                }
                                else
                                {
                                    m_Z = (Nominal - m_XBar) / Sigma.Value;

                                    switch (base.LimitType)
                                    {
                                        case LimitType.Bilateral:
                                            //! Pp 계산
                                            m_Pp = (base.UpperTol - base.LowerTol) / (6 * m_Sigma);
                                            //! Ppk 계산
                                            m_Ppk = Math.Min(((m_XBar - base.LowerTol) / (3 * m_Sigma.Value)), ((base.UpperTol - m_XBar) / (3 * m_Sigma.Value)));
                                            break;
                                        case LimitType.UnilateralLower:
                                            //! Pp 계산
                                            m_Pp = null;
                                            //! Ppk 계산
                                            m_Ppk = (base.UpperTol - m_XBar) / (3 * m_Sigma.Value);
                                            break;
                                        case LimitType.UnilateralUpper:
                                            //! Pp 계산
                                            m_Pp = null;
                                            //! Ppk 계산
                                            m_Ppk = (m_XBar - base.LowerTol) / (3 * m_Sigma.Value);
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                m_Sigma = null;

                                m_Cp = null;
                                m_Cpk = null;
                                m_Pp = null;
                                m_Ppk = null;
                                m_Z = null;
                            }
                        }
                        else
                        {
                            m_Sigma = null;

                            m_Cp = null;
                            m_Cpk = null;
                            m_Pp = null;
                            m_Ppk = null;
                            m_Z = null;
                        }

                        // 구간 설정
                        m_FrequencyCount = (int)(Math.Round(Math.Sqrt(m_Actual.Count), 0)) + 1;
                        // 구간 폭
                        m_FrequencyWidth = Math.Ceiling((m_RBar / m_FrequencyCount) * 1000.0) / 1000.0;
                        // 아래 경계
                        m_LowerLimit = Math.Round((m_X.Min() - m_FrequencyWidth / 2.0), 3);
                        // 첫 구간경계
                        m_FirstFrequency = m_LowerLimit - (m_FrequencyWidth * 2.0);

                        // 추가 구간 계산
                        additionalWidthLeft = (int)Math.Ceiling(Math.Abs(Math.Min(LowerTol, (m_XBar - (3.0 * m_Sigma.Value))) - m_FirstFrequency) / m_FrequencyWidth);

                        // 분포 계산
                        for (int i = 0; i < m_FrequencyCount; i++)
                        {
                            if (i == 0)
                            {
                                m_Distribution.Add(m_FirstFrequency);
                            }
                            else
                            {
                                m_Distribution.Add(m_FirstFrequency + (m_FrequencyWidth * i));
                            }
                        }

                        additionalWidthRight = (int)Math.Ceiling(Math.Abs(Math.Max(UpperTol, (m_XBar + (3.0 * m_Sigma.Value))) - m_Distribution[m_Distribution.Count - 1]) / m_FrequencyWidth);

                        // 추가구간 분포 계산
                        for (int i = 1; i <= additionalWidthLeft; i++)
                        {
                            m_Distribution.Insert(0, m_FirstFrequency - (m_FrequencyWidth * i));
                        }

                        for (int i = 1; i <= additionalWidthRight; i++)
                        {
                            m_Distribution.Add(m_Distribution[m_Distribution.Count - 1] + m_FrequencyWidth);
                        }

                        m_NormalDistribution.Clear();
                        for (int i = 0; i < m_Distribution.Count; i++)
                        {
                            if (!(m_Sigma == null || m_Sigma.Value == 0))
                            {
                                tempZ = ((m_Distribution[i] - m_XBar) / m_Sigma.Value);
                            }
                            else
                            {
                                tempZ = 0.0;
                            }

                            m_NormalDistribution.Add(new PointD(m_Distribution[i], ((1 / (Math.Sqrt(2.0 * Math.PI))) * Math.Exp(-Math.Pow(tempZ, 2.0) / 2.0))));
                        }

                        for (int i = 0; i <= m_Distribution.Count - 1; i++)
                        {
                            int count = 0;
                            if (i == 0)
                            {
                                foreach (double v in m_X)
                                {
                                    if (v <= m_Distribution[i])
                                    {
                                        count += 1;
                                    }
                                }
                            }
                            else if (i == m_Distribution.Count - 1)
                            {
                                foreach (double v in m_X)
                                {
                                    if (v >= m_Distribution[i])
                                    {
                                        count += 1;
                                    }
                                }
                            }
                            else
                            {
                                foreach (double v in m_X)
                                {
                                    if (m_Distribution[i] <= v & v < m_Distribution[i + 1])
                                    {
                                        count += 1;
                                    }
                                }
                            }
                            m_Frequency.Add(count);

                            // Nominal, UTol, LTol 계산
                            if (i <= m_Distribution.Count - 2)
                            {
                                if (m_Distribution[i] <= Nominal & Nominal < m_Distribution[i + 1])
                                {

                                    m_NominalList.Add(true);
                                }
                                else
                                {
                                    m_NominalList.Add(false);
                                }

                                if (m_Distribution[i] <= UpperTol & UpperTol < m_Distribution[i + 1])
                                {
                                    m_UTolList.Add(true);
                                }
                                else
                                {
                                    m_UTolList.Add(false);
                                }

                                if (m_Distribution[i] <= LowerTol & LowerTol < m_Distribution[i + 1])
                                {
                                    m_LTolList.Add(true);
                                }
                                else
                                {
                                    m_LTolList.Add(false);
                                }
                            }
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// X-Bar 관리 하한
        /// </summary>
        public double LCLx
        {
            get
            {
                return m_LCLx;
            }
        }

        /// <summary>
        /// 샘플의 범위
        /// </summary>
        public List<double> R
        {
            get
            {
                return m_R;
            }
        }

        /// <summary>
        /// 샘픔 범위의 평균
        /// </summary>
        public double R_Bar
        {
            get
            {
                return m_RBar;
            }
        }



        /// <summary>
        /// 샘플 범위의 관리 상한
        /// </summary>
        public double UCLr
        {
            get
            {
                return m_UCLr;
            }
        }

        /// <summary>
        /// 샘플 범위의 관리 하한
        /// </summary>
        public double LCLr
        {
            get
            {
                return m_LCLr;
            }
        }

        /// <summary>
        /// X-Bar 관리 상한
        /// </summary>
        public double UCLx
        {
            get
            {
                return m_UCLx;
            }
        }

        /// <summary>
        /// 샘플의 평균
        /// </summary>
        public List<double> X
        {
            get
            {
                return m_X;
            }
        }

        /// <summary>
        /// 샘플 평균의 평균
        /// </summary>
        public double X_Bar
        {
            get
            {
                return m_XBar;
            }
        }

        private double A2()
        {
            if (m_ActualSubGroupSize == 0)
            {
                return 0.0;
            }
            else
            {
                switch (m_ActualSubGroupSize)
                {
                    case 2:
                        return 1.880;
                    case 3:
                        return 1.023;
                    case 4:
                        return 0.729;
                    case 5:
                        return 0.577;
                    case 6:
                        return 0.483;
                    case 7:
                        return 0.419;
                    case 8:
                        return 0.373;
                    case 9:
                        return 0.337;
                    case 10:
                        return 0.308;
                    case 11:
                        return 0.285;
                    case 12:
                        return 0.266;
                    case 13:
                        return 0.249;
                    case 14:
                        return 0.235;
                    case 15:
                        return 0.223;
                    case 16:
                        return 0.212;
                    case 17:
                        return 0.203;
                    case 18:
                        return 0.194;
                    case 19:
                        return 0.187;
                    case 20:
                        return 0.180;
                    case 21:
                        return 0.173;
                    case 22:
                        return 0.167;
                    case 23:
                        return 0.162;
                    case 24:
                        return 0.157;
                    case 25:
                        return 0.153;
                }
            }

            return 1.880;
        }

        private double D2()
        {
            if (m_ActualSubGroupSize == 0)
            {
                return 0.0;
            }
            else
            {
                switch (m_ActualSubGroupSize)
                {
                    case 2:
                        return 1.128;
                    case 3:
                        return 1.693;
                    case 4:
                        return 2.059;
                    case 5:
                        return 2.326;
                    case 6:
                        return 2.534;
                    case 7:
                        return 2.704;
                    case 8:
                        return 2.847;
                    case 9:
                        return 2.970;
                    case 10:
                        return 3.078;
                    case 11:
                        return 3.173;
                    case 12:
                        return 3.258;
                    case 13:
                        return 3.336;
                    case 14:
                        return 3.407;
                    case 15:
                        return 3.472;
                    case 16:
                        return 3.532;
                    case 17:
                        return 3.588;
                    case 18:
                        return 3.640;
                    case 19:
                        return 3.689;
                    case 20:
                        return 3.735;
                    case 21:
                        return 3.778;
                    case 22:
                        return 3.819;
                    case 23:
                        return 3.858;
                    case 24:
                        return 3.895;
                    case 25:
                        return 3.931;
                }
            }

            return 1.128;
        }

        private double D3()
        {
            if (m_ActualSubGroupSize == 0)
            {
                return 0.0;
            }
            else
            {
                switch (m_ActualSubGroupSize)
                {
                    case 2:
                        return 0.0;
                    case 3:
                        return 0.0;
                    case 4:
                        return 0.0;
                    case 5:
                        return 0.0;
                    case 6:
                        return 0.0;
                    case 7:
                        return 0.076;
                    case 8:
                        return 0.136;
                    case 9:
                        return 0.184;
                    case 10:
                        return 0.223;
                    case 11:
                        return 0.256;
                    case 12:
                        return 0.283;
                    case 13:
                        return 0.307;
                    case 14:
                        return 0.328;
                    case 15:
                        return 0.347;
                    case 16:
                        return 0.363;
                    case 17:
                        return 0.378;
                    case 18:
                        return 0.391;
                    case 19:
                        return 0.403;
                    case 20:
                        return 0.415;
                    case 21:
                        return 0.425;
                    case 22:
                        return 0.434;
                    case 23:
                        return 0.443;
                    case 24:
                        return 0.451;
                    case 25:
                        return 0.459;
                }
            }

            return 0.0;
        }

        private double D4()
        {
            if (m_ActualSubGroupSize == 0)
            {
                return 0.0;
            }
            else
            {
                switch (m_ActualSubGroupSize)
                {
                    case 2:
                        return 3.268;
                    case 3:
                        return 2.574;
                    case 4:
                        return 2.282;
                    case 5:
                        return 2.114;
                    case 6:
                        return 2.004;
                    case 7:
                        return 1.924;
                    case 8:
                        return 1.864;
                    case 9:
                        return 1.816;
                    case 10:
                        return 1.777;
                    case 11:
                        return 1.744;
                    case 12:
                        return 1.717;
                    case 13:
                        return 1.693;
                    case 14:
                        return 1.672;
                    case 15:
                        return 1.653;
                    case 16:
                        return 1.637;
                    case 17:
                        return 1.622;
                    case 18:
                        return 1.608;
                    case 19:
                        return 1.597;
                    case 20:
                        return 1.585;
                    case 21:
                        return 1.575;
                    case 22:
                        return 1.566;
                    case 23:
                        return 1.557;
                    case 24:
                        return 1.548;
                    case 25:
                        return 1.541;
                }
            }

            return 3.268;
        }

        private double c4(int n)
        {
            switch (n)
            {
                case 2:
                    return 0.797885;
                case 3:
                    return 0.886227;
                case 4:
                    return 0.921318;
                case 5:
                    return 0.939986;
                case 6:
                    return 0.951533;
                case 7:
                    return 0.959369;
                case 8:
                    return 0.965030;
                case 9:
                    return 0.969311;
                case 10:
                    return 0.972659;
                case 11:
                    return 0.975350;
                case 12:
                    return 0.977559;
                case 13:
                    return 0.979406;
                case 14:
                    return 0.980971;
                case 15:
                    return 0.982316;
                case 16:
                    return 0.983484;
                case 17:
                    return 0.984506;
                case 18:
                    return 0.985410;
                case 19:
                    return 0.986214;
                case 20:
                    return 0.986934;
                case 21:
                    return 0.987583;
                case 22:
                    return 0.988170;
                case 23:
                    return 0.988705;
                case 24:
                    return 0.989193;
                case 25:
                    return 0.989640;
                case 26:
                    return 0.990052;
                case 27:
                    return 0.990433;
                case 28:
                    return 0.990786;
                case 29:
                    return 0.991113;
                case 30:
                    return 0.991418;
                case 31:
                    return 0.991703;
                case 32:
                    return 0.991969;
                case 33:
                    return 0.992219;
                case 34:
                    return 0.992454;
                case 35:
                    return 0.992675;
                case 36:
                    return 0.992884;
                case 37:
                    return 0.993080;
                case 38:
                    return 0.993267;
                case 39:
                    return 0.993443;
                case 40:
                    return 0.993611;
                case 41:
                    return 0.993770;
                case 42:
                    return 0.993922;
                case 43:
                    return 0.994066;
                case 44:
                    return 0.994203;
                case 45:
                    return 0.994335;
                case 46:
                    return 0.994460;
                case 47:
                    return 0.994580;
                case 48:
                    return 0.994695;
                case 49:
                    return 0.994806;
                case 50:
                    return 0.994911;
                case 51:
                    return 0.995013;
                case 52:
                    return 0.995110;
                case 53:
                    return 0.995204;
                case 54:
                    return 0.995294;
                case 55:
                    return 0.995381;
                case 56:
                    return 0.995465;
                case 57:
                    return 0.995546;
                case 58:
                    return 0.995624;
                case 59:
                    return 0.995699;
                case 60:
                    return 0.995772;
                case 61:
                    return 0.995842;
                case 62:
                    return 0.995910;
                case 63:
                    return 0.995976;
                case 64:
                    return 0.996040;
                case 65:
                    return 0.996102;
                case 66:
                    return 0.996161;
                case 67:
                    return 0.996219;
                case 68:
                    return 0.996276;
                case 69:
                    return 0.996330;
                case 70:
                    return 0.996383;
                case 71:
                    return 0.996435;
                case 72:
                    return 0.996485;
                case 73:
                    return 0.996534;
                case 74:
                    return 0.996581;
                case 75:
                    return 0.996627;
                case 76:
                    return 0.996672;
                case 77:
                    return 0.996716;
                case 78:
                    return 0.996759;
                case 79:
                    return 0.996800;
                case 80:
                    return 0.996841;
                case 81:
                    return 0.996880;
                case 82:
                    return 0.996918;
                case 83:
                    return 0.996956;
                case 84:
                    return 0.996993;
                case 85:
                    return 0.997028;
                case 86:
                    return 0.997063;
                case 87:
                    return 0.997097;
                case 88:
                    return 0.997131;
                case 89:
                    return 0.997163;
                case 90:
                    return 0.997195;
                case 91:
                    return 0.997226;
                case 92:
                    return 0.997257;
                case 93:
                    return 0.997286;
                case 94:
                    return 0.997315;
                case 95:
                    return 0.997344;
                case 96:
                    return 0.997372;
                case 97:
                    return 0.997399;
                case 98:
                    return 0.997426;
                case 99:
                    return 0.997452;
                case 100:
                    return 0.997478;
            }

            double result = (double)4 * (n - 1) / ((double)4 * n - 3);
            return Math.Round(result, 6);
        }

    }
}
