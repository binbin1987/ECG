using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 插值或抽样
    /// </summary>
    internal class MWF_IPD_OF : ITLV<InterpolationOrDecimation>
    {
        private InterpolationOrDecimation _interpolationOrDecimation;
        public override byte TagType
        {
            get { return 0x0F; }
        }

        public override InterpolationOrDecimation Content
        {
            get { return _interpolationOrDecimation; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            if (Enum.IsDefined(typeof(InterpolationOrDecimationType), buffer[offset]))
            {
                _interpolationOrDecimation.Code = (InterpolationOrDecimationType)buffer[offset];
                offset += 1;
                if (GetData16(buffer, 2, ref offset, out _interpolationOrDecimation.SupplementaryInformation))
                {
                    return ResolveResultCode.SUCCESS;
                }
            }
            return ResolveResultCode.CONTENT_ERROR;
        }
    }

    internal struct InterpolationOrDecimation
    {
        public InterpolationOrDecimationType Code;
        public ushort SupplementaryInformation;//补充
    }

    internal enum InterpolationOrDecimationType : byte
    {
        UnconditionalDecimation = 1,
        UnconditionalInterpolation = 2,
        LagrangesInterpolation = 3,
        SplineInterpolation = 4,
        LinearInterpolation = 5,
        Addition = 6
    }
}
