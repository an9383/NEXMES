using System;
using System.Collections.Generic;
using System.Linq;

namespace WIZ.MT
{
    public class SingleSampleSPC : SPCBase
    {
        /// <summary>
        /// 실제값
        /// </summary>
        private List<double> m_Actual = new List<double>();
        /// <summary>
        /// 실제값의 평균
        /// </summary>
        private double m_XBar = 0.0;
        /// <summary>
        /// Moving Range
        /// </summary>
        private List<double> m_mR = new List<double>();
        /// <summary>
        /// Moving Range의 평균
        /// </summary>
        private double m_mRBar = 0.0;
        /// <summary>
        /// X-Bar 관리 상한
        /// </summary>
        private double m_UCLx = 0.0;
        /// <summary>
        /// X-Bar 관리 하한
        /// </summary>
        private double m_LCLx = 0.0;
        /// <summary>
        /// mR-Bar 관리 상한
        /// </summary>
        private double m_UCLmR = 0.0;
        /// <summary>
        /// mR-Bar 관리 하한
        /// </summary>
        private double m_LCLmR = 0.0;
        /// <summary>
        /// 실제값
        /// </summary>
        public List<double> Actual
        {
            get
            {
                return m_Actual;
            }
            set
            {
                m_Distribution.Clear();
                m_Frequency.Clear();
                m_Deviation.Clear();
                m_mR.Clear();

                m_Actual = value;

                m_Z = 0.0;
                double tempDeviSum = 0.0;
                double tempZ = 0.0;
                int additionalWidthLeft = 0;
                int additionalWidthRight = 0;
                List<double> tempXList = new List<double>();
                int center = 0;

                if (m_Actual.Count <= 1)
                {
                    m_Sigma = null;

                    m_Cp = null;
                    m_Cpk = null;
                    m_Pp = null;
                    m_Ppk = null;
                    return;
                }

                switch (base.PointMethod)
                {
                    case PointMethod.ROUNDED:
                        //! 평균 계산 (X_Bar)
                        m_XBar = Math.Round(m_Actual.Average(), base.Point);

                        //! 중간값 계산
                        tempXList.AddRange(m_Actual);
                        tempXList.Sort();
                        center = tempXList.Count / 2;
                        if (tempXList.Count % 2 == 1)
                        {
                            m_Median = m_Actual[center];
                        }
                        else
                        {
                            m_Median = Math.Round((m_Actual[center - 1] + m_Actual[center]) / 2.0, base.Point);
                        }

                        m_Deviation.Clear();
                        m_mR.Clear();
                        for (int i = 0; i < m_Actual.Count; i++)
                        {
                            // ! 편차 계산
                            m_Deviation.Add(Math.Round(Math.Abs(m_Actual[i] - m_XBar), base.Point));

                            //! Moving Range 계산
                            if (i > 0)
                            {
                                m_mR.Add(Math.Round(Math.Abs(m_Actual[i] - m_Actual[i - 1]), base.Point));
                            }
                        }

                        // TODO Actual 값이 1개일 경우 오류 발생

                        //! Moving Range 평균 계산 (mR_Bar)
                        m_mRBar = Math.Round(m_mR.Average(), base.Point);

                        //! Moving Range의 표준편차 계산
                        m_SigmaWithin = Math.Round(m_mRBar / 1.128, base.Point);

                        //! UCLx 계산
                        m_UCLx = Math.Round(m_XBar + (2.66 * m_mRBar), base.Point);

                        //! LCLx 계산
                        m_LCLx = Math.Round(m_XBar - (2.66 * m_mRBar), base.Point);

                        //! UCLmR 계산
                        m_UCLmR = Math.Round(3.268 * m_mRBar, base.Point);

                        //! 표준편차 계산
                        if (m_Actual.Count == 0)
                        {
                            m_Sigma = null;
                            m_Cp = null;
                            m_Cpk = null;
                            m_Pp = null;
                            m_Ppk = null;
                            m_Z = null;
                        }
                        else
                        {
                            for (int i = 0; i < m_Deviation.Count; i++)
                            {
                                tempDeviSum += Math.Pow(m_Deviation[i], 2);
                            }

                            m_Sigma = Math.Round(Math.Sqrt((tempDeviSum / (m_Actual.Count - 1))), base.Point);

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

                        // 구간 설정
                        m_FrequencyCount = (int)(Math.Round(Math.Sqrt(m_Actual.Count), 0)) + 1;
                        // 구간 폭
                        m_FrequencyWidth = Math.Round(Math.Ceiling((m_mRBar / m_FrequencyCount) * 1000.0) / 1000.0, base.Point);
                        // 아래 경계
                        m_LowerLimit = Math.Round(Math.Round((m_Actual.Min() - m_FrequencyWidth / 2.0), 3), base.Point);
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
                                foreach (double v in m_Actual)
                                {
                                    if (v <= m_Distribution[i])
                                    {
                                        count += 1;
                                    }
                                }
                            }
                            else if (i == m_Distribution.Count - 1)
                            {
                                foreach (double v in m_Actual)
                                {
                                    if (v >= m_Distribution[i])
                                    {
                                        count += 1;
                                    }
                                }
                            }
                            else
                            {
                                foreach (double v in m_Actual)
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
                    case PointMethod.TRUNCATE:
                        break;
                    default:
                        //! 평균 계산 (X_Bar)
                        m_XBar = m_Actual.Average();

                        //! 중간값 계산
                        tempXList.AddRange(m_Actual);
                        tempXList.Sort();
                        center = tempXList.Count / 2;
                        if (tempXList.Count % 2 == 1)
                        {
                            m_Median = m_Actual[center];
                        }
                        else
                        {
                            m_Median = (m_Actual[center - 1] + m_Actual[center]) / 2.0;
                        }

                        m_Deviation.Clear();
                        m_mR.Clear();
                        for (int i = 0; i < m_Actual.Count; i++)
                        {
                            // ! 편차 계산
                            m_Deviation.Add(Math.Abs(m_Actual[i] - m_XBar));

                            //! Moving Range 계산
                            if (i > 0)
                            {
                                m_mR.Add(Math.Abs(m_Actual[i] - m_Actual[i - 1]));
                            }
                        }

                        //! Moving Range 평균 계산 (mR_Bar)
                        m_mRBar = m_mR.Average();

                        //! Moving Range의 표준편차 계산
                        m_SigmaWithin = m_mRBar / 1.128;

                        //! UCLx 계산
                        m_UCLx = m_XBar + (2.66 * m_mRBar);

                        //! LCLx 계산
                        m_LCLx = m_XBar - (2.66 * m_mRBar);

                        //! UCLmR 계산
                        m_UCLmR = 3.268 * m_mRBar;

                        //! 표준편차 계산
                        if (m_Actual.Count == 0)
                        {
                            m_Sigma = null;
                            m_Cp = null;
                            m_Cpk = null;
                            m_Pp = null;
                            m_Ppk = null;
                            m_Z = null;
                        }
                        else
                        {
                            for (int i = 0; i < m_Deviation.Count; i++)
                            {
                                tempDeviSum += Math.Pow(m_Deviation[i], 2);
                            }

                            m_Sigma = Math.Sqrt((tempDeviSum / (m_Actual.Count - 1)));
                            m_Sigma = m_SigmaWithin;

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
                                        m_Cpk = ((base.UpperTol - m_XBar) / (3 * m_SigmaWithin));
                                        break;
                                    case LimitType.UnilateralUpper:
                                        //! Cp 계산
                                        m_Cp = null;
                                        //! Cpk 계산
                                        m_Cpk = ((m_XBar - base.LowerTol) / (3 * m_SigmaWithin));
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
                                        m_Pp = (base.UpperTol - base.LowerTol) / (6 * m_Sigma.Value);
                                        //! Ppk 계산
                                        m_Ppk = Math.Min(((m_XBar - base.LowerTol) / (3 * m_Sigma.Value)), ((base.UpperTol - m_XBar) / (3 * m_Sigma.Value)));
                                        break;
                                    case LimitType.UnilateralLower:
                                        //! Pp 계산
                                        m_Pp = null;
                                        //! Ppk 계산
                                        m_Ppk = ((base.UpperTol - m_XBar) / (3 * m_Sigma.Value));
                                        break;
                                    case LimitType.UnilateralUpper:
                                        //! Pp 계산
                                        m_Pp = null;
                                        //! Ppk 계산
                                        m_Ppk = ((m_XBar - base.LowerTol) / (3 * m_Sigma.Value));
                                        break;
                                }
                            }
                        }

                        // 구간 설정
                        m_FrequencyCount = (int)(Math.Round(Math.Sqrt(m_Actual.Count), 0)) + 1;
                        // 구간 폭
                        m_FrequencyWidth = Math.Ceiling((m_mRBar / m_FrequencyCount) * 1000.0) / 1000.0;
                        // 아래 경계
                        m_LowerLimit = Math.Round((m_Actual.Min() - m_FrequencyWidth / 2.0), 3);
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
                                foreach (double v in m_Actual)
                                {
                                    if (v <= m_Distribution[i])
                                    {
                                        count += 1;
                                    }
                                }
                            }
                            else if (i == m_Distribution.Count - 1)
                            {
                                foreach (double v in m_Actual)
                                {
                                    if (v >= m_Distribution[i])
                                    {
                                        count += 1;
                                    }
                                }
                            }
                            else
                            {
                                foreach (double v in m_Actual)
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
        /// 실제값의 평균
        /// </summary>
        public double X_Bar
        {
            get
            {
                return m_XBar;
            }
        }

        /// <summary>
        /// Moving Range
        /// </summary>
        public List<double> mR
        {
            get
            {
                return m_mR;
            }
        }

        /// <summary>
        /// Moving Range의 평균
        /// </summary>
        public double mR_Bar
        {
            get
            {
                return m_mRBar;
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
        /// mR-Bar 관리 상한
        /// </summary>
        public double UCLmR
        {
            get
            {
                return m_UCLmR;
            }
        }

        /// <summary>
        /// mR-Bar 관리 하한
        /// </summary>
        public double LCLmR
        {
            get
            {
                return m_LCLmR;
            }
        }
    }
}
