using System.Collections.Generic;
using System.Drawing;

namespace WIZ.MT
{
    /// <summary>
    /// SPC 관리요소 베이스 클래스
    /// </summary>
    /// <remarks>기본 SPC Helper 클래스 요소 정의</remarks>
    public abstract class SPCBase
    {
        /// <summary>
        /// 기준값
        /// </summary>
        private double m_Nominal = 0.0;
        /// <summary>
        /// 하한공차
        /// </summary>
        private double m_LowerTolOffset = 0.0;
        /// <summary>
        /// 하한공차 결과값
        /// </summary>
        private double m_LowerTol = 0.0;
        /// <summary>
        /// 상한공차
        /// </summary>
        private double m_UpperTol = 0.0;
        /// <summary>
        /// 상한공차 결과값
        /// </summary>
        private double m_UpperTolOffset = 0.0;
        /// <summary>
        /// 소수점
        /// </summary>
        private int m_Point = 6;
        /// <summary>
        /// 소수점 자리 처리 방법
        /// </summary>
        private PointMethod m_PointMethod = PointMethod.ROUNDED;
        /// <summary>
        /// 공차 타입
        /// </summary>
        private LimitType m_LimitType = LimitType.Bilateral;

        /// <summary>
        /// Cp
        /// </summary>
        protected double? m_Cp = null;
        /// <summary>
        /// Cpk
        /// </summary>
        protected double? m_Cpk = null;
        /// <summary>
        /// Pp
        /// </summary>
        protected double? m_Pp = null;
        /// <summary>
        /// Ppk
        /// </summary>
        protected double? m_Ppk = null;
        /// <summary>
        /// 표준편차
        /// </summary>
        protected double? m_Sigma = null;
        /// <summary>
        /// Movig Range의 표준편차
        /// </summary>
        protected double m_SigmaWithin = 0.0;
        /// <summary>
        /// 샘플 평균의 편차
        /// </summary>
        protected List<double> m_Deviation = new List<double>();
        /// <summary>
        /// 도수분포 빈도
        /// </summary>
        protected List<int> m_Frequency = new List<int>();
        /// <summary>
        /// 도수분포 구간
        /// </summary>
        protected int m_FrequencyCount;
        /// <summary>
        /// 도수분포 구간 폭
        /// </summary>
        protected double m_FrequencyWidth;
        /// <summary>
        /// 도수분포 첫 구간경계
        /// </summary>
        protected double m_FirstFrequency;
        /// <summary>
        /// 표준정규분포 Z
        /// </summary>
        protected double? m_Z = null;
        /// <summary>
        /// 중간값
        /// </summary>
        protected double m_Median = 0.0;
        /// <summary>
        /// 도수분포 분산
        /// </summary>
        protected List<double> m_Distribution = new List<double>();
        /// <summary>
        /// 도수분포 최소경계값
        /// </summary>
        protected double m_LowerLimit;
        /// <summary>
        /// 실제 입력받은 측정값의 서브그룹 사이즈
        /// </summary>
        protected int m_ActualSubGroupSize = 1;

        /// <summary>
        /// 기준값
        /// </summary>
        /// <remarks></remarks>
        /// <value></value>
        public double Nominal
        {
            get
            {
                return m_Nominal;
            }
            set
            {
                m_Nominal = value;
            }
        }

        /// <summary>
        /// 상한공차
        /// </summary>
        public double UpperTolOffset
        {
            get
            {
                return m_UpperTolOffset;
            }
            set
            {
                m_UpperTolOffset = value;
                m_UpperTol = m_Nominal + m_UpperTolOffset;
            }
        }

        /// <summary>
        /// 하한공차
        /// </summary>
        public double LowerTolOffset
        {
            get
            {
                return m_LowerTolOffset;
            }
            set
            {
                m_LowerTolOffset = value;
                m_LowerTol = m_Nominal + m_LowerTolOffset;
            }
        }

        /// <summary>
        /// 상한공차 결과값
        /// </summary>
        public double UpperTol
        {
            get
            {
                return m_UpperTol;
            }
            set
            {
                m_UpperTol = value;
                m_UpperTolOffset = m_UpperTol - m_Nominal;
            }
        }

