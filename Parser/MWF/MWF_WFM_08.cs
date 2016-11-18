using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 波形类型
    /// </summary>
    internal class MWF_WFM_08 : ITLV<WaveformType>
    {
        private WaveformType _waveformType = WaveformType.Unidentified;
        public override byte TagType
        {
            get { return 0x08; }
        }

        public override WaveformType Content
        {
            get { return _waveformType; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            if (Enum.IsDefined(typeof(WaveformType), buffer[offset]))
            {
                _waveformType = (WaveformType)buffer[offset];
                offset += 1;
                return ResolveResultCode.SUCCESS;
            }
            return ResolveResultCode.CONTENT_ERROR;
        }
    }
    /// <summary>
    /// 波形类型
    /// </summary>
    internal enum WaveformType : byte
    {
        Unidentified = 0,
        /// <summary>
        /// 静息12导
        /// </summary>
        ECG_STD12,
        /// <summary>
        /// 长时心电图
        /// </summary>
        ECG_LTERM,
        ECG_VECTR,
        ECG_EXCER,
        ECG_INTR,
        ECG_SURF,
        ECG_ILATE,
        ECG_LATE,
        SOUND = 30,
        PULSE,
        MON_LTRM = 20,
        MON_SPL,
        MON_PWR = 25,
        MON_TRD,
        MCG = 100,
        EEG_REST = 40,
        EEG_EP,
        EEG_CSA,
        EEG_LTRM
    }
}
