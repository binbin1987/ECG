using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 采样率信息
    /// </summary>
    internal class MWF_IVL_0B : ITLV<SamplingInfo>
    {
        private SamplingInfo _samplingRateInfo = new SamplingInfo();
        public override byte TagType
        {
            get { return 0x0B; }
        }

        public override SamplingInfo Content
        {
            get { return _samplingRateInfo; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            _samplingRateInfo.Unit = buffer[offset];
            offset++;
            _samplingRateInfo.Exponent = (sbyte)buffer[offset];
            offset++;
            uint iValue;
            if (GetData32(buffer, base.DataLength - 2, ref offset, out iValue))
            {
                _samplingRateInfo.Value = (int)iValue;
                if (_samplingRateInfo.IsValid(3))
                {
                    return ResolveResultCode.SUCCESS;
                }
            }
            return ResolveResultCode.CONTENT_ERROR;
        }

        public int SamplesPerSecond
        {
            get
            {
                double value = _samplingRateInfo.Value * Math.Pow(10.0, (double)_samplingRateInfo.Exponent);
                switch (_samplingRateInfo.Unit)
                {
                    case 0://Hz
                        return (int)(value);
                    case 1://Sampling interval ms
                        return (int)(1/value);
                    default:
                        return 500;
                }
            }
        }
    }

    /// <summary>
    /// 采样信息
    /// </summary>
    internal struct SamplingInfo
    {
        /// <summary>
        /// 单位
        /// </summary>
        public byte Unit;
        /// <summary>
        /// 次幂指数
        /// </summary>
        public sbyte Exponent;
        /// <summary>
        /// 值
        /// </summary>
        public int Value;

        public bool IsValid(int maxUnitCode)
        {
            return Unit >= 0
                && Unit <= maxUnitCode 
                && Exponent >= -128 
                && Exponent <= 127;
        }
    }
}
