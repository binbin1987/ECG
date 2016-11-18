using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 波形信息
    /// </summary>
    internal class MWF_INF_15 : ITLV<WaveformInformation>
    {
        private WaveformInformation _waveformInformation = new WaveformInformation();
        public override byte TagType
        {
            get { return 0x15; }
        }

        public override WaveformInformation Content
        {
            get { return _waveformInformation; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            if (GetData16(buffer, 2, ref offset, out _waveformInformation.InformationCode))
            {
                if (DataLength > 2)
                {
                    if (GetData32(buffer, 4, ref offset, out _waveformInformation.StartingTime))
                    {
                        if (DataLength > 6)
                        {
                            if (GetData32(buffer, 4, ref offset, out _waveformInformation.Duration))
                            {
                                if (DataLength > 10)
                                {
                                    _waveformInformation.Information = Encoding.Default.GetString(buffer, offset, base.DataLength - 10);
                                    offset += base.DataLength - 10;
                                }
                            }
                        }
                    }
                }
                return ResolveResultCode.SUCCESS;
            }
            return ResolveResultCode.CONTENT_ERROR;
        }
    }
    internal struct WaveformInformation
    {
        public ushort InformationCode;
        public uint StartingTime;
        public uint Duration;
        public string Information;
    }
}