        /// <summary>
        /// 하한공차 결과값
        /// </summary>
        public double LowerTol
        {
            get
            {
                return m_LowerTol;
            }
            set
            {
                m_LowerTol = value;
                m_LowerTolOffset = m_Nominal - m_LowerTol;
            }
        }

        /// <summary>
        /// 소수점
        /// </summary>
        public int Point
        {
            get
            {
                return m_Point;
            }
            set
            {
                m_Point = value;
            }
        }

        /// <summary>
        /// 소수점 자리 처리 방법
        /// </summary>
        public PointMethod PointMethod
        {
            get
            {
                return m_PointMethod;
            }
            set
            {
                m_PointMethod = value;
            }
        }

        public LimitType LimitType
        {
            get
            {
                return m_LimitType;
            }
            set
            {
                m_LimitType = value;
            }
        }

        /// <summary>
        /// Cp
        /// </summary>
        public double? Cp
        {
            get
            {
                return m_Cp;
            }
        }

        /// <summary>
        /// Cpk
        /// </summary>
        public double? Cpk
        {
            get
            {
                return m_Cpk;
            }
        }
        /// <summary>
        /// Pp
        /// </summary>
        public double? Pp
        {
            get
            {
                return m_Pp;
            }
        }

        /// <summary>
        /// Ppk
        /// </summary>
        public double? Ppk
        {
            get
            {
                return m_Ppk;
            }
        }

        /// <summary>
        /// 샘플 평균의 표준편차
        /// </summary>
        public double? Sigma
        {
            get
            {
                return m_Sigma;
            }
        }

        /// <summary>
        /// 군내 표준편차
        /// </summary>
        public double? SigmaWithin
        {
            get
            {
                return m_SigmaWithin;
            }
        }

        /// <summary>
        /// 표준정규분포 그래프 해상도
        /// </summary>
        protected int m_NormalDistResolution = 60;

        /// <summary>
        /// 표준정규분포 그래프 좌표
        /// </summary>
        protected List<PointD> m_NormalDistribution = new List<PointD>();

        /// <summary>
        /// 표준정규분포 그래프 좌표
        /// </summary>
        public List<PointD> NormalDistribution
        {
            get
            {
                return m_NormalDistribution;
            }
        }

        /// <summary>
        /// 기준값 표시 리스트
        /// </summary>
        protected List<bool> m_NominalList = new List<bool>();

        /// <summary>
        /// 공차상한 표시 리스트
        /// </summary>
        protected List<bool> m_UTolList = new List<bool>();

        /// <summary>
        /// 공차하한 표시 리스트
        /// </summary>
        protected List<bool> m_LTolList = new List<bool>();

        /// <summary>
        /// 도수분포 빈도
        /// </summary>
        public List<int> Frequency
        {
            get
            {
                return m_Frequency;
            }
        }

        /// <summary>
        /// 도수분포 분산
        /// </summary>
        public List<double> DIstribution
        {
            get
            {
                return m_Distribution;
            }
        }

        /// <summary>
        /// 표준정규분포 Z
        /// </summary>
        public double? Z
        {
            get
            {
                return m_Z;
            }
        }

        /// <summary>
        /// 중간값
        /// </summary>
        public double Median
        {
            get
            {
                return m_Median;
            }
        }
        /// <summary>
        /// 실제 입력받은 측정값의 서브그룹 사이즈
        /// </summary>
        public int ActualSubGroupSize
        {
            get
            {
                return m_ActualSubGroupSize;
            }
            set
            {
                m_ActualSubGroupSize = value;
            }
        }
    }

    public enum PointMethod
    {
        TRUNCATE = 1,
        ROUNDED = 0,
    }

    public enum LimitType
    {
        /// <summary>
        /// 양측공차
        /// </summary>
        Bilateral = 0,
        /// <summary>
        /// 이하공차
        /// </summary>
        UnilateralLower = 1,
        /// <summary>
        /// 이상공차
        /// </summary>
        UnilateralUpper = 2
    }

    public struct PointD
    {
        public double X;
        public double Y;

        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }

        public override bool Equals(object obj)
        {
            return obj is PointD && this == (PointD)obj;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
        public static bool operator ==(PointD a, PointD b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator !=(PointD a, PointD b)
        {
            return !(a == b);
        }
    }
}
