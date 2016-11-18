using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 采样幅度信息
    /// </summary>
    internal class MWF_SEN_0C : ITLV<SamplingInfo>
    {
        private SamplingInfo _samplingResolutionInfo = new SamplingInfo();
        public override byte TagType
        {
            get { return 0x0C; }
        }

        public override SamplingInfo Content
        {
            get { return _samplingResolutionInfo; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            _samplingResolutionInfo.Unit = buffer[offset];
            offset++;
            _samplingResolutionInfo.Exponent = (sbyte)buffer[offset];
            offset++;
            uint iValue;
            if (GetData32(buffer, base.DataLength - 2, ref offset, out iValue))
            {
                _samplingResolutionInfo.Value = (int)iValue;
                if (_samplingResolutionInfo.IsValid(3))
                {
                    return ResolveResultCode.SUCCESS;
                }
            }
            return ResolveResultCode.CONTENT_ERROR;
        }

        public double AVM
        {
            get
            {
                double value = _samplingResolutionInfo.Value * Math.Pow(10.0, (double)_samplingResolutionInfo.Exponent);
                if (_samplingResolutionInfo.Unit == 0)
                {
                    return value * 1000000.0;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
